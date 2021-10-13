using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace BeyondSports.DataReader
{
    public class StaticSoccerDataReader : IDataReader
    {
        private readonly float worldScale = 0.01f;
        private TrackingData loadedData;

        public async Task<(long start, long end)> GetFrameRange()
        {
            if (loadedData != null)
            {
                return (loadedData.frames.Min(x => x.frameID), loadedData.frames.Max(x => x.frameID));
            }
            return (0, 0);
        }

        public async Task<TrackingFrame> GetFrame(long frameID)
        {
            if (loadedData != null && loadedData.frames.LongLength < frameID)
            {
                return loadedData.frames[frameID];
            }

            return new TrackingFrame();
        }

        public async Task SetDataPath(string path)
        {
            loadedData = null;
            using (var webRequest = UnityWebRequest.Get(path))
            {
                await webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    loadedData = DecodeData(webRequest.downloadHandler.text);
                }
                else
                {
                    Debug.LogError(webRequest.error);
                }
            }
        }

        private TrackingData DecodeData(string rawData)
        {
            var lines = rawData.Split('\n');

            return new TrackingData
                (
                    lines.Select(line => GetFrame(line)).ToArray()
                );

            TrackingFrame GetFrame(string rawLine)
            {
                var splitLine = rawLine.Split(':');
                var splitTrackingObjects = splitLine[1].Split(';');
                var splitBall = splitLine[2].Split(',');

                long frameID = long.TryParse(splitLine[0], out frameID) ? frameID : -1;

                return new TrackingFrame(frameID, GetTrackingObjects(), new[] { GetBall() }, splitBall.Skip(3).ToArray());

                TrackedObject[] GetTrackingObjects()
                {
                    if (splitLine.Length <= 1)
                    {
                        return new TrackedObject[0];
                    }

                    return splitTrackingObjects.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => GetTrackingObject(x)).ToArray();

                    TrackedObject GetTrackingObject(string rawTrackingObject)
                    {
                        var splitTrackingObject = rawTrackingObject.Split(',');

                        if (splitTrackingObject.Length == 6)
                        {
                            return new TrackedObject
                                (
                                    teamId: int.TryParse(splitTrackingObject[0], out int teamID) ? teamID : -1,
                                    id: int.TryParse(splitTrackingObject[1], out int id) ? id : -1,
                                    shirtNumber: int.TryParse(splitTrackingObject[2], out int shirtNumber) ? shirtNumber : -1,
                                    position: new Vector3
                                    (
                                        x: int.TryParse(splitTrackingObject[3], out int xPosition) ? xPosition * worldScale : 0,
                                        y: int.TryParse(splitTrackingObject[4], out int yPosition) ? yPosition * worldScale : 0
                                    ),
                                    speed: double.TryParse(splitTrackingObject[5], out double speed) ? speed : 0
                                );
                        }
                        else
                        {
                            Debug.LogWarning($"failed to decode TrackingObject encountered {splitTrackingObject.Length} instead of 6 elements\n {rawTrackingObject}");
                            return new TrackedObject();
                        }
                    }
                }

                BallData GetBall()
                {
                    if (splitLine.Length <= 2)
                        return new BallData();

                    if (splitBall.Length > 4)
                    {
                        return new BallData
                        (
                            position: new Vector3
                            (
                                x: int.TryParse(splitBall[0], out int xPosition) ? xPosition * worldScale : 0,
                                y: int.TryParse(splitBall[1], out int yPosition) ? yPosition * worldScale : 0,
                                z: int.TryParse(splitBall[2], out int zPosition) ? zPosition * worldScale : 0
                            ),
                            speed: double.TryParse(splitBall[3], out double speed) ? speed : 0
                        );
                    }
                    else
                    {
                        Debug.LogWarning($"failed to decode TrackingObject encountered {splitBall.Length} less than 4 elements\n {splitLine[2]}");
                        return new BallData();
                    }
                }
            }
        }
    }
}
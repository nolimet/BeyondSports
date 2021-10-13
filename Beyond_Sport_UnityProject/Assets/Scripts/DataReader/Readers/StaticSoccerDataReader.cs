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
                return (loadedData.frames.Min(x => x.Key), loadedData.frames.Max(x => x.Key));
            }
            return (0, 0);
        }

        public async Task<TrackingFrame> GetFrame(long frameID)
        {
            if (loadedData != null && loadedData.frames.TryGetValue(frameID, out var frame))
            {
                return frame;
            }

            return new TrackingFrame();
        }

        public async Task SetDataPath(string path)
        {
            loadedData = null;
            using (var webRequest = UnityWebRequest.Get(path))
            {
                Debug.Log("Download Started");
                await webRequest.SendWebRequest();

                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    string data = webRequest.downloadHandler.text;
                    Debug.Log("Download Completed");
                    await Task.Run(() =>
                    {
                        Debug.Log("Decoding Started");
                        loadedData = DecodeData(data);
                        Debug.Log("Decoding Completed");
                    });
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
                    lines.Where(line => !string.IsNullOrEmpty(line)).Select(line => DecodeFrame(line)).ToDictionary(k => k.frameID, v => v)
                );

            TrackingFrame DecodeFrame(string rawLine)
            {
                var splitLine = rawLine.Split(':');
                string[] splitTrackingObjects = splitLine.Length > 1 ? splitLine[1].Split(';') : new string[0];
                string[] splitBall = splitLine.Length > 2 ? splitLine[2].Split(',') : new string[0];

                long frameID = long.TryParse(splitLine[0], out frameID) ? frameID : long.MinValue;

                return new TrackingFrame(frameID, DecodeTrackedObjects(), new[] { DecodeBall() }, splitBall.Length > 3 ? splitBall.Skip(3).ToArray() : new string[0]);

                TrackedObjectData[] DecodeTrackedObjects()
                {
                    if (splitTrackingObjects.Length == 0)
                    {
                        return new TrackedObjectData[0];
                    }

                    return splitTrackingObjects.Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => DecodeTrackedObject(x)).ToArray();

                    TrackedObjectData DecodeTrackedObject(string rawTrackingObject)
                    {
                        var splitTrackingObject = rawTrackingObject.Split(',');

                        if (splitTrackingObject.Length == 6)
                        {
                            return new TrackedObjectData
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
                            return new TrackedObjectData();
                        }
                    }
                }

                TrackedBallData DecodeBall()
                {
                    if (splitBall.Length > 4)
                    {
                        return new TrackedBallData
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
                        if (splitLine.Length > 2)
                        {
                            Debug.LogWarning($"failed to decode TrackingObject encountered {splitBall.Length} less than 4 elements\n {splitLine[2]}");
                        }

                        return new TrackedBallData();
                    }
                }
            }
        }
    }
}
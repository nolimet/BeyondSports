using BeyondSports.DataReader;
using UnityEngine;

namespace Assets.Scripts
{
    public class Test : MonoBehaviour
    {
        private TrackingDataReaderService dataReaderService = new TrackingDataReaderService(new StaticSoccerDataReader());

        [SerializeField]
        private string fileName = "match_data.dat";

        public async void Start()
        {
            await dataReaderService.SetReaderPath($"File://{Application.streamingAssetsPath}/{fileName}");
        }
    }
}
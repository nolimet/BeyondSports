using System.Threading.Tasks;

namespace BeyondSports.DataReader
{
    public class TrackingDataReaderService
    {
        public TrackingDataReaderService(DataReaderConfiguration dataReaderConfiguration)
        {
            switch (dataReaderConfiguration.ReaderType)
            {
                case ReaderTypes.StaticSoccer:
                    dataReader = new StaticSoccerDataReader();
                    break;
            }
        }

        private readonly IDataReader dataReader;

        public async Task<TrackingFrame> GetFrame(long frameID)
        {
            return await dataReader.GetFrame(frameID);
        }

        public async Task<(long start, long end)> GetFrameRange()
        {
            return await dataReader.GetFrameRange();
        }

        public async Task SetReaderPath(string path)
        {
            await dataReader.SetDataPath(path);
        }
    }
}
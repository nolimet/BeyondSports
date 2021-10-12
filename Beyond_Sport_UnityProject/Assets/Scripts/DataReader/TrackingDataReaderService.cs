using System.Threading.Tasks;

namespace BeyondSports.DataReader
{
    public class TrackingDataReaderService
    {
        public TrackingDataReaderService(IDataReader dataReader)
        {
            this.dataReader = dataReader;
        }

        private readonly IDataReader dataReader;

        public async Task<TrackingFrame> GetFrame(long frameID)
        {
            return await dataReader.GetFrame(frameID);
        }

        public async Task<long> GetFrameCount()
        {
            return await dataReader.GetFrameCount();
        }

        public async Task SetReaderPath(string path)
        {
            await dataReader.SetDataPath(path);
        }
    }
}
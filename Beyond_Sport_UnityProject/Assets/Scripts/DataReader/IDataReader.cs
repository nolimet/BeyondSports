using System.Threading.Tasks;

namespace BeyondSports.DataReader
{
    public interface IDataReader
    {
        Task SetDataPath(string path);

        Task<TrackingFrame> GetFrame(long frameID);

        Task<(long start, long end)> GetFrameRange();
    }
}
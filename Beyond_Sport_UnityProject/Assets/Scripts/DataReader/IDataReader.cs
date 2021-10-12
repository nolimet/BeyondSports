using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondSports.DataReader
{
    public interface IDataReader
    {
        Task SetDataPath(string path);

        Task<TrackingFrame> GetFrame(long frameID);

        Task<long> GetFrameCount();
    }
}
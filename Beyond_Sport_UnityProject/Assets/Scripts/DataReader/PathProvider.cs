using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeyondSports.DataReader
{
    public static class PathProvider
    {
        public static string GetPathFromConfiguration(DataReaderConfiguration configuration)
        {
            return GetPath(configuration.PathMode, configuration.FilePath);
        }

        public static string GetPath(PathMode pathMode, string filePath)
        {
            //TODO add device specifc path
            switch (pathMode)
            {
                case PathMode.Absolute:
                    return filePath;

                case PathMode.Relative_StreamingAssets:
                    return $"File://{Application.streamingAssetsPath}/{filePath}";

                case PathMode.Relative_DataPath:
                    return $"File://{Application.dataPath}/{filePath}";
            }

            return string.Empty;
        }
    }
}
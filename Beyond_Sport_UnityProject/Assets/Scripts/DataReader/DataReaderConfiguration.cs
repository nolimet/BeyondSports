using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace BeyondSports.DataReader
{
    [CreateAssetMenu(fileName = "Data Reader Configuration", menuName = "Configuration/Data Reader")]
    public class DataReaderConfiguration : ScriptableObject
    {
        [SerializeField]
        private ReaderTypes readerType;

        [SerializeField]
        private PathMode pathMode;

        [SerializeField]
        private string filePath;

        public string FilePath => filePath;
        public ReaderTypes ReaderType => readerType;
        public PathMode PathMode => pathMode;
    }
}
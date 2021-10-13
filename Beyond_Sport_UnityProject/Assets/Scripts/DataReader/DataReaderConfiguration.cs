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

        [SerializeField]
        private float framesPerSecond; //Doing it as a float se can have less than one whole frame each second

        public string FilePath => filePath;
        public ReaderTypes ReaderType => readerType;
        public PathMode PathMode => pathMode;

        public float FramesPerSecond => framesPerSecond;

        public string GetPath()
        {
            return PathProvider.GetPathFromConfiguration(this);
        }
    }
}
namespace MicToPngConverter
{
    public class MicToPng
    {
        string _path;
        string _outputPath;
        int _convertedFiles = 0;

        public delegate void ProgressHandler(int progress);
        public event ProgressHandler? OnProgressChanged;

        public MicToPng(string path)
        {
            _path = path;
            _outputPath = path + "/converted/";
        }

        public MicToPng(string path, string outputPath)
        {
            _path = path;
            _outputPath = outputPath;
        }
    }
}

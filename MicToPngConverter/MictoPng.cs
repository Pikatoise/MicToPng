namespace MicToPngConverter
{
    /// <summary>
    /// Конвертор файлов с расширением .mic, используемых в игре Stalcraft. 
    /// </summary>
    ///
    /// Сканирует указанную директорию на наличие .mic файлов, заменяет формат внутри файла и его расширение
    /// Затем сохраняет конвертированные изображения в директорию и предоставляет возможность открыть папку с результатом
    /// 
    /// Формат выходных изображений: PNG
    /// Директория с конвертированными изображениями: 
    ///     ./converted - По умолчанию
    ///     Указанная в конструкторе
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

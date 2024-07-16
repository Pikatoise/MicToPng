namespace MicToPngConverter
{
    /// <summary>
    /// Конвертор файлов с расширением .mic, используемых в игре Stalcraft. 
    /// </summary>
    ///
    /// Сканирует указанную директорию на наличие MIC файлов, заменяет формат внутри файла и его расширение
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

        /// <summary>
        /// Вызывается при обновлении прогресса
        /// </summary>
        public event ProgressHandler? OnProgressChanged;
        public delegate void ProgressHandler(int progress);


        /// <summary>
        /// Количество файлов с расширением .mic
        /// </summary>
        public int FileCount
        {
            get
            {
                return GetMicFiles().Length;
            }
        }

        /// <summary>
        /// Прогресс конвертации файлов в процентном соотношении
        /// </summary>
        public int Progress
        {
            get
            {
                if (_convertedFiles == 0)
                    return 0;

                return _convertedFiles / FileCount * 100;
            }
        }

        /// <summary>
        /// Инициализирует новый конвертер файлов директории <paramref name="path"/>
        /// </summary>
        /// <param name="path">Директория, содержащая файлы .mic</param>
        public MicToPng(string path)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Директория не существует");

            _path = path;
            _outputPath = path + "/converted/";
        }

        /// <summary>
        /// Инициализирует новый конвертер файлов директории <paramref name="path"/>
        /// <para>Сохранение выходных изображений производится по пути <paramref name="outputPath"/></para>
        /// </summary>
        /// <param name="path">Директория, содержащая файлы .mic</param>
        /// <param name="outputPath">Директория с результатом конвертации</param>
        public MicToPng(string path, string outputPath)
        {
            if (!Directory.Exists(path))
                throw new DirectoryNotFoundException("Директория не существует");

            _path = path;
            _outputPath = outputPath;
        }

        private string[] GetMicFiles() => Directory.GetFiles(_path, "*.mic");
    }
}

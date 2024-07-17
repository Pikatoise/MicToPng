using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Input;

namespace MicToPng
{
    public partial class MainWindow: Window
    {
        MicToPngConverter.MicToPng? converter;
        string? _savedPath = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonMinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ButtonCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BorderWindowDragZone_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void ButtonSelectFolder_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = "C:\\Users";
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                PBarStatus.Visibility = Visibility.Hidden;
                ButtonOpenFolder.Visibility = Visibility.Hidden;

                _savedPath = dialog.FileName;

                converter = new MicToPngConverter.MicToPng(dialog.FileName);
                int micFilesCount = converter.FileCount;

                TBlockFileCount.Text = micFilesCount.ToString();
                SPanelFileCount.Visibility = Visibility.Visible;

                if (micFilesCount > 0)
                    GridConvert.Visibility = Visibility.Visible;
                else
                    GridConvert.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (converter != null)
            {
                PBarStatus.Visibility = Visibility.Visible;
                ButtonOpenFolder.Visibility = Visibility.Hidden;

                converter.OnFinish += (convertedCount) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        PBarStatus.Visibility = Visibility.Hidden;
                        ButtonOpenFolder.Visibility = Visibility.Visible;
                    });
                };

                converter.ConvertFiles();
            }
        }

        private void ButtonOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            if (converter != null)
                converter.OpenOutputFolder();
        }

        private void ButtonRefresh_Click(object sender, RoutedEventArgs e)
        {
            if (_savedPath != null)
            {
                PBarStatus.Visibility = Visibility.Hidden;
                ButtonOpenFolder.Visibility = Visibility.Hidden;

                converter = new MicToPngConverter.MicToPng(_savedPath);
                int micFilesCount = converter.FileCount;

                TBlockFileCount.Text = micFilesCount.ToString();
                SPanelFileCount.Visibility = Visibility.Visible;

                if (micFilesCount > 0)
                    GridConvert.Visibility = Visibility.Visible;
                else
                    GridConvert.Visibility = Visibility.Hidden;
            }
        }
    }
}
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows;
using System.Windows.Input;

namespace MicToPng
{
    public partial class MainWindow: Window
    {
        MicToPngConverter.MicToPng? converter;

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
                converter = new MicToPngConverter.MicToPng(dialog.FileName);

                int micFilesCount = converter.FileCount;

                SPanelFileCount.Visibility = Visibility.Visible;

                TBlockFileCount.Text = micFilesCount.ToString();

                if (micFilesCount > 0)
                {
                    ButtonConvert.Visibility = Visibility.Visible;
                }
                else
                    ButtonConvert.Visibility = Visibility.Hidden;

                PBarStatus.Visibility = Visibility.Hidden;
                ButtonOpenFolder.Visibility = Visibility.Hidden;
            }
        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {
            if (converter != null)
            {
                PBarStatus.Value = 0;
                PBarStatus.Visibility = Visibility.Visible;

                converter.OnProgressChanged += (percentes) =>
                {
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        PBarStatus.Value = percentes;

                        if (percentes == 100)
                        {
                            PBarStatus.Visibility = Visibility.Hidden;
                            ButtonOpenFolder.Visibility = Visibility.Visible;
                        }
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
    }
}
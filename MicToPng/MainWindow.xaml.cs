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

        }

        private void ButtonConvert_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonOpenFolder_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
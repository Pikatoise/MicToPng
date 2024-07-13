using System.Windows;
using System.Windows.Input;

namespace MicToPng
{
    public partial class MainWindow: Window
    {
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
    }
}
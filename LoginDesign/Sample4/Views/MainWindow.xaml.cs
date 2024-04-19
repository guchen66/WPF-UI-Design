using Sample4.Helper;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sample4.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            /*if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }*/

            this.DragMove();
        }

       
    }
}

using System.Windows;

namespace Lesson008
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new ViewModel();
            this.DataContext = _Model;
        }

        private ViewModel _Model;

        private void OnLoad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnFilte_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

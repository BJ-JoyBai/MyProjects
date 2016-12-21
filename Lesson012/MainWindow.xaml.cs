using System.Windows;

namespace Lesson012
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new MainModel();
            this.DataContext = _Model;
        }
        private MainModel _Model;

        private void OnInitDatabase_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.InitDatabase();
                MessageBox.Show("数据库已经创建完成");
            }
            catch(System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //创建内存数据模型，用数据模型创建数据库
    }
}

using System.Windows;
using System.Windows.Input;

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
                if (_Model.DatabaseExist())
                {
                    if (MessageBox.Show("数据库已经存在，重建数据库将清除原有数据,是否重建？","重建确认",MessageBoxButton.OKCancel, MessageBoxImage.Exclamation, MessageBoxResult.Cancel) != MessageBoxResult.OK)
                        return;
                    this.Cursor = Cursors.Wait;
                    _Model.DeleteDatabase();
                }
                this.Cursor = Cursors.Wait;
                _Model.InitDatabase();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("数据库已经创建完成");
            }
            catch(System.Exception ex)
            {
                this.Cursor = Cursors.Arrow;
                MessageBox.Show(ex.Message);
            }
        }

        private void OnQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.QueryContacts();
               
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Submit();
                MessageBox.Show("数据提交成功");

            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //创建内存数据模型，用数据模型创建数据库
    }
}

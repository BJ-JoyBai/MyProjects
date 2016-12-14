using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
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
            try
            {
                OpenFileDialog aDlg = new OpenFileDialog();
                aDlg.Filter = "日志文件 (*.log)|*.log|文本文件 (*.txt)|*.txt|所有文件 (*.*)|*.*";
                if (aDlg.ShowDialog() != true) return;
                _Model.LoadSource(aDlg.FileName);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnFilte_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Filte();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);//获取当前栈信息，指出错误位置
            }
        }
    }
}

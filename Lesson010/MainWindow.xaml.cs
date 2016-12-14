using Microsoft.Win32;
using System;
using System.Windows;

namespace Lesson010
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
                aDlg.Filter = "Xml文件 (*.xml)|*.xml|所有文件 (*.*)|*.*";
                if (aDlg.ShowDialog() != true) return;
                _Model.Load(aDlg.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnQuery_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Query();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
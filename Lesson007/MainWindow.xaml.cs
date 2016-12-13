using Microsoft.Win32;
using System;
using System.IO;
using System.Text;
using System.Windows;

namespace Lesson007
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            _Model = new RegexModel();
            this.DataContext = _Model;
        }
        private RegexModel _Model;

        private void OnTest_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Test();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnLoadSampleText_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog aDlg = new OpenFileDialog();
                aDlg.Title = "选择样本文件";
                aDlg.Filter = "文本文件 (.txt)|*.txt|所有文件 (*.*)|*.*";
                if (aDlg.ShowDialog() != true) return;
                _Model.SampleText = File.ReadAllText(aDlg.FileName, Encoding.Default);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnReplace_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Replace();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSave_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                SaveFileDialog aDlg = new SaveFileDialog();
                if (aDlg.ShowDialog() != true) return;
                File.WriteAllText(aDlg.FileName, e.Parameter as string);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSave_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = !string.IsNullOrWhiteSpace(e.Parameter as string);
        }
    }
}

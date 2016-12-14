using System;
using System.Windows;

namespace Lesson009
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
            try
            {
                _Model.Load();//启动时自动加载
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private ViewModel _Model;

        private void OnNewContact_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.NewContact();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Model.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //关闭窗口时自动保存
        private void OnWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                _Model.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnDeleteContact_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.DeleteCantact(e.Parameter as Contact);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnDeleteContact_CanExecute(object sender, System.Windows.Input.CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = e.Parameter as Contact != null;
        }
    }
}

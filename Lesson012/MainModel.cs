using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson012
{
    class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        private const string ConnectionString = @"Data Source=lenovo-PC\sqlexpress;Initial catalog=LingDemo001;Integrated Security=true";
        private MyDataDataContext _DataContext = new MyDataDataContext(ConnectionString);

        public void InitDatabase()
        {
            if (_DataContext.DatabaseExists())
                throw new ApplicationException("数据库已经存在");
            _DataContext.CreateDatabase();
        }
    }
}

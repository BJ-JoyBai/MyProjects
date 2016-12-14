using System.ComponentModel;

namespace Lesson010
{
    class NotifyPropertyChangedObject : INotifyPropertyChanged
    {
        protected void SetValue<T>(ref T aStorage, T aValue, string aPropertyName)
        {
            if (object.Equals(aStorage, aValue)) return;
            aStorage = aValue;
            OnPropertyChanged(aPropertyName);
        }
        protected void OnPropertyChanged(params string[] aNames)
        {
            foreach (string aName in aNames)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
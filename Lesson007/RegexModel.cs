using System.ComponentModel;
using System.Text.RegularExpressions;

namespace Lesson007
{
    class RegexModel : INotifyPropertyChanged
    {
        public string Pattern
        {
            get { return _Pattern; }
            set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); }
        }
        private string _Pattern;

        public string SampleText
        {
            get { return _SampleText; }
            set { if (_SampleText == value) return; _SampleText = value; OnPropertyChanged(nameof(SampleText)); }
        }
        private string _SampleText;

        public MatchCollection TestResult
        {
            get { return _TestResult; }
            set
            {
                if (_TestResult == value) return;
                _TestResult = value;
                OnPropertyChanged("TestResult");
            }
        }
        private MatchCollection _TestResult;

        public string ReplacePattern
        {
            get { return _ReplacePattern; }
            set
            {
                if (_ReplacePattern == value) return;
                _ReplacePattern = value;
                OnPropertyChanged("ReplacePattern");
            }
        }
        private string _ReplacePattern;

        public string ReplaceResult
        {
            get { return _ReplaceResult; }
            set
            {
                if (_ReplaceResult == value) return;
                _ReplaceResult = value;
                OnPropertyChanged("ReplaceResult");
            }
        }
        private string _ReplaceResult;

        public void Test()
        {
            Regex aRegex = new Regex(Pattern);
            TestResult = aRegex.Matches(SampleText);
        }

        public void Replace()
        {
            Regex aRegex = new Regex(Pattern);
            ReplaceResult = aRegex.Replace(SampleText, ReplacePattern);
        }

        private void OnPropertyChanged(params string[] aPropertyNames)
        {
            foreach (string aPropertyName in aPropertyNames)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

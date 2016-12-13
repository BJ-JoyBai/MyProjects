using System;
using System.ComponentModel;

namespace Lesson006
{
    class TestModel : INotifyPropertyChanged
    {

        public int Data1
        {
            get { return _Data1; }
            set
            {
                if (_Data1 == value) return; _Data1 = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data1"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }
        private int _Data1;

        public IOperator CurrentOperator
        {
            get { return _CurrentOperator; }
            set
            {
                if (_CurrentOperator == value) return; _CurrentOperator = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentOperator)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }
        private IOperator _CurrentOperator;

        public int Data2
        {
            get { return _Data2; }
            set
            {
                if (_Data2 == value) return; _Data2 = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Data2"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Result"));
            }
        }
        private int _Data2;

        public int Result
        {
            get
            {
                if (CurrentOperator == null) return 0;
                return CurrentOperator.Calc(Data1, Data2);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public IOperator[] Operators { get; } = new IOperator[]
        {
            new Operator_Add(),
            new Operator_Sub(), 
            new Operator_Mul(),
            new Operator_Div(),
        };
    }

    interface IOperator
    {
        string Operator { get; }
        int Calc(int aData1, int aData2);
    }

    class Operator_Add : IOperator
    {
        public string Operator { get { return "+"; } }

        public int Calc(int aData1, int aData2)
        {
            return aData1 + aData2;
        }
    }

    class Operator_Sub : IOperator
    {
        public string Operator
        {
            get
            {
                return "-";
            }
        }

        public int Calc(int aData1, int aData2)
        {
            return aData1 - aData2;
        }
    }

    class Operator_Mul : IOperator
    {
        public string Operator
        {
            get
            {
                return "*";
            }
        }

        public int Calc(int aData1, int aData2)
        {
            return aData1 * aData2;
        }
    }

    class Operator_Div : IOperator
    {
        public string Operator
        {
            get
            {
                return "/";
            }
        }

        public int Calc(int aData1, int aData2)
        {
            return aData1 / aData2;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using NST_Test_Task;

namespace NST_Test_Task
{
    public class FunctionResult : INotifyPropertyChanged
    {
        private string _x;
        public string X
        {
            get { return _x; }
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged();
                    UpdateResult();
                }
            }
        }

        private string _y;
        public string Y
        {
            get { return _y; }
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged();
                    UpdateResult();
                }
            }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set
            {
                if (_result != value)
                {
                    _result = value;
                    OnPropertyChanged();
                }
            }
        }
        public MainViewModel viewModel;
        public bool isTesting = false;
        public void UpdateResult()
        {
            if (!isTesting)
            {
                SetReferenceToViewModel();
            }
            int type = viewModel.GetTypeOfFunction();
            double finalResult = CalcFunc(type);
            Result = finalResult.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        double c = 0, x = 0, y = 0;
        private void ParseVariables()
        {

            double.TryParse(viewModel.SelectedCoefficientC, out c);
            double.TryParse(X, out x);
            double.TryParse(Y, out y);
        }
        public double CalcFunc(int type)
        {
            ParseVariables();
            return (viewModel.CoefficientA * Math.Pow(x, type)) + (viewModel.CoefficientB * Math.Pow(y, type - 1)) + c;
        }
        private void SetReferenceToViewModel()
        {
            viewModel = Application.Current.MainWindow.DataContext as MainViewModel;
        }
    }
}
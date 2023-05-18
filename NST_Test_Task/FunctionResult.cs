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
        private double _x;
        public double X
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

        private double _y;
        public double Y
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
        //Обновляю результат в столбце f(x,y)
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
        //Нахожу значение коэффицента C
        double c = 0;
        private void ParseVariables()
        {

            double.TryParse(viewModel.SelectedCoefficientC, out c);
        }
        //Возвращаю итоговое значение
        public double CalcFunc(int type)
        {
            ParseVariables();
            return (viewModel.CoefficientA * Math.Pow(_x, type)) + (viewModel.CoefficientB * Math.Pow(_y, type - 1)) + c;
        }
        //Нахожу референс VM в приложении
        private void SetReferenceToViewModel()
        {
            viewModel = Application.Current.MainWindow.DataContext as MainViewModel;
        }
    }
}
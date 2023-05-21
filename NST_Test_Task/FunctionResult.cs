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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        //Нахожу значение коэффицента C
        double c = 0;
        //Нахожу референс VM в приложении
        private void SetReferenceToViewModel()
        {
            viewModel = Application.Current.MainWindow.DataContext as MainViewModel;
        }
    }
}
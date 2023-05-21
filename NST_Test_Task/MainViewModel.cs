using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Prism;
using Prism.Commands;
using NST_Test_Task;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;

namespace NST_Test_Task
{
    public class MainViewModel : INotifyPropertyChanged
    {
        //Объявление коллекции для таблицы
        public ObservableCollection<FunctionResult> functionResults;

        //Поля коэффицентов
        private double coefficientA;
        private double coefficientB;
        //Массив коэффицентов для каждой функции
        private double[] _aCoefficents = { 0, 0, 0, 0, 0 };
        private double[] _bCoefficents = { 0, 0, 0, 0, 0 };
        private string selectedFunctionType;
        private string selectedCoefficientC;

        public MainViewModel()
        {
            functionResults = new ObservableCollection<FunctionResult>();
            AddRowCommand = new DelegateCommand(AddRow);
            SelectedFunctionType = "Линейная";
            SelectedCoefficientC = "1";
        }

        
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ObservableCollection<FunctionResult> FunctionResults
        {
            get { return functionResults; }
            set
            {
                functionResults = value;
                RaisePropertyChanged("FunctionResults");
                GetTypeOfFunction();
                UpdateResult();
            }
        }

        public double CoefficientA
        {
            get { return coefficientA; }
            set
            {
                coefficientA = value;
                _aCoefficents[GetTypeOfFunction()-1] = value;    
                RaisePropertyChanged("CoefficientA");
                UpdateResult();
            }
        }

        public double CoefficientB
        {
            get { return coefficientB; }
            set
            {
                coefficientB = value;
                GetTypeOfFunction();
                _bCoefficents[GetTypeOfFunction() - 1] = value;
                RaisePropertyChanged("CoefficientB");
                UpdateResult();
            }
        }
        //Внесение типов функций в ComboBox
        public ObservableCollection<string> FunctionTypes { get; } = new ObservableCollection<string> { "Линейная", "Квадратичная", "Кубическая", "4-ой степени", "5-ой степени" };

        //Задаю выбранную функцию и вызываю событие о изменении значения
        public string SelectedFunctionType
        {
            get { return selectedFunctionType; }
            set
            {
                selectedFunctionType = value;
                UpdateCoefficientCValues();
                GetTypeOfFunction();
                RaisePropertyChanged("SelectedFunctionType");
                UpdateResult();
            }
        }

        public ObservableCollection<string> CoefficientCValues { get; } = new ObservableCollection<string>();
        //Задаю коэффицент и вызываю событие о изменении значения
        public string SelectedCoefficientC
        {
            get { return selectedCoefficientC; }
            set
            {
                selectedCoefficientC = value;
                GetTypeOfFunction();
                RaisePropertyChanged("SelectedCoefficientC");
                UpdateResult();
            }
        }
        public ICommand AddRowCommand { get; }

        //Обновляю список коэффицентов C при выборе новой функции
        private void UpdateCoefficientCValues()
        {
            CoefficientCValues.Clear();

            if (SelectedFunctionType == "Линейная")
            {
                CoefficientCValues.Add("1");
                CoefficientCValues.Add("2");
                CoefficientCValues.Add("3");
                CoefficientCValues.Add("4");
                CoefficientCValues.Add("5");
                CoefficientA = _aCoefficents[0];
                CoefficientB = _bCoefficents[0];
            }
            else if (SelectedFunctionType == "Квадратичная")
            {
                CoefficientCValues.Add("10");
                CoefficientCValues.Add("20");
                CoefficientCValues.Add("30");
                CoefficientCValues.Add("40");
                CoefficientCValues.Add("50");
                CoefficientA = _aCoefficents[1];
                CoefficientB = _bCoefficents[1];
            }
            else if (SelectedFunctionType == "Кубическая")
            {
                CoefficientCValues.Add("100");
                CoefficientCValues.Add("200");
                CoefficientCValues.Add("300");
                CoefficientCValues.Add("400");
                CoefficientCValues.Add("500");
                CoefficientA = _aCoefficents[2];
                CoefficientB = _bCoefficents[2];
            }
            else if (SelectedFunctionType == "4-ой степени")
            {
                CoefficientCValues.Add("1000");
                CoefficientCValues.Add("2000");
                CoefficientCValues.Add("3000");
                CoefficientCValues.Add("4000");
                CoefficientCValues.Add("5000");
                CoefficientA = _aCoefficents[3];
                CoefficientB = _bCoefficents[3];
            }
            else if (SelectedFunctionType == "5-ой степени")
            {
                CoefficientCValues.Add("10000");
                CoefficientCValues.Add("20000");
                CoefficientCValues.Add("30000");
                CoefficientCValues.Add("40000");
                CoefficientCValues.Add("50000");
                CoefficientA = _aCoefficents[4];
                CoefficientB = _bCoefficents[4];
            }
        }
        //Возвращаю степень функции
        public int GetTypeOfFunction()
        {

                // Вычислите и обновите значения в соответствии с выбранной функцией
                if (SelectedFunctionType == "Линейная")
                {
                    return 1;   
                }
                else if (SelectedFunctionType == "Квадратичная")
                {
                    return 2;
                }
                else if (SelectedFunctionType == "Кубическая")
                {
                    return 3;
                }
                else if (SelectedFunctionType == "4-ой степени")
                {
                    return 4;
                }
                else if (SelectedFunctionType == "5-ой степени")
                {
                    return 5;
                }
            return 0;

        }
        public void UpdateResult()
        {
            if(functionResults.Count > 0)
            {
                foreach(var function in functionResults)
                {
                    function.Result = CalcFunc(GetTypeOfFunction(), function).ToString();
                }
            }
        }
        //Метод добавления новой строки
        private void AddRow()
        {
            FunctionResults.Add(new FunctionResult());
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public double CalcFunc(int type, FunctionResult func)
        {
            ParseVariables();
            return (CoefficientA * Math.Pow(func.X, type)) + (CoefficientB * Math.Pow(func.Y, type - 1)) + c;
        }
        //Переменная с коэффицентом C
        private double c;
        private void ParseVariables()
        {
            double.TryParse(SelectedCoefficientC, out c);
        }
    }
}

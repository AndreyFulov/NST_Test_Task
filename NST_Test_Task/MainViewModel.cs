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
        private string selectedFunctionType;
        private string selectedCoefficientC;

        public MainViewModel()
        {
            functionResults = new ObservableCollection<FunctionResult>();
            AddRowCommand = new DelegateCommand(AddRow);
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
            }
        }

        public double CoefficientA
        {
            get { return coefficientA; }
            set
            {
                coefficientA = value;
                GetTypeOfFunction();    
                RaisePropertyChanged("CoefficientA");
            }
        }

        public double CoefficientB
        {
            get { return coefficientB; }
            set
            {
                coefficientB = value;
                GetTypeOfFunction();
                RaisePropertyChanged("CoefficientB");
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
            }
            else if (SelectedFunctionType == "Квадратичная")
            {
                CoefficientCValues.Add("10");
                CoefficientCValues.Add("20");
                CoefficientCValues.Add("30");
                CoefficientCValues.Add("40");
                CoefficientCValues.Add("50");
            }
            else if (SelectedFunctionType == "Кубическая")
            {
                CoefficientCValues.Add("100");
                CoefficientCValues.Add("200");
                CoefficientCValues.Add("300");
                CoefficientCValues.Add("400");
                CoefficientCValues.Add("500");
            }
            else if (SelectedFunctionType == "4-ой степени")
            {
                CoefficientCValues.Add("1000");
                CoefficientCValues.Add("2000");
                CoefficientCValues.Add("3000");
                CoefficientCValues.Add("4000");
                CoefficientCValues.Add("5000");
            }
            else if (SelectedFunctionType == "5-ой степени")
            {
                CoefficientCValues.Add("10000");
                CoefficientCValues.Add("20000");
                CoefficientCValues.Add("30000");
                CoefficientCValues.Add("40000");
                CoefficientCValues.Add("50000");
            }
        }
        //Возвращаю степень функции
        public int GetTypeOfFunction()
        {

            if (double.TryParse(SelectedCoefficientC, out double c))
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
            }
            return 0;

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
        private void ChechIsTextboxContainNumeric(string box, string newText)
        {
            if (!IsNumeric(newText))
            {
                box = string.Empty;
            }
        }
        private bool IsNumeric(string text)
        {
            return int.TryParse(text, out _);
        }
    }
}

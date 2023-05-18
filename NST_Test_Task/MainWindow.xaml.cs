using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using NST_Test_Task;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Объявление VM класса
            DataContext = new MainViewModel();
        }
    }

}

using NUnit.Framework;
using NST_Test_Task;
using static System.Net.Mime.MediaTypeNames;
using System.Windows;
namespace NST_Test_Task.Tests
{
    [TestFixture]
    public class FunctionResultTests
    {
        [Test]
        public void UpdateResult_LinearFunction_CalculatesCorrectResult()
        {
            // Arrange
            var viewModel = new MainViewModel();
            var functionResult = new FunctionResult();
            functionResult.X = "2";
            functionResult.Y = "3";
            viewModel.CoefficientA = "1";
            viewModel.CoefficientB = "2";
            viewModel.SelectedCoefficientC = "3";
            viewModel.SelectedFunctionType = "Линейная";
            Application.Current.MainWindow.DataContext = viewModel;

            // Act
            functionResult.UpdateResult();

            // Assert
            Assert.AreEqual("12", functionResult.Result);
        }

        [Test]
        public void UpdateResult_QuadraticFunction_CalculatesCorrectResult()
        {
            // Arrange
            var viewModel = new MainViewModel();
            var functionResult = new FunctionResult();
            functionResult.X = "2";
            functionResult.Y = "3";
            viewModel.CoefficientA = "2";
            viewModel.CoefficientB = "3";
            viewModel.SelectedCoefficientC = "4";
            viewModel.SelectedFunctionType = "Квадратичная";
            Application.Current.MainWindow.DataContext = viewModel;

            // Act
            functionResult.UpdateResult();

            // Assert
            Assert.AreEqual("43", functionResult.Result);
        }

        // Add more test cases for other function types and scenarios
    }
}

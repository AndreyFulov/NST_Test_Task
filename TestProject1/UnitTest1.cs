using NUnit.Framework;
using NST_Test_Task;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace NST_Test_Task.Tests
{
    [TestFixture]
    public class FunctionResultTests
    {
        
        [Test]
        public void UpdateResult_LinearFunction_CalculatesCorrectResult()
        {
            FunctionResult functionResult = new FunctionResult();
            MainViewModel viewModel = new MainViewModel();

            // Arrange
            functionResult.viewModel = viewModel;
            functionResult.isTesting = true;
            functionResult.X = 2;
            functionResult.Y = 8;
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedCoefficientC = "2";
            viewModel.SelectedFunctionType = "Линейная";

            // Act
            double res = functionResult.CalcFunc(1);
            functionResult.UpdateResult();


            // Assert
            Assert.AreEqual("14", functionResult.Result);
        }

        [Test]
        public void UpdateResult_QuadraticFunction_CalculatesCorrectResult()
        {
            FunctionResult functionResult = new FunctionResult();
            MainViewModel viewModel = new MainViewModel();

            // Arrange
            functionResult.viewModel = viewModel;
            functionResult.isTesting = true;
            functionResult.X = 2;
            functionResult.Y = 6;
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedFunctionType = "Квадратичная";
            viewModel.SelectedCoefficientC = "20";
            

            // Act
            double res = functionResult.CalcFunc(2);


            // Assert
            Assert.AreEqual("76", res.ToString());
        }
        [Test]
        public void UpdateResult_CubicFunction_CalculatesCorrectResult()
        {
            FunctionResult functionResult = new FunctionResult();
            MainViewModel viewModel = new MainViewModel();

            // Arrange
            functionResult.viewModel = viewModel;
            functionResult.isTesting = true;
            functionResult.X = 2;
            functionResult.Y = 6;
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedFunctionType = "Кубическая";
            viewModel.SelectedCoefficientC = "200";


            // Act
            double res = functionResult.CalcFunc(3);


            // Assert
            Assert.AreEqual("504", res.ToString());
        }
        [Test]
        public void UpdateResult_FourthFunction_CalculatesCorrectResult()
        {
            FunctionResult functionResult = new FunctionResult();
            MainViewModel viewModel = new MainViewModel();

            // Arrange
            functionResult.viewModel = viewModel;
            functionResult.isTesting = true;
            functionResult.X = 2;
            functionResult.Y = 6;
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedFunctionType = "4-ой степени";
            viewModel.SelectedCoefficientC = "2000";


            // Act
            double res = functionResult.CalcFunc(4);


            // Assert
            Assert.AreEqual("3760", res.ToString());
        }
        [Test]
        public void UpdateResult_FifthFunction_CalculatesCorrectResult()
        {
            FunctionResult functionResult = new FunctionResult();
            MainViewModel viewModel = new MainViewModel();

            // Arrange
            functionResult.viewModel = viewModel;
            functionResult.isTesting = true;
            functionResult.X = 2;
            functionResult.Y = 6;
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedFunctionType = "4-ой степени";
            viewModel.SelectedCoefficientC = "20000";


            // Act
            double res = functionResult.CalcFunc(5);


            // Assert
            Assert.AreEqual("30432", res.ToString());
        }


    }
}

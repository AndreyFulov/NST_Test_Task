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
            viewModel.SelectedFunctionType = "Линейная";
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedCoefficientC = "2";
            

            // Act
            double res = viewModel.CalcFunc(1, functionResult);


            // Assert
            Assert.AreEqual("14", res.ToString());
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
            viewModel.SelectedFunctionType = "Квадратичная";
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            
            viewModel.SelectedCoefficientC = "20";


            // Act
            double res = viewModel.CalcFunc(2, functionResult);


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
            viewModel.SelectedFunctionType = "Кубическая";
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            
            viewModel.SelectedCoefficientC = "200";


            // Act
            double res = viewModel.CalcFunc(3, functionResult);


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
            viewModel.SelectedFunctionType = "4-ой степени";
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedCoefficientC = "2000";


            // Act
            double res = viewModel.CalcFunc(4, functionResult);


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
            viewModel.SelectedFunctionType = "5-ой степени";
            viewModel.CoefficientA = 2;
            viewModel.CoefficientB = 8;
            viewModel.SelectedCoefficientC = "20000";


            // Act
            double res = viewModel.CalcFunc(5, functionResult);


            // Assert
            Assert.AreEqual("30432", res.ToString());
        }


    }
}

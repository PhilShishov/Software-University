
namespace CalculatorApp.Controllers
{
    using CalculatorApp.Models;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : Controller
    {
        public IActionResult Index(decimal leftOperand, decimal rightOperand, string @operator, decimal result)
        {
            Calculator calculator = new Calculator
            {
                LeftOperand = leftOperand,
                RightOperand = rightOperand,
                Operator = @operator,
                Result = result
            };

            return View(calculator);
        }

        public IActionResult Calculate(Calculator calculator)
        {
            calculator.CalculateResult();

            if (calculator.RightOperand == 0 && calculator.Operator == "/")
            {
                TempData["Error"] = "Can not divide by 0";
            }

            else
            {
                Data.CalculatorHistory.Add(calculator);
            }


            return RedirectToAction("Index", calculator);
        }

        public IActionResult History()
        {
            return View(Data.CalculatorHistory);
        }
    }
}

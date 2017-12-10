using System.Web.Mvc;

namespace Calculator_CSharp.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        public ActionResult Index(Calculator calculator)
        {
            return View(calculator);
        }

        [HttpPost]
        public ActionResult Calculate(Calculator calculator)
        {
            calculator.Result = CalculateResult(calculator);
            return RedirectToAction("Index", calculator);
        }

        private decimal CalculateResult(Calculator calculator)
        {
            switch (calculator.Operator)
            {
                case "+":
                    return calculator.LeftOperand + calculator.RightOperand;

                case "-":
                    return calculator.LeftOperand - calculator.RightOperand;

                case "*":
                    return calculator.LeftOperand * calculator.RightOperand;

                case "/":
                    if (calculator.RightOperand == 0)
                        return 0;
                    return calculator.LeftOperand / calculator.RightOperand;

                default:
                    return 0;
            }
        }
    }
}

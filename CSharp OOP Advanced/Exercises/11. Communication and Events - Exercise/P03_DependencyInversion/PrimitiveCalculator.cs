namespace P03_DependencyInversion
{
    public class PrimitiveCalculator
    {
        private IStrategy currentStrategy;

        public PrimitiveCalculator()
        {
            this.currentStrategy = new AdditionStrategy();
        }

        public void ChangeStrategy(char @operator)
        {
            switch (@operator)
            {
                case '+':
                    this.currentStrategy = new AdditionStrategy();
                    break;
                case '-':
                    this.currentStrategy = new SubtractionStrategy();
                    break;
                case '*':
                    this.currentStrategy = new MultiplicationStrategy();
                    break;
                case '/':
                    this.currentStrategy = new DivisionStrategy();
                    break;

            }
        }

        public int PerformCalculation(int firstOperand, int secondOperand)
        {
            return this.currentStrategy.Calculate(firstOperand, secondOperand);
        }
    }
}

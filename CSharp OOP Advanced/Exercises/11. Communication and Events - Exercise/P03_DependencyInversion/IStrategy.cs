namespace P03_DependencyInversion
{
    public interface IStrategy
    {
        int Calculate(int firstOperand, int secondOperand);
    }
}
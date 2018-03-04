namespace WildFarm.Models
{
    public abstract class Food
    {
        protected Food(int quantity)
        {
            Quantity = quantity;
        }

        public int Quantity { get; }
    }
}

namespace DungeonsAndCodeWizards
{
    public abstract class Item
    {
        protected Item(int weight)
        {
            Weight = weight;
        }

        public int Weight { get; }

        public abstract void AffectCharacter(Character character);
    }
}

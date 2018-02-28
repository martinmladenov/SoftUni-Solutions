namespace MordorsCruelPlan
{
    using Foods;

    public static class FoodFactory
    {
        public static Food MakeFood(string foodName)
        {
            switch (foodName.ToLower())
            {
                case "cram":
                    return new CramFood();
                case "lembas":
                    return new LembasFood();
                case "apple":
                    return new AppleFood();
                case "melon":
                    return new MelonFood();
                case "honeycake":
                    return new HoneyCakeFood();
                case "mushrooms":
                    return new MushroomsFood();
                default:
                    return new OtherFood();
            }
        }
    }
}

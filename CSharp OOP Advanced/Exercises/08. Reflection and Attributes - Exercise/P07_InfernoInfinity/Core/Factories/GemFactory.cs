namespace InfernoInfinity.Core.Factories
{
    using System;
    using Contracts;
    using Models.Gems;

    public class GemFactory
    {
        public IGem CreateGem(string typeName, string clarityName)
        {
            GemClarity rarity = Enum.Parse<GemClarity>(clarityName, true);

            return (IGem)Activator.CreateInstance(Type.GetType("InfernoInfinity.Models.Gems." + typeName), rarity);
        }
    }
}

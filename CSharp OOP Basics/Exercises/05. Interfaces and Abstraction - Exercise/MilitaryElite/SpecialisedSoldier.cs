using System;

public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
{
    protected SpecialisedSoldier(int id, string firstName, string lastName, double salary, Corps corps) : base(id, firstName, lastName, salary)
    {
        Corps = corps;
    }

    public Corps Corps { get; }

    public override string ToString()
    {
        return $"{base.ToString()}{Environment.NewLine}" +
               $"Corps: {Corps}";
    }
}


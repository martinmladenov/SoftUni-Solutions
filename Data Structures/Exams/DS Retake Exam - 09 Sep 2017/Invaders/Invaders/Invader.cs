public class Invader : IInvader
{
    public Invader(int damage, int distance)
    {
        Damage = damage;
        Distance = distance;
    }
    
    public int Damage { get; set; }
    public int Distance { get; set; }

    public int CompareTo(IInvader other)
    {
        int cmp = this.Distance.CompareTo(other.Distance);

        if (cmp == 0)
        {
            cmp = other.Damage.CompareTo(this.Damage);
        }

        return cmp;
    }
}

namespace ContainerLogistics.Classes
{
    public class Liquid : Product
    {
        public bool IsHazardous { get; }
        public Liquid(string name, double mass, bool isHazardous) : base(name, mass)
        {
            IsHazardous = isHazardous;
        }
    }
}
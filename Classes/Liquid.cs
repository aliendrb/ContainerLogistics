namespace ContainerLogistics.Classes
{
    public class Liquid : Product
    {
        public bool IsHazardous { get; }
        public Liquid(string name, double weight, bool isHazardous) : base(name, weight)
        {
            IsHazardous = isHazardous;
        }
    }
}
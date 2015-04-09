namespace Infestation
{
    internal class Parasite : Infestor
    {
        public Parasite(string id)
            : base(id, UnitClassification.Biological, 1, 1, 1)
        {
        }
    }
}
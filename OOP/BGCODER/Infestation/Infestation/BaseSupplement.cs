namespace Infestation
{
    internal abstract class BaseSupplement : ISupplement
    {
        public int PowerEffect { get; protected set; }

        public int HealthEffect { get; protected set; }

        public int AggressionEffect { get; protected set; }

        public virtual void ReactTo(ISupplement otherSupplement)
        {
        }
    }
}
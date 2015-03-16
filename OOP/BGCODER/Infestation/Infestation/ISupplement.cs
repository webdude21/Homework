namespace Infestation
{
    public interface ISupplement
    {
        int PowerEffect { get; }

        int HealthEffect { get; }

        int AggressionEffect { get; }

        void ReactTo(ISupplement otherSupplement);
    }
}
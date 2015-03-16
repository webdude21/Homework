namespace Infestation
{
    internal class InfestationSpores : BaseSupplement
    {
        public InfestationSpores()
        {
            this.PowerEffect = -1;
            this.AggressionEffect = 20;
        }

        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is InfestationSpores)
            {
                this.PowerEffect = 0;
                this.AggressionEffect = 0;
            }
        }
    }
}
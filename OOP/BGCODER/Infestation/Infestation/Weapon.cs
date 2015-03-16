namespace Infestation
{
    internal class Weapon : BaseSupplement
    {
        public override void ReactTo(ISupplement otherSupplement)
        {
            if (otherSupplement is WeaponrySkill)
            {
                this.AggressionEffect = 3;
                this.PowerEffect = 10;
            }
        }
    }
}
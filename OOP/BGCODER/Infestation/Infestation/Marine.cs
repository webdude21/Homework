namespace Infestation
{
    internal sealed class Marine : Human
    {
        public Marine(string id)
            : base(id)
        {
            this.AddSupplement(new WeaponrySkill());
        }
    }
}
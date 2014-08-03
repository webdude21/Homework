namespace CompositePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var king = new Commander("Leonidas");

            var grandGeneral = new Commander("Xena The Princess Warrior");

            var generalProtos = new Commander("General Protos");

            var officerTonga = new Commander("Officer Tonga");
            officerTonga.Add(new Person("Kin"));
            officerTonga.Add(new Person("Briko"));
            officerTonga.Add(new Person("Zaler"));

            var officerHerin = new Commander("Officer Herin");
            officerHerin.Add(new Person("Gorok"));
            officerHerin.Add(new Person("Bozat"));
            officerHerin.Add(new Person("Koreb"));
            officerHerin.Add(new Person("Tikal"));
            officerHerin.Add(new Person("Mera"));

            var officerSalazar = new Commander("Officer Salazar");
            officerSalazar.Add(new Person("Kira"));
            officerSalazar.Add(new Person("Zaler"));
            officerSalazar.Add(new Person("Perin"));
            officerSalazar.Add(new Person("Subotli"));

            generalProtos.Add(officerHerin);
            generalProtos.Add(officerSalazar);
            generalProtos.Add(officerTonga);

            grandGeneral.Add(generalProtos);

            king.Add(grandGeneral);

            king.Display(1);
        }
    }
}
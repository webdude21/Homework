namespace FacadePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var es = HomeTheaterPro.GetInstance();

            es.InitHomeSystem();
            es.Next();
            es.Next();
            es.Stop();
        }
    }
}
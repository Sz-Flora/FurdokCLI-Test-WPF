namespace StrandCLI
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Furdo> furdok = new List<Furdo>();
            var sorok = File.ReadAllLines("strandadatok.txt").Skip(1);

            foreach (var sor in sorok)
            {
                furdok.Add(new Furdo(sor));
            }

            Console.WriteLine("7. feladat:");
            Console.WriteLine($"Fürdők száma: {furdok.Count}");

            Console.WriteLine("8. feladat:");
            int osszeg = 0;
            foreach (var f in furdok)
            {
                osszeg += f.Ar;
            }
            double atlag = (double)osszeg / furdok.Count;
            Console.WriteLine($"A fürdőbelépők átlagos ára: {atlag:F1}");

            Console.WriteLine("9. feladat:");
            Furdo leghidegebb = furdok.MinBy(x => x.Vizhofok);
            Console.WriteLine($"A leghidegebb víz a(z) {leghidegebb.Cim} nevű fürdőben van.");

            Console.WriteLine("10. feladat:");
            Console.WriteLine("Kérem, adja meg egy fürdő nevét!");
            string bekertfurdo = Console.ReadLine();
            bool vane = false;
            foreach (var f in furdok)
            {
                if (f.Nev == bekertfurdo)
                {
                    vane = true;
                    Console.WriteLine($"A fürdő {f.Telepules()} településen van, az írányítószáma: {f.IRSZ()}");
                    break;
                }
            }
            if (vane == false)
            {
                Console.WriteLine("Nincs ilyen nevű fürdő.");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auticka
{
    class Automat
    {
        public List<Vertex> Vrcholy = new List<Vertex>();
        public List<Hrana> Hrany = new List<Hrana>();
        public Vertex Stav = new Vertex();

        public bool StavZmena = false;
        public bool AcceptingState;

        public void ResetState()
        {
            Stav = Vrcholy[0];
        }
        
        public void Action(char c)
        {
            foreach(Hrana hrana in Stav.Hrany)
            {
                if(c == hrana.Hodnota)
                {
                    Stav = hrana.Vrcholy[1];
                    StavZmena = true;
                }
                
            }

            if(StavZmena == false)
            {
                ResetState();
                StavZmena = false;
            }
            else
            {
                StavZmena = false;

            }

            if (Stav.Koncovy == true)
            {
                AcceptingState = true;
            }
            else
            {
                AcceptingState = false;
            }
        }
        
        public void Start()
        {
            string input = Console.ReadLine();

            foreach(char pismeno in input)
            {
                Action(pismeno);
            }

            if(AcceptingState == true)
            {
                Console.WriteLine("fajne");
            }
            else
            {
                Console.WriteLine("nyt");
            }
        }
    }
    class Hrana
    {
        public List<Vertex> Vrcholy = new List<Vertex>(2);
        public char Hodnota;
    }
    class Vertex
    {
        public List<Hrana> Hrany = new List<Hrana>();
        public bool Koncovy = false;
        public int Hodnota;
    }
    class Nacitani
    {
        public static Automat Automat()
        {
            Automat automat = new Automat();

            int pocetVrch = int.Parse(Console.ReadLine());
            int pocetHran = int.Parse(Console.ReadLine());
            
            automat.Vrcholy = new List<Vertex>(pocetVrch);

            for (int i = 0; i < automat.Vrcholy.Capacity; i++)
            {
                automat.Vrcholy.Add(new Vertex());
                automat.Vrcholy[i].Hodnota = i;
            }

            automat.Hrany = new List<Hrana>(pocetHran);

            for (int i = 0; i < automat.Hrany.Capacity; i++)
            {
                automat.Hrany.Add(new Hrana());
            }

            for (int i = 0; i < automat.Hrany.Capacity; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                automat.Hrany[i].Vrcholy.Add(automat.Vrcholy[int.Parse(input[0])]);
                automat.Hrany[i].Vrcholy.Add(automat.Vrcholy[int.Parse(input[1])]);
                automat.Hrany[i].Hodnota = char.Parse(input[2]);

                automat.Vrcholy[int.Parse(input[1])].Hrany.Add(automat.Hrany[i]);
                automat.Vrcholy[int.Parse(input[0])].Hrany.Add(automat.Hrany[i]);
            }

            string[] konce = Console.ReadLine().Split(' ');

            foreach(string konec in konce)
            {
                automat.Vrcholy[int.Parse(konec)].Koncovy = true;
            }

            automat.Stav = automat.Vrcholy[0];

            return automat;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            Automat auto = Nacitani.Automat();

            auto.Start();

            Console.ReadKey();
        }
    }
}

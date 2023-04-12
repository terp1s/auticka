using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auticka
{
    class Automat
    {
        public List<Vertex> Vrcholy;
        public List<Hrana> Hrany;
        Vertex Stav = new Vertex();

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
                }
            }
           
            if(Stav.Koncovy == true)
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
            string[] input = Console.ReadLine().Split(' ');

            foreach(string pismeno in input)
            {
                Action(char.Parse(pismeno));
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
        public List<Hrana> Hrany;
        public bool Koncovy = false;
    }
    class Nacitani
    {
        public Automat Automat()
        {
            Automat automat = new Automat();

            int pocetVrch = int.Parse(Console.ReadLine());
            int pocetHran = int.Parse(Console.ReadLine());
            
            automat.Vrcholy = new List<Vertex>(pocetVrch);
            automat.Hrany = new List<Hrana>(pocetHran);

            for (int i = 0; i < automat.Hrany.Count; i++)
            {
                string[] input = Console.ReadLine().Split(' ');

                automat.Hrany[i].Vrcholy.Add(automat.Vrcholy[int.Parse(input[1])]);
                automat.Hrany[i].Vrcholy.Add(automat.Vrcholy[int.Parse(input[0])]);
                automat.Hrany[i].Hodnota = char.Parse(input[2]);

            }

            string[] konce = Console.ReadLine().Split(' ');

            foreach(string konec in konce)
            {
                automat.Vrcholy[int.Parse(konec)].Koncovy = true;
            }

            return automat;

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}

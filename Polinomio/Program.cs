namespace Polinomio
{
    //HA HA HA HA OOOO HEY JESSIE HEY JESSIE
    internal class Program
    {
        const int N = 100; // tamaño del vector de monomios
        struct Monomio
        {
            public double coef;
            public int exp;
        }
        struct Polinomio
        {
            public Monomio[] mon; // array de monomios
            public int nMon; // número de monomios
                             // último monomio en nMon=1
        }

        static Polinomio miPolinomio;
        static Polinomio miPolinomio1;
        static void Main(string[] args)
        {
            static void leeMonomio(out Monomio m)
            {
                Console.Write("Coeficiente: ");
                m.coef = double.Parse(Console.ReadLine());
                Console.Write("Exponente: ");
                m.exp = int.Parse(Console.ReadLine());
            }
            static void leePolinomio(out Polinomio p)
            {
                p.mon = new Monomio[N];
                Console.Write("Número de monomios: ");
                p.nMon = int.Parse(Console.ReadLine());
                Console.WriteLine("Introduce monomios");
                for (int i = 0; i < p.nMon; i++)
                    leeMonomio(out p.mon[i]);
            }
             
            static void escribePolinomio(Polinomio p)
            {
                for (int i = 0; i < p.nMon; i++)
                {
                    if (p.mon[i].coef > 0 && i != 0) { Console.Write(" + "); }

                    if (p.mon[i].exp == 0)
                    { Console.Write(p.mon[i].coef); }
                    else if (p.mon[i].exp == 1)
                    { Console.Write(p.mon[i].coef + "x"); }
                    else
                    { Console.Write(p.mon[i].coef + "x^" + p.mon[i].exp); }
                    Console.Write(" ");
                }
                    
            }
            
            static void addPolinomio(ref Polinomio p)
            {
                p.nMon++;
                leeMonomio(out p.mon[p.nMon - 1]);
            }

            

            static Polinomio sumaPolinomios(Polinomio P1 , Polinomio P2)
            {
                bool sameExponent = false;
                
                
                Polinomio Plargo;
                Polinomio Pcorto;
                if (P1.nMon >= P2.nMon)
                { Plargo = P1;Pcorto = P2; }
                else { Plargo = P2;Pcorto = P1; }
                
                for (int k = 0; k < Pcorto.nMon; k++)
                {
                    sameExponent = false;
                    int i = 0;
                    while (i < Plargo.nMon && !sameExponent)
                     {
                        sameExponent = (Plargo.mon[i].exp == Pcorto.mon[k].exp);
                        i++;
                     }
                  if (sameExponent)
                  { 
                  Plargo.mon[i-1].coef += Pcorto.mon[k].coef;
                        if (Plargo.mon[i - 1].coef == 0)
                        {
                            Plargo.mon[i-1] = Plargo.mon[Plargo.nMon-1];
                            Plargo.nMon--;
                            
                        }

                  }
                  else 
                  { 
                    Plargo.nMon++;
                    Plargo.mon[Plargo.nMon - 1] = Pcorto.mon[k];
                  }

                }
                return Plargo;
            }


            leePolinomio(out miPolinomio);
            escribePolinomio(miPolinomio);
            Console.WriteLine();
            leePolinomio(out miPolinomio1);
            escribePolinomio(miPolinomio1);
            Console.WriteLine();
            Console.WriteLine("Suma de los dos polinomios");
           escribePolinomio(sumaPolinomios(miPolinomio, miPolinomio1));

            








        }
    }
}

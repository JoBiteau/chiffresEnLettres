using System;
using System.Collections.Generic;

namespace ChiffresEnLettres
{
    class Program
    {

        private static int entier;


        static void Main(string[] args)
        {
            var input = "";

            while("quit" != input)
            {
                Console.WriteLine("Entrez un entier positif entre 0 et 999: ");
                input = Console.ReadLine();

                try
                {
                    entier = int.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("La valeure choisie n'est pas un entier");
                    continue;
                }

                if(entier < 0)
                {
                    Console.WriteLine("La valeure choisie est négative");
                    continue;
                } else if (entier > 999)
                {
                    Console.WriteLine("La valeure choisie supérieure à 999");
                    continue;
                }

                var retour = toLiteral(entier);

                Console.WriteLine($"{retour}");
            }

        }

        static string toLiteral(int value)
        {
            string[] uniteesTab =
            {
                "zero",
                "un",
                "deux",
                "trois",
                "quatre",
                "cinq",
                "six",
                "sept",
                "huit",
                "neuf"
            }; 
            string[] dizainesTab =
            {
                "",
                "dix",
                "vingt",
                "trente",
                "quarante",
                "cinquante",
                "soixante",
                "soixante-dix",
                "quatre-vingt",
                "quatre-vingt-dix"
            };
            string[] exceptionsTab =
            {
                "",
                "onze",
                "douze",
                "treize",
                "quatorze",
                "quinze",
                "seize",
                "dix-sept",
                "dix-huit",
                "dix-neuf",
            };

            int[] norm = {2,
                          3,
                          4,
                          5,
                          6,
                          8 };


            int unitee = value % 10;
            int dizaine = (value % 100)/10;
            int centaine = (value % 1000)/100;

            string unitees = uniteesTab[unitee];
            string dizaines = dizainesTab[dizaine];
            string centaines = "";

            if( unitee == 0 && (dizaine > 0 || centaine > 0))
            {
                unitees = "";
            }
            
            if (dizaine == 1 && unitee != 0)
            {
                dizaines = exceptionsTab[unitee];
                unitees = "";
            } else if ( unitee == 1 && (
                dizaine == 2 || 
                dizaine == 3 || 
                dizaine == 4 || 
                dizaine == 5 || 
                dizaine == 6 || 
                dizaine == 8 ))
            {
                dizaines = dizainesTab[dizaine] + " et " + unitees;
                unitees = "";
            }

            if (centaine > 1)
            {
                centaines = uniteesTab[centaine] + " cent";
            } 
            else if (centaine == 1)
            {
                centaines = "cent";
            } 
            else
            {
                centaines = "";
            }

            string retour = centaines + " " + dizaines + " " + unitees;

            return retour;
        }
    }
}

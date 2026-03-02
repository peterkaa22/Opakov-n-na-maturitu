using System;
using System.Collections.Generic;

namespace Piskvorky
{
    class Program
    {
        
        
        static (char hrac1, char hrac2) symboly = ('X', 'O');

      
        static char[,] pole = new char[3, 3];

        static Dictionary<char, int> skore = new Dictionary<char, int>
        {
            { 'X', 0 },
            { 'O', 0 }
        };

        static void Main(string[] args)
        {
            ResetujPole();
            int tah = 0;
            bool hraBezi = true;

            Console.WriteLine("--- C# PIŠKVORKY ---");

            while (hraBezi)
            {
                VykresliPole();
                char aktualniHrac = (tah % 2 == 0) ? symboly.hrac1 : symboly.hrac2;
                Console.WriteLine($"\nNa řadě je hráč: {aktualniHrac}");

              
                var (radek, sloupec) = ZiskejVstup();

                if (pole[radek, sloupec] == ' ')
                {
                    pole[radek, sloupec] = aktualniHrac;
                    
                    if (ZkontrolujVitezstvi(aktualniHrac))
                    {
                        VykresliPole();
                        Console.WriteLine($"\nVítěz je {aktualniHrac}!");
                        skore[aktualniHrac]++;
                        hraBezi = false;
                    }
                    else if (tah == 8)
                    {
                        VykresliPole();
                        Console.WriteLine("\nRemíza!");
                        hraBezi = false;
                    }
                    tah++;
                }
                else
                {
                    Console.WriteLine("Toto pole je již obsazené! Zkus to znovu.");
                }
            }
            Console.WriteLine($"Konečné skóre - X: {skore['X']}, O: {skore['O']}");
            Console.ReadLine();
        }

        static void ResetujPole()
        {
            for (int r = 0; r < 3; r++)
                for (int s = 0; s < 3; s++)
                    pole[r, s] = ' ';
        }

        static void VykresliPole()
        {
            Console.WriteLine("  0 1 2");
            for (int r = 0; r < 3; r++)
            {
                Console.Write(r + " ");
                for (int s = 0; s < 3; s++)
                {
                    Console.Write(pole[r, s] + (s < 2 ? "|" : ""));
                }
                Console.WriteLine();
                if (r < 2) Console.WriteLine("  -----");
            }
        }

        static (int radek, int sloupec) ZiskejVstup()
        {
            while (true)
            {
                try
                {
                    Console.Write("Zadej řádek a sloupec (např. 1 2): ");
                    string[] vstup = Console.ReadLine().Split(' ');
                    int r = int.Parse(vstup[0]);
                    int s = int.Parse(vstup[1]);
                    if (r >= 0 && r < 3 && s >= 0 && s < 3) return (r, s);
                }
                catch { }
                Console.WriteLine("Neplatný vstup, zkus to znovu.");
            }
        }

        static bool ZkontrolujVitezstvi(char p)
        {
            for (int i = 0; i < 3; i++)
            {
           
                if ((pole[i, 0] == p && pole[i, 1] == p && pole[i, 2] == p) ||
                    (pole[0, i] == p && pole[1, i] == p && pole[2, i] == p))
                    return true;
            }
            
            if ((pole[0, 0] == p && pole[1, 1] == p && pole[2, 2] == p) ||
                (pole[0, 2] == p && pole[1, 1] == p && pole[2, 0] == p))
                return true;

            return false;
        }
    }
}
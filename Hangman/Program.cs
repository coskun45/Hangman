using System;

namespace Hangman
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            int maxVersuch;
            Console.WriteLine("Hangman");
            Console.WriteLine("=======");
            //Liste von Wörtern
            string[] suchWörter =
            { "variable", "initialisieren", "anweisung", "zuweisen",
             "implementieren", "verzweigungen", "mehrdimensionalarray",
              "ifabfrage", "datenmenge", "fehlermeldung" };
            //Randomzahl für ein zufälliges Wort Auswahl 
            Random zufallig = new Random();
            int randomZahl = zufallig.Next(0, 10);
            string ausgewähltesWort = suchWörter[randomZahl];
            //Je nachdem ausgewähltes Wort Versuchzahl
            if (10<=ausgewähltesWort.Length && ausgewähltesWort.Length<15)
            {
                maxVersuch = 5;
            }
            else if (ausgewähltesWort.Length<10)
            {
                maxVersuch = 4;
            }
            else
            {
                maxVersuch = 6;
            }
            //Char Array damit Wort in Buchstaben teilen
            char[] buchstabenArray = new char[ausgewähltesWort.Length];
            Console.WriteLine("Gesucht ist ein Wort mit {0} Buchstaben.", buchstabenArray.Length);
            //Statt Buchstaben "-" machen
            for (int i = 0; i < buchstabenArray.Length; i++)
                buchstabenArray[i] = '-';
            Console.Write("Das geheime Wort ist: ");
            //Liste von Buchstaben mit Strich  
            foreach (var k in buchstabenArray)
            {
                Console.Write(k);
            }
            Console.WriteLine("\n");
            while (counter < maxVersuch)
            {
                Console.WriteLine();
                Console.Write("Buchstaben eingeben: ");
                char tus = Convert.ToChar(Console.ReadKey().KeyChar);
                tus = char.ToLower(tus);
                Console.WriteLine();
                Console.Write("Das geheime Wort ist: ");
                //wechsel - in Buchstabe
                for (int j = 0; j < buchstabenArray.Length; j++)
                {
                    if (tus == ausgewähltesWort[j])
                    {
                        buchstabenArray[j] = tus;
                    }
                }
                Console.Write(buchstabenArray);
                //Kontrol Ausgabe ob eingegebene Bucstaben richtig oder falsch
                for (int i = 0; i < buchstabenArray.Length; i++)
                {
                    if (buchstabenArray[i] == tus)
                    {
                        Console.Write("   --> " + tus + " ist richtig!\n");
                        i = buchstabenArray.Length;
                    }
                    if (i == buchstabenArray.Length - 1)
                    {
                        Console.Write("   --> " + tus + " ist falsch !\n");
                        //Zahl falsch Versuch
                        counter++;
                        Console.WriteLine("{0} von {1} Fehlern .", counter, maxVersuch);
                        if (counter == maxVersuch)
                        {
                            Console.WriteLine("Game Over ): ");
                            Console.WriteLine("Ausgewähltes Wort: {0}", ausgewähltesWort);
                        }
                    }
                }
                // Kontrol ob Spieler die Zahl von Buchstaben erreicht dann Gewinnen
                for (int p = 0; p < buchstabenArray.Length; p++)
                {
                    if (buchstabenArray[p] == '-')
                    {
                        p = buchstabenArray.Length;
                    }
                    if (p == buchstabenArray.Length - 1)
                    {
                        Console.WriteLine("Du hast gewonnen (: ");
                        counter = 6;
                    }
                }

            }
        }
    }
}

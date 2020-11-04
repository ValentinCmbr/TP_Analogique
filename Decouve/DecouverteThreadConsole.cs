using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DecouverteThreadConsole
{
    class DecouverteThreadConsole
    {
        static void Main(string[] args)
        {
            
            // La durée en seconde du thread principal
            int dureeMain = 20;

            // Le thread lui même, création sans le demarrer
            ThreadStart delegateRunLetter = new ThreadStart(RunLetter);
            Thread LaTache = new Thread(delegateRunLetter);

            // Demarrage des threads
            Console.WriteLine("> Le thread est créé.\n> Démarrage...");
            LaTache.Start();

            // Le thread principal compte le temps
            Console.WriteLine("> Main en route pour {0} secondes...", dureeMain);
            for(int i = 1; i < dureeMain; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine(" > main: " + i + "sec.");
            }

            // Arret du thread LaTache
            Console.WriteLine(" > Demande d'arret des threads.");

            stop = true;

            // On attend que le thread en cours soit effectivement terminé avant de continuer.
            LaTache.Join();
            Console.WriteLine("> Le thread LaTache est terminé.");

            Console.WriteLine("\n\n\t\tTouche \"Entrée\"pour terminer...");
            Console.ReadLine();
        }
        
        public static void RunLetter()
        {
            /// Un random pour le sleep..
            Random rnd = new Random();

            /// La lettre à afficher
            char letter = 'a';

            Console.WriteLine("\t\t ----> Le RunLetter commence son travail.");
            while (true)
            {
                if (letter < 'z')
                    letter++;
                else
                    letter = 'a';

                Console.WriteLine("\t\t ----> Letter: " + letter.ToString());

                // Sleep pour un temps aléatoire < 1267ms
                Thread.Sleep(rnd.Next(1267));
            }
            while (!stop)
            {

            }
            Console.WriteLine("\t\t -----> Le RunLetter a fini son travail.");
        }
        public static bool stop = false;
    }
}

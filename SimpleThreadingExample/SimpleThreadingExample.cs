using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadingExample
{
    class SimpleThreadingExample
    {
        static void Main(string[] args)
        {
            int iter = 15;

            // Création des objets encapsulant les threads.
            MyThreadLetter ThLetter = new MyThreadLetter();
            MyThreadNumber ThCptr = new MyThreadNumber();
            Console.WriteLine(" > Le thread est créé.");

            ThLetter.Start();
            ThCptr.Start(19);

            Console.WriteLine("> En route pour {0} sec. ...", iter);
            for (int i = 0; i < iter; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("> main : " + i + "sec.");
            }
            Console.WriteLine("> Demande d'arrêt du thread;");
            ThLetter.stop = true;
            ThCptr.stop = true;

            ThLetter.LaTache.Join();
            ThCptr.laTache.Join();

            Console.WriteLine("> Les threads sont terminés.");
            Console.WriteLine("\n\n\t\tTouche \"Entrée\" pour terminer...");
            Console.ReadLine();

        }
    }
}

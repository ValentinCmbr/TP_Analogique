using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadingExample
{
    class MyThreadLetter
    {
        private bool Stop;
        private char Letter;
        private Thread laTache;

        Random rnd = new Random();

        public bool stop { get => Stop; set => Stop = value; }
        public char letter { get => Letter; set => Letter = value; }
        public Thread LaTache { get => laTache; set => laTache = value; }

        public MyThreadLetter()
        {
            // Creation d'un thread, sans le démarrer
            LaTache = new Thread(new ThreadStart(RunLetter));
        }


        public void Start()
        {
            try
            {
                LaTache.Start();
                Console.WriteLine("Letter demarré correctement...");

            }
            catch(ThreadStateException ex)
            {
                Console.WriteLine("Letter a déjà été démarré...");
            }
        }
        private void RunLetter()
        {
            Letter = 'z';
            Console.WriteLine("\t\t---> Le threadLetter commence son travail.");
            while(!Stop)
            {
                if (Letter < 'z')
                    Letter++;
                else
                    Letter = 'a';
                Console.WriteLine("\t\t----> Letter:" + Letter.ToString());

                // Sleep pour un temps aléatoire < 1267ms
                Thread.Sleep(rnd.Next(1267));
            }
            Console.WriteLine("\t\t---> Le threadLetter a fini son travail.");
        }
    }
}

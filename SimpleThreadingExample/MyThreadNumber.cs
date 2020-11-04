using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleThreadingExample
{
    class MyThreadNumber
    {
        private bool Stop;
        private int Number;
        private Thread LaTache;

        Random rnd = new Random();

        public bool stop { get => Stop; set => Stop = value; }
        public int number { get => Number; set => Number = value; }
        public Thread laTache { get => LaTache; set => LaTache = value; }

        public MyThreadNumber()
        {
            laTache = new Thread(new ParameterizedThreadStart(RunNumber));
        }

        public void Start(int max = 999)
        {
            try
            {
                laTache.Start(max);
                Console.WriteLine("Number démarré correctement..");
            }
            catch( ThreadStartException ex)
            {
                Console.WriteLine("Number a déjà été demarré..");
                throw ex;
            }
            catch(OutOfMemoryException ex)
            {
                Console.WriteLine("Number ne pet pas démarrer par manque de mémoire..");
                throw ex;
            }
        }

        private void RunNumber(object max)
        {
            while (!Stop)
            {
                if (Number < (int)max)
                    Number++;
                else
                    Number = 0;
                Console.WriteLine(" ===========> Number: " + Number.ToString());

                // Sleep pour un temps aléatoire < 323 ms
                Thread.Sleep(rnd.Next(323));
            }
            Console.WriteLine("Le threadNumber a fini son travail.");
        }
    }
}

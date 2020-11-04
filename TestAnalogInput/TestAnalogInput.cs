using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MccDaq;
using LibAnalogTools;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace TestAnalogInput
{
    class TestAnalogInput
    {
        private MccBoard acqBoard;
        public AnalogInput LightIn;
        public TestAnalogInput() {
            this.acqBoard = new MccBoard(0);
            this.LightIn = new AnalogInput(this.acqBoard, 7);
        }
        
        public void Run()
        {
            while (true)
            {
                
            }
        }
        

        static void Main(string[] args)
        {

        }
    }
}

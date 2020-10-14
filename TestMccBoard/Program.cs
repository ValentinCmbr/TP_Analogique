using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MccDaq;
using LibCapteurAn;

namespace TP_Analogique
{
    class TestMccBoard
    {
        static void Main(string[] args)
        {
            ushort dataValue = 0;
            Range range = Range.Bip10Volts;
            MccBoard mccBoard7 = new MccBoard(0);
            for(int i = 0; i < 200; i++)
            {
                Console.WriteLine(dataValue);
                var ULStat = mccBoard7.AIn(7, range, out dataValue);
                Console.ReadKey();
            }
            

        }
    }
}

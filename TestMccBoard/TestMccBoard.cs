using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MccDaq;
using LibCapteurAn;
using System.Security.Authentication.ExtendedProtection;
using System.Threading;

namespace TP_Analogique
{
    class TestMccBoard
    {
        static void Main(string[] args)
        {
            float option = 0;
            ushort dataValueLum = 0;
            float dataValueLumVolt = 0;
            ushort dataValueTemp = 0;
            float dataValueTempVolt = 0;
            int channelLum = 0;
            int channelTemp = 0;
            Range range = Range.Bip10Volts;
            MccBoard mccBoard = new MccBoard(0);
            for(int i = 0; i < 200; i++)
            {
                channelLum = 7;
                channelTemp = 6;

                mccBoard.AIn(channelLum, range, out dataValueLum);
                mccBoard.VIn(channelLum, range, out dataValueLumVolt,0);


                mccBoard.AIn(channelTemp, range, out dataValueTemp);
                mccBoard.VIn(channelTemp, range, out dataValueTempVolt, 0);

                Console.WriteLine( "DataLum: " + dataValueLum.ToString());
                Console.WriteLine(dataValueLumVolt + "Volts");
                Console.WriteLine("DataTemp: " + dataValueTemp.ToString());
                Console.WriteLine(dataValueTempVolt + "Volts");

                Thread.Sleep(1000);
            }

            Console.ReadKey();
        }
    }
}

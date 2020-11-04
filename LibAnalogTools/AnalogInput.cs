using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MccDaq;

namespace LibAnalogTools
{
    public class AnalogInput
    {
        private int channel;
        private ushort mesureBrute;
        private float mesureVolt;
        private MccBoard acqBoard;
        public int Channel { get => channel; }
        public ushort MesureBrute { get => mesureBrute; }
        public float MesureVolt { get => mesureVolt; }

        public AnalogInput(MccBoard board, int channel = 0)
        {
            this.acqBoard = board;
        }

    }
}

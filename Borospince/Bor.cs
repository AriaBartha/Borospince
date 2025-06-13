using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borospince
{
    internal class Bor
    {
        private string fajta;
        private int evjarat;
        private double alkoholtartalom;

        public Bor(string fajta, int evjarat, double alkoholtartalom = 12.5)
        {
            this.Fajta = fajta;
            this.Evjarat = evjarat;
            this.Alkoholtartalom = alkoholtartalom;
        }

        public string Fajta { get => fajta; set => fajta = value; }
        public int Evjarat { get => evjarat; set => evjarat = value; }
        public double Alkoholtartalom 
        { get => alkoholtartalom; 
          set 
            { 
                if(value < 0 || value > 100)
                {
                    throw new BorospinceException("Nem megfelelő alkoholtartalom!");
                    
                }
                else
                {
                    alkoholtartalom = value;
                }
            } 
        }
    }
}

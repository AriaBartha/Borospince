﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        public override string ToString()
        {
            return $"fajta: {fajta} (évjárat: {evjarat}), melynek alkoholtartalma: {alkoholtartalom}%";
        }

        public override bool Equals(object obj)
        {
            if (obj is Bor other)
            {
                return string.Equals(Fajta, other.Fajta, StringComparison.OrdinalIgnoreCase)
                &&
                Evjarat == other.Evjarat &&
                Alkoholtartalom == other.Alkoholtartalom;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return (Fajta.ToLower(), Evjarat, Alkoholtartalom).GetHashCode();
        }
    }
}


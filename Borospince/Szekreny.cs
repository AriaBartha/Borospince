using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borospince
{
    internal class Szekreny
    {
        private List<Bor> borok;
        public Szekreny()
        {
            borok = new List<Bor>();
        }
        
        public Bor get_bor(int n)
        {
            if(n < 0 || n >= borok.Count)
            {
                throw new BorospinceException("Nem létező index!"); 
            }
            return borok[n];
        }
        public override bool Equals(object obj)
        {
            if (obj is Bor bor)
            {
                borok.Add((Bor)obj); return true;
            }
            else
            {
                throw new TypeAccessException("Nem bor!");
            }
        }

        /*public static Szekreny operator +(Szekreny s, object b)
        {
            if (b is Bor bor)
            {
                s.borok.Add(bor);
            }
                
            else
            {
                throw new TypeAccessException("Nem bor!");
            }
               
            return s;
        }*/
        public static Szekreny operator +(Szekreny sz1, Szekreny sz2)
        {
            if (sz1 != null)
            {
                Szekreny ujszekreny = new Szekreny();
                ujszekreny.borok = sz1.borok.Concat(sz2.borok).ToList();
                return ujszekreny;
            }
            else
            {
                throw new TypeAccessException("Nem szekrény!");
            }
        }

        public double atlag_alkoholtartalom(Szekreny szekreny)
        {
            if(borok.Count == 0)
            {
                throw new TypeAccessException("Üres szekrény!");
            }
            else
            {
                
                double alkoholtartalom = 0;
                for(int i = 0; i < borok.Count; i++)
                {
                    alkoholtartalom += szekreny.borok[i].Alkoholtartalom;
                }
                return alkoholtartalom / borok.Count;
            }
        }

        public Dictionary<string, int> Statisztika()
        {
            if(borok.Count == 0)
            {
                return new Dictionary<string, int>();
            }
            else
            {
                return borok
               .GroupBy(a => a.Fajta.ToLower())
               .ToDictionary(b => b.Key, b => b.Count());
            }
        }
    }
}

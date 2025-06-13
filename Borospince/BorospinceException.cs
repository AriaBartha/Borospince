using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borospince
{
    internal class BorospinceException : Exception
    {
        public BorospinceException(string message) : base(message) { }
        
    }
}

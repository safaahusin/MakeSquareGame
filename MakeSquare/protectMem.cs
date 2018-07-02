using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MakeSquare
{
     class protectMem 
    {
        private Int32 m_ResourceInUse; // default with false, when 1 means that resource isn't in use

        public void enter()
        {
            while (Interlocked.Exchange(ref m_ResourceInUse, 1) == 1) ;
        }


        public void leave()
        {
            Volatile.Write(ref m_ResourceInUse, 0); 
        }


        

    }
}

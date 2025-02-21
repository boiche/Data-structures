using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Miscellaneous.SOLID.Single_Responsibility.Pattern
{
    internal class InvoicePersistence
    {
        public Invoice Invoice { get; set; }
        public void SaveToFile()
        {
            //Doing stuff about saving the object to a file

            throw new NotImplementedException();
        }
    }
}

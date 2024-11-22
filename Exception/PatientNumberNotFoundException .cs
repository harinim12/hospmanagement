using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace HospManagement.Exceptions
{
    public class PatientNumberNotFoundException : Exception
    {
     
        public PatientNumberNotFoundException() { }
        
        public PatientNumberNotFoundException(string message) : base(message) { }

      
    }
}

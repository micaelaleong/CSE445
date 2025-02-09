using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace TempConversion
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TempConversionService : ITempConversionService
    {
        public int c2f(int c)
        {
            double f = c * 1.8 + 32; // C to F formula; use double for greater accuracy
            return Convert.ToInt32(f); // return converted F temperature as int
        }

        public int f2c(int f)
        {
            double c = (f - 32.0) * (5.0 / 9.0); ; // F to C formula; use double for greater accuracy
            return Convert.ToInt32(c); // return converted C temp as int
        }
    }
}

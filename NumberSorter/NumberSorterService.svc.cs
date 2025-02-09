using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace NumberSorter
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class NumberSorterService : INumberSorterService
    {
        public string sort(string s)
        {
            List<float> numbers = new List<float>();

            string[] numStrings = s.Split(',');

            foreach (string str in numStrings)
            {
                numbers.Add(float.Parse(str.Trim()));
            }

            numbers.Sort();

            return string.Join(",", numbers);
        }
    }
}

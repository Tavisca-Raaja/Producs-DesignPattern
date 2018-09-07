using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class ActivityProductFare:IFareStrategy
    {
        public Decimal FareCalculation(IProduct product)
        {

            LogFile.Instance.WriteLog("Fare Calculated for Activity Product");
            return product.Fare + (product.Fare / 20);
        }
    }
}

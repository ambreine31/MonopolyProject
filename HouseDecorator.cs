using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //when a house is added to a property, the total property price is increased
    public class HouseDecorator:PropertyDecorator
    {
        public HouseDecorator(IProperty prop):base(prop)
        {
        }
        
        public override double SetTotalPrice()
        {
            base.TotalPrice =  base.TotalPrice + base.PropertyPrice * 0.5;
            return base.TotalPrice;
        }  

    }
}

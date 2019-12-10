using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
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
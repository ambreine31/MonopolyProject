using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //when a hotel added to a property, the total property price is increased even more
    public class HotelDecorator:PropertyDecorator
    {
        public HotelDecorator(IProperty prop) : base(prop)
        {
        }

        public override double SetTotalPrice()
        {
            base.TotalPrice = base.TotalPrice + base.PropertyPrice;
            return base.TotalPrice;
        }
    }
}
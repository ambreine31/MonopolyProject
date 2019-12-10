using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public abstract class PropertyDecorator:IProperty
    {
        private IProperty prop;

        public PropertyDecorator(IProperty Prop)
        {
            prop = Prop;
        }
        public string Name
        {
            get { return prop.Name; }
            set { prop.Name = value; }
        }
        
        public double PropertyPrice
        {
            get { return prop.PropertyPrice; }
            set { prop.PropertyPrice = value; }
        }

        public double TotalPrice
        {
            get { return prop.TotalPrice; }
            set { prop.TotalPrice = value; }
        }

        public abstract double SetTotalPrice();

    }
}
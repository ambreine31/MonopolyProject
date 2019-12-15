using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //decorator, encloses prop in the constructor to add the abstract method to it
    public abstract class PropertyDecorator:IProperty
    {
        private IProperty prop;

        public PropertyDecorator(IProperty Prop)
        {
            prop = Prop;
        }

        public int Box_num
        {
            get { return prop.Box_num; }
            set { prop.Box_num = value; }
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

        public Player Owner
        {
            get { return prop.Owner; }
            set { prop.Owner = value; }
        }
        public abstract double SetTotalPrice();

    }
}
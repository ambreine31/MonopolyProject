using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //concrete component
    public class Property:IProperty
    {
        private int box_num;
        private string name;
        private double propertyprice;
        private double totalprice;
        //used to calculate total tax price (with added houses and hotels)
        private Player owner;

        public Property(int box_num,string name, double propertyprice)
        {
            this.box_num = box_num;
            this.name = name;
            this.propertyprice = propertyprice;
            this.totalprice = propertyprice;
            this.owner = null;
            //at the start of the game no properties are owned by players

        }
        public int Box_num
        {
            get { return this.box_num; }
            set { this.box_num = value; }
        }
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        public double PropertyPrice
        {
            get { return this.propertyprice; }
            set { this.propertyprice = value; }
        }
        public double TotalPrice
        {
            get { return this.totalprice; }
            set { this.totalprice = value; }
        }
        public Player Owner
        {
            get { return this.owner; }
            set { this.owner = value; }
        }
    }

}
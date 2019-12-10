using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        private int position;
        private string token;
        private double money;
        private bool injail;
        private List<Property> properties;

        public Player(string token, double money)
        {
            this.token = token;
            this.money = money;
            this.injail = false;
            this.properties = null;
            this.position = 0;
        }

        public int Position
        {
            get { return this.position; }
            set { this.position = value; }
        }
        public string Token
        {
            get { return this.token; }
            set { this.token = value; }
        }

        public double Money
        {
            get { return this.money; }
            set { this.money = value; }
        }

        public bool Injail
        {
            get { return this.injail; }
            set { this.injail = value; }
        }

        public List<Property> Properties
        {
            get { return this.properties; }
            set { this.properties = value; }
        }

        public void RollDiceAndMove(Random generateur)
        {
            int dice1 = generateur.Next(1, 7);
            int dice2 = generateur.Next(1, 7);
            Console.WriteLine(this.token + " rolled a " + dice1 + " and a " + dice2);

            int sum_dice = dice1 + dice2;
            this.position = Loop(this.position + sum_dice);
        }

        
        static int Loop(int index)
        {
            if (index >= 40)
            {
                index = index - 40;
            }
            return index;
        }
        
        public void BuyProperty(List<Property> properties)
        {
            foreach(Property p in properties)
            {
                if(p.Box_num == this.position)
                {
                    Console.WriteLine("This is property: " + p.Name);
                    if(p.Owner == null)
                    {
                        Console.WriteLine("This property is up for sale, price is $" + p.PropertyPrice);
                        Console.WriteLine("Your current balance is $" + this.money);
                        Console.WriteLine("Do you wish to buy this property? (y or n)");
                        string response = Console.ReadLine();
                        if (response == "y")
                        {
                            this.money = this.money - p.PropertyPrice;
                            p.Owner = this;
                            Console.WriteLine("You've aquired " + p.Name + " for $" + p.PropertyPrice);
                            Console.WriteLine("Your current balance is $" + this.money);
                        }
                    }
                    if(p.Owner != null)
                    {
                        if(p.Owner == this)
                        {
                            Console.WriteLine("This is your property, do you wish to buy a house or hotel?");
                            Console.WriteLine("Your current balance is $" + this.money);
                            Console.WriteLine("1. Buy a House for $" + p.PropertyPrice * 0.5);
                            Console.WriteLine("2. Buy a Hotel for $" + p.PropertyPrice);
                            Console.WriteLine("3. No purchase");
                            Console.Write("Your choice: ");
                            int choice = Convert.ToInt32(Console.ReadLine());
                            if(choice == 1)
                            {
                                HouseDecorator house_decorator = new HouseDecorator(p);
                                house_decorator.SetTotalPrice();
                                Console.WriteLine("The total price of your property is now $" + p.TotalPrice.ToString());
                            }
                            else if(choice == 2)
                            {
                                HotelDecorator hotel_decorator = new HotelDecorator(p);
                                hotel_decorator.SetTotalPrice();
                                Console.WriteLine("The total price of your property is now $" + p.TotalPrice.ToString());
                            }
                        }
                        if(p.Owner != this)
                        {
                            Console.WriteLine("This property is owned by player " + p.Owner.Token);
                            double tax = p.TotalPrice * 0.1;
                            Console.WriteLine("You owe him a tax of $" + tax);
                        }
                        
                    }
                }
            }
        }
    }
}
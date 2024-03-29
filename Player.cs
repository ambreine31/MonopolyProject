using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        private int position; //current placement on board
        private string token; //letter corresponding to token
        private double money; 
        private bool injail; //in or out of jail
        private int time; //time spent in jail

        public Player(string token, double money)
        {
            this.token = token;
            this.money = money;
            this.injail = false;
            this.position = 0;
            this.injail = false;
            this.time = 0; 
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

        public int RollDiceAndMove(Random generator)
        {
            //generating dice numbers
            int dice1 = generator.Next(1, 7);
            int dice2 = generator.Next(1, 7);
            Console.WriteLine(this.token + " rolled a " + dice1 + " and a " + dice2);
            int sum_dice = dice1 + dice2;

            if(this.injail == false)
            {
                //move the player according to sum of dice
                this.position = Loop(this.position + sum_dice);
                Console.WriteLine();

                //some boxes on the monopoly board correspond to specific options like being sent 
                //to jail, paying a tax, or choosing a chance card
                if(this.position == 30) 
                {
                    GoToJail();
                }
                else if(this.position == 10)
                {
                    Console.WriteLine("Visiting the jail");
                }
                else if (this.position == 2 || this.position == 17 || this.position == 33)
                {
                    Console.WriteLine("Community Chest, you receive $100!");
                    this.money = this.money + 100;
                    Console.WriteLine("Your current balance is $" + this.money);
                }
                else if(this.position == 4)
                {
                    Console.WriteLine("Income tax, pay $200!");
                    this.money = this.money - 200;
                    Console.WriteLine("Your current balance is $" + this.money);
                }
                else if(this.position == 20)
                {
                    Console.WriteLine("Free Parking.");
                }
                else if(this.position == 38)
                {
                    Console.WriteLine("Luxury tax, pay $100");
                    this.money = this.money - 200;
                    Console.WriteLine("Your current balance is $" + this.money);
                }
                else if(this.position == 7 || this.position == 22 || this.position == 36)
                {
                    ChanceCards(generator);
                }


            }
            //returns 1 if the player rolls a double
            if(dice1 == dice2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //card is picked randomely and results in a move for the Player concerned
        public void ChanceCards(Random generator)
        {
            Console.WriteLine("Pick a Chance Card");
            Console.ReadKey();
            int choice  = generator.Next(1, 7);

            if(choice == 1)
            {
                Console.WriteLine("Advance to START");
                this.position = 0;
                Console.WriteLine("You passed START, collect $200");
                this.money = this.money + 200;
                Console.WriteLine("Your current balance is $" + this.money);
            }
            if (choice == 2)
            {
                Console.WriteLine("Bank pays you a dividend of $50");
                this.money = this.money + 50;
                Console.WriteLine("Your current balance is $" + this.money);

            }
            if (choice == 3)
            {
                Console.WriteLine("Move forward 3 spaces");
                this.position = this.position + 3;
            }
            if (choice == 4)
            {
                Console.WriteLine("Make reparations on your car, pay $20");
                this.money = this.money - 20;
                Console.WriteLine("Your current balance is $" + this.money);
            }
            if (choice == 5)
            {
                Console.WriteLine("Go to jail");
                GoToJail();
            }
            if (choice == 6)
            {
                Console.WriteLine("You won the lottery! You earn $1000");
                this.money = this.money + 1000;
                Console.WriteLine("Your current balance is $" + this.money);
            }
            
        }

        //sends player to jail position and changes jail status to true
        public void GoToJail()
        {
            this.position = 10;
            this.injail = true;
            Console.WriteLine("You've been sent to jail!");
            Console.WriteLine();
        }

        public void LeaveJail()
        {
            this.injail = false;
            Console.WriteLine("You've been released from jail!");
        }

        //counts jail sentence time and releases player once time is up
        public void TimeInJail()
        {
            time++;
            if(time == 3)
            {
                Console.WriteLine("You've finished your jail sentence.");
                LeaveJail();
                time = 0;
            }
        }

        //if position is off the gameboard limits, loop back to the beginning of the board
        //and collect $200 from crossing the START 
        public int Loop(int index)
        {
            if (index >= 40)
            {
                index = index - 40;

                Console.WriteLine("You passed START, collect $200");
                this.money = this.money + 200;
                Console.WriteLine("Your current balance is $" + this.money);
                Console.ReadKey();
            }
            return index;
        }
        
        public void BuyProperty(List<Property> properties)
        {
            foreach(Property p in properties)
            {
                if(p.Box_num == this.position) //if you land on a property
                {
                    Console.WriteLine();
                    Console.WriteLine("This is property: " + p.Name);

                    //if property isn't owned by a player yet
                    if(p.Owner == null)
                    {
                        Console.WriteLine("This property is up for sale, price is $" + p.PropertyPrice);
                        Console.WriteLine("Your current balance is $" + this.money);
                        Console.WriteLine();
                        Console.WriteLine("Do you wish to buy this property? (y or n)");
                        string response = Console.ReadLine();
                        if (response == "y") //player becomes owner, spends money
                        {
                            this.money = this.money - p.PropertyPrice;
                            p.Owner = this;
                            Console.WriteLine();
                            Console.WriteLine("You've acquired " + p.Name + " for $" + p.PropertyPrice);
                            Console.WriteLine("Your current balance is $" + this.money);
                        }
                        else
                        {
                            Console.WriteLine("You haven't acquired this property");
                        }
                    }
                    else if(p.Owner != null) //property is already owned
                    {
                        if(p.Owner == this) //property is owned by current player, he can choose to add a house or hotel
                        {
                            Console.WriteLine();
                            Console.WriteLine("This is your property, do you wish to buy a house or hotel?");
                            Console.WriteLine("Your current balance is $" + this.money);
                            Console.WriteLine("1. Buy a House for $" + p.PropertyPrice * 0.5);
                            Console.WriteLine("2. Buy a Hotel for $" + p.PropertyPrice);
                            Console.WriteLine("3. No purchase");
                            Console.WriteLine();
                            Console.Write("Your choice: ");
                            Console.WriteLine();
                            int choice = Convert.ToInt32(Console.ReadLine());

                            //decorators are used to add a house or hotel to the total price of the property
                            if(choice == 1) 
                            {
                                HouseDecorator house_decorator = new HouseDecorator(p);
                                house_decorator.SetTotalPrice();
                                Console.WriteLine("The total price of your property is now $" + p.TotalPrice.ToString());
                                this.money = this.money - p.PropertyPrice * 0.5;
                                Console.WriteLine("Your current balance is $" + this.money);
                            }
                            else if(choice == 2)
                            {
                                HotelDecorator hotel_decorator = new HotelDecorator(p);
                                hotel_decorator.SetTotalPrice();
                                Console.WriteLine("The total price of your property is now $" + p.TotalPrice.ToString());
                                this.money = this.money - p.PropertyPrice;
                                Console.WriteLine("Your current balance is $" + this.money);
                            }
                            else
                            {
                                Console.WriteLine("No extra purchase was made");
                            }
                        }
                        if(p.Owner != this) //property is owned by an opposing player
                        {
                            //tax is calculated and paid by current player/received by owner
                            Console.WriteLine("This property is owned by player " + p.Owner.Token);
                            double tax = p.TotalPrice * 0.1;
                            Console.WriteLine("You owe him a tax of $" + tax);
                            Console.WriteLine("Your current balance is $" + this.money);
                            this.money = this.money - tax;
                            Console.WriteLine("After tax your current balance is $" + this.money);
                            p.Owner.Money = p.Owner.Money + tax;
                        }                       
                    }
                }
            }
        }
    }
}

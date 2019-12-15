using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Program
    {
    
    static void mainText()
        {
            //Game welcome messages and explanations
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("WELCOME TO THE MONOPOLY GAME!");
            Console.WriteLine();
            Console.WriteLine("Empty boxes like this |  | are properties on sale and boxes with | ? | are mystery boxes.");
            Console.WriteLine("When a player buys a property, his lower case letter appears in the corresponding box like this |a  |.");
            Console.WriteLine();
            Console.WriteLine("How many players? (2 to 4)");
            int num_players = Convert.ToInt32(Console.ReadLine());
            string[] tokens = new string[] { "A", "B", "C", "D" };


            //creating the collection of all the players with their initial money
            PlayerCollection collection = new PlayerCollection();
            int initial_money = 2000;
            for (int i = 0; i < num_players; i++)
            {
                Console.WriteLine("Enter name of player " + (i+1));
                string name = Console.ReadLine();
                Console.WriteLine(name + " you will be player " + tokens[i]);
                Console.WriteLine();
                collection[i] = new Player(tokens[i], initial_money);
            }
            Console.WriteLine("Each player starts with $2000");

            //instantiating the gameboard
            GameBoard Monopoly = GameBoard.GetInstance;

            //initializing the list of properties with all of the corresponding names
            List<Property> properties = new List<Property>();
            properties.Add(new Property(1, "Mediterranean Avenue", 60));
            properties.Add(new Property(3, "Baltic Avenue", 60));
            properties.Add(new Property(5, "Reading Railroad", 200));
            properties.Add(new Property(6, "Oriental Avenue", 100));
            properties.Add(new Property(8, "Vermont Avenue", 100));
            properties.Add(new Property(9, "Connecticut Avenue", 120));
            properties.Add(new Property(11, "St Charles Place", 140));
            properties.Add(new Property(12, "Electric Company", 150));
            properties.Add(new Property(13, "States Avenue", 140));
            properties.Add(new Property(14, "Virginia Avenue", 160));
            properties.Add(new Property(15, "Pennsylvania Railroad",200));
            properties.Add(new Property(16, "St James Place", 180));
            properties.Add(new Property(18, "Tennesee Avenue", 180));
            properties.Add(new Property(19, "New York Avenue", 200));
            properties.Add(new Property(21, "Kentucky Avenue", 220));
            properties.Add(new Property(23, "Indiana Avenue", 220));
            properties.Add(new Property(24, "Illinois Avenue", 240));
            properties.Add(new Property(25, "B&O Railroad", 200));
            properties.Add(new Property(26, "Atlantic Avenue", 260));
            properties.Add(new Property(27, "Ventnor Avenue", 260));
            properties.Add(new Property(28, "Water Works", 150));
            properties.Add(new Property(29, "Marvin Gardens", 280));
            properties.Add(new Property(31, "Pacific Avenue", 300));
            properties.Add(new Property(32, "North Carolina Avenue", 300));
            properties.Add(new Property(34, "Pennsylvania Avenue", 320));
            properties.Add(new Property(35, "Short Line", 200));
            properties.Add(new Property(37, "Park Place", 350));
            properties.Add(new Property(39, "Boardwalk", 400));

            //displaying the gameboard
            Monopoly.DisplayBoard(collection,properties);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Player A starts");

            //initializing player iterator and random generator
            PlayerIterator iterator = collection.CreateIterator();
            Random generator = new Random();

            //the game runs on an infinite loop
            while (true)
            {
                //using the iterator, players play one after the other
                for (Player item = iterator.First(); !iterator.IsDone; item = iterator.Next())
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("It's Player " + item.Token + "'s turn:");
                    Console.WriteLine("Roll the dice");
                    Console.ReadKey();

                    int isdouble = 0;
                    if(item.Injail == false)
                    {
                        //player rolls the dice, moves and is asked if he wants to buy the
                        //corresponding property
                        isdouble = item.RollDiceAndMove(generator);
                        Console.WriteLine();
                        Monopoly.DisplayBoard(collection, properties);
                        item.BuyProperty(properties);
                        Console.ReadKey();

                        if(isdouble == 1)
                        {
                            //if the player rolled a double he plays once more
                            Console.WriteLine();
                            Console.WriteLine("Player " + item.Token + " rolled a double! Play again.");
                            Console.ReadKey();
                            isdouble = isdouble + item.RollDiceAndMove(generator);
                            Console.WriteLine();
                            Monopoly.DisplayBoard(collection, properties);
                            item.BuyProperty(properties);
                            Console.ReadKey();
                            if (isdouble == 2)
                            {
                                //same process if he rolls double again
                                Console.WriteLine();
                                Console.WriteLine("Player " + item.Token + " rolled a double once again! Play again.");
                                Console.ReadKey();
                                isdouble = isdouble + item.RollDiceAndMove(generator);
                                Console.WriteLine();
                                Monopoly.DisplayBoard(collection, properties);
                                item.BuyProperty(properties);
                                Console.ReadKey();
                                if (isdouble == 3)
                                {
                                    //after the third double he is sent to jail
                                    Console.WriteLine();
                                    Console.WriteLine("Player " + item.Token + " rolled a double for the 3rd time! Go to Jail!");
                                    item.GoToJail();
                                    Console.WriteLine();
                                    Monopoly.DisplayBoard(collection, properties);
                                }
                            }
                        }

                    }

                    if(item.Injail == true)
                    {
                        //if the player is in jail he rolls the dice but only gets out if he rolls a
                        //double or serves his sentence
                        Console.WriteLine("Roll a double in order to get out of jail!");
                        isdouble = item.RollDiceAndMove(generator);
                        Console.ReadKey();
                        Monopoly.DisplayBoard(collection, properties);
                        if(isdouble == 1)
                        {
                            Console.WriteLine("You rolled a double!");
                            item.LeaveJail();
                        }
                        else
                        {
                            item.TimeInJail();
                        }
                        
                    }
                    Console.WriteLine();

                }
            }
            

            
        }
        

    static void Main(string[] args)
        {
            mainText();
            Console.ReadKey();
            
        }
    }
}
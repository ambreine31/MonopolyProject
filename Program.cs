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
            Console.WriteLine("WELCOME TO THE MONOPOLY GAME!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("How many players? (2 to 4)");
            int num_players = Convert.ToInt32(Console.ReadLine());
            string[] tokens = new string[] { "A", "B", "C", "D" };

            PlayerCollection collection = new PlayerCollection();
            int initial_money = 100;
            for (int i = 0; i < num_players; i++)
            {
                Console.WriteLine("Enter name of player " + (i+1));
                string name = Console.ReadLine();
                Console.WriteLine(name + " you will be player " + tokens[i]);
                collection[i] = new Player(tokens[i], initial_money);
            }

            GameBoard Monopoly = GameBoard.GetInstance;

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



            // ADD ATTRIBUTES TO PROPERTY INTERFACE
            // REMOVE PROPERTIES FROM PLAYER AND ADD OWNER TO PROPERTY


            Monopoly.DisplayBoard(collection);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Player A starts");

            PlayerIterator iterator = collection.CreateIterator();
            int a = 0;
            Random generateur = new Random();

            while (a <8)
            {
                for (Player item = iterator.First(); !iterator.IsDone; item = iterator.Next())
                {
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine("It's Player " + item.Token + "'s turn:");
                    Console.WriteLine("Roll the dice");
                    Console.ReadKey();
                    item.RollDiceAndMove(generateur);
                    item.BuyProperty(properties);
                    Console.WriteLine();
                    Console.WriteLine();
                    Monopoly.DisplayBoard(collection);

                }
                a++;
            }
            

            
        }
        

    static void Main(string[] args)
        {


            
            IProperty prop = new Property(2,"madison ave", 1000);
            PropertyDecorator decorator = new HouseDecorator(prop);
            Console.WriteLine(decorator.PropertyPrice.ToString());
            Console.WriteLine(decorator.SetTotalPrice().ToString());
            Console.WriteLine("prop tot price" + prop.TotalPrice.ToString());
            Console.WriteLine(decorator.SetTotalPrice().ToString());
            Console.WriteLine(decorator.SetTotalPrice().ToString());
            PropertyDecorator decorator2 = new HotelDecorator(decorator);
            Console.WriteLine(decorator2.SetTotalPrice().ToString());


            /*
            PlayerCollection collection = new PlayerCollection();
            collection[0] = new Player("A", 2000);
            collection[1] = new Player("B", 3000);

            PlayerIterator iterator = collection.CreateIterator();
            Console.WriteLine("All the players:");

            for(Player item = iterator.First(); !iterator.IsDone; item = iterator.Next())
            {
                Console.WriteLine(item.Money);
            }
            */
            //mainText();
            Console.ReadKey();
            
        }
    }
}
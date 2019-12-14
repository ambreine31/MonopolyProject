using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public sealed class GameBoard
    {
        private static int counter = 0;
        private static GameBoard instance = null;
        

        public static GameBoard GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new GameBoard();
                return instance;
            }
        }
        private GameBoard()
        {
            counter++;
            //Console.WriteLine("Counter Value " + counter.ToString());
        }
        public void PrintDetails(string message)
        {
            Console.WriteLine(message);
        }

        public void DisplayBoard(PlayerCollection collection,List<Property>properties)
        {
            PlayerIterator iterator = collection.CreateIterator();
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("|");


            for (int i = 0; i < 40; i++)
            {

                for (Player item = iterator.First(); !iterator.IsDone; item = iterator.Next())
                {
                    if(item.Position == i)
                    {
                        Console.Write(item.Token);
                    }  
                }
                foreach(Property p in properties)
                {
                    if(p.Owner != null && p.Box_num == i)
                    {
                        Console.Write(p.Owner.Token.ToLower());
                    }
                }

                if (i == 0)
                {
                    Console.Write("START");
                }
                else if (i == 10)
                {
                    Console.Write("JAIL");
                }
                else if (i == 2 || i == 4|| i == 7 || i == 17 || i == 20 || i == 22 || i == 33 || i == 36 || i == 38)
                {
                    Console.Write(" ? ");
                }
                else if (i == 30)
                {
                    Console.Write("GO JAIL");
                }
                else
                {
                    Console.Write("    ");
                }
                Console.Write("|");
            }
            Console.Write("BACK TO START ->");
            Console.WriteLine();
            Console.WriteLine();
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //this is the iterator design pattern that allows us to cycle through all of the Players
    //contained in our player collection
    public class PlayerIterator:IPlayerIterator
    {
        private PlayerCollection players;
        private int current = 0;
        private int step = 1;

        public PlayerIterator(PlayerCollection playercollection)
        {
            this.players = playercollection;
        }

        public Player First()
        {
            current = 0;
            return players[current] as Player;
        }

        public Player Next()
        {
            current += step;
            if (!IsDone)
            {
                return players[current] as Player;
            }
            else
            {
                return null;
            }
        }

        public Player Current
        {
            get { return players[current] as Player; }
        }

        public bool IsDone
        {
            get { return current >= players.Count; }
        }

    }
}
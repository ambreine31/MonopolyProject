using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class PlayerCollection:IPlayerAggregate
    {
        private ArrayList playerlist = new ArrayList();

        public PlayerIterator CreateIterator()
        {
            return new PlayerIterator(this);
        }
        public int Count
        {
            get { return playerlist.Count; }
        }

        public object this[int index]
        {
            get { return playerlist[index]; }
            set { playerlist.Add(value); }
        }
    }
}
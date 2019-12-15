using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Aggregate interface used to create iterator object
    public interface IPlayerAggregate
    {
        PlayerIterator CreateIterator();
    }
}
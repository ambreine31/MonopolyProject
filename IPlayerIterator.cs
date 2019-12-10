using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface IPlayerIterator
    {
        Player First();
        Player Next();
        bool IsDone { get; }
        Player Current { get; }
    }
}
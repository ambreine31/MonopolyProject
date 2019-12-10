using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface IProperty
    {
        string Name { get; set; }
        double PropertyPrice { get; set; }
        double TotalPrice { get; set; }

    }
}
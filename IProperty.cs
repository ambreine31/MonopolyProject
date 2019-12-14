using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface IProperty
    {
        int Box_num { get; set; }
        string Name { get; set; }
        double PropertyPrice { get; set; }
        double TotalPrice { get; set; }
        Player Owner { get; set; }
    }
}
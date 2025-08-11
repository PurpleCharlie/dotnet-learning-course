using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Models;

public class Tank
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Volume { get; set; }
    public double MaxVolume { get; set; }

    /*          Foreign key         */
    public int UnitId { get; set; }
}

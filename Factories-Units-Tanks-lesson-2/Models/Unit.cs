using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Models;

public class Unit
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    /*          Foreign Key         */
    public int FactoryId { get; set; }
}

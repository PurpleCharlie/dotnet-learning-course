using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Models;

public class Unit : IEntity<UnitId>
{
    public UnitId Id { get; init; }
    public string Name { get; set; }
    public string? Description { get; set; }

    /*          Foreign Key         */
    public long FactoryId { get; set; }

    /*          Навигационное свойство          */
    public List<Tank>? Tanks { get; set; }
}

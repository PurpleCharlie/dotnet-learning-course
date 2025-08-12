using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Models;

public class Factory : IEntity<FactoryId>
{
    public FactoryId Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }

    /*          Навигационное свойство          */
    public List<Unit>? Units { get; init; }
}

using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Models;

public class Tank : IEntity<TankId>
{
    public TankId Id { get; init; }
    public string Name { get; init; }
    public string? Description { get; init; }
    private double? _volume;

    public double? Volume
    {
        get => _volume;
        init
        {
            if (value is < 0) 
                throw new ArgumentOutOfRangeException(nameof(value), "Не может быть ниже 0");

            _volume = value;
        }
    }

    private double? _maxVolume;
    public double? MaxVolume
    {
        get => _maxVolume;
        init
        {
            if (value is < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "Не может быть ниже 0");

            _maxVolume = value;
        }
    }

    /*          Foreign key         */
    public long UnitId { get; set; }
}

using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Models;

namespace Factories_Units_Tanks_lesson_2.Builders;

public class TankBuilder : ITankBuilderFluent
{
    private TankId _id;
    private string _name;
    private string _description;
    private double _volume;
    private double _maxVolume;
    private long _unitId;

    private TankBuilder(long unitId)
    {
        _unitId = unitId;
        _id = new TankId();
        _id.Next();
    }

    public static TankBuilder Create(long unitId) => new(unitId);

    public ITankBuilderFluent WithName(string name)
    {
        _name = name;

        return this;
    }

    public ITankBuilderFluent WithDescription(string description)
    {
        _description = description;

        return this;
    }

    public ITankBuilderFluent WithVolume(double volume)
    {
        _volume = volume;

        return this;
    }

    public ITankBuilderFluent WithMaxVolume(double maxVolume)
    {
        _maxVolume = maxVolume;

        return this;
    }

    public Tank Build()
    {
        return new Tank
        {
            Name = _name,
            Description = _description ?? "N/A",
            Volume = _volume,
            MaxVolume = _maxVolume,
            UnitId = _unitId
        };
    }
}

public interface ITankBuilderFluent
{
    ITankBuilderFluent WithName(string name);
    ITankBuilderFluent WithDescription(string description);
    ITankBuilderFluent WithVolume(double volume);
    ITankBuilderFluent WithMaxVolume(double maxVolume);
}
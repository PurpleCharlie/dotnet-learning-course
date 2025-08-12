using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Models;

namespace Factories_Units_Tanks_lesson_2.Builders;

public class UnitBuilder : IUnitBuilderFluent
{
    private UnitId _id;
    private string _name;
    private string _description;
    private long _factoryId;
    private List<TankBuilder> _tanksBuilders = new();

    private UnitBuilder(long factoryId) 
    {
        _factoryId = factoryId;
        _id = new UnitId();
        _id.Next();
    }

    public static UnitBuilder Create(long factoryId) => new(factoryId);

    public IUnitBuilderFluent WithName(string name)
    {
        _name = name;

        return this;
    }

    public IUnitBuilderFluent WithDescription(string description)
    {
        _description = description;

        return this;
    }

    public IUnitBuilderFluent AddTank(Action<ITankBuilderFluent> configure)
    {
        var tankBuilder = TankBuilder.Create(_id.GetId());
        configure(tankBuilder);
        _tanksBuilders.Add(tankBuilder);

        return this;
    }

    public Unit Build()
    {
        return new Unit
        {
            Name = _name,
            Description = _description ?? "N/A",
            FactoryId = _factoryId,
            Tanks = _tanksBuilders.Select(tb => tb.Build()).ToList(),
        };
    }
}

public interface IUnitBuilderFluent
{
    IUnitBuilderFluent WithName(string name);
    IUnitBuilderFluent WithDescription(string description);
    IUnitBuilderFluent AddTank(Action<ITankBuilderFluent> configure);
}
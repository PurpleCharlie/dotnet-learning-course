using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Builders;

public class FactoryBuilder
{
    private FactoryId _id;
    private string _name;
    private string _description;
    private List<UnitBuilder> _unitBuilders = new();

    private FactoryBuilder() 
    {
        _id = new FactoryId();
        _id.Next();
    }

    public static FactoryBuilder Create() => new();

    public FactoryBuilder WithName(string name)
    {
        _name = name;

        return this;
    }

    public FactoryBuilder WithDescription(string description)
    {
        _description = description;

        return this;
    }
    
    public FactoryBuilder AddUnit(Action<IUnitBuilderFluent> configure)
    {
        var unitBuilder = UnitBuilder.Create(_id.GetId());
        configure(unitBuilder);
        _unitBuilders.Add(unitBuilder);

        return this;
    }

    public Factory Build()
    {
        return new Factory
        {
            Name = _name,
            Description = _description ?? "N/A",
            Units = _unitBuilders.Select(u => u.Build()).ToList()
        };
    }
}

using Factories_Units_Tanks_lesson_2.Builders;
using Factories_Units_Tanks_lesson_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Seeder;

public static class DataSeeder
{
    public static IEnumerable<Factory> GenerateEntities(int factoryCount, int unitPerFactoryCount, int tanksPerUnitCount)
    {
        var random = new Random();
        

        for (int i = 0; i <  factoryCount; i++)
        {
            var randNumFactory = random.Next(10, 100);
            var factoryBuilder = FactoryBuilder.Create()
                                        .WithName($"Фабрика-{randNumFactory:000}")
                                        .WithDescription($"Описание для фабрики {i}");
            for (int j = 0; j < unitPerFactoryCount; j++)
            {
                var randNumUnit = random.Next(100, 1000);
                factoryBuilder.AddUnit(unitBuilder =>
                {
                    unitBuilder
                    .WithName($"Установка-{randNumFactory:000}-{randNumUnit:000}")
                    .WithDescription($"Описание для установки {i + j}");

                    for (int k = 0; k < tanksPerUnitCount; k++)
                    {
                        var randNumTank = random.Next(500, 2000);
                        unitBuilder.AddTank(tankBuilder =>
                            tankBuilder
                            .WithName($"Резервуар-{randNumFactory:000}-{randNumUnit:000}-{randNumTank:000}")
                            .WithDescription($"Описание для резервуара {i + j + k}")
                            .WithVolume(random.Next(10, 1000))
                            .WithMaxVolume(random.Next(1000, 5000)));
                    }
                });
            }

            yield return factoryBuilder.Build();
        }
    }
}

using Factories_Units_Tanks_lesson_2.Builders;
using Factories_Units_Tanks_lesson_2.Seeder;

/*var factoryBuilder = FactoryBuilder.Create();

var factory = factoryBuilder
    .WithName("Фабрика_1")
    .WithDescription("Описание фабрики")
    .AddUnit(
        ub => ub
        .WithName("Установка_1")
        .WithDescription("Описание установки")
        .AddTank(
            tb => tb
            .WithName("Резервуар_1")
            .WithDescription("Описание резервуара")
            .WithVolume(1300.5)
            .WithMaxVolume(4500.9))
        .AddTank(tb => tb
            .WithName("Резервуар_2")
            .WithDescription("Описание второго резервуара")
            .WithVolume(1000.5)
            .WithMaxVolume(5500.9)))
    .Build();

var tanksName = factory.Units
    .SelectMany(u => u.Tanks) 
    .Select(t => t.Name)        
    .ToList();                  

foreach (var tank in tanksName)
{
    Console.WriteLine($"Название резеруара: {tank}");
}

*/

foreach (var factory in DataSeeder.GenerateEntities(5, 3, 3))
{
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
    Console.WriteLine($"{factory.Name} - содержит установки: \n{string.Join(", ", factory.Units.Select(u => u.Name))}\n" +
        $"\nА также резервуары: {string.Join(", ", factory.Units.SelectMany(u => u.Tanks).Select(t => t.Name)) + "\n"}");
    Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
}

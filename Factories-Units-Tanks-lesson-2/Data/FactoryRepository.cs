using Factories_Units_Tanks_lesson_2.Interfaces;
using Factories_Units_Tanks_lesson_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Data;

public class FactoryRepository : IRepository<Factory, int>
{
    public FactoryRepository()
    {
        
    }

    public void Add(Factory item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Factory item)
    {
        throw new NotImplementedException();
    }

    public Factory GetById(int id)
    {
        throw new NotImplementedException();
    }

    public void Update(Factory item)
    {
        throw new NotImplementedException();
    }
}

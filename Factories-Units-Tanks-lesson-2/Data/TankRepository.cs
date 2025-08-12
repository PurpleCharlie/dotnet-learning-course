using Factories_Units_Tanks_lesson_2.Configure;
using Factories_Units_Tanks_lesson_2.Interfaces;
using Factories_Units_Tanks_lesson_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Data;

public class TankRepository : IRepository<Tank, TankId>
{
    public void Add(Tank item)
    {
        throw new NotImplementedException();
    }

    public void Delete(Tank item)
    {
        throw new NotImplementedException();
    }

    public Tank GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Tank GetById(TankId id)
    {
        throw new NotImplementedException();
    }

    public void Update(Tank item)
    {
        throw new NotImplementedException();
    }
}

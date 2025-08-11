using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Interfaces;

public interface IRepository<T, TKey> where T : IEntity<TKey>
{
    void Add(T item);
    void Update(T item);
    void Delete(T item);
    T GetById(TKey id);
}

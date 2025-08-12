using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factories_Units_Tanks_lesson_2.Configure;

public class UnitId
{
    private static long _id;

    static UnitId()
    {
        _id = 0;
    }

    public long Next() => ++_id;
    public long GetId() => _id;
}

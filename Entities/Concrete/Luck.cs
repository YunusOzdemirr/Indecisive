using System;
using Shared.Entities.Abstract;

namespace Entities.Concrete
{
    public class Luck
    {
        public object LuckyObject { get; set; }
        public IEnumerable<Object> LuckyList { get; set; }
    }
}


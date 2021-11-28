using System;
namespace Shared.Utilities.Validation
{
    public class DateConflictValidator
    {
      public static bool CheckDateConflict(DateTime start, DateTime end,DateTime query)
        {
            if (query.Ticks>start.Ticks&& query.Ticks<end.Ticks)
            {
                return true;
            }
            return false;
        }
    }
}


using System.Collections.Generic;
using System.Linq;

public class Sorter
{
    public static IList<T> Sort<T>(IList<T> customList)
    {
        return customList.OrderBy(item => item).ToList();
    }
}
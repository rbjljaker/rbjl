using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistinctTuplesComparer
/// </summary>
public class DistinctTuplesComparer<T1, T2> : EqualityComparer<Tuple<T1, T2>>
{
    public override bool Equals(Tuple<T1, T2> t1, Tuple<T1, T2> t2)
   {
       //Check whether the compared objects reference the same data.
       if (Object.ReferenceEquals(t1.Item1, t2.Item1)) return true;

       //Check whether any of the compared objects is null.
       if (Object.ReferenceEquals(t1.Item1, null) || Object.ReferenceEquals(t2.Item1, null))
           return false;

       //Check whether the products' properties are equal.
       //return x.id == y.id && x.value == y.value;
       return t1.Item1.Equals(t2.Item1) && t1.Item2.Equals(t2.Item2);
   }

    public override int GetHashCode(Tuple<T1, T2> t)
    {
        return base.GetHashCode();
    }
}

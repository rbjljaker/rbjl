using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistinctDDLValue
/// </summary>
public class DistinctDDLValue : IEqualityComparer<DDLValueDto>
{
    // Products are equal if their names and product numbers are equal.
    public bool Equals(DDLValueDto x, DDLValueDto y)
    {

        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the products' properties are equal.
        return x.id == y.id && x.value == y.value;
    }

    // If Equals() returns true for a pair of objects 
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(DDLValueDto ddl)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(ddl, null)) return 0;

        //Get hash code for the Name field if it is not null.
        int hashProductName = ddl.id == null ? 0 : ddl.id.GetHashCode();

        //Get hash code for the Code field.
        int hashProductCode = ddl.value == null ? 0 : ddl.value.GetHashCode();

        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }

}
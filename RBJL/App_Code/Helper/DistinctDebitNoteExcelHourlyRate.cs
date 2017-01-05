using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DistinctDebitNoteExcelHourlyRate
/// </summary>
public class DistinctDebitNoteExcelHourlyRate : IEqualityComparer<DebitNoteExcelHourlyRateDto>
{
    // Products are equal if their names and product numbers are equal.
    public bool Equals(DebitNoteExcelHourlyRateDto x, DebitNoteExcelHourlyRateDto y)
    {

        //Check whether the compared objects reference the same data.
        if (Object.ReferenceEquals(x, y)) return true;

        //Check whether any of the compared objects is null.
        if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
            return false;

        //Check whether the products' properties are equal.
        return x.year == y.year && x.hourlyRate == y.hourlyRate;
    }

    // If Equals() returns true for a pair of objects 
    // then GetHashCode() must return the same value for these objects.

    public int GetHashCode(DebitNoteExcelHourlyRateDto ddl)
    {
        //Check whether the object is null
        if (Object.ReferenceEquals(ddl, null)) return 0;

        //Get hash code for the Name field if it is not null.
        int hashProductName = ddl.year == null ? 0 : ddl.year.GetHashCode();

        //Get hash code for the Code field.
        int hashProductCode = ddl.hourlyRate == null ? 0 : ddl.hourlyRate.GetHashCode();

        //Calculate the hash code for the product.
        return hashProductName ^ hashProductCode;
    }
}
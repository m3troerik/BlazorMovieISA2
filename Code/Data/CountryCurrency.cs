using Abc.Data.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Abc.Data
{
    public class CountryCurrency : DetailedEntity
    {
        public int? CountryId { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}

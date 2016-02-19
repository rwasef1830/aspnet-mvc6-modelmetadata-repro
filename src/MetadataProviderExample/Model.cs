using System;
using System.ComponentModel.DataAnnotations;

namespace MetadataProviderExample
{
    public class Model
    {
        public DateTime DateTimeProperty { get; set; } 
        public DateTime? DateTimeNullableProperty { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateProperty { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateNullableProperty { get; set; }
    }
}
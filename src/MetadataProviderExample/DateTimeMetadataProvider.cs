using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNet.Mvc.ModelBinding.Metadata;

namespace MetadataProviderExample
{
    class DateTimeMetadataProvider : IDisplayMetadataProvider
    {
        static readonly IReadOnlyDictionary<string, string> s_EditFormatStringsByDataTypeName =
            new ReadOnlyDictionary<string, string>(
                new Dictionary<string, string>
                {
                    [nameof(DataType.Date)] = CultureTable.DateFormat,
                    [nameof(DataType.Time)] = CultureTable.TimeFormat,
                    [nameof(DataType.DateTime)] = CultureTable.DateTimeFormat,
                    [nameof(DateTimeOffset)] = CultureTable.DateTimeFormat
                });

        public void GetDisplayMetadata(DisplayMetadataProviderContext context)
        {
            var key = context.DisplayMetadata.DataTypeName
                      ?? context.Attributes.OfType<DataTypeAttribute>().FirstOrDefault()?.GetDataTypeName()
                      ?? (Nullable.GetUnderlyingType(context.Key.ModelType) ?? context.Key.ModelType).Name;

            string formatString;
            if (s_EditFormatStringsByDataTypeName.TryGetValue(key, out formatString))
            {
                context.DisplayMetadata.EditFormatString = formatString;
                context.DisplayMetadata.DisplayFormatString = formatString;
            }
        }
    }
}
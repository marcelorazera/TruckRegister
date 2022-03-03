using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckRegister.Domain.Helper
{
    public static class EnumHelper
    {
        public class EnumDescription
        {
            public Int32 Value { get; set; }
            public String Name { get; set; }
            public String Description { get; set; }
            public Enum EnumValue { get; set; }
        }

        public static string DisplayName(this Enum value)
        {
            var enumType = value.GetType();
            var enumValue = Enum.GetName(enumType, value);
            var member = enumType.GetMember(enumValue)[0];

            try
            {
                var attrs = member.GetCustomAttributes(typeof(DisplayAttribute), false);

                var outString = ((DisplayAttribute)attrs[0]).Name;

                if (((DisplayAttribute)attrs[0]).ResourceType != null)
                    outString = ((DisplayAttribute)attrs[0]).GetName();

                return outString;
            }
            catch (Exception)
            {
                return enumValue;

            }

        }

        public static IEnumerable<EnumDescription> ToList<T>()
        {
            return from Enum e in Enum.GetValues(typeof(T))
                   select new EnumDescription
                   {
                       EnumValue = e,
                       Description = e.ToDescription(),
                       Value = Convert.ToInt32(e),
                       Name = e.ToString()
                   };
        }

        public static IEnumerable<EnumDescription> ToList(Type type)
        {
            return from Enum e in Enum.GetValues(type)
                   select new EnumDescription
                   {
                       EnumValue = e,
                       Description = e.ToDescription(),
                       Value = Convert.ToInt32(e),
                       Name = e.ToString(),
                   };
        }

        public static object Value(Type type, string value)
        {
            return Enum.Parse(type, value, true);
        }

        public static string ToDescription(this Enum value)
        {
            var attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}

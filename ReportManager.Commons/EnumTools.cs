using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ReportManager.Commons
{
    public class EnumTools
    {
        public static string GetDescription(Enum en)
        {
            Type type = en.GetType();
            MemberInfo[] memInfo = type.GetMember(en.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return en.ToString();
        }

        public static List<EnumModel> GetEnumList<T>()
        {
            var ret = new List<EnumModel>();

            foreach (Enum element in Enum.GetValues(typeof(T)))
            {
                ret.Add(new EnumModel() { Id = Convert.ToInt32(element), Value = GetDescription(element) });
            }

            return ret;
        }
    }

    public class EnumModel
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}

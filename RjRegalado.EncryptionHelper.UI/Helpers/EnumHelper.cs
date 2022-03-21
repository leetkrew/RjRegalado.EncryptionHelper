using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace RjRegalado.EncryptionHelper.UI.Helpers
{

    public interface IEnumHelper
    {
        
        
    }

    public class EnumHelper : IEnumHelper
    {

        public enum OperationMethods
        {
            [Description("Certificate (encrypt)")] EncryptByCertificate = 1,
            [Description("Certificate (decrypt)")] DecryptByCertificate = 2,
        }

        public enum ListAll
        {
            All = 0
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            return attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }

        public static string GetEnumKey(Enum code)
        {
            return Enum.GetName(code.GetType(), code)?.Replace("_", " ");
        }

        public static string GetEnumKeyByValue<T>(int value)
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException();
            }

            try
            {
                var result = ToList<T>().First(x => x.Id == value).Name;

                return string.IsNullOrEmpty(result) ? "(Undefined)" : result;
            }
            catch
            {
                return "(Undefined)";
            }
        }

        public static List<EnumHelper> ToList<T>()
        {
            if (!typeof(T).IsEnum)
            {
                throw new InvalidOperationException();
            }

            var keysArray = new string[Enum.GetValues(typeof(T)).Length];
            var valuesArray = new int[Enum.GetValues(typeof(T)).Length];
            var keysDescriptionArray = new string[Enum.GetValues(typeof(T)).Length];

            //get the values
            var cnt = 0;
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                valuesArray[cnt] = (int)item;
                cnt++;
            }

            //get the description
            cnt = 0;
            foreach (var item in Enum.GetValues(typeof(T)))
            {
                var fi = item.GetType().GetField(item.ToString());
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var desc = attributes.Length > 0 ? attributes[0].Description : item.ToString();
                keysDescriptionArray[cnt] = desc;
                cnt++;
            }

            //get the name
            cnt = 0;
            foreach (var item in Enum.GetNames(typeof(T)))
            {
                keysArray[cnt] = item;
                cnt++;
            }

            var result = new List<EnumHelper>();
            
            for (var i = 0; i <= keysArray.Length - 1; i++)
            {
                result.Add(new EnumHelper()
                {
                    Description = keysDescriptionArray[i],
                    Name = keysArray[i],
                    Id = valuesArray[i]
                });
            }

            return result;
        }
    }
}

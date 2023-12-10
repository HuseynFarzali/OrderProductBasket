using System;
using System.ComponentModel.DataAnnotations;

namespace DefaultWebApplication.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RGBCodeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string rgbCode;
            try
            {
                rgbCode = (string)value;
                if (rgbCode is null)
                    return false;
            }
            catch(Exception)
            {
                return false;
            }

            if (!rgbCode.StartsWith('#') || rgbCode.Length != 7)
                return false;

            int rgbNumberCode;

            try
            {
                rgbNumberCode = Convert.ToInt32(rgbCode[1..]);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessage, name, "#123456");
        }
    }
}

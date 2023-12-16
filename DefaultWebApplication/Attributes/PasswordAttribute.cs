using System;
using System.ComponentModel.DataAnnotations;

namespace DefaultWebApplication.Attributes
{
    public class PasswordAttribute : ValidationAttribute
    {
        public int RequiredLength { get; set; } = 8;
        public bool CapitalLetterRequired { get; set; } = true;

        public override bool IsValid(object value)
        {
            string password;

            try
            {
                password = (string)value;
            }
            catch(Exception)
            {
                return false;
            }

            if (password.Length < RequiredLength)
                return false;

            if (CapitalLetterRequired)
            {
                for (int i = 0; i < RequiredLength; i++)
                {
                    if (password[i] == ' ')
                        return false;
                    if (password[i] >= 65 && password[i] <= 90)
                        return true;
                }

                return false;
            }

            return true;
        }

        public override string FormatErrorMessage(string name = "name")
        {
            return base.FormatErrorMessage(name);
        }
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmployeeManagement.Helpers
{
    public static class CommonHelper
    {
        public static bool IsValidInt(string input)
        {
            return Int32.TryParse(input, out int result);
        }

        public static bool IsNotEmptyText(string inputText)
        {
            return !string.IsNullOrEmpty(inputText);
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(email, pattern);
        }
        public static bool IsValueSelected(ComboBox comboBox)
        {
            return comboBox.SelectedIndex >= 0;
        }

        public static bool IsOneOf(this string inputText, params string[] values) 
        {
            foreach(string value in values) 
            {
                if(!inputText.Equals(value, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

    }
}

using System.Text.RegularExpressions;

namespace Group_14.CommonLayer.Utilities
{
    public static class Validator
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidId(int id)
        {
            return id > 0;
        }
    }
}

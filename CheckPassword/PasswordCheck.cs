using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CheckPassword
{
    public class PasswordCheck
    {
        private static List<string> commonPasswords = new List<string>()
    {
        "Qwertyui1", "Password0",
        "AdminAdmin1", "Welcome1",
        "Iloveyou1", "1Q2w3e4r",
        "Whatever1", "Password1",
        "1Qaz2wsx3edc"
    };

        private static bool CheckMinimumLength(string password)
        {
            return password.Length >= 8;
        }

        private static bool ContainsDigit(string password)
        {
            return password.Any(char.IsDigit);
        }

        private static bool ContainsUppercaseLetter(string password)
        {
            return password.Any(char.IsUpper);
        }

        private static bool ContainsLowercaseLetter(string password)
        {
            return password.Any(char.IsLower);
        }

        private static bool IsCommonPassword(string password)
        {
            return commonPasswords.Contains(password);
        }

        private static bool HasRepeatingCharacters(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] && password[i] == password[i + 2])
                {
                    return true;
                }
            }
            return false;
        }

        private static bool HasSequentialCharacters(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if ((password[i + 1] == password[i] + 1) && (password[i + 2] == password[i] + 2))
                {
                    return true;
                }

                if ((password[i + 1] == password[i] - 1) && (password[i + 2] == password[i] - 2))
                {
                    return true;
                }
            }
            return false;
        }


        public static bool ValidatePassword(string password)
        {
            if (!CheckMinimumLength(password))
            {
                MessageBox.Show("Password must be at least 8 characters long.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!ContainsDigit(password))
            {
                MessageBox.Show("Password must contain at least one digit.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!ContainsUppercaseLetter(password))
            {
                MessageBox.Show("Password must contain at least one uppercase letter.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!ContainsLowercaseLetter(password))
            {
                MessageBox.Show("Password must contain at least one lowercase letter.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (IsCommonPassword(password))
            {
                MessageBox.Show("Password is too common. Please choose a more secure password.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (HasRepeatingCharacters(password))
            {
                MessageBox.Show("Password contains repeating characters. Avoid repeating the same character more than 3 times in a row.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (HasSequentialCharacters(password))
            {
                MessageBox.Show("Password contains sequential characters. Avoid sequences like 'abc' or '123'.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (password.Contains(" "))
            {
                MessageBox.Show("Password should not contain spaces.", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

    }


}

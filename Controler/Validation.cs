using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bookshop_Management_System.Controler
{
    internal class Validation
    {
        public static Boolean IsValidEmail(string email)
            {
                if (string.IsNullOrWhiteSpace(email)) return false;
                // Simple regex for email validation
                try
                {
                    return Regex.IsMatch(email,
                        @"^[^\s@]+@[^\s@]+\.[^\s@]+$",
                        RegexOptions.IgnoreCase);
                }
                catch
                {
                    return false;
                }
            }

            public static Boolean IsValidContact(string contact)
            {
                if (string.IsNullOrWhiteSpace(contact)) return false;
                // Accept digits only and require starting with 07 and total 10 digits
                return Regex.IsMatch(contact, "^07\\d{8}$");
            }
            public static Boolean IsValidIsbn(string isbn)
            {
                if (string.IsNullOrWhiteSpace(isbn)) return false;

                // Keep digits and possible 'X' for ISBN-10
                var cleaned = new string(isbn.Where(c => char.IsDigit(c) || c == 'X' || c == 'x').ToArray());

                // ISBN-10 validation
                if (cleaned.Length == 10)
                {
                    // first 9 must be digits
                    for (int i = 0; i < 9; i++)
                        if (!char.IsDigit(cleaned[i])) return false;

                    int sum = 0;
                    for (int i = 0; i < 10; i++)
                    {
                        int val;
                        if (i == 9 && (cleaned[i] == 'X' || cleaned[i] == 'x'))
                            val = 10;
                        else if (char.IsDigit(cleaned[i]))
                            val = cleaned[i] - '0';
                        else
                            return false;

                        // weights 10 down to 1
                        sum += (10 - i) * val;
                    }

                    return sum % 11 == 0;
                }

                // ISBN-13 validation
                if (cleaned.Length == 13 && cleaned.All(char.IsDigit))
                {
                    int sum = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        int d = cleaned[i] - '0';
                        sum += (i % 2 == 0) ? d : d * 3;
                    }

                    int check = (10 - (sum % 10)) % 10;
                    return check == (cleaned[12] - '0');
                }

                return false;
            }

            public static bool IsValidPublisherId(string pubId)
            {
                if (string.IsNullOrWhiteSpace(pubId)) return false;
                return Regex.IsMatch(pubId.Trim(), "^[pP]\\d{3}$");
            }

            public static bool IsValidAuthorId(string authId)
            {
                if (string.IsNullOrWhiteSpace(authId)) return false;
                return Regex.IsMatch(authId.Trim(), "^[aA]\\d{3}$");
            }

            public static bool IsValidStaffId(string staffId)
            {
                if (string.IsNullOrWhiteSpace(staffId)) return false;
                return Regex.IsMatch(staffId.Trim(), "^[uU]\\d{3}$");
            }
        }
    }




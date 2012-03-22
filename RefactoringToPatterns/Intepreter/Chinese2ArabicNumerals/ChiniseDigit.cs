using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinese2ArabicNumerals
{
    public class ChiniseDigit
    {
        private static readonly Dictionary<string, string> mapping = new Dictionary<string, string>()
                                                                         {
                                                                             {"��", "0"},
                                                                             {"һ", "1"},
                                                                             {"��", "2"},
                                                                             {"��", "3"},
                                                                             {"��", "4"},
                                                                             {"��", "5"},
                                                                             {"��", "6"},
                                                                             {"��", "7"},
                                                                             {"��", "8"},
                                                                             {"��", "9"},
                                                                             {"ʮ", "10"},
                                                                         };

        private readonly string Origin;

        public ChiniseDigit(string s)
        {
            Origin = s;
        }

        public string Transform()
        {
            var stringBuilder = new StringBuilder();
            var reverse = Origin.Reverse();
            foreach (var digit in reverse)
            {
                if (digit.ToString() == "ʮ")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping["ʮ"] : mapping["һ"]);
                }
                else
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Insert(0, mapping[digit.ToString()]);
                    }
                    else
                    {
                        stringBuilder.Remove(0, 1);
                        stringBuilder.Insert(0, mapping[digit.ToString()]);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
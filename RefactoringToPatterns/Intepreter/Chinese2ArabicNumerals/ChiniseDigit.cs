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
                                                                             {"��", "100"},
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
                var key = digit.ToString();

                if (key == "��")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping.Get(key) : mapping["һ"]);
                }
                else if (key == "ʮ")
                {
                    stringBuilder.Insert(0, stringBuilder.Length == 0 ? mapping[key] : mapping["һ"]);
                }
                else if (key == "��")
                {
                    stringBuilder.Insert(0, mapping.Get(key));
                }
                else
                {
                    if (stringBuilder.Length == 0)
                    {
                        stringBuilder.Insert(0, mapping.Get(key));
                    }
                    else
                    {
                        stringBuilder.Remove(0, 1);
                        stringBuilder.Insert(0, mapping.Get(key));
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
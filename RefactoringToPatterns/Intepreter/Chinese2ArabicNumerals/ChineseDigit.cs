using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinese2ArabicNumerals
{
    public class ChineseDigit
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
                                                                             {"ǧ", "1000"},
                                                                             {"��", "10000"},
                                                                         };

        private readonly string Origin;

        public ChineseDigit(string s)
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

                if (stringBuilder.Length == 0)
                {
                    stringBuilder.Append(mapping.Get(key));
                    continue;
                }

                if (key == "��")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["һ"]);
                    continue;
                }
                if (key == "ǧ")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["һ"]);
                    continue;
                }
                if (key == "��")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["һ"]);
                    continue;
                }
                if (key == "ʮ")
                {
                    AddZero(key, stringBuilder);
                    stringBuilder.Insert(0, mapping["һ"]);
                    continue;
                }
                if (key == "��")
                {
                    continue;
                }
                stringBuilder.Remove(0, 1);
                stringBuilder.Insert(0, mapping.Get(key));
            }

            return stringBuilder.ToString();
        }

        private static void AddZero(string key, StringBuilder stringBuilder)
        {
            var diffLen = mapping.Get(key).Length - stringBuilder.Length;
            for (var i = 0; i < diffLen - 1; i++)
            {
                stringBuilder.Insert(0, mapping.Get("��"));
            }
        }
    }
}
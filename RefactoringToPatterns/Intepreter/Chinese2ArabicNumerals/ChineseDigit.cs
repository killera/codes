using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chinese2ArabicNumerals
{
    public class ChineseDigit
    {
        private static readonly Dictionary<string, string> mapping = new Dictionary<string, string>
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
        private bool IsTenLeading;
        private bool TouchedWan;

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
                IsTenLeading = key == "ʮ";

                var zeroCount = GetZeroCount(stringBuilder, key);

                switch (key)
                {
                    case "��":
                        TouchedWan = true;
                        stringBuilder.Insert(0, mapping.Get("��"), zeroCount);
                        break;
                    case "ǧ":
                        stringBuilder.Insert(0, mapping.Get("��"), zeroCount);
                        break;
                    case "��":
                        stringBuilder.Insert(0, mapping.Get("��"), zeroCount);
                        break;
                    case "ʮ":
                        stringBuilder.Insert(0, mapping.Get("��"), zeroCount);
                        break;
                    default:
                        stringBuilder.Insert(0, mapping.Get(key));
                        break;
                }
            }

            if (IsTenLeading)
            {
                stringBuilder.Insert(0, 1);
            }
            return stringBuilder.ToString();
        }

        private int GetZeroCount(StringBuilder stringBuilder, string key)
        {
            var currentDigit = mapping.Get(key).Length + (TouchedWan? 4: 0);
            var prevDigit = stringBuilder.Length;
            return currentDigit - prevDigit - 1;
        }
    }
}
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

                var diffLen = mapping.Get(key).Length - stringBuilder.Length;
                var zeroCount = diffLen - 1;
                switch (key)
                {
                    case "��":
                        UnshiftZero(stringBuilder, zeroCount);
                        break;
                    case "ǧ":
                        UnshiftZero(stringBuilder, zeroCount);
                        break;
                    case "��":
                        UnshiftZero(stringBuilder, zeroCount);
                        break;
                    case "ʮ":
                        UnshiftZero(stringBuilder, zeroCount);
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

        private static void UnshiftZero(StringBuilder stringBuilder, int zeroCount)
        {
            stringBuilder.Insert(0, mapping.Get("��"), zeroCount);
        }
    }


}
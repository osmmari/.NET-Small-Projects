using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Profiling
{
    class Generator
    {
        public static string GenerateDeclarations()
        {
            string result = "";
            foreach (var index in Constants.FieldCounts)
            {
                result += "\nstruct S" + index + "\n{\n";
                for (int i = 0; i < index; i++)
                {
                    result += "byte Value" + i + "; ";
                }
                result += "\n}\n";

                result += "\nclass C" + index + "\n{\n";
                for (int i = 0; i < index; i++)
                {
                    result += "byte Value" + i + "; ";
                }
                result += "\n}\n";
            }
            return result;
        }

        public static string GenerateArrayRunner()
        {
            string result = "";
            result += "public class ArrayRunner : IRunner\n{\n";

            foreach (var index in Constants.FieldCounts)
            {
                for (int i = 0; i < index; i++)
                {
                    result += "void PC" + i + "()\n{\n" +
                        "var array = new C" + i + "[Constants.ArraySize];\n" +
                        "for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C" +
                        i + "();\n}\n" +
                        "void PS" + i + "()\n{\nvar array = new S" +
                        i + "[Constants.ArraySize];\n}\n";
                }

                result += "\npublic void Call(bool isClass, int size, int count)\n{\n";
                for (int i = 0; i < index; i++)
                {
                    string helpString1 = "PC" + i;
                    string helpString2 = "PS" + i;
                    result += Helper1(helpString1) + Helper1(helpString2);
                }
                result += "\nthrow new ArgumentException();\n}";
            }

            result += "\n}";
            return result;
        }

        public static string GenerateCallRunner()
        {
            throw new NotImplementedException();
        }

        private static string Helper1(string word)
        {
            return "if (isClass && size == 1)\n{\n" +
                "for (int i = 0; i < count; i++) " + word + "();\n" +
                "return;\n}\n";
        }
    }
}

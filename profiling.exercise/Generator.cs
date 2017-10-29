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
                result += "void PC" + index + "()\n{\n" +
                    "var array = new C" + index + "[Constants.ArraySize];\n" +
                    "for (int i = 0; i < Constants.ArraySize; i++) array[i] = new C" +
                    index + "();\n}\n" +
                    "void PS" + index + "()\n{\nvar array = new S" +
                    index + "[Constants.ArraySize];\n}\n";
            }

            result += "\npublic void Call(bool isClass, int size, int count)\n{\n";
            foreach (var index in Constants.FieldCounts)
            {
                result += HelperPC(index) + HelperPS(index);
            }
            result += "\nthrow new ArgumentException();\n}";
            result += "\n}";
            return result;
        }

        public static string GenerateCallRunner()
        {
            throw new NotImplementedException();
        }

        private static string HelperPC(int number)
        {
            return "if (isClass && size == " + number + ")\n{\n" +
                "for (int i = 0; i < count; i++) PC" + number + "();\n" +
                "return;\n}\n";
        }

        private static string HelperPS(int number)
        {
            return "if (!isClass && size == " + number + ")\n{\n" +
                "for (int i = 0; i < count; i++) PS" + number + "();\n" +
                "return;\n}\n";
        }
    }
}

using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace lab3
{
    public class Program
    {
        static void Main()
        {
            string path = "C:\\Users\\yr\\Desktop\\ООП\\OOP-L3\\OOP-L3\\MyLib\\bin\\Debug\\net6.0\\MyLib.dll";

            void AddDll()
            {
                if (File.Exists(path))
                {
                    Assembly asm = Assembly.LoadFrom(path);
                    Type t = asm.GetType("MyLib.Student");
                    if (t is not null)
                    {
                        ConstructorInfo[] constructorInfo = t.GetConstructors();
                        object obj = constructorInfo[0].Invoke(new object[] { "c", 3, "cc", "ccc" });
                        MethodInfo print = t.GetMethod("PrintInfo", BindingFlags.Instance | BindingFlags.Public);
                        object result = print.Invoke(obj, new object[] { });
                    }
                }
            }

            Person Person1 = new Person("a", 1, "aa");
            Person1.PrintInfo();
            AddDll();
        }
    }
}

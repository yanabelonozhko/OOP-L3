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
            var hashes = new Dictionary<string, string>()
            {
                { "MyLib", "E2F73CECBA6998E927459C4B0531C5FFC6373F482E9F81FFDA1D17D3EF24D76B"},
                { "Example", "EXAMPLE_STRING_E2CBA699AWDAW73981273C5FFC6373F482E9D3EF24D76B"},
            };

            Person Person1 = new Person("a", 1, "aa");
            Person1.PrintInfo();

            Console.WriteLine("Введите название dll которую хотите подключить");
            string NameOfDll = Console.ReadLine();
            string path = NameOfDll + ".dll";
            if (File.Exists(path))
            {
                if (hashes.ContainsKey(NameOfDll)) {
                    string hash_vrft = hashes[NameOfDll];
                    string hash_temp = GetHash(path);
                    if (hash_temp == hash_vrft)
                    {
                        AddDll(path);
                    }
                    else
                    {
                        Console.WriteLine("Подключаемый файл не соответвует контрольной сумме");
                    }
                }
                else
                {
                    Console.WriteLine("Такого файла нет в списке разрешённых");
                }
            }
            else { 
                Console.WriteLine("такого файла нету вообще"); 
            }

            void AddDll(string path_to_file)
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
            string GetHash(string file)
            {
                using (FileStream stream = File.OpenRead(file))
                {
                    var sha = new SHA256Managed();
                    byte[] hash = sha.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", String.Empty);
                }
            }

        }
    }
}

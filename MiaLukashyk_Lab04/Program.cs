using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MiaLukashyk_Lab04
{
    internal class Program
    {
        public interface IDeveloper
        {
            int Experience { get; set; }
            string Tool { get; set; }
            void Destroy();
            void Create();
        }
        public class Programmer : IDeveloper, IComparable<IDeveloper>
        {
            public Programmer(string tool = "hands", int experience = 0)
            {
                Tool = tool;
                Experience = experience;
            }

            public string Tool { get; set; }
            public int Experience { get; set; }
            public void Create()
            {
                Console.WriteLine("Programmer.Create()");
            }

            public void Destroy()
            {
                Console.WriteLine("Programmer.Destroy()");
            }

            int IComparable<IDeveloper>.CompareTo(IDeveloper other)
            {
                return this.Experience.CompareTo(other.Experience);
            }

            public override string ToString()
            {
                return "Developer: " + Tool + " " + Experience;
            }
        }
        public class Builder : IDeveloper, IComparable<IDeveloper>
        {
            public Builder(string tool = "hands", int experience = 0)
            {
                Tool = tool;
                Experience = experience;
            }

            public string Tool { get; set; }
            public int Experience { get; set; }

            public void Create()
            {
                Console.WriteLine("Builder.Create()");
            }

            public void Destroy()
            {
                Console.WriteLine("Builder.Destroy()");
            }

            int IComparable<IDeveloper>.CompareTo(IDeveloper other)
            {
                return this.Experience.CompareTo(other.Experience);
            }

            public override string ToString()
            {
                return "Builder: " + Tool + " " + Experience;
            }
        }

        static void Main(string[] args)
        {
            IDeveloper[] developers = new IDeveloper[]
            {
                new Programmer("laptop", 1),
                new Programmer("computer", 10),
                new Programmer("laptop", 3),
                new Builder("hummer", 2),
                new Builder("hands", 4),
                new Builder("ruler", 2)
            };
            foreach (IDeveloper dev in developers)
            {
                Console.WriteLine(dev.Tool);
                dev.Create();
                dev.Destroy();
            }
            var result = from dev in developers orderby dev.Experience select dev;
            foreach(IDeveloper dev in result)
            {
                Console.WriteLine(dev);
            }


            Dictionary<uint, string> dict = new Dictionary<uint, string>();
            for(int i = 0; i < 1; ++i)
            {
                Console.Write("Enter id: ");
                uint id = uint.Parse(Console.ReadLine());
                Console.Write("Enter name: ");
                dict.Add(id, Console.ReadLine());
            }
            Console.WriteLine("Enter id to find: ");
            uint idToFind = uint.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(dict[idToFind]);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}

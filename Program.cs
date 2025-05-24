using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Academy
{
    class Program
    {
        static readonly string delimiter = "\n----------------------------------------------\n";
        static void Main(string[] args)
        {

#if INHERITANCE
			Human human = new Human("Montana", "Antonio", 25);
			human.Info();
			Console.WriteLine(delimiter);

			Student student = new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96);
			student.Info();
			Console.WriteLine(delimiter);

			Teacher teacher = new Teacher("White", "Walter", 50, "Chemistry", 25);
			teacher.Info();
			Console.WriteLine(delimiter);

			Human tommy = new Human("Vercetty", "Tommy", 30);
			tommy.Info();
			Console.WriteLine(delimiter);

			Student s_tommy = new Student(tommy, "Theft", "Vice", 95, 98);
			s_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate g_tommy = new Graduate(s_tommy, "How to make money");
			g_tommy.Info();
			Console.WriteLine(delimiter);

			Graduate graduate = new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to catch Heizenberg");
			graduate.Info();
			Console.WriteLine(delimiter); 
#endif

#if SAVE_TO_FILE
			//Generalization (Обобщение):
			Human[] group = new Human[]
				{
					//Upcast - преобразование объекта дочернего класса в объект базового класса
					new Student("Pinkman", "Jessie", 22, "Chemistry", "WW_220", 95, 96),
					new Teacher("White", "Walter", 50, "Chemistry", 25),
					new Graduate("Vercetty", "Tommy", 30, "Theft", "Vice", 95, 98, "How to make money"),
					new Graduate("Schreder", "Hank", 40, "Criminalistic", "OBN", 70, 80, "How to catch Heizenberg"),
					new Teacher("Diaz", "Ricardo", 50, "Weapons distribution", 20)
				};

			Print(group);
			Save(group, "group.csv"); 
#endif
        
            Human[] group = Load("base.csv");
            Print(group);

            Console.WriteLine("DONE");
            Console.ReadLine();
        }
        public static void Print(Human[] group)
        {
            for (int i = 0; i < group.Length; i++)
            {
                Console.WriteLine(group[i]);
            }
        }
        public static void Save(Human[] group, string filename)
        {

            StreamWriter sw = new StreamWriter(filename);

            for (int i = 0; i < group.Length; i++)
            {
                sw.WriteLine(group[i].ToFileString());
            }

            sw.Close();

            Process.Start("notepad.exe", filename);
        }
        public static Human[] Load(string filename)
        {
            List<Human> group = new List<Human>();

            try
            {
                StreamReader sr = new StreamReader(filename);

                while (!sr.EndOfStream)
                {
                    string buffer = sr.ReadLine();
                    Human human = HumanFactory(buffer.Split(':').First());
                    human.Init(buffer.Split(':').Last().Split(','));
                    group.Add(human);
                }

                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return group.ToArray();
        }
        public static Human HumanFactory(string type)
        {
            Human human = null;
            switch (type)
            {
                case "Human": human = new Human("", "", 0); break;
                case "Student": human = new Student("", "", 0, "", "", 0, 0); break;
                case "Graduate": human = new Graduate("", "", 0, "", "", 0, 0, "n/a"); break;
                case "Specialist": human = new Specialist("", "", 0, "", "", 0, 0, "n/a",0.0,"",0); break;
                case "Teacher": human = new Teacher("", "", 0, "", 0); break;
            }
            return human;
        }
    }
}

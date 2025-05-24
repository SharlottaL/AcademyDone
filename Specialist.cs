using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Academy
{
    internal class Specialist : Graduate
    {
        public double Experience { get; set; }
        public string SpecialSkills { get; set; }
        public int Salary { get; set; }
        public Specialist
            (
            string last_name, string first_name, int age,
            string speciality, string group, double rating, double attendance,
            string subject,
            double experience, string special_skills, int salary
            ) : base(last_name, first_name, age, speciality, group, rating, attendance, subject)
        {
            Experience = experience;
            SpecialSkills = special_skills;
            Salary = salary;
            Console.WriteLine($"SConstructor\t:{this.GetHashCode()}");
        }
        public Specialist(Graduate graduate, double experience, string special_skills, int salary) : base(graduate)
        {
            Experience = experience;
            SpecialSkills = special_skills;
            Salary = salary;
            Console.WriteLine($"SConstructor\t:{this.GetHashCode()}");
        }
        ~Specialist()
        {
            Console.WriteLine($"SDestructor\t:{this.GetHashCode()}");
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine($"{Experience} {SpecialSkills} {Salary}");
        }
        public override string ToString()
        {
            return (base.ToString() + ":").Split('.').Last().PadRight(12)
                + $"{Experience.ToString().PadRight(15)}{SpecialSkills.PadRight(15)}{Salary.ToString().PadRight(5)}";
        }

        public override string ToFileString()
        {
            return $"{GetType().ToString().Split('.').Last()}:{Experience},{SpecialSkills},{Salary}";
        }
        public override Human Init(string[] values)
        {
            base.Init(values);
            this.Experience = Convert.ToDouble(values[8]);
            this.SpecialSkills = values[9];
            this.Salary = Convert.ToInt32(values[10]);
            return this;
        }
    }
}

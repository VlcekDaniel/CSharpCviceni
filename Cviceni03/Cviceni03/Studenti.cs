using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni03
{
    class Studenti
    {
        public delegate int KomparatorStudentu(Student student1, Student student2);
        public Student[] PoleStudentu { get; set; }
        public void Nacti()
        {
            PoleStudentu = new Student[5];
            for (int i = 0; i < PoleStudentu.Length; i++)
            {
                Random random = new Random();
                Console.WriteLine("Zadejte cislo studenta: ");
                int cislo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Zadejte jmeno studenta: ");
                string jmeno = Console.ReadLine();                
                FakultaEnum typFakulty = (FakultaEnum)random.Next(4);
                PoleStudentu[i] = new Student(jmeno,cislo,typFakulty);
            }
        }
        public void Vypis()
        {
            for (int i = 0; i < PoleStudentu.Length; i++)
            {
                Console.WriteLine(PoleStudentu[i].ToString());
            }
        }
      
        public void Sort(KomparatorStudentu komparatorStudentu)
        {
            for (int i = 0; i < PoleStudentu.Length-1; i++)
            {
                for (int j = 0; j < PoleStudentu.Length-1; j++)
                {
                    if (komparatorStudentu(PoleStudentu[j],PoleStudentu[j + 1]) > 1)
                    {
                        Student pom = PoleStudentu[j];
                        PoleStudentu[j] = PoleStudentu[j + 1];
                        PoleStudentu[j + 1] = pom;
                    }
                }
            }
        }
        public int CompareCislo(Student student1, Student student2)
        {
            return student1.Cislo - student2.Cislo;
        }
        public int CompareJmeno(Student student1, Student student2)
        {
            return String.Compare(student1.Jmeno, student2.Jmeno);
        }
        public int CompareFakulta(Student student1, Student student2)
        {
            return student1.TypFakulty - student2.TypFakulty;
        }
    }
}

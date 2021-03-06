using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cviceni03
{    class Student
    {
        public Student(string jmeno, int cislo, FakultaEnum cisloFakulty) {
            this.Jmeno = jmeno;
            this.Cislo = cislo;
            this.TypFakulty = cisloFakulty;
        }
        public string Jmeno { get; set; }
        public int Cislo { get; set; }
        public FakultaEnum TypFakulty { get; set; }
        public override string ToString()
        {
            return $"{Jmeno} \t {Cislo} {TypFakulty}";
        }
    }
}

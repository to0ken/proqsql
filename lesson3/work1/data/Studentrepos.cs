using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcademyApp.model;

namespace AcademyApp.data
{
    internal class Studentrepos
    {
        private readonly string conn_srt;
        public Studentrepos(string connection_string) { 
        
            conn_srt = connection_string;
        }

        public List<student> FindAllStudents()
        {
            var students = new List<student>();
            return students;
        }
    }
}

using System;
using System.Runtime.CompilerServices;


namespace AcademyApp.model
{
    public class student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName}{Age}";
        }
        
    }
}

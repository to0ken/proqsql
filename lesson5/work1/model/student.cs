using System;
using System.Runtime.CompilerServices;


namespace AcademyApp.model
{
    public class student
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public int GroupId { get; set; }

        public override string ToString()
        {
            return $"{FirstName}{LastName}{Age}";
        }

    }
}

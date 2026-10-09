using System;
using System.Runtime.CompilerServices;


namespace AcademyApp.model
{
    public class student
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Age { get; set; }
        string GroupId { get; set; }
        public override string ToString()
        {
            return $"{FirstName}{LastName}{Age}";
        }
        
    }
}

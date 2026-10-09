using System;

namespace AcademyApp.model
{
    public class group
    {
        public string GroupName { get; set; }
     
        public int GroupId { get; set; }
        

        public override string ToString()
        {
            return $"{GroupName}";
        }

    }
}

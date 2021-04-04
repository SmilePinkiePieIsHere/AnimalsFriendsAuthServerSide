using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace AnimalsFriends.Helpers
{
    public class Classes
    {
        public class AnimalStatus
        {
            public static string NeedHome = "NeedHome";

            public static string Adopted = "Adopted";

            public static string InMedicalCare = "InMedicalCare";
        }

        public class AnimalSpecies
        {
            public static string Cat = "cat";

            public static string Dog = "dog";
        }

        public enum UserRole
        {
            Admin,
            User
        }

        public enum BlogCategory
        {
            News,
            Causes
        }

        public class Gender
        {
            public static string Male = "male";

            public static string Female = "female";
        }    
    }
}

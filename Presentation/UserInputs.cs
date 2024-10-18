using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Presentation.UserInputs;

namespace Presentation
{
    public class UserInputs
    {

        public class UserDetails
        {
            
            public string Name { get; set; }
            public int Age { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public string Skill { get; set; }
            public int Experience { get; set; }

           
            public UserDetails(string name, int age, string phone, string email, string skill, int experience)
            {
                Name = name;
                Age = age;
                Phone = phone;
                Email = email;
                Skill = skill;
                Experience = experience;
            }
        }


     








    }
}

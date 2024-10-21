using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment13thSept
{
     class EmployeePromotion : Employee
    {
        List<int>Eligible=new List<int>();
        private List<string> promotionList;

        public EmployeePromotion()
        {
            promotionList = new List<string>();
        }

        public void TakeEmployeeNames()
        {
            string name;
            Console.WriteLine("Please enter the employee names in the order of their eligibility for promotion (enter blank to stop):");

            do
            {
                name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name))
                {
                    promotionList.Add(name);
                }
            } while (!string.IsNullOrEmpty(name));
        }

        public void PrintPromotionList()
        {   
            promotionList.Sort();
            Console.WriteLine("\nPromotion Eligibility List:");
            for (int i = 0; i < promotionList.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {promotionList[i]}");
            }
        }

        public int GetEmployeePosition(string name)
        {
            int position = promotionList.IndexOf(name);
            return position + 1; // Adjust for 1-based indexing
        }






    }
}

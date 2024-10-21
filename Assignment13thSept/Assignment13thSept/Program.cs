using System.Security.Cryptography.X509Certificates;

namespace Assignment13thSept
{
    public class Employee
    {
        int id, age;
        string name;
        double salary;

        public Employee()
        {
        }

        public Employee(int id, int age, string name, double salary)
        {
            this.id = id;
            this.age = age;
            this.name = name;
            this.salary = salary;
        }

        public void TakeEmployeeDetailsFromUser()
        {
            Console.WriteLine("Please enter the employee ID");
            id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee name");
            name = Console.ReadLine();
            Console.WriteLine("Please enter the employee age");
            age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the employee salary");
            salary = Convert.ToDouble(Console.ReadLine());
        }

        public override string ToString()
        {
            return "Employee ID : " + id + "\nName : " + name + "\nAge : " + age + "\nSalary : " + salary;
        }



        public int Id { get => id; set => id = value; }
        public int Age { get => age; set => age = value; }
        public string Name { get => name; set => name = value; }
        public double Salary { get => salary; set => salary = value; }


        class EmployeeRepository
        {
            private List<Employee> employees;

            public EmployeeRepository()
            {
                employees = new List<Employee>();
            }

            public void AddEmployee(Employee
         employee)
            {
                employees.Add(employee);
            }

            public Employee GetEmployeeById(int id)
            {
                return employees.Find(e => e.Id == id);
            }

            public List<Employee> GetAllEmployees()
            {
                return employees;
            }
        }







        static void Main(string[] args)
        {
            Employee e = new Employee();
            Console.WriteLine("Hello, World!");
            EmployeePromotion employeePromotion = new EmployeePromotion();
            employeePromotion.TakeEmployeeNames();
            employeePromotion.PrintPromotionList();

            Console.Write("Please enter name of employee");
            string nameToCheck = Console.ReadLine();

            int position = employeePromotion.GetEmployeePosition(nameToCheck);

            if (position > 0)
            {
                Console.WriteLine($"{nameToCheck} is at position {position} for promotion.");
            }
            else
            {
                Console.WriteLine($"{nameToCheck} is not in the promotion list.");
            }

            EmployeeRepository employeeRepository = new EmployeeRepository();

            while (true)
            {
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Get employee by ID");
                Console.WriteLine("3. List all employees");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Employee employee = new Employee();
                        employee.TakeEmployeeDetailsFromUser();
                        employeeRepository.AddEmployee(employee);
                        break;
                    case 2:
                        Console.Write("Enter employee ID: ");
                        int id = int.Parse(Console.ReadLine());
                        Employee foundEmployee = employeeRepository.GetEmployeeById(id);
                        if (foundEmployee != null)
                        {
                            Console.WriteLine(foundEmployee.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Employee not found.");
                        }
                        break;
                    case 3:
                        List<Employee> allEmployees = employeeRepository.GetAllEmployees();
                        foreach (Employee emp in allEmployees)
                        {
                            Console.WriteLine(emp.ToString());
                        }
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;


                }
            }

        }
 }
    
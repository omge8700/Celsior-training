using QuestPDF.Fluent;
using System;
using System.IO;
using QuestPDF.Infrastructure;
using static Presentation.UserInputs;

class Program
{
    static void Main(string[] args)
    {

        QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;
        // Collecting user details
        UserDetails user = GetUserDetails();

        // Generate and save PDF
        var document = new UserDetailsPdfDocument(user);

        // Define the file path where the PDF will be saved
        string outputPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "UserDetails.pdf");

        // Save the document as PDF
        document.GeneratePdf(outputPath);

        Console.WriteLine($"PDF generated and saved at {outputPath}");
    }

   
    static UserDetails GetUserDetails()
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your phone number: ");
        string phone = Console.ReadLine();

        Console.Write("Enter your email: ");
        string email = Console.ReadLine();

        Console.Write("Enter your skill: ");
        string skill = Console.ReadLine();

        Console.Write("Enter your experience (in years): ");
        int experience = int.Parse(Console.ReadLine());

        return new UserDetails(name, age, phone, email, skill, experience);
    }
}


           

            





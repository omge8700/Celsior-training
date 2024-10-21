using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using static Presentation.UserInputs;

public class UserDetailsPdfDocument : IDocument
{
    private readonly UserDetails _userDetails;

    // Constructor accepting user details
    public UserDetailsPdfDocument(UserDetails userDetails)
    {
        _userDetails = userDetails;
    }

   
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

    public void Compose(IDocumentContainer container)
    {
        container
            .Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(2, Unit.Centimetre);
                page.PageColor(Colors.White);
                page.DefaultTextStyle(x => x.FontSize(16));

                // Adding header
                page.Header()
                    .Text("User Details")
                    .SemiBold()
                    .FontSize(20)
                    .FontColor(Colors.Blue.Medium);

                page.Content()
                    .PaddingVertical(1, Unit.Centimetre)
                    .Column(column =>
                    {
                        // Add User Information
                        column.Item().Text($"Name: {_userDetails.Name}");
                        column.Item().Text($"Age: {_userDetails.Age}");
                        column.Item().Text($"Phone: {_userDetails.Phone}");
                        column.Item().Text($"Email: {_userDetails.Email}");
                        column.Item().Text($"Skill: {_userDetails.Skill}");
                        column.Item().Text($"Experience: {_userDetails.Experience} years");
                    });

                // Footer section
                page.Footer()
                    .AlignCenter()
                    .Text(x =>
                    {
                        x.Span("Generated on: ");
                        x.Span(DateTime.Now.ToString("MMMM dd, yyyy")).SemiBold();
                    });
            });
    }
}

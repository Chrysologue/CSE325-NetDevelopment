using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        // Define where your 'stores' folder and output file are located
        string storeFolder = "stores";
        string summaryFile = "sales_summary.txt";

        // Call the function to generate the report
        GenerateSalesSummary(storeFolder, summaryFile);
        
        Console.WriteLine("Sales summary report generated successfully!");
    }

    // This is the function you need to copy for your notes.md file (#3)
    public static void GenerateSalesSummary(string folderPath, string outputFilePath)
    {
        string[] salesFiles = Directory.GetFiles(folderPath);
        decimal totalSales = 0;
        
        StringBuilder report = new StringBuilder();
        StringBuilder details = new StringBuilder();

        report.AppendLine("Sales Summary");
        report.AppendLine("----------------------------");

        foreach (var file in salesFiles)
        {
            string fileName = Path.GetFileName(file);
            string fileContent = File.ReadAllText(file);

            if (decimal.TryParse(fileContent.Trim(), out decimal fileSales))
            {
                totalSales += fileSales;
                details.AppendLine($" {fileName}: {fileSales:C}");
            }
        }

        report.AppendLine($" Total Sales: {totalSales:C}");
        report.AppendLine();
        report.AppendLine(" Details:");
        report.Append(details.ToString());

        File.WriteAllText(outputFilePath, report.ToString());
    }
}
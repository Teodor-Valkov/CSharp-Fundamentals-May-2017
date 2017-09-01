namespace _14.ExportToExcel
{
    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using System.IO;

    internal class StartUp
    {
        private static void Main()
        {
            ExcelPackage xlsPackage = new ExcelPackage();
            ExcelWorksheet workSheet = xlsPackage.Workbook.Worksheets.Add("MySheet");

            workSheet.Cells[1, 1, 1, 11].Merge = true;
            workSheet.Cells[1, 1, 1, 11].Style.Font.Size = 18;
            workSheet.Cells[1, 1, 1, 11].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            workSheet.Cells[1, 1].Value = "Exam Results";

            using (StreamReader reader = new StreamReader("../../StudentData.txt"))
            {
                int row = 2;

                string line = string.Empty;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] columns = line.Split('\t');

                    for (int i = 1; i <= columns.Length; i++)
                    {
                        workSheet.Cells[row, i].Value = columns[i - 1];
                    }

                    row++;
                }
            }

            FileStream fileStream = new FileStream("../../MySheet.xlsx", FileMode.Create);

            xlsPackage.SaveAs(fileStream);
        }
    }
}
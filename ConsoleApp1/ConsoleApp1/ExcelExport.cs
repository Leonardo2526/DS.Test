using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Test1
{
    class ExcelExport
    {
        static void Main(string[] args)
        {
            DisplayInExcel();

        }

        static void DisplayInExcel()
        {
            string excelFilePath = Environment.ExpandEnvironmentVariables(@"%USERPROFILE%\Desktop\Test.xlsx");

            var excelApp = new Excel.Application();

            excelApp.Workbooks.Add();

            //Get sheets in the active workbook
            Excel.Sheets sheets = excelApp.ActiveWorkbook.Sheets;

            //Creare new worksheet
            Excel.Worksheet newWorksheet1 = null;
            Excel.Worksheet newWorksheet2 = null;
            Excel.Worksheet newWorksheet3 = null;



            newWorksheet1 = sheets.Add(Type.Missing, sheets[1], Type.Missing, Type.Missing);
            newWorksheet1.Name = "Mylist1";
            newWorksheet2 = sheets.Add(Type.Missing, newWorksheet1, Type.Missing, Type.Missing);
            newWorksheet2.Name = "Mylist2";
            sheets[1].Delete();



            // Establish column headings in cells A1 and B1.
            newWorksheet1.Cells[1, "A"] = 1;
            newWorksheet1.Cells[1, "B"] = 2;

            newWorksheet1.Columns[1].AutoFit();
            newWorksheet1.Columns[2].AutoFit();

            newWorksheet2.Cells[1, "A"] = 2;
            newWorksheet2.Cells[1, "B"] = 3;

            newWorksheet2.Columns[1].AutoFit();
            newWorksheet2.Columns[2].AutoFit();

            newWorksheet3 = sheets.Add(Type.Missing, newWorksheet2, Type.Missing, Type.Missing);
            newWorksheet3.Name = "Total";

            int sum1 = 0;
            int sum2 = 0;
            int[] Sum = new int[33];
            //Convert.ToInt32(newWorksheet1.Columns[1]);
            //Convert.ToInt32(newWorksheet2.Rows[1]);

            foreach (Excel.Worksheet sheet in sheets)
            {
                if (sheet.Name != "Total")
                {
                    Sum[1] += sheet.Cells[1, "A"].Value;
                    sum2 += sheet.Cells[1, "B"].Value;

                }
            }
            newWorksheet3.Cells[1, "A"] = Sum[1];
            newWorksheet3.Cells[1, "B"] = sum2;


            newWorksheet3.Columns[1].AutoFit();
            newWorksheet3.Columns[2].AutoFit();


            excelApp.ActiveWorkbook.SaveAs(excelFilePath);
            excelApp.Visible = false;
            excelApp.ActiveWorkbook.Close(true);
            excelApp.Quit();

            DateTime date1 = new DateTime();
            DateTime dateOnly = date1.Date;
            Console.WriteLine(dateOnly.ToString("MM/dd/yyyy HH:mm"));
        }
    }
}

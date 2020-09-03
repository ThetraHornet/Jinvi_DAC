using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Quickstarts.EmptyServer
{
    public class ExcelFunction : IDisposable
    {
        public static Application excel = new _Excel.Application();
        public string path = "";
        public Workbooks wbs = excel.Workbooks;
        public Workbook wb;
        public Worksheet ws;
        public Range range;

        //Dispose
        // Flag: Has Dispose already been called?
        bool disposed = false;
        // Instantiate a SafeHandle instance.
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public ExcelFunction() { }

        public ExcelFunction(string path, int Sheet)
        {
            excel.DisplayAlerts = false;
            this.path = path;
            wb = wbs.Open(this.path);
            ws = (Worksheet)wb.Worksheets[Sheet];
            range = ws.UsedRange;
        }

        public ExcelFunction(string path)
        {
            excel.DisplayAlerts = false;
            this.path = path;
            wb = excel.Workbooks.Open(path);
        }

        public string ReadCell(int i, int j)
        {
            i++;
            j++;
            if (ws.Cells[i, j].Value != null)
                return ws.Cells[i, j].Value.ToString();
            else
                return "";
        }

        public void ChangeSheets(int sheetIndex)
        {
            ws = wb.Worksheets[sheetIndex];
        }

        public int SheetCount()
        {
            return excel.Sheets.Count;
        }

        // Public implementation of Dispose pattern callable by consumers.
        public void Dispose()
        {
            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(ws);

            //close and release
            wb.Close(0);
            Marshal.ReleaseComObject(wb);

            wbs.Close();
            Marshal.ReleaseComObject(wbs);

            excel.Quit();
            Marshal.ReleaseComObject(excel);

            Dispose(true);
            GC.SuppressFinalize(this);


        }


        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }
    }
}
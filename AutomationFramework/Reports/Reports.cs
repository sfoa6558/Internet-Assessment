﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.Reports
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Reports
    {
        private string BrowserType;
        private string url;
        private DateTime date;
        private FileStream fs;
        private StringBuilder reportcsv;
        private string filePath;
        private string fileName;

        public Reports(string BrowserType, string url)
        {
            this.BrowserType = BrowserType;
            this.url = url;
            date = DateTime.Now;
            fileName = date.Date.Date.ToShortDateString() + date.TimeOfDay.Hours.ToString() + date.TimeOfDay.Minutes.ToString();
            reportcsv = new StringBuilder();
            filePath = @"C:\Users\AutomationFramework\Desktop\Automation\" + fileName + ".csv";
            createCsvFile();
        }

        private void createCsvFile()
        {
            reportcsv.Append("StepDescription,");
            reportcsv.Append("Pass/Fail,");
            reportcsv.Append("Exception");
            File.AppendAllText(filePath, reportcsv.ToString());
        }
        public void addLine(string description, string result, string exception)
        {
            reportcsv.Append(Environment.NewLine);
            reportcsv.Append(description + ",");
            reportcsv.Append(result + ",");
            reportcsv.Append(exception + ",");
            reportcsv.Append(Environment.NewLine);
            File.WriteAllText(filePath, reportcsv.ToString());
        }
    }
}


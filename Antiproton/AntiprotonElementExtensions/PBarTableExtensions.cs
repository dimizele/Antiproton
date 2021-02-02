using Antiproton.AntiprotonElements;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Antiproton.AntiprotonElementExtensions
{
    public static class PBarTableExtensions
    {
        public static List<PBarElement> GetAllTableRows(this PBarTable table)
        {
            return table.FindElements(By.TagName("tr")).ToList();
        }

        public static List<PBarElement> GetAllTableBodyRows(this PBarTable table)
        {
            return new PBarTable(table.PBarDriver, table.FindElement(By.TagName("tbody"))).GetAllTableRows();
        }
    }
}

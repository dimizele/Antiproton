using System;
using System.Collections.Generic;
using System.Text;

namespace Antiproton.DriverExtensions
{
    //This is a PBarDriver Extension class
    public static class TheStrongForce
    {
        public static T GoToPage<T>(this PBarDriver driver) where T : PBarPage, new()
        {
            var page = new T { Driver = driver };

            page.Driver.Navigate().GoToUrl(page.Url);

            return page;
        }
    }
}

using Logger;
using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antiproton
{
    public class PBarNavigation : INavigation
    {
        private INavigation _navigation;
        private PBarDriver _driver;

        public PBarNavigation(INavigation navigation, PBarDriver driver)
        {
            _navigation = navigation;
            _driver = driver;
        }

        public void Back()
        {
            Log.GetLogger().Info($"Navigating Back");
            _navigation.Back();
            _driver.WaitForDocumentState();
        }

        public void Forward()
        {
            Log.GetLogger().Info($"Navigating Forward");
            _navigation.Forward();
            _driver.WaitForDocumentState();
        }

        public void GoToUrl(string url)
        {
            Log.GetLogger().Info($"Navigating To Url [{url}]");
            _navigation.GoToUrl(url);
            _driver.WaitForDocumentState();
        }

        public void GoToUrl(Uri url)
        {
            Log.GetLogger().Info($"Navigating To Url [{JsonConvert.SerializeObject(url)}]");
            _navigation.GoToUrl(url);
            _driver.WaitForDocumentState();
        }

        public void Refresh()
        {
            Log.GetLogger().Info($"Refresh page");
            _navigation.Refresh();
            _driver.WaitForDocumentState();
        }
    }
}

using Logger;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace Antiproton
{
    public class PBarDriver : IWrapsDriver
    {
        private IWebDriver _driver;
        private IJavaScriptExecutor _jsExe;
        private WebDriverWait wait;

        public PBarDriver(IWebDriver driver)
        {
            _driver = driver; 
            _jsExe = (IJavaScriptExecutor)driver;
        }

        public IWebDriver WrappedDriver => _driver;

        public IJavaScriptExecutor JavaScriptExecutor => _jsExe;

        public WebDriverWait Wait
        {
            get
            {
                return wait ?? new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(5));
            }
            set
            {
                wait = value;
            }
        }

        public string Url 
        {
            get
            {
                Log.GetLogger().Info($"Driver Url is [{_driver.Url}]");
                return _driver.Url;
            }
            set 
            {
                Log.GetLogger().Info($"Setting the Driver Url to [{value}]");
                _driver.Url = value;
            }
        }

        public string Title
        {
            get
            {
                Log.GetLogger().Info($"Driver Title Property is [{_driver.Title}]");
                return _driver.Title;
            }
        }

        public string PageSource
        {
            get
            {
                Log.GetLogger().Info($"Driver PageSource Property is [{_driver.Title}]");
                return _driver.PageSource;
            }
        }

        public string CurrentWindowHandle
        {
            get
            {
                Log.GetLogger().Info($"Driver CurrentWindowHandle Property is [{_driver.Title}]");
                return _driver.CurrentWindowHandle;
            }
        }

        public ReadOnlyCollection<string> WindowHandles => _driver.WindowHandles;

        public void Close()
        {
            Log.GetLogger().Info($"Closing Driver");
            _driver.Close();
        }

        public void Quit()
        {
            Log.GetLogger().Info($"Quitting Driver");
            _driver.Quit();
        }

        public void Dispose()
        {
            Log.GetLogger().Info($"Disposing Driver");
            _driver.Dispose();
        }

        public IOptions Manage()
        {
            return new PBarOptions(_driver.Manage());
        }

        public INavigation Navigate()
        {
            return new PBarNavigation(_driver.Navigate(), this);
        }

        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }

        public PBarElement FindElement(By by)
        {
            Log.GetLogger().Info($"Finding element by locator:[{by}]");
            return new PBarElement(this, _driver.FindElement(by), by);
        }

        public ReadOnlyCollection<PBarElement> FindElements(By by)
        {
            Log.GetLogger().Info($"Finding elements by locator:[{by}]");
            return new ReadOnlyCollection<PBarElement>(_driver.FindElements(by).Select(el => new PBarElement(this, el, by)).ToList());
        }

        public bool PeekElement(By by)
        {
            try
            {
                _driver.FindElement(by);

                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void WaitForDocumentState()
        {
            for (int i = 0; i < 30; i++)
            {
                string documentReady = (_driver as IJavaScriptExecutor).ExecuteScript("return document.readyState") as string;
                if (!documentReady.Equals("complete"))
                {
                    Thread.Sleep(1000);
                }
            }
        }
    }
}

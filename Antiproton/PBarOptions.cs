using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Antiproton
{
    public class PBarOptions : IOptions
    {
        private IOptions _options;

        public PBarOptions(IOptions options)
        {
            _options = options;
        }

        public ICookieJar Cookies => _options.Cookies;

        public IWindow Window => new PBarWindow(_options.Window);

        public ILogs Logs => _options.Logs;

        public ITimeouts Timeouts()
        {
            return _options.Timeouts();
        }
    }
}

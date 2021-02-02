using Antiproton;
using Antiproton.DriverExtensions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestBases
{
    public class TestBase
    {
        protected PBarDriver Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            BeforeAll();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            AfterAll();
        }

        [SetUp]
        public void SetUp()
        {
            BeforeEach();
        }

        [TearDown]
        public void TearDown()
        {
            AfterEach();
        }

        public virtual void BeforeAll()
        {
            
        }

        public virtual void AfterAll()
        {

        }

        public virtual void BeforeEach()
        {
            DriverInit();
        }

        public virtual void AfterEach()
        {
            DriverDispose();
        }

        public void DriverInit()
        {
            Driver = new AntiprotonAccumulator().CreateChromeDriver(TimeSpan.FromSeconds(5));
        }

        public void DriverDispose()
        {
            Driver.Dispose();
        }
    }
}

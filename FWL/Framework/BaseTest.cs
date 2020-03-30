using FWL.Framework.Utils;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;

namespace FWL.Framework
{
    public abstract class BaseTest
    {
        public static JObject testData;

        [SetUp]
        public void Setup()
        {
            testData = TestDataUtil.GetTestData(GetType().Name.Trim());
            BrowserExt.Initiate(Config.Get(ConfigString.BaseUrl),
                Config.Get(ConfigInt.ResolutionWidth),
                Config.Get(ConfigInt.ResolutionHeight));
        }

        [Test]
        public abstract void RunTest();

        [TearDown]
        public void Teardown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                var directory = $"{Directory.GetCurrentDirectory()}\\Screenshots";
                Directory.CreateDirectory(directory);
                File.WriteAllBytes($"{directory}\\{GetType().Name}_{DateTime.Now.Ticks}.jpeg",
                    BrowserExt.GetScreenshot());
            }
            BrowserExt.Quit();
        }
    }
}
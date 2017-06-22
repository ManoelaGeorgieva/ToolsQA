using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsQA.Pages.DraggablePage;
using ToolsQA.Pages.DroppablePage;
using ToolsQA.Pages.ResizablePage;
using ToolsQA.Pages.SelectablePage;
using ToolsQA.Pages.SortablePage;

namespace ToolsQA
{
    public class TearDown
    {
        public IWebDriver driver;


        public void SaveLogs()
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Logs\");
            string filename = path + TestContext.CurrentContext.Test.MethodName + ".txt";

            using (var writer = File.AppendText(filename))
            {
                writer.WriteLine(DateTime.Now + "            " + TestContext.CurrentContext.Result.Outcome);
                writer.WriteLine();
            }
        }
        public void TakeScreenShot(IWebDriver driver)
        {

            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\Logs\");
            string filename = path + TestContext.CurrentContext.Test.MethodName + ".txt";
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(path + TestContext.CurrentContext.Test.Name + ".jpg", ScreenshotImageFormat.Jpeg);

        }
    }
}


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
    [TestFixture]
    public class SelectablePageTests
    {
        public IWebDriver driver;
        public Actions builder;
        TearDown cleaner = new TearDown();

        [SetUp]
        public void Init()
        {
            this.driver = new ChromeDriver();
            builder = new Actions(driver);
        }

        [TearDown]
        public void CleanUp()
        {
            cleaner.SaveLogs();
            this.driver.Quit();
        }
        [Test]
        [Property("Selectable", 3)]
        [Property("InteractionPage", 3)]
        public void SelectAll()
        {
            var page = new SelectablePage(driver);
            page.GoToSelectable();

            builder.DragAndDrop(page.FirstItem, page.SeventhItem).Perform();

            Assert.IsTrue(page.AreAllSelected());
        }

        [Test]
        [Property("Selectable", 3)]
        [Property("InteractionPage", 3)]
        public void SelectFirstItem()
        {
            var page = new SelectablePage(driver);

            page.GoToSelectable();
            Assert.IsFalse(page.ISSelected(page.FirstItem));
            page.FirstItem.Click();
            Assert.IsTrue(page.ISSelected(page.FirstItem));
        }

        [Test]
        [Property("Selectable", 3)]
        [Property("InteractionPage", 3)]
        public void SelectableTest()
        {
            var page = new SelectablePage(driver);
            page.GoToSelectable();
            page.SecondItem.Click();
            page.ForthItem.Click();
            page.SixthItem.Click();

            Assert.IsFalse(page.ISSelected(page.SecondItem));
            Assert.IsFalse(page.ISSelected(page.ForthItem));
            Assert.IsTrue(page.ISSelected(page.SixthItem));
        }

        [Test]
        [Property("Selectable", 3)]
        [Property("InteractionPage", 3)]
        public void SelectMultipleItems()
        {
            var page = new SelectablePage(driver);
            page.GoToSelectable();
            builder.KeyDown(Keys.Control).Perform();
            page.SecondItem.Click();
            page.ForthItem.Click();
            page.SixthItem.Click();
            builder.KeyUp(Keys.Control);
            Assert.IsTrue(page.ISSelected(page.SecondItem));
            Assert.IsTrue(page.ISSelected(page.ForthItem));
            Assert.IsTrue(page.ISSelected(page.SixthItem));
        }

        [Test]
        [Property("Selectable", 3)]
        [Property("InteractionPage", 3)]
        public void SelectMultipleItemstest()
        {
            var page = new SelectablePage(driver);
            page.GoToSelectable();
            page.GridBTN.Click();            
            builder.DragAndDrop(page.GridItem1, page.GridItem6).Perform();

            Assert.IsTrue(page.ISSelected(page.GridItem1));
            Assert.IsTrue(page.ISSelected(page.GridItem2));
            Assert.IsTrue(page.ISSelected(page.GridItem5));
            Assert.IsTrue(page.ISSelected(page.GridItem6));
        }

    }
}

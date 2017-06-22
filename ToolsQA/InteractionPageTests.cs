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
    public class InteractionPageTests
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
        [Property("Resizable", 3)]
        [Property("InteractionPage", 3)]
        public void ResizeElement()
        {
            var page = new ResizablePage(driver);
            page.NavigateToResizable();
            int height = page.ElementToResize.Size.Height;
            int width = page.ElementToResize.Size.Width;
            builder.DragAndDropToOffset(page.ResizeArrow, 75, 152).Perform();
            int heightAfter = page.ElementToResize.Size.Height;
            int widthAfter = page.ElementToResize.Size.Width;

            Assert.IsTrue(heightAfter > height);
            Assert.IsTrue(widthAfter > width);
        }

        [Test]
        [Property("Resizable", 3)]
        [Property("InteractionPage", 3)]
        public void ConstrainedResizeElement()
        {
            var page = new ResizablePage(driver);
            page.NavigateToResizable();
            page.constrainResizeAreaBTN.Click();
            int originalWidth = page.constrainResizableElement.Size.Width;
            int originalHeight = page.constrainResizableElement.Size.Height;

            builder.DragAndDropToOffset(page.ConstrainedResizeArrow, 200, 200).Perform();

            int editedWidth = page.constrainResizableElement.Size.Width;
            int editedHeight = page.constrainResizableElement.Size.Height;
            
            Assert.GreaterOrEqual(page.constrainContainer.Size.Width, editedWidth);
            Assert.GreaterOrEqual(page.constrainContainer.Size.Height, editedHeight);
        }

        [Test]
        [Property("Resizable", 3)]
        [Property("InteractionPage", 3)]
        public void MinResizeElement()
        {
            var page = new ResizablePage(driver);
            page.NavigateToResizable();
            page.MinMaxBtn.Click();
            builder.DragAndDropToOffset(page.arrowMinMax, -200, -200).Perform();

            int editedWidth = page.elementMinMax.Size.Width;
            int editedHeight = page.elementMinMax.Size.Height;

            Assert.GreaterOrEqual(200, editedWidth);
            Assert.GreaterOrEqual(150, editedHeight);
        }

        [Test]
        [Property("Resizable", 3)]
        [Property("InteractionPage", 3)]
        public void MaxResizeElement()
        {
            var page = new ResizablePage(driver);
            page.NavigateToResizable();
            page.MinMaxBtn.Click();
            builder.DragAndDropToOffset(page.arrowMinMax, 500, 600).Perform();

            int editedWidth = page.elementMinMax.Size.Width;
            int editedHeight = page.elementMinMax.Size.Height;

            Assert.GreaterOrEqual(350, editedWidth);
            Assert.GreaterOrEqual(250, editedHeight);
        }
        
        [Test]
        [Property("Sortable", 3)]
        [Property("InteractionPage", 3)]
        public void SortMoveDown()
        {
            var page = new SortablePage(this.driver);
            page.GoToSortable();

            string originalText = page.FirstItem.Text;
            builder.MoveToElement(page.FirstItem).ClickAndHold().MoveToElement(page.SixthItem).MoveByOffset(10, 10).Release().Perform();

            int result = page.Position(page.AllItems, originalText);

            Assert.AreEqual(6, result);
        }

        [Test]
        [Property("Sortable", 3)]
        [Property("InteractionPage", 3)]
        public void SortMoveUp()
        {
            var page = new SortablePage(this.driver);
            page.GoToSortable();

            string originalText = page.FifthItem.Text;
            builder.MoveToElement(page.FifthItem).ClickAndHold().MoveToElement(page.SecondItem).MoveByOffset(-10, -10).Release().Perform();

            int result = page.Position(page.AllItems, originalText);

            Assert.AreEqual(2, result);
        }

        [Test]
        [Property("Sortable", 3)]
        [Property("InteractionPage", 3)]
        public void SortMoveToRightList()
        {
            var page = new SortablePage(this.driver);
            page.GoToSortable();
            page.ConnectedListsBtn.Click();
            builder.MoveToElement(page.LeftItem1).ClickAndHold().MoveToElement(page.RightItem1).MoveByOffset(-10, -10).Release().Perform();
            
            Assert.AreEqual("Item 2", page.LeftItem1.Text);
        }
    }
}

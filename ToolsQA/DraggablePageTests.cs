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
    public class DraggablePageTests
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
        [Property("Draggable", 3)]
        [Property("InteractionPage", 3)]
        public void DraggableDefaultFunctionality()
        {
            var page = new DraggablePage(driver);

            page.NavigateTo();
            string styleBefore = page.elementDragMeAround.GetAttribute("style");
            builder.DragAndDropToOffset(page.elementDragMeAround, 50, 100).Release().Perform();
            string styleAfter = page.elementDragMeAround.GetAttribute("style");

            Assert.AreNotEqual(styleBefore, styleAfter);
        }

        [Test]
        [Property("Draggable", 3)]
        [Property("InteractionPage", 3)]
        public void DragVertically()
        {
            var page = new DraggablePage(driver);
            page.NavigateTo();
            page.constrainMovementBTN.Click();
            int beforeY = page.elementToDragVertically.Location.Y;
            int beforeX = page.elementToDragVertically.Location.X;

            builder.DragAndDropToOffset(page.elementToDragVertically, 0, 100).Release().Perform();

            int afterY = page.elementToDragVertically.Location.Y;
            int afterX = page.elementToDragVertically.Location.X;

            Assert.AreEqual(beforeX, afterX);
            Assert.Greater(afterY, beforeY);
        }

        [Test]
        [Property("Draggable", 3)]
        [Property("InteractionPage", 3)]
        public void DragHorizontally()
        {
            var page = new DraggablePage(driver);
            page.NavigateTo();
            page.constrainMovementBTN.Click();
            int beforeY = page.elementToDragHorizontally.Location.Y;
            int beforeX = page.elementToDragHorizontally.Location.X;

            builder.DragAndDropToOffset(page.elementToDragHorizontally, 100, 0).Release().Perform();

            int afterY = page.elementToDragHorizontally.Location.Y;
            int afterX = page.elementToDragHorizontally.Location.X;

            Assert.Greater(afterX, beforeX);
            Assert.AreEqual(afterY, beforeY);
        }

        [Test]
        [Property("Draggable", 3)]
        [Property("InteractionPage", 3)]
        public void DragHorizontallyWithnABox()
        {
            var page = new DraggablePage(driver);
            page.NavigateTo();
            page.constrainMovementBTN.Click();
            int beforeY = page.elementContainedInABox.Location.Y;
            int beforeX = page.elementContainedInABox.Location.X;

            builder.DragAndDropToOffset(page.elementContainedInABox, page.elementContainer.Size.Width + 100, 0).Release().Perform();

            int afterY = page.elementContainedInABox.Location.Y;
            int afterX = page.elementContainedInABox.Location.X;

            Assert.LessOrEqual(page.elementContainer.Location.X, afterX);
            Assert.AreEqual(beforeY, afterY);
        }

        [Test]
        [Property("Draggable", 3)]
        [Property("InteractionPage", 3)]
        public void DragVerticallyWithnABox()
        {
            var page = new DraggablePage(driver);
            page.NavigateTo();
            page.constrainMovementBTN.Click();
            int beforeY = page.elementContainedInABox.Location.Y;
            int beforeX = page.elementContainedInABox.Location.X;

            builder.DragAndDropToOffset(page.elementContainedInABox, 0, page.elementContainer.Size.Height + 100).Release().Perform();

            int afterY = page.elementContainedInABox.Location.Y;
            int afterX = page.elementContainedInABox.Location.X;

            Assert.LessOrEqual(page.elementContainer.Location.Y, afterY);
            Assert.AreEqual(beforeX, afterX);
        }

        [Test]
        [Property("Draggable", 3)]
        [Property("InteractionPage", 3)]
        public void DraggableOutsideTheContainer()
        {
            var page = new DraggablePage(driver);
            page.NavigateTo();
            string styleBefore = page.elementDragMeAround.GetAttribute("style");
            builder.DragAndDropToOffset(page.elementDragMeAround, -200, -200).Release().Perform();
            string styleAfter = page.elementDragMeAround.GetAttribute("style");

            Assert.IsFalse(page.elementDragMeAround.Displayed);
        }

    }
}
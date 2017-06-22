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
using System.Threading;
using System.Threading.Tasks;
using ToolsQA.Pages.DraggablePage;
using ToolsQA.Pages.DroppablePage;
using ToolsQA.Pages.ResizablePage;
using ToolsQA.Pages.SelectablePage;
using ToolsQA.Pages.SortablePage;

namespace ToolsQA
{
    [TestFixture]
    public class DroppablePageTests
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
        [Property("Droppable", 3)]
        [Property("InteractionPage", 3)]
        public void DropElementInSquare()
        {
            var page = new DroppablePage(driver);
            page.NavigateToDroppable();

            builder.DragAndDrop(page.DraggableElement, page.DropElement).Perform();

            Assert.IsTrue(page.DropElement.Displayed);
        }

        [Test]
        [Property("Droppable", 3)]
        [Property("InteractionPage", 3)]
        public void DropInAcceptElement()
        {
            var page = new DroppablePage(driver);
            page.NavigateToDroppable();
            page.AcceptBTN.Click();

            builder.DragAndDrop(page.elementCanNotBeDropped, page.AcceptDropElement).Perform();

            Assert.IsTrue(page.AcceptDroppedMessge.Displayed);
        }

        [Test]
        [Property("Droppable", 3)]
        [Property("InteractionPage", 3)]
        public void RevertWhenDroppedInElement()
        {
            var page = new DroppablePage(driver);
            page.NavigateToDroppable();
            page.revertDraggablePositionBTN.Click();
            int beforeX = page.revertWhenDropped.Location.X;
            int beforeY = page.revertWhenDropped.Location.Y;
            builder.DragAndDrop(page.revertWhenDropped, page.dropingContainer).Perform();
            Thread.Sleep(2000);
            int afterX = page.revertWhenDropped.Location.X;
            int afterY = page.revertWhenDropped.Location.Y;
            Assert.IsTrue(page.dropingContainerMessage.Displayed);
            Assert.AreEqual(beforeX, afterX);
            Assert.AreEqual(beforeY, afterY);

        }

        [Test]
        [Property("Droppable", 3)]
        [Property("InteractionPage", 3)]
        public void NotRevertWhenOutsideElement()
        {
            var page = new DroppablePage(driver);
            page.NavigateToDroppable();
            page.revertDraggablePositionBTN.Click();
            int beforeX = page.revertWhenDropped.Location.X;
            int beforeY = page.revertWhenDropped.Location.Y;
            builder.DragAndDropToOffset(page.revertWhenDropped, 121, 159).Perform();
            int afterX = page.revertWhenDropped.Location.X;
            int afterY = page.revertWhenDropped.Location.Y;
            Assert.AreNotEqual(beforeX, afterX);
            Assert.AreNotEqual(beforeY, afterY);

        }

        [Test]
        [Property("Droppable", 3)]
        [Property("InteractionPage", 3)]
        public void RevertWhenNotDropped()
        {
            var page = new DroppablePage(driver);
            page.NavigateToDroppable();
            page.revertDraggablePositionBTN.Click();
            int beforeX = page.revertWhenNotDropped.Location.X;
            int beforeY = page.revertWhenNotDropped.Location.Y;
            builder.DragAndDrop(page.revertWhenNotDropped, page.dropingContainer).Perform();
            int afterX = page.revertWhenNotDropped.Location.X;
            int afterY = page.revertWhenNotDropped.Location.Y;
            Assert.IsTrue(page.dropingContainerMessage.Displayed);
            Assert.AreNotEqual(beforeX, afterX);
            Assert.AreNotEqual(beforeY, afterY);
        }

        [Test]
        [Property("Droppable", 3)]
        [Property("InteractionPage", 3)]
        public void RevertWhenOutsideElement()
        {
            var page = new DroppablePage(driver);
            page.NavigateToDroppable();
            page.revertDraggablePositionBTN.Click();
            int beforeX = page.revertWhenNotDropped.Location.X;
            int beforeY = page.revertWhenNotDropped.Location.Y;
            builder.DragAndDropToOffset(page.revertWhenNotDropped, 121, 159).Perform();
            int afterX = page.revertWhenNotDropped.Location.X;
            int afterY = page.revertWhenNotDropped.Location.Y;
            Assert.AreNotEqual(beforeX, afterX);
            Assert.AreNotEqual(beforeY, afterY);

        }
    }
}
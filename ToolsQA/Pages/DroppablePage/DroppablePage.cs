using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages.DroppablePage
{
    class DroppablePage : BasePage
    {
        public DroppablePage(IWebDriver driver) : base(driver)
        { }

        public IWebElement DraggableElement
        {
            get
            { return this.Driver.FindElement(By.XPath("//*[@id=\"draggableview\"]/p")); }
        }

        public IWebElement DropElement
        {
            get
            { return this.Driver.FindElement(By.Id("droppableview")); }
        }

        public IWebElement DroppedMessge
        {
            get
            { return this.Driver.FindElement(By.XPath("//*[@id=\"droppableview\"]/p")); }
        }

        public IWebElement AcceptDropElement
        {
            get
            { return this.Driver.FindElement(By.Id("droppableaccept")); }
        }

        public IWebElement AcceptDroppedMessge
        {
            get
            { return this.Driver.FindElement(By.XPath("//*[@id=\"droppableaccept\"]/p")); }
        }

        public IWebElement AcceptBTN
        {
            get
            { return this.Driver.FindElement(By.Id("ui-id-2")); }
        }

        public IWebElement elementCanNotBeDropped
        {
            get
            { return this.Driver.FindElement(By.Id("draggable-nonvalid")); }
        }

        public IWebElement revertDraggablePositionBTN
        {
            get {
                return this.Driver.FindElement(By.Id("ui-id-4"));
            }
        }

        public IWebElement revertWhenDropped
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggablerevert"));
            }
        }

        public IWebElement revertWhenNotDropped
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggablerevert2"));
            }
        }

        public IWebElement dropingContainer
        {
            get
            {
                return this.Driver.FindElement(By.Id("droppablerevert"));
            }
        }

        public IWebElement dropingContainerMessage
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"droppablerevert\"]/p"));
            }
        }

        public void NavigateToDroppable()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/droppable/");
        }
    }
}

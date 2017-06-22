using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages.DraggablePage
{
    public class DraggablePage : BasePage
    {
        public DraggablePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement elementDragMeAround
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggable"));
            }
        }

        public IWebElement constrainMovementBTN
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
        }

        public IWebElement elementToDragVertically
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl"));
            }
        }

        public IWebElement elementToDragHorizontally
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl2"));
            }
        }

        public IWebElement elementContainer
        {
            get
            {
                return this.Driver.FindElement(By.Id("containment-wrapper"));
            }
        }


        public IWebElement elementContainedInABox
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl3"));
            }
        }

        public IWebElement elementConstrainedInParent
        {
            get
            {
                return this.Driver.FindElement(By.Id("draggabl5"));
            }
        }


        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/draggable/");
        }

    }
}

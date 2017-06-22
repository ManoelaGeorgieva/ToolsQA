using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages.ResizablePage
{
    public class ResizablePage :BasePage
    {
        public ResizablePage(IWebDriver driver) : base(driver)
        { }

        public string URL
        {
            get
            {
                return base.url + "resizable/";
            }
        }

        public void NavigateToResizable()
        {
            this.Driver.Navigate().GoToUrl(this.URL);
        }

        public IWebElement ElementToResize
        {
            get
            { return this.Driver.FindElement(By.Id("resizable")); }
        }

        public IWebElement ResizeArrow
        {
            get
            { return this.Driver.FindElement(By.XPath("//*[@id=\"resizable\"]/div[3]")); }
        }

        public IWebElement ConstrainedResizeArrow
        {
            get
            { return this.Driver.FindElement(By.XPath("//*[@id=\"resizableconstrain\"]/div[3]")); }
        }

        public IWebElement constrainResizeAreaBTN
        {
            get
            { return this.Driver.FindElement(By.Id("ui-id-3")); }
        }

        public IWebElement constrainResizableElement
        {
            get
            { return this.Driver.FindElement(By.Id("resizableconstrain")); }
        }

        public IWebElement constrainContainer
        {
            get
            { return this.Driver.FindElement(By.Id("container1")); }
        }

        public IWebElement MinMaxBtn
        {
            get
            { return this.Driver.FindElement(By.Id("ui-id-5")); }
        }

        public IWebElement elementMinMax
        {
            get
            { return this.Driver.FindElement(By.Id("resizable_max_min")); }
        }

        public IWebElement arrowMinMax
        {
            get
            { return this.Driver.FindElement(By.XPath("//*[@id=\"resizable_max_min\"]/div[3]")); }
        }
    }
}

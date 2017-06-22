using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages.SortablePage
{
    public partial class SortablePage
    {
        public List<IWebElement> AllItems
        {
            get
            {
                return this.Driver.FindElements(By.ClassName("ui-sortable")).ToList();
            }
        }
        public IWebElement FirstItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[1]"));
            }
        }
        public IWebElement SecondItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[2]"));
            }
        }

        public IWebElement ThirdItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[3]"));
            }
        }

        public IWebElement ForthItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[4]"));
            }
        }

        public IWebElement FifthItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[5]"));
            }
        }

        public IWebElement SixthItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[6]"));
            }
        }

        public IWebElement SeventhItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable\"]/li[7]/span"));
            }
        }

        public IWebElement ConnectedListsBtn
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
        }
        public IWebElement LeftItem1
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable1\"]/li[1]"));
            }
        }
        public IWebElement RightItem1
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"sortable2\"]/li[1]"));
            }
        }
    }
}

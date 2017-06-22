using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;


namespace ToolsQA.Pages.SelectablePage
{
    public partial class SelectablePage
    {
        
        public IWebElement FirstItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[1]"));
            }
        }

        public IWebElement SecondItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[2]"));
            }
        }

        public IWebElement ThirdItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[3]"));
            }
        }

        public IWebElement ForthItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[4]"));
            }
        }

        public IWebElement FifthItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[5]"));
            }
        }

        public IWebElement SixthItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[6]"));
            }
        }

        public IWebElement SeventhItem
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable\"]/li[7]"));
            }
        }

        public IWebElement GridBTN
        {
            get
            {
                return this.Driver.FindElement(By.Id("ui-id-2"));
            }
        }

        public IWebElement GridItem1
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[1]"));
            }
        }

        public IWebElement GridItem2
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[2]"));
            }
        }

        public IWebElement GridItem3
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[3]"));
            }
        }

        public IWebElement GridItem4
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[4]"));
            }
        }
        public IWebElement GridItem5
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[5]"));
            }
        }
        public IWebElement GridItem6
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[6]"));
            }
        } 
            
            public IWebElement GridItem7
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[7]"));
            }
        }
        public IWebElement GridItem8
        {
            get
            {
                return this.Driver.FindElement(By.XPath("//*[@id=\"selectable_grid\"]/li[8]"));
            }
        }
    
    }
}

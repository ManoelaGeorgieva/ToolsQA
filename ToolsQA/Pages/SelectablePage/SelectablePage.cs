using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages.SelectablePage
{
    public partial class SelectablePage : BasePage
    {
        public SelectablePage(IWebDriver driver) : base(driver)
        {
        }

        public void GoToSelectable()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/selectable/");
        }

        public bool ISSelected(IWebElement elementToCheck)
        {
            bool isSelected = false;
            string sample = elementToCheck.GetAttribute("class");
            if (sample.Contains("selected"))
            {
                isSelected = true;
            }
            return isSelected;
        }

        public bool AreAllSelected()
        {
            List<IWebElement> allItems = new List<IWebElement>
            { FirstItem, SecondItem, ThirdItem, ForthItem, FifthItem, SixthItem, SeventhItem };
            bool isSelected = false;
            foreach (var item in allItems)
            {
                string sample = item.GetAttribute("class");
                if (sample.Contains("selected"))
                {
                    isSelected = true;
                }
            }
            return isSelected;
        }
    }
}

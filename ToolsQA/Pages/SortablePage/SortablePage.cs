using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace ToolsQA.Pages.SortablePage
{
    public partial class SortablePage : BasePage
    {
        public SortablePage(IWebDriver driver) : base(driver)
        {
        }
        public void GoToSortable()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/sortable/");
        }

        public int Position(List<IWebElement> allItems, string textNeeded)
        {
            int position = 0;

            string itemText = allItems[0].Text;

            char[] delimiterChars = { '\n', '\r' };
            string[] order = itemText.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < order.Length; i++)
            {
                if (order[i].Contains(textNeeded))
                {
                    position = i;
                    break;
                }

            }

            return position + 1;
        }
    }
}

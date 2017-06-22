using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using ToolsQA.Models;

namespace ToolsQA.Pages.RegistrationPage
{
    public partial class RegistrationPage : BasePage
    {
        public RegistrationPage(IWebDriver driver) : base(driver)
        {
        }
        public void NavigateTo()
        {
            this.Driver.Navigate().GoToUrl("http://demoqa.com/registration/");
        }

        public void FillRegistrationForm(RegistrationUser user)
        {
            Type(this.FirstName, user.FirstName);
            Type(this.LastName, user.LastName);
            ClickOnElements(this.MaritalStatus, user.MaritalStatus);
            ClickOnElements(this.Hobbys, user.Hobbys);
            this.CountryOption.SelectByText(user.Country);
            this.MounthOption.SelectByText(user.BirthMonth);
            this.DayOption.SelectByText(user.BirthDay);
            this.YearOption.SelectByText(user.BirthYear);
            Type(this.Phone, user.Phone);
            Type(this.UserName, user.UserName);
            Type(this.Email, user.Email);
            Type(this.Description, user.Description);
            Type(this.Password, user.Password);
            Type(this.ConfirmPassword, user.ConfirmPassword);

        }

        public void SelectPicture(string Picture)
        {
            if (Picture == null)
            {

            }
            else
            {
                this.UploadButton.Click();
                this.Driver.SwitchTo().ActiveElement().SendKeys(Picture);
            }

        }

        public void SubmitRegistrationForm()
        {
            this.SubmitButton.Click();
        }

        private void ClickOnElements(List<IWebElement> elements, string conditions)
        {

            for (int i = 0; i < conditions.Length; i++)
            {
                if (conditions[i] == '1')
                {
                    elements[i].Click();
                }
            }
        }

        private void Type(IWebElement element, string text)
        {
            if (text == null)
            {
                element.SendKeys(string.Empty);
            }
            else
            {
                element.Clear();
                element.SendKeys(text);
            }
        }
    }
}

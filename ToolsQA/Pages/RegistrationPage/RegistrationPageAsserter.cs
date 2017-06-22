using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsQA.Pages.RegistrationPage
{
    public static class RegistrationPageAsserter
    {
        public static void AssertRegistrationPageIsOpen(this RegistrationPage page, string text)
        {
            Assert.AreEqual(text, page.Header.Text);
        }

        public static void AssesrtSuccessMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.RegistrationSuccessMessage.Displayed);
            Assert.AreEqual(text, page.RegistrationSuccessMessage.Text);
        }

        public static void AssertNamesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForNames.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForNames.Text);
        }

        public static void AssertHobbiesErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForHobby.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForHobby.Text);
        }


        public static void AssertPhoneErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessagesForPhone.Displayed);
            StringAssert.Contains(text, page.ErrorMessagesForPhone.Text);
        }

        public static void AssertUsernameErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageforUsername.Displayed);
            StringAssert.Contains(text, page.ErrorMessageforUsername.Text);
        }

        public static void AssertEmailErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageforEmail.Displayed);
            StringAssert.Contains(text, page.ErrorMessageforEmail.Text);
        }

        public static void AssertPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageforPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageforPassword.Text);
        }

        public static void AssertConfirmPasswordErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.ErrorMessageforConfirmPassword.Displayed);
            StringAssert.Contains(text, page.ErrorMessageforConfirmPassword.Text);
        }

        public static void AssertRegistrationErrorMessage(this RegistrationPage page, string text)
        {
            Assert.IsTrue(page.RegistrationErrorMessage.Displayed);
            StringAssert.Contains(text, page.RegistrationErrorMessage.Text);
        }
        
    }
}

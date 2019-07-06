using OpenQA.Selenium;
using RelevantCodes.ExtentReports;
using SpecflowPages;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using static SpecflowPages.CommonMethods;

namespace SpecflowTests
{
    [Binding]
    public class AddLanguage1Steps :Utils.Start
   
    {
        [Given(@"I clicked on the Language tab under the Profile page")]
        public void GivenIClickedOnTheLanguageTabUnderTheProfilePage()
        {
            //Wait
            Thread.Sleep(1500);

            // Click on Profile tab
            Driver.driver.FindElement(By.XPath("//a[starts-with(text(),'Profile') and @class='item']")).Click();
            Thread.Sleep(1500);

            // Clear all entries
            //Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody/tr/td[3]/span[2]")).Click();

            //Click on Add New button
            Driver.driver.FindElement(By.XPath("//thead//tr[1]//th[3]//div[contains(text(), 'Add New') and @class='ui teal button ']")).Click();

        }

        [When(@"Fill the form by using ""(.*)"" and ""(.*)""")]
        public void WhenFillTheFormByUsingAnd(string language, string level)
        {
            Driver.driver.FindElement(By.XPath("//input[@name='name']")).SendKeys(language);
            Driver.driver.FindElement(By.XPath("//select[@name='level']")).SendKeys(level);
            Driver.driver.FindElement(By.XPath("//input[@value='Add']")).Click();
        }
        
        [Then(@"added language should be displayed on my listings")]
        public void ThenAddedLanguageShouldBeDisplayedOnMyListings()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Language");

                Thread.Sleep(1000);
                string ExpectedValue = "language";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[2]/div/div/div/div[3]/form/div[2]/div/div[2]/div/table/tbody[1]/tr/td[1'")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    test.Log(LogStatus.Pass, "Test Passed, Added a Language Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "LanguageAdded");
                }

                else
                    CommonMethods.test.Log(LogStatus.Fail, "Test Failed");

            }
            catch (Exception e)
            {
                CommonMethods.test.Log(LogStatus.Fail, "Test Failed", e.Message);
            }

        }
    }
}

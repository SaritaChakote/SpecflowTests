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
    public class ShareSkillPageSteps 
    {
        [Given(@"I have logged in to skillswap\.")]
        public void GivenIHaveLoggedInToSkillswap_()
        {
            // Click on profile tab
            Driver.driver.FindElement(By.XPath("//*[@id='account-profile-section']/div/section[1]/div/a[2]")).Click();
            Thread.Sleep(3000);
        }
        
        [Given(@"I added my profile")]
        public void GivenIAddedMyProfile()
        {
            // Click on Share Skill Page
            Driver.driver.FindElement(By.XPath("/html/body/div[1]/div/section[1]/div/div[2]/a")).Click();
            Thread.Sleep(3000);
        }
        
        [When(@"I am adding new skill on share skill page")]
        public void WhenIAmAddingNewSkillOnShareSkillPage()
        {
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[1]/div/div[2]/div/div[1]/input")).SendKeys("Manual Testing");
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[2]/div/div[2]/div[1]/textarea")).SendKeys("I have experience in Manual Testing.");
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[1]/select/option[7]")).Click();
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[3]/div[2]/div/div[2]/div[1]/select/option[5]")).Click();
            IWebElement Category = Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
            Category.SendKeys("QA");
            Category.Click();
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[5]/div[2]/div[1]/div[1]/div/label")).Click();
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[6]/div[2]/div/div[1]/div/label")).Click();
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[2]/input")).SendKeys("20/06/2019");
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[1]/div[4]/input")).SendKeys("30/06/2019");
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[2]/input")).SendKeys("0900am");
            Driver.driver.FindElement(By.XPath("//*[@id='service-listing-section']/div[2]/div/form/div[7]/div[2]/div/div[2]/div[3]/input")).SendKeys("0500pm");
            Driver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input")).Click();
            Driver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")).SendKeys("QA");
            Driver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input")).Click();
            Driver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input")).Click();
            Driver.driver.FindElement(By.XPath("/html/body/div/div/div[1]/div[2]/div/form/div[11]/div/input[1]")).Click();
        }
        
        [Then(@"The skill should get added on Managed listing page")]
        public void ThenTheSkillShouldGetAddedOnManagedListingPage()
        {
            try
            {
                //Start the Reports
                CommonMethods.ExtentReports();
                Thread.Sleep(1000);
                CommonMethods.test = CommonMethods.extent.StartTest("Add a Skill on ShareSkill page");

                Thread.Sleep(1000);
                string ExpectedValue = "Manual Testing";
                string ActualValue = Driver.driver.FindElement(By.XPath("//*[@id='listing-management-section']/div[2]/div[1]/table/tbody/tr/td[3]")).Text;
                Thread.Sleep(500);
                if (ExpectedValue == ActualValue)
                {
                    CommonMethods.test.Log(LogStatus.Pass, "Test Passed, Added a Skill Successfully");
                    SaveScreenShotClass.SaveScreenshot(Driver.driver, "SkillAdded");
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


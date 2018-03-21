using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;

namespace Teste_Automatizado
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.bing.com");

            IWebElement campoDeTexto =  driver.FindElement(By.Name("q"));
            campoDeTexto.SendKeys("Caelum");

            campoDeTexto.Submit();
            driver.Close();
        }
    }
}

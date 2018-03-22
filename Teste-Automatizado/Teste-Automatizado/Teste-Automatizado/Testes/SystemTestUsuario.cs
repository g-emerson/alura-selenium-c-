using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace Teste_Automatizado.Testes
{
    [TestFixture]
    class SystemTestUsuario
    {
        IWebDriver driver;

        [SetUp]
        public void AntesDosTestes()
        {
            driver = new FirefoxDriver();
        }

        [TearDown]
        public void DepoisDosTestes()
        {
            driver.Close();
        }

        [Test]
        public void deveCadastrarUsuario()
        {           
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("Usuario 1 nome");
            campoEmail.SendKeys("email@user.com");

            btnSalvar.Click();

            bool achouNome = driver.PageSource.Contains("Usuario 1 nome");
            bool achouEmail = driver.PageSource.Contains("email@user.com");

            Assert.IsTrue(achouNome);
            Assert.IsTrue(achouEmail);

         }

        [Test]
        public void deveValidarNomeCadastrarUsuario()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios/new");

            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys("");
            campoEmail.SendKeys("");

            btnSalvar.Click();

            bool mensagemNome = driver.PageSource.Contains("Nome obrigatorio!");
            bool mensagemEmail = driver.PageSource.Contains("E-mail obrigatorio!");

            Assert.IsTrue(mensagemNome);
            Assert.IsTrue(mensagemEmail);

          }

        [Test]
        public void deveValidarLinkNovoUsuario()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");

            IWebElement linkNovoUser = driver.FindElement(By.LinkText("Novo Usuário"));

            linkNovoUser.Click();

            bool achouCampoNome = driver.PageSource.Contains("Nome:");

            Assert.IsTrue(achouCampoNome);
        }
    }
}

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Teste_Automatizado.Pages;

namespace Teste_Automatizado.Testes
{
    [TestFixture]
    class SystemTestUsuario
    {    
        private PageUsuario usuarios;
        IWebDriver driver;


        public SystemTestUsuario()
        {
            driver = new FirefoxDriver();
            usuarios = new PageUsuario(driver);
        }

        [SetUp]
        public void AntesDosTestes()
        {
         // driver = new FirefoxDriver();
        }

        [TearDown]
        public void DepoisDosTestes()
        {
            driver.Close();
        }

        [Test]
        public void deveCadastrarUsuario()
        {
            usuarios.Visita();
            usuarios.Novo().Cadastra("Testes nome", "Emai@user.com");

            Assert.IsTrue(usuarios.ExisteNaListagem("Testes nome", "Emai@user.com"));
        }
        /*
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
        */
    }
}

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
             driver = new FirefoxDriver();
        }

        [TearDown]
        public void DepoisDosTestes()
        {
            //driver.Close();
        }

        [Test]
        public void deveCadastrarUsuario()
        {
            usuarios.Visita();
            usuarios.Novo().Cadastra("Testes nome", "Emai@user.com");

            Assert.IsTrue(usuarios.ExisteNaListagem("Testes nome", "Emai@user.com"));
        }
        
        [Test]
        public void deveValidarNomeCadastrarUsuario()
        {
            usuarios.Visita();
            PageNovoUsuario teste = usuarios.Novo();
            teste.Cadastra("", "email.com");
            
            Assert.IsTrue(teste.ValidaNomeObrigadotio());      
          }

        [Test]
        public void deveValidarEmailCadastrarUsuario()
        {
            usuarios.Visita();
            PageNovoUsuario teste = usuarios.Novo();
            teste.Cadastra("nome", "");

            Assert.IsTrue(teste.ValidaEmailObrigadotio());
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

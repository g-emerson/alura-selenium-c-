using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using Teste_Automatizado.Pages;
using OpenQA.Selenium.Support.UI;

namespace Teste_Automatizado.Testes
{
    [TestFixture]
    class SystemTestUsuario
    {    
        private PageUsuario usuarios;
        IWebDriver driver;
        
         [SetUp]
        public void AntesDosTestes()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/apenas-teste/limpa");
            usuarios = new PageUsuario(driver);

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

        [Test]
        public void deveExcluirUsuario()
        {
            usuarios.Visita();
            usuarios.Novo().Cadastra("Usuario Excluir", "Emai@user.com");
            Assert.IsTrue(usuarios.ExisteNaListagem("Usuario Excluir", "Emai@user.com"));

            usuarios.Exclui(1);
            usuarios.Novo();
            usuarios.Visita();
            
            Assert.IsFalse(usuarios.ExisteNaListagem("Usuario Excluir", "Emai@user.com"));
        }        

        [Test]
        public void deveEditarUsuario()
        {
            usuarios.Visita();
            usuarios.Novo().Cadastra("Usuario Editar", "email@editar.com.br");

            usuarios.Visita();
            usuarios.EditarDadosUsuario(1).Editar("Usuario Modificado", "email@modificado.com.br");
            Assert.IsFalse(usuarios.ExisteNaListagem("Usuario Editar", "email@editar.com.br"));
            Assert.IsTrue(usuarios.ExisteNaListagem("Usuario Modificado", "email@modificado.com.br"));
        }


    }
}

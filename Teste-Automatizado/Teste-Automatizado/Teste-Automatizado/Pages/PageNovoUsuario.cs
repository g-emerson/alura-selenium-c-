using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Automatizado.Pages
{
    public class PageNovoUsuario
    {

        IWebDriver driver;
        public PageNovoUsuario(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Cadastra(String nome, String email)
        {
            IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
            IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
            IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));

            campoNome.SendKeys(nome);
            campoEmail.SendKeys(email);
            btnSalvar.Click();
        }

        public bool ValidaNomeObrigadotio()
        {
          // IWebElement campoNome = driver.FindElement(By.Name("usuario.nome"));
          // IWebElement campoEmail = driver.FindElement(By.Name("usuario.email"));
          // IWebElement btnSalvar = driver.FindElement(By.Id("btnSalvar"));
          //
          // campoNome.SendKeys(nome);
          // campoEmail.SendKeys(email);
          // btnSalvar.Click();

            bool mensagemNome = driver.PageSource.Contains("Nome obrigatorio!");
  
            return mensagemNome;
        }

        public bool ValidaEmailObrigadotio()
        {
            bool mensagemEmail = driver.PageSource.Contains("E-mail obrigatorio!");

            return mensagemEmail;
        }

    }
}

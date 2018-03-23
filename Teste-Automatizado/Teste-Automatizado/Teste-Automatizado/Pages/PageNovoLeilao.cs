using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Automatizado.Pages
{
    class PageNovoLeilao
    {
        IWebDriver driver;
        public PageNovoLeilao(IWebDriver driver)
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

using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Automatizado.Pages
{
    public class PageUsuario
    {
        IWebDriver driver;
        public PageUsuario(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PageNovoUsuario Novo()
        {
            driver.FindElement(By.LinkText("Novo Usuário")).Click();

            return new PageNovoUsuario(driver);
        }

        public bool ExisteNaListagem(String nome, String email)
        {
            bool achouNome = driver.PageSource.Contains(nome);
            bool achouEmail = driver.PageSource.Contains(email);

            return achouEmail && achouEmail;
        }

        public void Visita()
        {
            driver.Navigate().GoToUrl("http://localhost:8080/usuarios");
        }

    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Automatizado.Pages
{
    class PageLeiloes
    {
        IWebDriver driver;
        public PageLeiloes(IWebDriver driver)
        {
            this.driver = driver;
        }

        public PageNovoLeilao Novo()
        {
            driver.FindElement(By.LinkText("Novo Leilão")).Click();

            return new PageNovoLeilao(driver);
        }

        public void Visita()
        {
                driver.Navigate().GoToUrl("http://localhost:8080/leiloes");
        }


        public bool existe(string produto, double valor, string usuario, bool usado)
        {
            return driver.PageSource.Contains(produto) &&
                    driver.PageSource.Contains(Convert.ToString(valor)) &&
                    driver.PageSource.Contains(usuario) &&
                    driver.PageSource.Contains(usado ? "Sim" : "Não");
        }
        public bool ExisteNaListagem(string nome, double preco, String usuario, bool usado)
        {//"Produto", 300, "Usuario", true
            return driver.PageSource.Contains(nome) &&
                      driver.PageSource.Contains(Convert.ToString(preco)) &&
                      driver.PageSource.Contains(usuario) &&
                      driver.PageSource.Contains(usado ? "Sim" : "Não");
        }

        public void Exclui(int posicao)
        {
            driver.FindElements(By.TagName("button"))[posicao - 1].Click();

            // pega o alert que está aberto
            IAlert alert = driver.SwitchTo().Alert();
            // confirma
            alert.Accept();
        }
    }
}

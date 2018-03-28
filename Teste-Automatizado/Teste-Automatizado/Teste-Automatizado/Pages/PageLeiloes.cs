using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Automatizado.Testes;

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
                driver.Navigate().GoToUrl(new URLDaAplicacao().GetUrlBase() + "/leiloes");
        }
              
        public bool ExisteNaListagem(string nome, double preco, String usuario, bool usado)
        {//"Produto", 300, "Usuario", true
            return driver.PageSource.Contains(nome) &&
                      driver.PageSource.Contains(Convert.ToString(preco)) &&
                      driver.PageSource.Contains(usuario) &&
                      driver.PageSource.Contains(usado ? "Sim" : "Não");
        }

        public PageDetalhesLeilao Detalhes(int posicao)
        {
            driver.FindElements(By.LinkText("exibir"))[posicao - 1].Click();
            return new PageDetalhesLeilao(driver);

        }
    }
}

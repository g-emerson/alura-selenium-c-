using OpenQA.Selenium;
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
        
        public bool ExisteNaListagem(String nome, String preco, String usuario, String  usado)
        {//"Produto", 300, "Usuario", true
            bool achouNome = driver.PageSource.Contains(nome);
            bool achouValor = driver.PageSource.Contains(preco);
            bool achouUsuario = driver.PageSource.Contains(usuario);
            bool achouUsado = driver.PageSource.Contains(usado);


            return achouEmail && achouEmail;
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

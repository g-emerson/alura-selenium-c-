using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        public void Cadastra(String nome, int preco, String usuario, bool usado)
        {
            IWebElement campoNome = driver.FindElement(By.Name("leilao.nome"));
            IWebElement campoValorInicial = driver.FindElement(By.Name("leilao.valorInicial"));
            IWebElement checkUsado = driver.FindElement(By.Name("leilao.usado"));
            SelectElement cbUsuario = new SelectElement(driver.FindElement(By.Name("leilao.usuario.id")));

            campoNome.SendKeys(nome);
            campoValorInicial.SendKeys(preco.ToString());
            cbUsuario.SelectByText(usuario);

            if (usado)
            {
                checkUsado.Click();
            }

            campoValorInicial.Submit();
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

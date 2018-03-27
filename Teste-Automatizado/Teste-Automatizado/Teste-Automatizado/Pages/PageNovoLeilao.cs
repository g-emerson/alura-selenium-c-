using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
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
            IWebElement btnSalvar = driver.FindElement(By.TagName("button"));

            campoNome.SendKeys(nome);
            campoValorInicial.SendKeys(preco.ToString());
            cbUsuario.SelectByText(usuario);

            if (usado)
            {
                checkUsado.Click();
            }

            btnSalvar.Click();
        }

        public bool validaNomeLeilaoObrigatorio()
        {
            
            bool mensagemNome = driver.PageSource.Contains("Nome obrigatorio!");


            return mensagemNome;
        }
       
        public bool validaLanceLeilaoObrigatorio()
        {
            return driver.PageSource.Contains("Valor inicial deve ser maior que zero!");
        }
        

    }
}

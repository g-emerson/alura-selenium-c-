using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Automatizado.Pages;

namespace Teste_Automatizado.Testes
{
    class CriadorDeCenarios
    {
        private IWebDriver driver;

        public CriadorDeCenarios(IWebDriver driver)
        {
            this.driver = driver;
        }

        public CriadorDeCenarios umUsuario(string nome, string email)
        {
            PageUsuario usuarios = new PageUsuario(driver);
            usuarios.Visita();
            usuarios.Novo().Cadastra(nome, email);

            return this;
        }

        public CriadorDeCenarios umLeilao(string usuario, string produto , double valor, bool usado)
        {
            PageLeiloes leiloes = new PageLeiloes(driver);
            leiloes.Visita();
            leiloes.Novo().Cadastra(produto, valor, usuario, usado);

            return this;
        }
    }
}

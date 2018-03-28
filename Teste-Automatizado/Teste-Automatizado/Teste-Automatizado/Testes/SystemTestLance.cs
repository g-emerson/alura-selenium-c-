using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_Automatizado.Pages;

namespace Teste_Automatizado.Testes
{
    [TestFixture]
    class SystemTestLance
    {
        private FirefoxDriver driver;
        private PageLeiloes leiloes;
        private PageUsuario usuarios;


        [SetUp]
        public void AntesDosTestes()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:8080/apenas-teste/limpa");
            leiloes = new PageLeiloes(driver);
            usuarios = new PageUsuario(driver);

            CriadorDeCenarios cenario = new CriadorDeCenarios(driver);
            cenario.umUsuario("Usuario 1 comprador", "comprador@user.com");
            cenario.umUsuario("Usuario Criado", "vendedor@user.com");
            cenario.umLeilao("Usuario Criado", "Geladeira", 100, false);

           // usuarios.Visita();
           // usuarios.Novo().Cadastra("Usuario 1 comprador", "comprador@user.com");
           // usuarios.Novo().Cadastra("Usuario 1 vendedor", "vendedor@user.com");
           // Assert.IsTrue(usuarios.ExisteNaListagem("Usuario 1 vendedor", "vendedor@user.com"));
           // leiloes.Visita();
           // leiloes.Novo().Cadastra("Produto", 300, "Usuario 1 vendedor", true);
        }

        [TearDown]
        public void DepoisDosTestes()
        {
            driver.Close();
        }

        [Test]
        public void DeveDarLance()
        {
            leiloes.Visita();
            PageDetalhesLeilao lances = leiloes.Detalhes(1);

            lances.Lance("Usuario 1 comprador", 150);
            Assert.IsTrue(lances.ExisteLance("Usuario 1 comprador", 150));                      
        }

    }
}

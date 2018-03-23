using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste_Automatizado.Testes
{
    [TestFixture]
    class SystemTestLeilao
    {
        public SystemTestLeilao()
        {
        }

        public void deveCadastrarUmLeilao()
        {
            leilao.Visita();

            leilao.Novo().Cadastra("Produto",300, "Usuario", true);

            leilao.ExisteNaListagem("Produto", 300, "Usuario", true);

        }
    }
}
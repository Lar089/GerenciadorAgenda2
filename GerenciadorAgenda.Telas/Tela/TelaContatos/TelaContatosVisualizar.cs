using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaContatos
{
    class TelaContatosVisualizar : TelaMenu
    {
        private TelaMenuContatos telaContatos;

        public TelaContatosVisualizar(TelaMenuContatos telaContatos) : base("Visualizar")
        {
            this.telaContatos = telaContatos;
        }

        public override TelaMenu Executar()
        {
            Console.Clear();
            telaContatos.VisualizarContatoss();

            Console.WriteLine("Nenhum Compromisso cadastrado");

            Pausar();

            return null;
        }
    }
}

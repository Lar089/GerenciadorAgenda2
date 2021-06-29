using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;
using GerenciadorAgenda.Telas.Tela.TelaContatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaCompromisso
{
    public class TelaCompromissoIdContatos : TelaMenu
    {
        private TelaMenuCompromisso telaCompromissoIdContatos;
        private TelaMenuContatos telaContatos;
        private ControladorContatos controladorContatos;
        public int IdContatos;

        public TelaCompromissoIdContatos(TelaMenuCompromisso telaCompromissoIdContatos) : base("Selecione o ID do Contato")
        {
            this.telaCompromissoIdContatos = telaCompromissoIdContatos;
            this.telaContatos = new TelaMenuContatos(controladorContatos);
        }

        public override TelaMenu Executar()
        {
            Console.Clear();
            if (!telaContatos.VerificarDependenciasContatos())
                return null;

            telaContatos.VisualizarContatoss();

            Console.Write("\nDigite o id do Contatos que você deseja selecionar: ");
            IdContatos = LerInt();

            Pausar();

            return null;
        }
    }
}

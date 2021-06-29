using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaContatos
{
    class TelaContatosEditar : TelaMenu
    {
        private TelaMenuContatos telaContatos;
        private ControladorContatos controladorContatos;

        public TelaContatosEditar(TelaMenuContatos telaContatos) : base("Editar")
        {
            this.telaContatos = telaContatos;
        }

        public override TelaMenu Executar()
        {
            if (!telaContatos.VerificarDependenciasContatos())
                return null;

            Console.Clear();

            telaContatos.VisualizarContatoss();
            Console.Write("\nDigite o id do Contatos que você deseja editar: ");
            int id = LerInt();

            Console.Write("Digite o nome do Contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o email do Contato: ");
            string email = Console.ReadLine();

            Console.Write("Digite o telefone do Contato: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite a empresa do Contato: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o cargo da pessoa do Contato: ");
            string cargoPessoa = Console.ReadLine();

            Contatos contato = new Contatos(nome, email, telefone, empresa, cargoPessoa);
            contato.Id = id;
            bool conseguiuEditar = controladorContatos.EditarRegistro(contato);

            if (conseguiuEditar)
                ImprimirMensagem("Tarefa alterada com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao alterar a tarefa", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}

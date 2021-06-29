using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaContatos
{
    class TelaContatosInserir : TelaMenu
    {
        private TelaMenuContatos telaContatos;
        private ControladorContatos controladorContatos;

        public TelaContatosInserir(TelaMenuContatos telaContatos) : base("Inserir")
        {
            this.telaContatos = telaContatos;
        }

        public override TelaMenu Executar()
        {
            Console.Clear();

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

            Console.WriteLine();
            bool conseguiuInserir = controladorContatos.InserirRegistro(contato);

            if (conseguiuInserir)
                ImprimirMensagem("Novo Contato criada com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao criar um novo Contato", TipoMensagem.ERRO);

            Pausar();
            return null;
        }
    }
}

using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaContatos
{
    public class TelaMenuContatos : TelaMenu
    {
        private readonly ControladorContatos controladorContatos;
        public TelaMenuContatos(ControladorContatos controladorContatos) : base("Tela de Contatos")
        {
            this.controladorContatos = controladorContatos;

            AdicionarOpcao(new TelaContatosInserir(this));
            AdicionarOpcao(new TelaContatosEditar(this));
            AdicionarOpcao(new TelaContatosExcluir(this));
            AdicionarOpcao(new TelaContatosVisualizar(this));
        }

        public bool VerificarDependenciasContatos()
        {
            if (controladorContatos.SelecionarTodosRegistros().Count == 0)
            {
                Console.Clear();
                Console.WriteLine();
                ImprimirMensagem("Nenhum Contatos cadastrado, por favor cadastre alguma", TipoMensagem.ERRO);
                Pausar();
                return false;
            }
            return true;
        }

        public void VisualizarContatoss()
        {
            string template = "{0, -3} | {1, -20} | {2, -25} | {3, -10} | {4, -15} | {5, -15}";

            Console.WriteLine(template, "Id", "Nome", "Email", "Telefone", "Empresa", "Cargo da Pessoa");
            Console.WriteLine();

            List<Contatos> Contatoss = controladorContatos.SelecionarTodosRegistros();

            if (Contatoss.Count == 0)
            {
                Console.WriteLine("Nenhum Contato cadastrada");
            }

            foreach (Contatos Contatos in Contatoss)
            {
                Console.WriteLine(template, Contatos.Id, Contatos.Nome,
                    Contatos.Email, Contatos.Telefone, Contatos.Empresa,
                    Contatos.Cargo);
            }
        }
    }
}

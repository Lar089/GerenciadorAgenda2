using GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaCompromisso
{
    class TelaCompromissoEditar : TelaMenu
    {
        private TelaMenuCompromisso telaCompromisso;
        private ControladorCompromisso controladorCompromisso;

        public TelaCompromissoEditar(TelaMenuCompromisso telaCompromisso) : base("Editar")
        {
            this.telaCompromisso = telaCompromisso;
        }

        public override TelaMenu Executar()
        {
            if (!telaCompromisso.VerificarDependenciasCompromisso())
                return null;

            Console.Clear();

            telaCompromisso.VisualizarCompromisso();
            Console.Write("\nDigite o id do Compromisso que você deseja editar: ");
            int id = LerInt();

            Console.Write("Digite o assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local do Compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data do Compromisso: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora inicial do Compromisso: ");
            string horaInicio = Convert.ToDateTime(Console.ReadLine()).ToString("HH:mm");

            Console.Write("Digite a hora de término do Compromisso: ");
            string horaTermino = Convert.ToDateTime(Console.ReadLine()).ToString("HH:mm");

            int idContatos = (new TelaCompromissoIdContatos(telaCompromisso).IdContatos);

            Compromisso compromisso = new Compromisso(assunto, local, data, horaInicio, horaTermino, idContatos);
            compromisso.Id = id;
            bool conseguiuEditar = controladorCompromisso.EditarRegistro(compromisso);

            if (conseguiuEditar)
                ImprimirMensagem("Compromisso alterado com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao alterar a Compromisso", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}

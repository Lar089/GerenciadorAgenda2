using GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaTarefas
{
    public class TelaTarefaEditar : TelaMenu
    {
        private TelaMenuTarefas telaTarefa;
        private ControladorTarefa controladorTarefa;

        public TelaTarefaEditar(TelaMenuTarefas telaTarefa) : base("Editar")
        {
            this.telaTarefa = telaTarefa;
            this.controladorTarefa = new ControladorTarefa();
        }

        public override TelaMenu Executar()
        {
            if (!telaTarefa.VerificarDependenciasTarefa())
                return null;

            Console.Clear();

            telaTarefa.VisualizarTarefas();
            Console.Write("\nDigite o id do Tarefa que você deseja editar: ");
            int id = LerInt();

            Console.Write("Digite o Titulo da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Percentual Concluido da Tarefa: ");
            int percentualConcluido = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a Prioridade da Tarefa:(Alta, Normal, Baixa) ");
            string prioridade = Console.ReadLine();

            Console.WriteLine();

            Tarefa tarefa = new Tarefa(titulo, percentualConcluido, controladorTarefa.DefinirPrioridade(prioridade));
            tarefa.Id = id;

            bool conseguiuEditar = controladorTarefa.InserirRegistro(tarefa);

            if (conseguiuEditar)
                ImprimirMensagem("Tarefa alterada com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao alterar a tarefa", TipoMensagem.ERRO);

            Pausar();
            return null;
        }
    }
}

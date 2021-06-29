using GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaTarefas
{
    public class TelaMenuTarefas : TelaMenu
    {
        private readonly ControladorTarefa controladorTarefa;

        public TelaMenuTarefas(ControladorTarefa controladorTarefa) : base("Tela de Tarefas")
        {
            this.controladorTarefa = controladorTarefa;

            AdicionarOpcao(new TelaTarefaInserir(this));
            AdicionarOpcao(new TelaTarefaEditar(this));
            AdicionarOpcao(new TelaTarefaExcluir(this));
            AdicionarOpcao(new TelaTarefaVisualizar(this));
        }

        public bool VerificarDependenciasTarefa()
        {
            if (controladorTarefa.SelecionarTodosRegistros().Count == 0)
            {
                Console.Clear();
                Console.WriteLine();
                ImprimirMensagem("Nenhum Tarefa cadastrado, por favor cadastre alguma", TipoMensagem.ERRO);
                Pausar();
                return false;
            }
            return true;
        }

        public void VisualizarTarefas()
        {
            string template = "{0, -3} | {1, -20} | {2, -15} | {3, -15} | {4, -10} | {5, -10}";

            Console.WriteLine(template, "Id", "Titulo", "Data de Criação", "Data de Conclusão", "Percentual de Concluido", "Prioridade");
            Console.WriteLine();

            List<Tarefa> tarefas = controladorTarefa.SelecionarTodosRegistros();

            if (tarefas.Count == 0)
            {
                Console.WriteLine("Nenhum Tarefa cadastrada");
            }

            foreach (Tarefa tarefa in tarefas)
            {
                Console.WriteLine(template, tarefa.Id, tarefa.Titulo,
                    tarefa.DataCriacao, tarefa.DataConclusao, tarefa.PercentualConcluido,
                    tarefa.Prioridade);
            }
        }
    }
}

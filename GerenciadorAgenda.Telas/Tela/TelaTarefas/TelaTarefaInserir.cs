using GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa;
using GerenciadorAgenda.Dominios.Dominio;
using System;

namespace GerenciadorAgenda.Telas.Tela.TelaTarefas
{
    public class TelaTarefaInserir : TelaMenu
    {
        private ControladorTarefa controladorTarefa;
        private TelaMenuTarefas telaTarefa;

        public TelaTarefaInserir(TelaMenuTarefas telaTarefa) : base("Inserir")
        {
            this.telaTarefa = telaTarefa;
            this.controladorTarefa = new ControladorTarefa();
        }

        public override TelaMenu Executar()
        {
            Console.Clear();

            Console.Write("Digite o Titulo da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite o Percentual Concluido da Tarefa: ");
            int percentualConcluido = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a Prioridade da Tarefa(Alta, Normal, Baixa): ");
            string prioridade = Console.ReadLine();

            Console.WriteLine();
            Tarefa tarefa = new Tarefa(titulo, percentualConcluido, controladorTarefa.DefinirPrioridade(prioridade));
            bool conseguiuInserir = controladorTarefa.InserirRegistro(tarefa);

            if (conseguiuInserir)
                ImprimirMensagem("Nova Tarefa criada com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao criar uma nova tarefa", TipoMensagem.ERRO);

            Pausar();
            return null;
        }
    }
}

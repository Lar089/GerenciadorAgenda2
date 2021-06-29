using System;

namespace GerenciadorAgenda.Telas.Tela.TelaTarefas
{
    public class TelaTarefaVisualizar : TelaMenu
    {
        private TelaMenuTarefas telaTarefa;

        public TelaTarefaVisualizar(TelaMenuTarefas telaTarefa) : base("Visualizar")
        {
            this.telaTarefa = telaTarefa;
        }

        public override TelaMenu Executar()
        {
            Console.Clear();
            telaTarefa.VisualizarTarefas();
            Pausar();

            return null;
        }
    }
}

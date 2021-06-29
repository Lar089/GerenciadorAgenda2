using GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa;
using System;

namespace GerenciadorAgenda.Telas.Tela.TelaTarefas
{
    public class TelaTarefaExcluir : TelaMenu
    {
        private TelaMenuTarefas telaTarefa;
        private ControladorTarefa controladorTarefa;

        public TelaTarefaExcluir(TelaMenuTarefas telaTarefa) : base("Excluir")
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
            Console.Write("\nDigite o id do Tarefa que deseja excluir: ");
            int id = LerInt();
            bool conseguiuExcluir = controladorTarefa.ExcluirRegistro(id);

            if (conseguiuExcluir)
                ImprimirMensagem("Tarefa excluida com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao excluir a tarefa", TipoMensagem.ERRO);


            Pausar();
            return null;
        }
    }
}

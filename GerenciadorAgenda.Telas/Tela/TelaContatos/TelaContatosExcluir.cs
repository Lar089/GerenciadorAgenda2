using System;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;

namespace GerenciadorAgenda.Telas.Tela.TelaContatos
{
    public class TelaContatosExcluir : TelaMenu
    {
        private TelaMenuContatos telaContatos;
        private ControladorContatos controladorContatos;

        public TelaContatosExcluir(TelaMenuContatos telaContatos) : base("Excluir")
        {
            this.telaContatos = telaContatos;
        }

        public override TelaMenu Executar()
        {
            if (!telaContatos.VerificarDependenciasContatos())
                return null;

            Console.Clear();
            telaContatos.VisualizarContatoss();
            Console.Write("\nDigite o id do Contatos que deseja excluir: ");
            int id = LerInt();

            bool conseguiuExcluir = controladorContatos.ExcluirRegistro(id);

            if (conseguiuExcluir)
                ImprimirMensagem("Tarefa excluida com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao excluir a tarefa", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}

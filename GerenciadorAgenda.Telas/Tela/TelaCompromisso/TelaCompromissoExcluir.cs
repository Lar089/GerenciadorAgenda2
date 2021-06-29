using GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaCompromisso
{
    public class TelaCompromissoExcluir : TelaMenu
    {
        private TelaMenuCompromisso telaCompromisso;
        private ControladorCompromisso controladorCompromisso;

        public TelaCompromissoExcluir(TelaMenuCompromisso telaCompromisso) : base("Excluir")
        {
            this.telaCompromisso = telaCompromisso;
        }

        public override TelaMenu Executar()
        {
            if (!telaCompromisso.VerificarDependenciasCompromisso())
                return null;

            Console.Clear();
            telaCompromisso.VisualizarCompromisso();
            Console.Write("\nDigite o id do Compromisso que deseja excluir: ");
            int id = LerInt();

            bool conseguiuExcluir = controladorCompromisso.ExcluirRegistro(id);

            if (conseguiuExcluir)
                ImprimirMensagem("Compromisso excluido com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao excluir o Compromisso", TipoMensagem.ERRO);

            Pausar();

            return null;
        }
    }
}

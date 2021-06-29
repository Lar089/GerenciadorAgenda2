using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaCompromisso
{
    public class TelaCompromissoVisualizar : TelaMenu
    {
        private TelaMenuCompromisso telaCompromisso;

        public TelaCompromissoVisualizar(TelaMenuCompromisso telaCompromisso) : base("Visualizar")
        {
            this.telaCompromisso = telaCompromisso;
        }

        public override TelaMenu Executar()
        {
            Console.Clear();
            telaCompromisso.VisualizarCompromisso();
            Pausar();

            return null;
        }
    }
}

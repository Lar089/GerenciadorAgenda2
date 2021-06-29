using GerenciadorAgenda.Telas.Menu;
using GerenciadorAgenda.Telas.Tela;
using System;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa;

namespace GerenciadorAgenda.Telas
{
    class Program
    {
        static void Main(string[] args)
        {
            ControladorTarefa controladorTarefa = new ControladorTarefa();
            ControladorContatos controladorContatos = new ControladorContatos();
            ControladorCompromisso controladorCompromisso = new ControladorCompromisso();
            TelaPrincipal principal = new TelaPrincipal(controladorTarefa, controladorContatos, controladorCompromisso);

            ExecutarMenu(principal);
        }

        private static void ExecutarMenu(TelaMenu menu)
        {
            while (true)
            {
                TelaMenu proximoMenu = menu.Executar();

                if (proximoMenu is OpcaoVoltar || proximoMenu == null)
                    break;

                ExecutarMenu(proximoMenu);
            }
        }
    }
}

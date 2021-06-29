using System;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos;
using GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa;
using GerenciadorAgenda.Telas.Tela.TelaCompromisso;
using GerenciadorAgenda.Telas.Tela.TelaContatos;
using GerenciadorAgenda.Telas.Tela.TelaTarefas;

namespace GerenciadorAgenda.Telas.Tela
{
    class TelaPrincipal : TelaMenu
    {
        public TelaPrincipal(ControladorTarefa controladorTarefa, ControladorContatos controladorContatos, ControladorCompromisso controladorCompromisso) 
            : base("Agenda Eletronica")
        {
            TelaMenuTarefas telaTarefa = new TelaMenuTarefas(controladorTarefa);
            TelaMenuContatos telaContatos = new TelaMenuContatos(controladorContatos);
            TelaMenuCompromisso telaCompromisso = new TelaMenuCompromisso(controladorCompromisso);

            AdicionarOpcao(telaTarefa);
            AdicionarOpcao(telaContatos);
            AdicionarOpcao(telaCompromisso);
        }
    }
}

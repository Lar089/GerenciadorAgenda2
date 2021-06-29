using GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;

namespace GerenciadorAgenda.Telas.Tela.TelaCompromisso
{
    public class TelaMenuCompromisso : TelaMenu
    {
        private readonly ControladorCompromisso controladorCompromisso;

        public TelaMenuCompromisso(ControladorCompromisso controladorCompromisso) : base("Tela de Compromisso")
        {
            this.controladorCompromisso = controladorCompromisso;

            AdicionarOpcao(new TelaCompromissoInserir(this));
            AdicionarOpcao(new TelaCompromissoEditar(this));
            AdicionarOpcao(new TelaCompromissoExcluir(this));
            AdicionarOpcao(new TelaCompromissoVisualizar(this));
        }

        public bool VerificarDependenciasCompromisso()
        {
            if (controladorCompromisso.SelecionarTodosRegistros().Count == 0)
            {
                Console.Clear();
                Console.WriteLine();
                ImprimirMensagem("Nenhum Compromisso cadastrado, por favor cadastre algum", TipoMensagem.ERRO);
                Pausar();
                return false;
            }
            return true;
        }

        public void VisualizarCompromisso()
        {
            string template = "{0, -3} | {1, -20} | {2, -15} | {3, -15} | {4, -10} | {5, -10} | {6, -3}";

            Console.WriteLine(template, "Id", "Assunto", "Local", "Data", "Hora de Inicio", "Hora de Término", "ID do Contado");
            Console.WriteLine();

            List<Compromisso> compromissos = controladorCompromisso.SelecionarTodosRegistros();

            if (compromissos.Count == 0)
            {
                Console.WriteLine("Nenhum Compromisso cadastrado");
            }

            foreach (Compromisso compromisso in compromissos)
            {
                Console.WriteLine(template, compromisso.Id, compromisso.Assunto, 
                    compromisso.Local, compromisso.Data.ToString("dd/MM/yyyy"), compromisso.HoraInicio, 
                    compromisso.HoraTermino, compromisso.IdContatos);
            }
        }
    }
}

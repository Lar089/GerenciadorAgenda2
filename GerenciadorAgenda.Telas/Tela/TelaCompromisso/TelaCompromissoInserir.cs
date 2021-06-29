using GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso;
using GerenciadorAgenda.Dominios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Telas.Tela.TelaCompromisso
{
    public class TelaCompromissoInserir : TelaMenu
    {
        private TelaMenuCompromisso telaCompromisso;
        private readonly ControladorCompromisso controladorCompromisso;
        TelaCompromissoIdContatos telaCompromissoIdContatos;

        public TelaCompromissoInserir(TelaMenuCompromisso telaCompromisso) : base("Inserir")
        {
            this.telaCompromisso = telaCompromisso;
            this.controladorCompromisso = new ControladorCompromisso();

            telaCompromissoIdContatos = new TelaCompromissoIdContatos(telaCompromisso);
            AdicionarOpcao(telaCompromissoIdContatos);
        }

        public override TelaMenu Executar()
        {
            Console.Clear();

            Console.Write("Digite o assunto do Compromisso: ");
            string assunto = Console.ReadLine();

            Console.Write("Digite o local do Compromisso: ");
            string local = Console.ReadLine();

            Console.Write("Digite a data do Compromisso: ");
            DateTime data = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a hora inicial do Compromisso: ");
            string horaInicio = Convert.ToDateTime(Console.ReadLine()).ToString("HH:mm");

            Console.Write("Digite a hora de término do Compromisso: ");
            string horaTermino = Convert.ToDateTime(Console.ReadLine()).ToString("HH:mm");

            
            int idContatos = telaCompromissoIdContatos.IdContatos; 

            Compromisso compromisso = new Compromisso(assunto, local, data, horaInicio, horaTermino, idContatos);
            
            bool conseguiuInserir = controladorCompromisso.InserirRegistro(compromisso);

            Console.WriteLine();

            if (conseguiuInserir)
                ImprimirMensagem("Novo Compromisso criado com sucesso", TipoMensagem.SUCESSO);
            else
                ImprimirMensagem("Erro ao criar um novo Compromisso", TipoMensagem.ERRO);

            Pausar();
            return null;
        }
    }
}

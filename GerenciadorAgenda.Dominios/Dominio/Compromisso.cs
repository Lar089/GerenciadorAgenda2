using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Dominios.Dominio
{
    public class Compromisso
    {
        private int id;
        private string assunto;
        private string local;
        private DateTime data;
        private string horaInicio;
        private string horaTermino;
        private int idContatos;

        public Compromisso(string assunto, string local, DateTime data,
            string horaInicio, string horaTermino, int idContatos)
        {
            this.Assunto = assunto;
            this.Local = local;
            this.Data = data;
            this.HoraInicio = horaInicio;
            this.HoraTermino = horaTermino;
            this.IdContatos = idContatos;
        }

        public int Id { get => id; set => id = value; }
        public string Assunto { get => assunto; set => assunto = value; }
        public string Local { get => local; set => local = value; }
        public DateTime Data { get => data; set => data = value; }
        public string HoraInicio { get => horaInicio; set => horaInicio = value; }
        public string HoraTermino { get => horaTermino; set => horaTermino = value; }
        public int IdContatos { get => idContatos; set => idContatos = value; }
    }
}

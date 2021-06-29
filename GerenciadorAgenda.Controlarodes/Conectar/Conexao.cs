using System;
using System.Data.SqlClient;

namespace GerenciadorAgenda.Controlarodes.Conectar
{
    class Conexao
    {
        private readonly string enderecoDBAgenda =
          @"Data Source=(LocalDb)\MSSqlLocalDB;Initial Catalog=DBTarefa;Integrated Security=True;Pooling=False";

        private SqlConnection conexaoComBanco;
        
        public Conexao()
        {
            conexaoComBanco = new SqlConnection(enderecoDBAgenda);
        }

        public void AbrirConexão(Action<SqlConnection> action)
        {
            conexaoComBanco.Open();

            action(conexaoComBanco);

            conexaoComBanco.Close();
        }


    }
}

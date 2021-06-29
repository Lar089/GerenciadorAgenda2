using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Controlarodes.Controladores.ControladoresTarefa
{
    public class SqlTarefa
    {

		public string SqlInsersao = @"INSERT INTO TBTarefa 
	                            (
		                            [titulo], 
		                            [dataCriacao], 
		                            [dataConclusao],
		                            [percentualConcluido],
		                            [prioridade]
	                            ) 
	                            VALUES
	                            (
                                    @titulo, 
		                            @dataCriacao, 
		                            @dataConclusao,
		                            @percentualConcluido,
		                            @prioridade
	                            );";

		public string SqlEdicao = @"UPDATE TBTarefa
	                            SET	
		                            [titulo] = @titulo, 
		                            [dataCriacao] = @dataCriacao, 
		                            [dataConclusao] = @dataConclusao,
		                            [percentualConcluido] = @percentualConcluido,
		                            [prioridade] = @prioridade
	                            WHERE
	                                [id] = @id";

		public string SqlExclusao = @"DELETE FROM TBTarefa
	                            WHERE
	                                [id] = @id";

		public string SqlVisualizacaoPorId = @"SELECT  
                                    [id],
		                            [titulo], 
		                            [dataCriacao], 
		                            [dataConclusao],
		                            [percentualConcluido],
		                            [prioridade]
	                            FROM
                                    TBTarefa
                                WHERE
                                    [id] = @id";

		public string SqlVisualizacaoTodos = @"SELECT
                                    [id],
                                    [titulo], 
		                            [dataCriacao], 
		                            [dataConclusao],
		                            [percentualConcluido],
		                            [prioridade]
	                            FROM
                                    TBTarefa";
	}
}

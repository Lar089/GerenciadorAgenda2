using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Controlarodes.Controladores.ControladoresContatos
{
    public class SqlContatos
    {
		public string SqlInsersao = @"INSERT INTO TBContatos 
	                            (
		                            [nome], 
		                            [email], 
		                            [telefone],
		                            [empresa],
		                            [cargo]
	                            ) 
	                            VALUES
	                            (
                                    @nome, 
		                            @email, 
		                            @telefone,
		                            @empresa,
		                            @cargo
	                            );";

		public string SqlEdicao = @"UPDATE TBContatos
	                            SET	
		                            [nome] = @nome, 
		                            [email] = @email, 
		                            [telefone] = @telefone,
		                            [empresa] = @empresa,
		                            [cargo] = @cargo
	                            WHERE
	                                [id] = @id";

		public string SqlExclusao = @"DELETE FROM TBContatos
	                            WHERE
	                                [id] = @id";

		public string SqlVisualizacaoPorId = @"SELECT  
                                    [id],
		                            [nome], 
		                            [email], 
		                            [telefone],
		                            [empresa],
		                            [cargo]
	                            FROM
                                    TBContatos
                                WHERE
                                    [id] = @id";

		public string SqlVisualizacaoTodos = @"SELECT  
                                    [id],
		                            [nome], 
		                            [email], 
		                            [telefone],
		                            [empresa],
		                            [cargo] 
	                            FROM
                                    TBContatos";
	}
}

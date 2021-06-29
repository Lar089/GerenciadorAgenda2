using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorAgenda.Controlarodes.Controladores.ControladoresCompromisso
{
    public class SqlCompromisso
    {
		public string SqlInsersao = @"INSERT INTO TBCompromisso 
	                            (
		                            [assunto], 
		                            [local], 
		                            [data],
		                            [horaInicio],
		                            [horaTermino],
		                            [idContatos]
	                            ) 
	                            VALUES
	                            (
                                    @assunto, 
		                            @local, 
		                            @data,
		                            @horaInicio,
		                            @horaTermino,
		                            @idContatos
	                            );";

		public string SqlEdicao = @"UPDATE TBCompromisso
	                            SET	
		                            [assunto] = @assunto, 
		                            [local] = @local, 
		                            [data] = @data,
		                            [horaInicio] = @horaInicio,
		                            [horaTermino] = @horaTermino,
		                            [idContatos] = @idContatos
	                            WHERE
	                                [id] = @id";

		public string SqlExclusao = @"DELETE FROM TBCompromisso
	                            WHERE
	                                [id] = @id";

		public string SqlVisualizacaoPorId = @"SELECT  
                                    [id],
		                            [assunto], 
		                            [local], 
		                            [data],
		                            [horaInicio],
		                            [horaTermino],
		                            [idContatos]
	                            FROM
                                    TBCompromisso
                                WHERE
                                    [id] = @id";

		public string SqlVisualizacaoTodos = @"SELECT  
                                    [id],
		                            [assunto], 
		                            [local], 
		                            [data],
		                            [horaInicio],
		                            [horaTermino],
		                            [idContatos]
	                            FROM
                                    TBCompromisso";
	}
}

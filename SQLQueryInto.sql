INSERT INTO TBContatos (nome, email,telefone, empresa, cargo)
VALUES ('carol', 'carol@gmail.com', '49 99988-7766', 'ndd', 'bolsista');

SELECT * FROM TBContatos;

INSERT INTO TBCompromisso(assunto, local, data, horaInicio, horaTermino, idContatos)
VALUES ('alguma projeto', 'café tal', '2021/08/22', '9:00', '11:00', 1);

SELECT * FROM TBCompromisso;

SELECT 
	CS.id,
	CS.assunto,
	CS.data,
	CS.horaInicio,
	CS.horaTermino,
	CT.id
FROM 
	TBCompromisso CS LEFT JOIN TBContatos CT 
ON 
	CS.idContatos = CT.Id;
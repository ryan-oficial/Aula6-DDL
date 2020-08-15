USE boletim;

/*DML - Data Manipulation Language*/
--INSERT - Inserir dados
INSERT INTO Aluno (Nome, Ra, Idade) VALUES ('Joao', 'R1236', 16);
INSERT INTO Materia (Titulo) VALUES ('Matematica');
-- Com FK´s
INSERT INTO Trabalho (DataEntrega, idAluno, IdMateria)
	VALUES 
	('2020-08-06T23:59:59', 3, 1);

--UPDATE - Alterar dados
UPDATE Trabalho SET 
	Nota = 7
	
WHERE IdTrabalho = 1;

--DELETE - Deletar dados
DELETE FROM Trabalho WHERE IdTrabalho = 2;


-- DQL de consulta simples
SELECT * FROM Trabalho;
SELECT * FROM Aluno;
SELECT * FROM Materia;
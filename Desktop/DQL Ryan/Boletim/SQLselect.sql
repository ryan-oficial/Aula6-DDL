USE boletim;
/*DQL - Data Query Language*/

--Selecina todos os dados de uma tabela
SELECT * FROM Aluno;

--Seleciona um dado especifico
SELECT * FROM Aluno WHERE 
	IdAluno = 2 OR --(||)
	IdAluno = 3;

--Seleciona como uma busca especifica
SELECT * FROM Aluno WHERE 
	Nome LIKE '%An%' AND
	Ra LIKE '%34%';

-- Ordenaçao por forma crescente | Padrao
SELECT * FROM Aluno ORDER BY Nome;
-- Ordenaçao por forma crescente
SELECT * FROM Aluno ORDER BY Nome ASC;
--Ordenaçao por forma decrecente
SELECT * FROM Aluno ORDER BY Idade DESC;

-- Seleciona dados com algumas condiçoes especiais 
SELECT * FROM Aluno WHERE IdAluno > 2 AND IdAluno < 4;


--Seleciona dados entre valores especificos
SELECT * FROM Trabalho WHERE 
	DataEntrega BETWEEN '2020-08-04T23:59:59' AND '2020-08-07T00:00:00';



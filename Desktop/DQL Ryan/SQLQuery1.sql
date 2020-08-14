/*Criamos o Banco*/
CREATE DATABASE boletim;
GO

/* Chamamos o banco para uso*/
USE boletim;
GO

/*Remove o Banco*/
--DROP DATABASE boletim;

/*Criamos a tabela aluno*/
/*IDENTITY - Gera os IDs*/
CREATE TABLE aluno(
	IdAluno INT IDENTITY PRIMARY KEY NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Ra VARCHAR(20),
	Idade INT
);

/*Criamos a tabela materia*/
CREATE TABLE materia(
	IdMateria INT PRIMARY KEY IDENTITY NOT NULL,
	TItulo VARCHAR(50) NOT NULL 
);
/*Criamos a tabela Trabalho*/
CREATE TABLE trabalho(
	IdTrabalho INT PRIMARY KEY IDENTITY NOT NULL,
	Nota DECIMAL,

	--Chamamos nosssas foreign Keys/CHaves estrangeiras
	IdAluno INT FOREIGN KEY REFERENCES aluno(IdAluno),
	IdMateria INT FOREIGN KEY REFERENCES materia (IdMateria)
);

/*Adicionamos a coluna esquecida: Data de entrega*/
ALTER TABLE trabalho ADD DataEntrega DATETIME;

/*Coluna de teste para remover*/
ALTER TABLE trabalho ADD teste INT

/*Coluna removida*/
ALTER TABLE trabalho DROP COLUMN teste
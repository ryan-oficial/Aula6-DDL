INSERT INTO Acesso (Tipo) VALUES
	('Administrador'),
	('Padrao');

INSERT INTO Categoria (Titulo) VALUES
	('Meetup'),
	('WorkShop'),
	('Bootcamp'),
	('Live');
	
INSERT INTO Localizacao (Logradouro, Numero, Complemento, Bairro, Cidade, UF, CEP)
	VALUES 
	('Alameda barão de Limeira', 539, NULL, 'Santa Cecilia', 'São Paulo', 'SP', '01202-001');

INSERT INTO Usuario (Nome, Email, Senha, DataNascimento, IdAcesso) VALUES
	('Ryan Ferraz', 'ryanferraz.barbosa@gmail.com', '1234567890', '1970-04-02T00:00:00', 1);

INSERT INTO Evento (DataEvento, Capacidade, IdLocalizacao, IdCategoria) VALUES
	('2020-29-25T22:00:00', 100, 1, 1 );



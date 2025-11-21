CREATE DATABASE Bibliotecla;

USE Bibliotecla;

CREATE TABLE LeitorFuncio
( 
	CodPessoa INT PRIMARY KEY AUTO_INCREMENT,
	Telefone VARCHAR(10),
	Nome VARCHAR(100),
	Cargo VARCHAR(12),
  	Usuario VARCHAR(20),
	Senha VARCHAR(10),
	Rua VARCHAR(100),
	NumRes VARCHAR(100),
	Cidade VARCHAR(100),
	Bairo VARCHAR(100),
	isDevedor INT
);

CREATE TABLE Titulo
( 
	CodTitulo INT PRIMARY KEY AUTO_INCREMENT,
	NomeTitulo VARCHAR(100),
	Autor VARCHAR(100),
	Genero VARCHAR(100)
);

CREATE TABLE Exemplar
( 
	CodExemplar INT PRIMARY KEY AUTO_INCREMENT,
	AnoPibli VARCHAR(10),
	EstadoFisc VARCHAR(100),
	Editora VARCHAR(100),
  	CodTitulo INT,
	FOREIGN KEY (CodTitulo) REFERENCES Titulo(CodTitulo)
);

CREATE TABLE Emprestimo
( 
	CodEmpres INT PRIMARY KEY AUTO_INCREMENT,
	CodExemplar INT,
	CodLeitor INT,
	DataEmpres VARCHAR(12),
  	DataDevol VARCHAR(20),
	PrazoDevol VARCHAR(10),
	isAtrasado INT
	FOREIGN KEY (CodExemplar) REFERENCES Exemplar(CodExemplar),
	FOREIGN KEY (CodLeitor) REFERENCES LeitorFuncio(CodPessoa)
);

CREATE TABLE Multa
( 
	CodMulta INT PRIMARY KEY AUTO_INCREMENT,
	PrecoMulta NUMERIC,
	CodLeitor INT,
  	CodEmpres INT,
	FOREIGN KEY (CodEmpres) REFERENCES Emprestimo(CodEmpres),
	FOREIGN KEY (CodLeitor) REFERENCES LeitorFuncio(CodPessoa)
);
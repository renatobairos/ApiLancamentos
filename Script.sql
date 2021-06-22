CREATE SCHEMA IF NOT EXISTS api_lancamentos;
USE api_lancamentos;


CREATE TABLE IF NOT EXISTS Lancamento (
	id int NOT NULL PRIMARY KEY AUTO_INCREMENT,
	data date NOT NULL,
	valor decimal(10, 2) NOT NULL,
	descricao varchar(100) NOT NULL,
	conta varchar(20) NOT NULL,
	tipo char(1) NOT NULL
);
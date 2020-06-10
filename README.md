# lojaAPI
API para ser consumida pelo front da loja Blue Modas

///SCRIPT PARA RODAR NO BANCO///


--BANCO: ///// PostgreSQL 11.8, compiled by Visual C++ build 1914, 64-bit \\\\\

CREATE DATABASE loja
    WITH 
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'Portuguese_Brazil.1252'
    LC_CTYPE = 'Portuguese_Brazil.1252'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;

-------------------------------------

CREATE TABLE PRODUTO(
	IDPRODUTO	INTEGER PRIMARY KEY,
	NOME		VARCHAR(50),
	IMAGEM		VARCHAR(100),
	VALOR		DECIMAL
);

INSERT INTO PRODUTO VALUES
(1,'Blusa','assets/blusa.png',20.99),
(2,'Calça','assets/calca.png',109.99),
(3,'Tênis','assets/tenis.png',299.90),
(4,'Chinelo','assets/chinelo.png',15.00),
(5,'Chapéu','assets/chapeu.png',65.00),
(6,'Camiseta','assets/camiseta.png',99.90),
(7,'Par de Meia','assets/meia.png',5.29),
(8,'Oculos','assets/oculos.png',25.00),
(9,'Short','assets/short.png',49.90),
(10,'Saia','assets/saia.png',45.90);

CREATE TABLE PEDIDO (
	IDTBLPEDIDO		INTEGER PRIMARY KEY,
	IDPEDIDO		INTEGER,
	IDPRODUTO		INTEGER,
	VALOR			DECIMAL,
	QUANTIDADE		INTEGER,
	TOTAL			DECIMAL,
	IDUSUARIO		INTEGER	
);

CREATE TABLE USUARIO (
	IDUSUARIO		INTEGER PRIMARY KEY,
	NOME			VARCHAR(100),
	EMAIL			VARCHAR(100),
	TELEFONE		INTEGER
)


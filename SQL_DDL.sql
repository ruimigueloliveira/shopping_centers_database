CREATE SCHEMA centro_comercial;
GO
-- DROP SCHEMA IF EXISTS centro_comercial;

DROP TABLE IF EXISTS centro_comercial.centro;
CREATE TABLE centro_comercial.centro (
    ID              INT             NOT NULL,
    Nome            VARCHAR(30)     NOT NULL,
	Localizacao		VARCHAR(30)		NOT NULL,
	Num_lojas		INT				NOT NULL	Default 0,
	Area_total		INT				NOT NULL,
    PRIMARY KEY(ID)
);

DROP TABLE IF EXISTS centro_comercial.pessoa;
CREATE TABLE centro_comercial.pessoa (
    NIF             INT             NOT NULL,
    Primeiro_nome   VARCHAR(20)     NOT NULL,
    Ultimo_nome     VARCHAR(20)     NOT NULL,
    Sexo            VARCHAR(20),
    Contacto        VARCHAR(12)     NOT NULL,
    PRIMARY KEY(NIF)
);

DROP TABLE IF EXISTS centro_comercial.responsavel_departamento;
CREATE TABLE centro_comercial.responsavel_departamento (
	NIF				INT				NOT NULL REFERENCES centro_comercial.pessoa(NIF),
    Num_func        INT             NOT NULL,      
    Salario         INT             CHECK(Salario > 1800 AND Salario < 2500),
    Habilitacoes    VARCHAR(MAX),
	ID_centro		INT				NOT NULL,
    PRIMARY KEY(Num_func),
	FOREIGN KEY(ID_centro) REFERENCES centro_comercial.centro(ID)
);

DROP TABLE IF EXISTS centro_comercial.departamento;
CREATE TABLE centro_comercial.departamento (
    ID              INT             NOT NULL,
    Nome            VARCHAR(20)     NOT NULL,
    Num_responsavel INT             NOT NULL,
    PRIMARY KEY(ID),
    FOREIGN KEY(Num_responsavel) REFERENCES centro_comercial.responsavel_departamento(Num_func),
);


DROP TABLE IF EXISTS centro_comercial.empresa;
CREATE TABLE centro_comercial.empresa (
    NIF             INT             NOT NULL,
    Nome            VARCHAR(22)     NOT NULL,
    Contacto        VARCHAR(12)     NOT NULL,  
    PRIMARY KEY(NIF)
);

DROP TABLE IF EXISTS centro_comercial.prestador;
CREATE TABLE centro_comercial.prestador (
    Servico         VARCHAR(20)     NOT NULL,
    Empresa         VARCHAR(20)     NOT NULL,
    Horas_mensais   INT,
    NIF             INT             NOT NULL,
    Custo_mensal    INT             NOT NULL,
    PRIMARY KEY(NIF)
);

DROP TABLE IF EXISTS centro_comercial.funcionario_loja;
CREATE TABLE centro_comercial.funcionario_loja (
    NIF             INT             NOT NULL REFERENCES centro_comercial.pessoa(NIF),
	Num_func		INT,
    Data_entrada    DATE            NOT NULL,
    Salario         INT             CHECK(Salario > 800 AND Salario < 1800),
    Numero_loja     INT,
    Horas_semanais  INT             NOT NULL,
    PRIMARY KEY(Num_func)
);


DROP TABLE IF EXISTS centro_comercial.loja;
CREATE TABLE centro_comercial.loja (
    Contacto        VARCHAR(12)     NOT NULL,
    Nome_comercial  VARCHAR(25)     NOT NULL,
    Renda           INT             NOT NULL,
    Num_loja        INT             NOT NULL,
	NIF_empresa     INT             NOT NULL,
	Tipo			VARCHAR(20)		NOT NULL,
	ID_centro		INT				NOT NULL,
	Area			INT				NOT NULL,
	Num_gerente		INT,
    PRIMARY KEY(Num_loja),
    FOREIGN KEY(NIF_empresa) REFERENCES centro_comercial.empresa(NIF),
	FOREIGN KEY(ID_centro) REFERENCES centro_comercial.centro(ID)
);

ALTER TABLE centro_comercial.funcionario_loja 
ADD CONSTRAINT num_loja_fk FOREIGN KEY(Numero_loja) REFERENCES centro_comercial.loja(Num_loja);

DROP TABLE IF EXISTS centro_comercial.interage;
CREATE TABLE centro_comercial.interage (
    ID_departamento INT     NOT NULL,
    NIF_prestador   INT     NOT NULL,
    FOREIGN KEY(ID_departamento)		REFERENCES centro_comercial.departamento(ID),
    FOREIGN KEY(NIF_prestador)			REFERENCES centro_comercial.prestador(NIF)
);

DROP TABLE IF EXISTS centro_comercial.comunica;
CREATE TABLE centro_comercial.comunica (
    ID_departamento INT     NOT NULL,
    NIF_empresa		INT     NOT NULL,
    FOREIGN KEY(ID_departamento)		REFERENCES centro_comercial.departamento(ID),
    FOREIGN KEY(NIF_empresa)			REFERENCES centro_comercial.empresa(NIF)
);

DROP TABLE IF EXISTS centro_comercial.eventos;
CREATE TABLE centro_comercial.eventos (
    Tipo            VARCHAR(20)     NOT NULL,
    Data_inicio     DATE            NOT NULL,
    Data_fim        DATE            NOT NULL,
    Nome            VARCHAR(20)     NOT NULL,
    ID_departamento INT             NOT NULL,
    PRIMARY KEY(Nome),
    FOREIGN KEY(ID_departamento) REFERENCES centro_comercial.departamento(ID)
);

/*
DROP TABLE IF EXISTS centro_comercial.eventos;
DROP TABLE IF EXISTS centro_comercial.comunica;
DROP TABLE IF EXISTS centro_comercial.interage;
DROP TABLE IF EXISTS centro_comercial.supervisiona;
ALTER TABLE centro_comercial.funcionario_loja  DROP CONSTRAINT num_loja_fk;
DROP TABLE IF EXISTS centro_comercial.loja;
DROP TABLE IF EXISTS centro_comercial.funcionario_loja;
DROP TABLE IF EXISTS centro_comercial.prestador;
DROP TABLE IF EXISTS centro_comercial.empresa;
DROP TABLE IF EXISTS centro_comercial.departamento;
DROP TABLE IF EXISTS centro_comercial.responsavel_departamento;
DROP TABLE IF EXISTS centro_comercial.pessoa;
DROP TABLE IF EXISTS centro_comercial.centro;
*/
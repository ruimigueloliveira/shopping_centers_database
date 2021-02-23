-- USE centro_comercial

-- Função que devolve o número de lojas de um centro
GO
CREATE FUNCTION fnGetNumLojas (@ID_centro AS INT)
RETURNS INT
AS
BEGIN
	RETURN (SELECT count(Num_loja) FROM centro_comercial.loja WHERE ID_centro = @ID_centro)
END

-- Função que devolve o ID do próximo centro a ser inserido
GO
CREATE FUNCTION fnGetNextIDCentro ()
RETURNS INT
AS
BEGIN
	RETURN (SELECT MAX(ID) + 1 FROM centro_comercial.centro)
END

-- Função que devolve o número do próximo responsável de departamento a ser inserido na base de dados
GO
CREATE FUNCTION fnGetNextNumResp ()
RETURNS INT
AS
BEGIN
	RETURN (SELECT MAX(Num_func) + 1 FROM centro_comercial.responsavel_departamento)
END

-- Função que devolve o número do próximo funcionário a ser inserido na base de dados
GO
CREATE FUNCTION fnGetNextNumFunc ()
RETURNS INT
AS
BEGIN
	RETURN (SELECT MAX(Num_func) + 1 FROM centro_comercial.funcionario_loja)
END

-- Função que devolve o número do próximo departamento a ser inserido num centro
GO
CREATE FUNCTION fnGetNextNumDep (@ID_centro as INT)
RETURNS INT
AS
BEGIN 
	DECLARE @depID INT
	IF NOT EXISTS (
		SELECT * FROM centro_comercial.departamento 
		JOIN centro_comercial.responsavel_departamento ON Num_responsavel = Num_func
		WHERE ID_centro = @ID_centro 
	)
		BEGIN
			SET @depID = CONCAT(@ID_centro, '1')
		END
	ELSE
		BEGIN
			SET @depID = (SELECT MAX(ID) + 1 FROM centro_comercial.departamento
			JOIN centro_comercial.responsavel_departamento ON Num_responsavel = Num_func
			WHERE ID_centro = @ID_centro)
		END
	RETURN @depID
END

-- Função que devolve o número do próximo departamento a ser inserido num centro
GO
CREATE FUNCTION fnGetNextNumLoja (@ID_centro as INT)
RETURNS INT
AS
BEGIN 
	DECLARE @numLoja INT
	IF NOT EXISTS (
		SELECT * FROM centro_comercial.loja 
		WHERE ID_centro = @ID_centro 
	)
		BEGIN
			SET @numLoja = CONCAT(@ID_centro, '001')
		END
	ELSE
		BEGIN
			SET @numLoja = (SELECT MAX(Num_loja) + 1 FROM centro_comercial.loja
			WHERE ID_centro = @ID_centro)
		END
	RETURN @numLoja
END

-- Função para retornar a data formatada
GO
SET LANGUAGE Portuguese;
GO
CREATE FUNCTION fnGetFormatDate (@Data AS DATE)
RETURNS VARCHAR(MAX)
AS
BEGIN
	RETURN DATENAME(D, @Data) + ' ' +
	DATENAME(M, @Data) + ' ' +
	DATENAME(YY, @Data)
END
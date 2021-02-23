USE centro_comercial

-- Trigger que gera um erro se tentarmos colocar um funcionário com menos de 40 horas_semanais
-- como gerente de uma loja
GO
CREATE TRIGGER trgLojaAlterada
ON centro_comercial.loja
AFTER UPDATE
AS
BEGIN

	IF EXISTS (
		SELECT * FROM centro_comercial.funcionario_loja 
		INNER JOIN inserted 
		ON inserted.Num_gerente = funcionario_loja.Num_func
		WHERE Horas_semanais < 40
	)
	BEGIN
		RAISERROR('Não pode colocar um funcionário em part-time como gerente da loja.', 5, 1)
		ROLLBACK TRANSACTION
		RETURN
	END
END

-- Trigger que gera um erro se o utilizador tentar remover um dos 3 departamentos essenciais
-- (marketing, comercial, operações)
-- Funciona mas optámos por usar um sp

--GO
--CREATE TRIGGER trgDelDepartamento
--ON centro_comercial.departamento
--AFTER DELETE
--AS
--BEGIN
--	IF EXISTS (SELECT * FROM deleted
--		JOIN responsavel_departamento as r on Num_func = deleted.Num_responsavel
--		WHERE deleted.id = CONCAT(r.ID_centro, '1') or deleted.id = CONCAT(r.ID_centro, '2') or deleted.id = CONCAT(r.ID_centro, '3'))
--	BEGIN
--		RAISERROR('Não pode remover nenhum dos 3 departamentos essenciais (marketing, comercial, operaçoes).', 5, 1)
--		ROLLBACK TRANSACTION
--		RETURN
--	END
--END
-- USE centro_comercial

-- Seleciona o nome de todas as lojas de uma empresa que existem num centro
GO
CREATE PROC spLojasList(@NIF_empresa AS INT, @ID_centro AS INT)
AS
SELECT DISTINCT
	Nome_comercial
FROM
	centro_comercial.loja JOIN centro_comercial.empresa on NIF_empresa = NIF
WHERE
	NIF_empresa = @NIF_empresa and ID_centro = @ID_centro
ORDER BY
	Nome_comercial

-- Seleciona todas as lojas de um centro
GO
CREATE PROC spLojasByCentro(@ID_centro AS INT)
AS
SELECT
	Nome_comercial,
	Num_loja
FROM
	centro_comercial.loja
WHERE
	ID_centro = @ID_centro
ORDER BY
	Num_loja

-- Seleciona todos os funcionários de uma loja
GO
CREATE PROC spFuncLojaList(@Num_loja AS INT)
AS
SELECT
	Num_func,
	Primeiro_nome,
	Ultimo_nome
FROM
	centro_comercial.funcionario_loja join centro_comercial.pessoa ON centro_comercial.funcionario_loja.NIF = centro_comercial.pessoa.NIF
WHERE
	Numero_loja = @Num_loja
ORDER BY
	Num_func

-- Seleciona todas as empresas de um centro
GO
CREATE PROC spEmpresas(@ID_centro AS INT)
AS
SELECT DISTINCT
	*
FROM
	centro_comercial.empresa 
	JOIN centro_comercial.comunica on NIF = NIF_empresa
	JOIN centro_comercial.departamento on ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento on Num_responsavel = Num_func
WHERE
	ID_centro = @ID_centro

-- Seleciona todos os departamentos de um centro
GO
CREATE PROC spDepartamentos(@ID_centro AS INT)
AS
SELECT
	*
FROM
	centro_comercial.departamento 
	JOIN centro_comercial.responsavel_departamento AS r ON Num_func = Num_responsavel
	JOIN centro_comercial.pessoa ON centro_comercial.pessoa.NIF = r.NIF 
WHERE
	ID_centro = @ID_centro

-- Seleciona todos os prestadores de um centro
GO
CREATE PROC spPrestadores(@ID_centro AS INT)
AS
SELECT
	*
FROM
	centro_comercial.prestador
	JOIN centro_comercial.interage ON NIF = NIF_prestador
	JOIN centro_comercial.departamento ON ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento ON Num_func = Num_responsavel
WHERE
	ID_centro = @ID_centro

-- Seleciona todas as lojas de um centro
GO
CREATE PROC spLojas(@ID_centro AS INT)
AS
SELECT
	*
FROM
	centro_comercial.loja AS l
	JOIN centro_comercial.empresa ON NIF = NIF_empresa
	JOIN centro_comercial.funcionario_loja AS f ON Num_func = Num_gerente
	JOIN centro_comercial.pessoa AS p ON p.NIF = f.NIF
WHERE
	l.ID_centro = @ID_centro


-- Remove todas as lojas de uma empresa de determinado centro
GO
CREATE PROC spDelLojasEmpresa(@NIF_empresa AS INT, @ID_centro AS INT)
AS
BEGIN
DELETE
	centro_comercial.comunica 
FROM
	centro_comercial.comunica JOIN centro_comercial.departamento ON ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento ON Num_func = Num_responsavel
WHERE
	NIF_empresa = @NIF_empresa AND ID_centro = @ID_centro
END
BEGIN
	IF EXISTS ( 
		SELECT * FROM centro_comercial.loja 
		WHERE ID_centro = @ID_centro AND NIF_empresa = @NIF_empresa
	)
	BEGIN
		DELETE
			centro_comercial.funcionario_loja 
		FROM
			centro_comercial.funcionario_loja JOIN centro_comercial.loja ON Num_loja = Numero_loja JOIN centro_comercial.empresa ON NIF_empresa = centro_comercial.empresa.NIF
		WHERE
			centro_comercial.empresa.NIF = @NIF_empresa and ID_centro = @ID_centro
	END
	BEGIN
		DELETE
			centro_comercial.loja 
		FROM
			centro_comercial.loja JOIN centro_comercial.empresa ON NIF = NIF_empresa 
		WHERE 
			NIF = @NIF_empresa and ID_centro = @ID_centro
	END
END

-- Remove um departamento se não for essencial (marketing, comercial, operaçoes)
GO
CREATE PROC spDelDepartamento(@ID_centro AS INT, @ID_departamento AS INT)
AS
BEGIN
	DELETE centro_comercial.departamento WHERE ID = @ID_departamento
END

-- Seleciona todos os eventos que ocorrem num centro
GO
CREATE PROC spEventos(@ID_centro AS INT)
AS
SET LANGUAGE Portuguese
SELECT 
	Tipo,
	Data_inicio = dbo.fnGetFormatDate(Data_inicio),
	Data_fim = dbo.fnGetFormatDate(Data_fim),
	centro_comercial.departamento.Nome as Dep_nome,
	centro_comercial.eventos.Nome as Nome,
	ID_departamento 
FROM
	centro_comercial.eventos JOIN centro_comercial.departamento on ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento on Num_responsavel = Num_func
WHERE
	ID_centro = @ID_centro

-- Seleciona os funcionarios que contém a string @nome de um centro com id @id_centro
GO
CREATE PROC spGetFuncByName (@nome AS VARCHAR(MAX), @id_centro AS INT)
AS
BEGIN
	SELECT DISTINCT
		*,
		Data_de_entrada = dbo.fnGetFormatDate(Data_entrada)
	FROM 
		centro_comercial.funcionario_loja as f 
		join centro_comercial.pessoa as p on p.NIF = f.NIF 
		join centro_comercial.loja on Numero_loja = Num_loja
	WHERE 
		Primeiro_nome like '%' + @nome + '%' and ID_centro = @id_centro
END

-- Seleciona todos os funcionários de um centro
GO
CREATE PROC spFuncionarios(@ID_centro AS INT)
AS
SET LANGUAGE Portuguese
SELECT
	Num_func,
	Primeiro_nome,
	Ultimo_nome,
	centro_comercial.pessoa.Contacto,
	centro_comercial.funcionario_loja.NIF,
	Salario,
	Horas_semanais,
	Data_entrada = dbo.fnGetFormatDate(Data_entrada),
	Numero_loja,
	Nome_comercial,
	Sexo
FROM
	centro_comercial.funcionario_loja join centro_comercial.pessoa on centro_comercial.funcionario_loja.NIF = centro_comercial.pessoa.NIF
	join centro_comercial.loja on Numero_loja = Num_loja
WHERE
	ID_centro = @ID_centro
ORDER BY
	Num_func

-- Seleciona todos os admnistradores de um centro
GO
CREATE PROC spAdmin(@ID_centro AS INT)
AS
SELECT 
	centro_comercial.responsavel_departamento.NIF,
    Num_func,
    Salario,
    Habilitacoes,
    Primeiro_nome,
    Ultimo_nome,
    Sexo,
    Contacto,
    centro_comercial.responsavel_departamento.ID_centro as ID_centro,
	Nome
FROM
	centro_comercial.responsavel_departamento join centro_comercial.pessoa on centro_comercial.pessoa.NIF = centro_comercial.responsavel_departamento.NIF
	left join centro_comercial.departamento on Num_responsavel = Num_func
WHERE
	centro_comercial.responsavel_departamento.ID_centro = @ID_centro

-- Seleciona todos os admnistradores de um centro sem repetições
GO
CREATE PROC spDistinctAdmin(@ID_centro AS INT)
AS
SELECT DISTINCT
    Num_func,
    Primeiro_nome,
    Ultimo_nome
FROM
	centro_comercial.responsavel_departamento join centro_comercial.pessoa on centro_comercial.pessoa.NIF = centro_comercial.responsavel_departamento.NIF
	left join centro_comercial.departamento on Num_responsavel = Num_func
WHERE
	centro_comercial.responsavel_departamento.ID_centro = @ID_centro


-- Remove o centro comercial pretendido e todas as suas ligações
GO
CREATE PROC spDelCentro(@ID_centro AS INT)
AS
BEGIN
	DELETE centro_comercial.comunica
	FROM centro_comercial.comunica join centro_comercial.departamento on ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento on Num_func = Num_responsavel
	WHERE ID_centro = @ID_centro
END
BEGIN
	DELETE centro_comercial.interage 
	FROM centro_comercial.interage join centro_comercial.departamento on ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento on Num_func = Num_responsavel
	WHERE ID_centro = @ID_centro
END
BEGIN
	DELETE centro_comercial.eventos 
	FROM centro_comercial.eventos join centro_comercial.departamento on ID = ID_departamento
	JOIN centro_comercial.responsavel_departamento on Num_func = Num_responsavel
	WHERE ID_centro = @ID_centro
END
BEGIN
	DELETE FROM centro_comercial.prestador
	WHERE NIF NOT IN (SELECT NIF_prestador FROM centro_comercial.interage)
END
BEGIN
	DELETE centro_comercial.departamento FROM centro_comercial.departamento
	JOIN centro_comercial.responsavel_departamento on Num_func = Num_responsavel
	WHERE ID_centro = @ID_centro
END
BEGIN
	DELETE centro_comercial.responsavel_departamento 
	WHERE ID_centro = @ID_centro
END
BEGIN
	DELETE centro_comercial.funcionario_loja 
	FROM centro_comercial.funcionario_loja join centro_comercial.loja on Num_loja = Numero_loja 
	WHERE ID_centro = @ID_centro
END
BEGIN
	DELETE centro_comercial.loja 
	WHERE  ID_centro = @ID_centro
END
BEGIN
	DELETE centro_comercial.empresa 
	WHERE NIF NOT IN (SELECT NIF_empresa FROM centro_comercial.comunica) and NIF NOT IN (SELECT NIF_empresa  FROM centro_comercial.loja) 
END
BEGIN
	DELETE FROM centro_comercial.pessoa
	WHERE NIF NOT IN (SELECT NIF FROM centro_comercial.funcionario_loja) and NIF NOT IN (SELECT NIF  FROM centro_comercial.responsavel_departamento)
END
BEGIN
	DELETE centro_comercial.centro
	WHERE  ID = @ID_centro
END
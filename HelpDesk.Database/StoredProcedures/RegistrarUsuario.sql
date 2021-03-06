IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RegistrarUsuario')
	DROP PROCEDURE RegistrarUsuario
GO

CREATE PROCEDURE RegistrarUsuario 
(
	@nome VARCHAR(200),
	@tipo INT,
	@descricao VARCHAR(200),
	@email VARCHAR(200),
	@senha VARCHAR(200)
) AS

BEGIN
	
	DECLARE @id INT 
	SET @id = (SELECT (ISNULL(MAX(ID_Usuario),0) + 1) FROM TB_USUARIO)

	INSERT INTO TB_USUARIO
	(
		ID_USUARIO, 
		ID_TIPO_USUARIO,
		NM_USUARIO,
		DS_USUARIO,
		DS_EMAIL,
		DS_SENHA,
		DT_CRIACAO_USUARIO
	)
	VALUES 
	(
		@id,
		@tipo,
		@nome,
		@descricao,
		@email,
		@senha,
		GETDATE()
	)

	SELECT @id

END
GO

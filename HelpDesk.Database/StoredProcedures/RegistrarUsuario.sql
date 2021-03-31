IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RegistrarUsuario')
	DROP PROCEDURE RegistrarUsuario
GO

CREATE PROCEDURE RegistrarUsuario 
(
	@nome VARCHAR,
	@tipo INT,
	@descricao VARCHAR
) AS

BEGIN
	
	DECLARE @id INT 
	SELECT @id = (MAX(ID_Usuario) + 1) FROM TB_USUARIO

	INSERT INTO TB_USUARIO
	(
		ID_USUARIO, 
		ID_TIPO_USUARIO,
		NM_USUARIO,
		DS_USUARIO,
		DT_CRIACAO_USUARIO
	)
	VALUES 
	(
		@id,
		@tipo,
		@nome,
		@descricao,
		GETDATE()
	)

END


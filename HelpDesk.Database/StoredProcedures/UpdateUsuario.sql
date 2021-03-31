IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateUsuario')
	DROP PROCEDURE UpdateUsuario
GO

CREATE PROCEDURE UpdateUsuario
(
	@id INT,
	@nome VARCHAR,
	@tipo INT,
	@descricao VARCHAR
) AS

BEGIN
	
	UPDATE TB_USUARIO
		SET ID_TIPO_USUARIO = @tipo,
		NM_USUARIO = @nome,
		DS_USUARIO = @descricao
	WHERE 
		ID_Usuario = @id
END

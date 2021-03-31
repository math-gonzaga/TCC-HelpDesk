IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetTipoUsuario')
	DROP PROCEDURE GetTipoUsuario
GO

CREATE PROCEDURE GetTipoUsuario 
(
	@id INT
) AS

BEGIN
	
	SELECT 
		ID_TIPO_USUARIO AS [ID],
		DS_TIPO_USUARIO AS [Descricao]
	FROM TB_TIPO_USUARIO
	WHERE ID_TIPO_USUARIO = @id

END

EXEC GetTipoUsuario 1

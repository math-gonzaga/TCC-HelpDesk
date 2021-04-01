IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetUsuarioByEmail')
	DROP PROCEDURE GetUsuarioByEmail
GO

CREATE PROCEDURE GetUsuarioByEmail 
(
	@email VARCHAR(200)
) AS

BEGIN
	
	SELECT 
		ID_USUARIO AS [ID], 
		ID_TIPO_USUARIO AS [Tipo],
		NM_USUARIO AS [Nome],
		DS_USUARIO AS [Descricao],
		DS_EMAIL AS [Email],
		DS_SENHA AS [SenhaHash],
		DT_CRIACAO_USUARIO AS [DataCriacao]
	FROM TB_USUARIO
	WHERE DS_EMAIL LIKE @email

END
GO


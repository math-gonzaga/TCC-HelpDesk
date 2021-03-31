﻿IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'GetChamado')
	DROP PROCEDURE GetChamado
GO

CREATE PROCEDURE GetChamado 
(
	@id INT
) AS

BEGIN
	
	SELECT 
		ID_CHAMADO AS [ID],
		ID_USUARIO AS [UsusarioID],
		ID_USUARIO_RESPOSTA AS [UsuarioRespostaID],
		DS_CHAMADO AS [Nome],
		DT_CRIACAO_CHAMADO AS [DataCriacao]
	FROM TB_CHAMADO
	WHERE ID_CHAMADO = @id

	SELECT 
		ID_MENSAGEM_CHAMADO AS [ID],
		ID_USUARIO AS [UsuarioID],
		DS_MENSAGEM_CHAMADO AS [Mensagem],
		DT_ENVIO_MENSAGEM AS [DataEnvio]
	FROM TB_MENSAGEM_CHAMADO
	WHERE ID_CHAMADO = @id

END

EXEC GetChamado 1

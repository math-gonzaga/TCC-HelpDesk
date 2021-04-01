﻿IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'ListChamado')
	DROP PROCEDURE ListChamado
GO

CREATE PROCEDURE ListChamado
AS

BEGIN
	
	SELECT 
		ID_CHAMADO AS [ID],
		ID_USUARIO AS [UsuarioID],
		ID_USUARIO_RESPOSTA AS [UsuarioRespostaID],
		DS_CHAMADO AS [Nome],
		DT_CRIACAO_CHAMADO AS [DataCriacao]
	FROM TB_CHAMADO

	SELECT 
		ID_MENSAGEM_CHAMADO AS [ID],
		ID_USUARIO AS [UsuarioID],
		DS_MENSAGEM_CHAMADO AS [Mensagem],
		DT_ENVIO_MENSAGEM AS [DataEnvio],
		ID_CHAMADO AS [ChamadoID]
	FROM TB_MENSAGEM_CHAMADO

END
GO

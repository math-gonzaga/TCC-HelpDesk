IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateChamado')
	DROP PROCEDURE UpdateChamado
GO

CREATE PROCEDURE UpdateChamado 
(
    @id INT
    ,@nome VARCHAR(500)
    ,@idUsuario INT
    ,@idUsuarioResposta INT = NULL
) 
AS

BEGIN 
    
    UPDATE TB_CHAMADO
        SET ID_USUARIO_RESPOSTA = @idUsuarioResposta,
        DS_CHAMADO = @nome
    WHERE 
        ID_CHAMADO = @id

END
GO
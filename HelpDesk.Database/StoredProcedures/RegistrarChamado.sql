IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RegistrarChamado')
	DROP PROCEDURE RegistrarChamado
GO

CREATE PROCEDURE RegistrarChamado 
(
    @nome VARCHAR(200)
    ,@idUsuario INT
    ,@idUsuarioResposta INT = NULL
) 
AS

BEGIN 
    
    DECLARE @id INT

    SELECT @id = (ISNULL(MAX(ID_CHAMADO),0) + 1) FROM TB_CHAMADO

    INSERT INTO TB_CHAMADO 
    (
        ID_CHAMADO,
        ID_USUARIO,
        ID_USUARIO_RESPOSTA,
        DS_CHAMADO,
        DT_CRIACAO_CHAMADO
    )
    VALUES 
    (
        @id,
        @idUsuario,
        @idUsuarioResposta,
        @nome,
        GETDATE()
    )

    SELECT @id

END
GO
IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RegistrarMensagem')
	DROP PROCEDURE RegistrarMensagem
GO

CREATE PROCEDURE RegistrarMensagem 
(
    @id INT
    ,@chamadoId INT
    ,@idUsuario INT
    ,@mensagem VARCHAR(500) = NULL
) 
AS

BEGIN 
    
    IF(@id > 0)
        BEGIN
            UPDATE TB_MENSAGEM_CHAMADO
                SET DS_MENSAGEM_CHAMADO = @mensagem
            WHERE
                ID_MENSAGEM_CHAMADO = @id
        END
    ELSE
        BEGIN
        
        DECLARE @newMensagemID INT = (SELECT (ISNULL(MAX(ID_MENSAGEM_CHAMADO),0)+ 1) FROM TB_MENSAGEM_CHAMADO )
        
        INSERT INTO TB_MENSAGEM_CHAMADO
            (
                ID_MENSAGEM_CHAMADO,
                ID_CHAMADO,         
                ID_USUARIO,			
                DS_MENSAGEM_CHAMADO,
                DT_ENVIO_MENSAGEM  
            )
            VALUES 
            (
                @newMensagemID,
                @chamadoId,
                @idUsuario,
                @mensagem,
                GETDATE()
            )
        END
END
GO
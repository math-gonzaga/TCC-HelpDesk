IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'TheSchema' AND  TABLE_NAME = 'MensagemChamadoListTableType'))
	DROP TYPE MensagemChamadoListTableType
GO

CREATE TYPE MensagemChamadoListTableType AS TABLE
(
      ID INT
    , Mensagem VARCHAR(200)
    , UsuarioId INT
    , DataEnvio DATETIME
);


IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'UpdateChamado')
	DROP PROCEDURE UpdateChamado
GO

CREATE PROCEDURE UpdateChamado 
(
    @id INT
    ,@nome VARCHAR
    ,@idUsuario INT
    ,@idUsuarioResposta INT = NULL
    ,@mensagens MensagemChamadoListTableType READONLY
) 
AS

BEGIN 
    
    UPDATE TB_CHAMADO
        SET ID_USUARIO_RESPOSTA = @idUsuarioResposta,
        DS_CHAMADO = @nome
    WHERE 
        ID_CHAMADO = @id
    
    DECLARE @mensagemID int, @mensagem VARCHAR(200), @usuarioID INT, @dataEnvio DATETIME

    DECLARE cursor1 CURSOR FOR
    SELECT ID, Mensagem, UsuarioId, DataEnvio FROM @mensagens

    OPEN cursor1

    FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataEnvio

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        IF(@mensagemID > 0)
            BEGIN
                UPDATE TB_MENSAGEM_CHAMADO
                    SET DS_MENSAGEM_CHAMADO = @mensagem
                WHERE
                    ID_MENSAGEM_CHAMADO = @mensagemID
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
                    @id,
                    @usuarioID,
                    @mensagem,
                    GETDATE()
                )
            END

        FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataEnvio
    END

    CLOSE cursor1

    DEALLOCATE cursor1
END
GO
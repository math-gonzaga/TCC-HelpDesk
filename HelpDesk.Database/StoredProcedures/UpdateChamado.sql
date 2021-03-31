IF (EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'TheSchema' AND  TABLE_NAME = 'MensagemChamadoListTableType'))
	DROP TYPE MensagemChamadoListTableType
GO

CREATE TYPE MensagemChamadoListTableType AS TABLE
(
      MensagemID INT
    , Mensagem VARCHAR
    , UsuarioId INT
    , DataCriacao DATETIME
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
        SET ID_USUARIO = @idUsuario,
        ID_USUARIO_RESPOSTA = @idUsuarioResposta,
        DS_CHAMADO = @nome
    WHERE 
        ID_CHAMADO = @id
    
    DECLARE @mensagemID int, @mensagem VARCHAR, @usuarioID INT, @dataCriacao DATETIME

    DECLARE cursor1 CURSOR FOR
    SELECT MensagemID, Mensagem, UsuarioId, DataCriacao FROM @mensagens

    OPEN cursor1

    FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataCriacao

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
                    @mensagemID,
                    @id,
                    @usuarioID,
                    @mensagem,
                    GETDATE()
                )
            END

        FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataCriacao
    END

    CLOSE cursor1

    DEALLOCATE cursor1
END
GO
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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RegistrarChamado')
	DROP PROCEDURE RegistrarChamado
GO

CREATE PROCEDURE RegistrarChamado 
(
    @nome VARCHAR
    ,@idUsuario INT
    ,@idUsuarioResposta INT = NULL
    ,@mensagens MensagemChamadoListTableType READONLY
) 
AS

BEGIN 
    
    DECLARE @id INT

    SELECT @id = (MAX(ID_CHAMADO) + 1) FROM TB_CHAMADO

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

    DECLARE @mensagemID int, @mensagem VARCHAR, @usuarioID INT, @dataCriacao DATETIME

    DECLARE cursor1 CURSOR FOR
    SELECT MensagemID, Mensagem, UsuarioId, DataCriacao FROM @mensagens

    OPEN cursor1

    FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataCriacao

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SELECT @mensagemID = (MAX(ID_MENSAGEM_CHAMADO) + 1) FROM TB_MENSAGEM_CHAMADO

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

        FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataCriacao
    END

    CLOSE cursor1

    DEALLOCATE cursor1
END
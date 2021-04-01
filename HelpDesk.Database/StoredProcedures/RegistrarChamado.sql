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

IF EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND name = 'RegistrarChamado')
	DROP PROCEDURE RegistrarChamado
GO

CREATE PROCEDURE RegistrarChamado 
(
    @nome VARCHAR(200)
    ,@idUsuario INT
    ,@idUsuarioResposta INT = NULL
    ,@mensagens MensagemChamadoListTableType READONLY
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

    DECLARE @mensagemID int, @mensagem VARCHAR(200), @usuarioID INT, @dataEnvio DATETIME

    DECLARE cursor1 CURSOR FOR
    SELECT ID, Mensagem, UsuarioId, DataEnvio FROM @mensagens

    OPEN cursor1

    FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataEnvio

    WHILE @@FETCH_STATUS = 0
    BEGIN
        
        SELECT @mensagemID = (ISNULL(MAX(ID_MENSAGEM_CHAMADO),0) + 1) FROM TB_MENSAGEM_CHAMADO

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

        FETCH NEXT FROM cursor1 INTO @mensagemID, @mensagem, @usuarioID, @dataEnvio
    END

    CLOSE cursor1

    DEALLOCATE cursor1

    SELECT @id

END
GO
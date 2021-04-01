CREATE TABLE TB_USUARIO (
ID_USUARIO               INTEGER,
ID_TIPO_USUARIO          INTEGER NOT NULL,
NM_USUARIO               VARCHAR(50) NOT NULL,
DS_USUARIO               VARCHAR(200) DEFAULT 'NÃO INFORMADO',
DS_EMAIL				 VARCHAR(200) NOT NULL,
DS_SENHA				 VARCHAR(200) NOT NULL,
DT_CRIACAO_USUARIO       DATE DEFAULT GETDATE(),
CONSTRAINT PK02_ID_USUARIO       PRIMARY KEY (ID_USUARIO),
CONSTRAINT FK02_ID_TIPO_USUARIO  FOREIGN KEY (ID_TIPO_USUARIO) REFERENCES TB_TIPO_USUARIO (ID_TIPO_USUARIO)
);
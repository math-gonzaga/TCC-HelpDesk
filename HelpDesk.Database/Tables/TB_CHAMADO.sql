CREATE TABLE TB_CHAMADO (
ID_CHAMADO          INTEGER,
ID_USUARIO          INTEGER,
ID_USUARIO_RESPOSTA INTEGER,
DS_CHAMADO          VARCHAR(200) NOT NULL,
DT_CRIACAO_CHAMADO  DATE DEFAULT GETDATE(),
CONSTRAINT PK03_ID_CHAMADO     PRIMARY KEY (ID_CHAMADO),
CONSTRAINT FK03_ID_USUARIO  FOREIGN KEY (ID_USUARIO) REFERENCES TB_USUARIO (ID_USUARIO)

);
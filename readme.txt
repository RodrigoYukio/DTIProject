**********BANCO**********

CREATE SEQUENCE IF NOT EXISTS public.seq_funcionario
    INCREMENT 1
    START 1
    MINVALUE 0
    MAXVALUE 9223372036854775807
    CACHE 1;

ALTER SEQUENCE public.seq_funcionario
    OWNER TO postgres;


CREATE TABLE IF NOT EXISTS public.ge_funcionario
(
    seq_funcionario integer NOT NULL DEFAULT nextval('seq_funcionario'::regclass),
    nome character varying(100) COLLATE pg_catalog."default" NOT NULL,
    dtanasc date NOT NULL,
    endereco character varying(100) COLLATE pg_catalog."default" NOT NULL,
    telefone character varying(100) COLLATE pg_catalog."default" NOT NULL,
    email character varying(100) COLLATE pg_catalog."default" NOT NULL,
    cpf character varying(100) COLLATE pg_catalog."default" NOT NULL,
    setor character varying(100) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT seq_funcionario_pk PRIMARY KEY (seq_funcionario)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.ge_funcionario
    OWNER to postgres;


**********VISUALSTUDIO (backend)**********
Ferramentas > Gerenciador de pacotes do NuGet > Configurações de Pacotes do Nuget > Origens do Pacote > Origem: https://www.myget.org/F/tnf/api/v3/index.json


**********VISUALSTUDIOCODE (frontend)**********
npm install
ng server

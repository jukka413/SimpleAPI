CREATE SCHEMA modultest AUTHORIZATION postgres;

CREATE TABLE modultest.users (
    id uuid NOT NULL,
    Email varchar not null,
    Nickname varchar,
    phone varchar
);

create extension "uuid-ossp";

insert into modultest.users values (uuid_generate_v4(),'123@yu.iu','jhu','9878987');
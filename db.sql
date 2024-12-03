create database game collate SQL_Latin1_General_CP1_CI_AS
go

use game
go

create table dbo.accounts
(
    id         int identity
        primary key,
    email      varchar(50)                not null,
    password   varchar(32)                not null,
    name       nvarchar(100)              not null,
    created_at datetime default getdate() not null,
    updated_at datetime default getdate() not null
)
    go

create table dbo.characters
(
    id         int identity
        primary key,
    account_id int                        not null
        references dbo.accounts,
    name       nvarchar(100)              not null,
    level      int      default 1         not null,
    exp        int      default 0         not null,
    created_at datetime default getdate() not null,
    updated_at datetime default getdate() not null,
    Coin       int      default 0         not null,
    HP         int      default 100       not null,
    MP         int      default 100       not null,
    def        int      default 0         not null,
    atk        int      default 0         not null
)
    go


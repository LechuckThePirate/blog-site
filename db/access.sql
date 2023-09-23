create table db.access
(
    Id        varchar(36)   not null
        primary key,
    Action    varchar(100)  not null,
    Data      varchar(1000) null,
    CreatedAt datetime      not null,
    CreatedBy varchar(100)  null
);


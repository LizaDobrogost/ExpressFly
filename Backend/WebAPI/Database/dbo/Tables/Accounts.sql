create table Accounts 
(
    [Id]          int identity (1, 1) not null,
    [FirstName]   nvarchar (50)       not null,
    [SecondName]  nvarchar (50)       not null,
    [Email]       nvarchar (50)       not null,
    [Password]	  nvarchar (255)      not null,
    [Role]        int                 not null,
    constraint [PK_Accounts] primary key clustered ([Id] asc)
);

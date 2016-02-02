create table Lists
(
	ListId int primary key identity (1,1),
	Name varchar (100) not null,
	CreatedDate DateTime not null 
);

create table Card

(

CardId int primary key identity (1,1),
ListId int not null foreign key references Lists (ListId),
CreatedDate DateTime not null,
Text varchar (100) not null

);

create table user_table
(
	id char(8) primary key,
	nickname nvarchar(20) not null unique,
	psword char(32) not null, 
);
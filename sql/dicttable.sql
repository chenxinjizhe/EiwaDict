use EiwaDB;

create table dictionary
(
	id int primary key,
	word nvarchar(20) not null,
	paraphase ntext not null
);

create index word_index on dictionary(word);
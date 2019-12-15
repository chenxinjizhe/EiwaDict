use EiwaDB;

create table word_table
(
	wid int,
	uid char(8),
	add_time datetime not null,
	primary key(wid,uid),
	foreign key(wid) references dictionary(id),
	foreign key(uid) references user_table(id)
)
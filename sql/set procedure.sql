use EiwaDB;
go
create proc InsertProc
@id int,
@word nvarchar(20),
@paraphase ntext
as 
begin
insert into dictionary([id],[word],[paraphase]) values(@id,@word,@paraphase)
end
create database DuongThiThuyDungDB
create table UserAccount(
	ID int IDENTITY(1,1),
	UserName varchar(20),
	Password varchar(100) not null,
	Status nvarchar(50) not null,
	primary key(UserName)
)
create table Category(
	CategoryID varchar(50) primary key,
	Name nvarchar(20),
	Description nvarchar(250),
	
)
insert into Category(CategoryID,Name,Description)
values('DH','dell','dell')
create table Product(
	ID int IDENTITY(1,1) primary key,
	Name nvarchar(250),
	UnitCost decimal(15,0),
	Quantity int,
	Image nvarchar(250),
	Description nvarchar(250),
	Status nvarchar(50),
	CategoryID varchar(50),
	constraint FK_Categorryid foreign key(CategoryID) references Category(CategoryID)

)
insert into Product(Name,UnitCost,Quantity,CategoryID)
values('may tinh dell',20000000,1,'DH')

insert into UserAccount(UserName,Password,Status)
values('admin','admin','active')
UPDATE UserAccount
SET Password = 'dung2000'
WHERE UserName ='dung2000';
-- versión SQLite3
-- enable FK support: pragma foreign_keys = ON;
drop table if exists Member;
drop table if exists Client;
drop table if exists Contact;
drop table if exists Area;
drop table if exists Pack;
drop table if exists PackArea;
drop table if exists Payment;
drop table if exists MonthlyCharge;
drop view if exists payment_with_total;

create table Client
(
	Id integer primary key autoincrement,
	Name varchar(50) not null,
	Surname varchar(50) not null,
	Address varchar(100),
	PhoneNumber numeric(13),
	Email varchar(50),
	-- constraint Client_pk primary key(Id),
	constraint Client_uq1 unique(Name, Surname)
);

create table Contact
(
	Id integer not null,
	Name varchar(100) not null,
	PhoneNumber numeric(13) not null,
	constraint Contact_pk primary key(Id)
);

create table Member
(
	Id integer not null,
	Active boolean not null,
	Height real,
	Weight real,
	Gender varchar(1),
	BirthDate date,
	PaymentDay integer not null,
	JoinDate date not null,
	Pack integer not null,
	Contact integer,
	Photo blob,
	constraint Member_pk primary key(Id),
	constraint Member_pk_fk foreign key(Id) references Client(Id),
	constraint Member_fk1 foreign key(Contact) references Contact(Id),
	constraint Pack_fk foreign key(Pack) references Pack(Id)
);

create table Area
(
	Id integer primary key autoincrement,
	Name varchar(50) not null,
	constraint Area_uq unique(Name)
);

create table Pack
(
	Id integer primary key autoincrement,
	Name varchar(50) not null,
	Price real not null,
	Membership real not null,
	constraint Pack_uq unique (Name)
);

create table PackArea
(
	Pack integer not null,
	Area integer not null,
	constraint PackArea_pk primary key(Pack, Area)
);

create table Payment
(
	Id integer not null,
	PaymentDate date not null,
	Amount real not null,
	Discount real not null,
	constraint Payment_pk primary key(Id)
);

create table MonthlyCharge
(
	Member integer not null,
	Payment integer,
	StartDate date not null,
	EndDate date not null,
	Notes text,
	constraint MonthlyCharge_pk primary key(Member, StartDate, EndDate),
	constraint MonthlyCharge_fk foreign key(Member) references Member(Id)
);

create table MembershipDebt
(
	Member integer not null,
	Payment integer,
	constraint MembershipDebt_pk primary key(Member),
	constraint MembershipDebt_fk foreign key(Member) references Member(Id),
	constraint MembershipDebt_fk2 foreign key(Payment) references Payment(Id)
);

create view payment_with_total as
select p.*, p.Amount - p.Discount as Total from Payment p;

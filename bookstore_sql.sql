---create Bookstore database--
create database BookStore;

use BookStore;

---create table---
create table Users(
UserId int primary key identity(1,1),
FullName varchar(255),
Email varchar(255),
Password varchar(255),
PhoneNumber bigint
)
select *from  Users;

----stored procedures for User Api------------------------
---Create procedured for User Registration----------------
Create procedure Registeruser(
@FullName varchar(255),
@Email varchar(255),
@Password varchar(255),
@PhoneNumber bigint)
As
Begin
insert into Users(FullName,Email,Password,PhoneNumber) values(@FullName,@Email,@Password,@PhoneNumber);
end

---Create procedure for User Login
create procedure UserLogin
(
@Email varchar(255),
@Password varchar(255)
)
as
begin
select * from Users
where Email = @Email and Password = @Password
End;
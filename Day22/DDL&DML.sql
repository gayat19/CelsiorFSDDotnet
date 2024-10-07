create database dbCompany07Oct2024

use dbCompany07Oct2024

--create,alter,drop - DDL
CREATE TABLE Area
(area varchar(10),
zipcode char(6)
)

select * from Area

sp_help Area

ALTER TABLE Area
add remarks varchar(20)

ALTER TABLE Area
drop column remarks

DROP TABLE Area


CREATE TABLE Areas
(area varchar(10) constraint pk_area primary key,
zipcode char(6)
)

CREATE TABLE Areas
(area varchar(10) primary key,
zipcode char(6)
)

CREATE TABLE Employees
(id INT IDENTITY(101,1) constraint pk_employee_ID primary key,
name varchar(20) not null,
phone varchar(15),
area varchar(10) constraint fk_area foreign key references Areas(area))

insert into areas(area,zipcode) values('ABC','887766')
insert into areas(area,zipcode) values('XYZ','998877'),('EFG','889900')

select * from Areas

insert into Employees(name,phone,area) values('Ramu','9876543210','ABC')

insert into Employees(name,phone,area) values('Somu','3210987654','XYZ'),('Bimu','7654983210','ABC')

--error coz of value given to teh identity column
insert into Employees(id,name,phone,area) values(104,'Ramu','9876543210','ABC')

--Foreign key constrint violation
insert into Employees(name,phone,area) values('Ramu','9876543210','KKK')

--Error coz of null to non null column
insert into Employees(name,phone,area) values(null,'9876543210','ABC')

select * from Employees

sp_help Employees

CREATE TABLE Skills
(skill_name varchar(50) constraint pk_skill primary key,
skill_description varchar(1000))

insert into Skills values('C#','Web'),('Java','OOPS'),('SQL','RDBMS')

CREATE TABLE EmployeesSkills
(Employee_id INT constraint fk_Employee_Skill_id foreign key references Employees(Id),
Employee_Skill varchar(50) constraint fk_Skill foreign key references Skills(skill_name),
skill_level float,
constraint pk_employee_skill primary key(Employee_id,Employee_skill))

sp_help EmployeesSkills

insert into EmployeesSkills values(101,'C#',7),(101,'SQL',7)
insert into EmployeesSkills values(102,'Java',8),(102,'SQL',7)

select * from EmployeesSkills

update EmployeesSkills set skill_level = 7.5 where Employee_id=101

update EmployeesSkills set skill_level = 7 where Employee_id=101 and Employee_Skill='SQL'

update Employees
set phone = '9988112233', area ='XYZ'
where Id = 103

delete  from EmployeesSkills 

delete  from EmployeesSkills where Employee_id=101 and Employee_Skill='SQL'

--error since it has a child record
delete from Employees where id =101
--error cannot drop parent tale when there is a child table referencing to it
DROP TABLE Employees
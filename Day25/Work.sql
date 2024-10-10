select * from Orders cross join Products
select * from Suppliers

select * from Products where CategoryID =3
union 
select * from Products where SupplierID in(2,4,7)


select * from Products where CategoryID =3
union all
select * from Products where SupplierID in(2,4,7)


select * from Products where CategoryID =3
intersect
select * from Products where SupplierID in(2,4,7)

select * from Products where CategoryID =3
Except
select * from Products where SupplierID in(2,4,7)

select top 5 * from products order by UnitPrice desc

select distinct supplierID from products

--print the supplier ids who have not made any supplies
select * from suppliers where SupplierID not in (select distinct supplierID from products)

--or

select supplierID from suppliers 
except
select distinct supplierID from products
-- print those product details that have never been ordered
select * from products where productId not in (select distinct ProductID from [Order Details])

select productId from Products
except 
select distinct ProductID from [Order Details]
--print the custome details who have never made any purchase
select CustomerID from Customers
Except
Select distinct customerID from orders 

select * from Employees

--print the employee name and reports to ID
select employeeId, Concat(Firstname,' ',LastName),ReportsTo managerID from Employees

--print the employee name and reports to ID
select emp.employeeId Employee_Id, Concat(emp.Firstname,' ',emp.LastName) Employee_Name, 
mgr.employeeId Manager_Id,Concat(mgr.Firstname,' ',mgr.LastName)manager_Name
from Employees emp join Employees mgr
on emp.ReportsTo = mgr.EmployeeID

select emp.employeeId Employee_Id, Concat(emp.Firstname,' ',emp.LastName) Employee_Name, 
mgr.employeeId Manager_Id,Concat(mgr.Firstname,' ',mgr.LastName)manager_Name
from Employees emp  left outer join Employees mgr
on emp.ReportsTo = mgr.EmployeeID

--print the products whose price is greater than products supplied by supplier from Germany
select * from products
where UnitPrice>(select UnitPrice from products where SupplierID in
(select SupplierID from Suppliers where Country = 'Germany'))

select * from products
where UnitPrice> all(select UnitPrice from products where SupplierID in
(select SupplierID from Suppliers where Country = 'Germany'))

select * from products
where UnitPrice> (select max(UnitPrice) from products where SupplierID in
(select SupplierID from Suppliers where Country = 'Germany'))

--stored procedure
use dbCompany07Oct2024

select * from EmployeesSkills
--data Injection
select * from EmployeesSkills where Employee_id = 101;delete from EmployeesSkills
select * from EmployeesSkills where Employee_Skill = 'C#';delete from EmployeesSkills

insert into EmployeesSkills values(101,'C#',7),(101,'SQL',7)
insert into EmployeesSkills values(102,'Java',8),(102,'SQL',7)

--Stored procedure is safe coz does not allow data injection
create procedure GetEmployeeSkills(@eskill varchar(100))
as
begin
	select * from EmployeesSkills where Employee_Skill = @eskill
end

drop proc GetEmployeeSkills

exec GetEmployeeSkills 'C#;delete from EmployeesSkills'



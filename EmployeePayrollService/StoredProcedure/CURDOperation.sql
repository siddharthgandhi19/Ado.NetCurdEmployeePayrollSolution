CREATE DATABASE Emp_Payroll;
USE Emp_Payroll;
CREATE TABLE EmpDetails (EmpId INT PRIMARY KEY IDENTITY, EmpName VARCHAR(40), EmpDept VARCHAR(40), EmpSalary BIGINT);
INSERT INTO EmpDetails VALUES ('Sid', 'Developer', 99000000), ('Lalit', 'JsDeveloper', 98000000), ('Sourav', 'Frontend', 8000000), ('Shubhi', 'HR', 7000000);
SELECT * FROM EmpDetails;

---store procedure

--VIEW
CREATE PROCEDURE GetEmpDetails 
AS BEGIN  
   SELECT * FROM EmpDetails
End 

--Insert
CREATE PROCEDURE AddNewEmpDetails
(  
   @EmpsName VARCHAR(40),  
   @EmpsDept VARCHAR(40),  
   @EmpsSalary BIGINT  
)
AS BEGIN  
   INSERT INTO EmpDetails VALUES(@EmpsName, @EmpsDept, @EmpsSalary)  
End

--Update
CREATE PROCEDURE UpdateEmpDetails
(  
   @EmpsId int,  
   @EmpsName VARCHAR(40),  
   @EmpsDept VARCHAR(40),  
   @EmpsSalary BIGINT  
)  
AS BEGIN  
   UPDATE EmpDetails SET EmpName = @EmpsName, EmpDept = @EmpsDept, EmpSalary = @EmpsSalary WHERE EmpId = @EmpsId 
END 
 
---Delete
CREATE PROCEDURE DeleteEmpDetails
(  
   @EmpsId int  
)  
AS BEGIN 
   DELETE FROM EmpDetails WHERE EmpId = @EmpsId  
END
--------------------------------------------------------------------------------------------------

EXEC GetEmpDetails

DECLARE  @EmpsName VARCHAR(40), @EmpsDept VARCHAR(40),  @EmpsSalary BIGINT 
EXEC AddNewEmpDetails 'Raju','Sales', 30785 

DECLARE @EmpsId INT, @EmpsName VARCHAR(40), @EmpsDept VARCHAR(40),  @EmpsSalary BIGINT 
EXEC UpdateEmpDetails 5, 'Ajay','PreSales', 29533 

DECLARE @EmpsId INT
EXEC DeleteEmpDetails 6


drop table EmpDetails
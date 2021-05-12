CREATE PROCEDURE spInsertEmployee
@Id INT NULL
,@Name NVARCHAR(50)
,@Salary INT
,@Email NVARCHAR(50)
,@Gender INT
AS
BEGIN
		INSERT INTO [tblEmployee] (
				 Name
				,Salary
				,Email
				,Gender
		)
		VALUES(
			 @Name
			,@Salary
			,@Email
			,@Gender
		)
END
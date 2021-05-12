CREATE PROCEDURE spUpdateEmployee
 @Id INT 
,@Name NVARCHAR(50)
,@Salary INT
,@Email NVARCHAR(50)
,@Gender INT
AS
BEGIN
		UPDATE [tblEmployee] 
		SET 
				 [Name]	 = @Name
				,Salary	 = @Salary
				,Email	 = @Email
				,Gender  = @Gender
		WHERE 
			Id=@Id
END
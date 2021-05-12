CREATE PROCEDURE spGetEmployeeById
@Id INT
AS
BEGIN
	SELECT 
		 E.Id
		,E.Name
		,E.Salary
		,E.Email
		,E.Gender
	FROM 
		[tblEmployee] E
	WHERE Id = @Id;
END
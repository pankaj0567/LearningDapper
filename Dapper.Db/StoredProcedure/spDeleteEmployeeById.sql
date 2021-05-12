CREATE PROCEDURE spDeleteEmployeeById
@Id INT
AS
BEGIN
	DELETE FROM  [tblEmployee] 
	WHERE Id = @Id;
END
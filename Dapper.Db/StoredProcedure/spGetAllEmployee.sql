CREATE PROCEDURE spGetAllEmployee
AS
BEGIN
	SELECT 
		 E.Id
		,E.Name
		,E.Salary
		,E.Email
		,E.Gender
	 FROM 
		[tblEmployee] E;
END
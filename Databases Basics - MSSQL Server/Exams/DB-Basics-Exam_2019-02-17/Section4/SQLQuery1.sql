
GO
CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(15,2))
RETURNS VARCHAR(MAX)
AS
BEGIN
	DECLARE @Student INT = (SELECT Id FROM Students WHERE Id = @studentId)
	DECLARE @StudentName VARCHAR(50) = (SELECT FirstName FROM Students WHERE Id = @studentId)

	IF(@Student IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!'
	END

	IF(@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!'
	END

	DECLARE @CountGrades INT = (SELECT COUNT(Grade) FROM StudentsExams WHERE StudentId = @studentId AND (Grade BETWEEN @grade AND (0.50 + @grade)))

	RETURN 'You have to update ' + CAST(@CountGrades AS varchar) + ' grades for the student ' + @StudentName 
END
GO

SELECT dbo.udf_ExamGradesToUpdate(12, 5.50)

GO
CREATE PROC usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	DECLARE @Student INT = (SELECT Id FROM Students WHERE Id = @StudentId)

	IF(@Student IS NULL)
	BEGIN
		RAISERROR('This school has no student with the provided id!', 16, 1)
		RETURN
	END

	DELETE FROM StudentsExams
	WHERE StudentId = @StudentId

	DELETE FROM StudentsTeachers
	WHERE StudentId = @StudentId

	DELETE FROM StudentsSubjects
	WHERE StudentId = @StudentId

	DELETE FROM Students
	WHERE Id = @StudentId
END

SELECT COUNT(*) FROM Students

EXEC usp_ExcludeFromSchool 1

CREATE TABLE ExcludedStudents
(
StudentId INT, StudentName VARCHAR(20)
)

GO
CREATE TRIGGER tr_DeletedStudent ON Students INSTEAD OF DELETE
AS
		INSERT INTO ExcludedStudents(StudentId, StudentName)
		SELECT Id, FirstName + ' ' + LastName FROM deleted
GO
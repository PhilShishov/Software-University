
--Find all teachers with their top students. 
--The top student is the person with highest average grade.
-- Select teacher full name (first name + last name), subject name, 
-- student full name (first name + last name) and corresponding grade. 
-- The grade must be formatted to the second digit after the decimal point.
--Sort the results by subject name (ascending), 
--then by teacher full name (ascending), then by grade (descending)


--Example
--Teacher Full Name	Subject Name	Student Full Name	Grade
--Farleigh Gerrans	Art	Horatia Kenforth	5.50
--Findlay Collingdon	Art	Zackariah Cordner	5.27
--Ruthanne Bamb	Biology	Merrill Habbijam	5.75

SELECT j.[Teacher Full Name], j.SubjectName ,j.[Student Full Name], FORMAT(j.TopGrade, 'N2') AS Grade
  FROM (
SELECT k.[Teacher Full Name],k.SubjectName, k.[Student Full Name], k.AverageGrade  AS TopGrade,
	   ROW_NUMBER() OVER (PARTITION BY k.[Teacher Full Name] ORDER BY k.AverageGrade DESC) AS RowNumber
  FROM (
  SELECT t.FirstName + ' ' + t.LastName AS [Teacher Full Name],
  	   s.FirstName + ' ' + s.LastName AS [Student Full Name],
  	   AVG(ss.Grade) AS AverageGrade,
  	   su.Name AS SubjectName
    FROM Teachers AS t 
    JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
    JOIN Students AS s ON s.Id = st.StudentId
    JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
    JOIN Subjects AS su ON su.Id = ss.SubjectId AND su.Id = t.SubjectId
GROUP BY t.FirstName, t.LastName, s.FirstName, s.LastName, su.Name
) AS k
) AS j
   WHERE j.RowNumber = 1 
ORDER BY j.SubjectName,j.[Teacher Full Name], TopGrade DESC
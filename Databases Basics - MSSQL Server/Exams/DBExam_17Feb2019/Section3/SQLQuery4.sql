
SELECT su.Name, AVG(ss.Grade) AS AverageGrade
  FROM Subjects AS su
  JOIN StudentsSubjects AS ss ON ss.SubjectId = su.Id
GROUP BY su.Name, su.Id
ORDER BY su.Id


--Divide the year in 4 quarters using the exam dates. 
--For each quarter get the subject name and the count of students who took the exam 
--with grade more or equal to 4.00. If the date is missing, replace it with “TBA”. 
--Order them by quarter ascending.
--Example
--Quarter	SubjectName	StudentsCount
--Q1	English	10
--Q1	French	12
--Q1	Physics	8
--Q2	English	10

SELECT k.Quarter, k.SubjectName, COUNT(k.StudentId) AS StudentsCount
  FROM
  (
SELECT 
		CASE
		WHEN DATEPART(qq, e.Date) = 1 THEN 'Q1'
		WHEN DATEPART(qq, e.Date) = 2 THEN 'Q2'
		WHEN DATEPART(qq, e.Date) = 3 THEN 'Q3'
		WHEN DATEPART(qq, e.Date) = 4 THEN 'Q4'		
		WHEN e.Date IS NULL THEN 'TBA'
		END AS [Quarter]
		,su.Name AS SubjectName
		,se.StudentId 
  FROM Exams AS e
  JOIN Subjects AS su ON su.Id = e.SubjectId
  JOIN StudentsExams AS se ON se.ExamId = e.Id
WHERE se.Grade >= 4.00
) AS k
GROUP BY k.Quarter, k.SubjectName
ORDER BY k.Quarter
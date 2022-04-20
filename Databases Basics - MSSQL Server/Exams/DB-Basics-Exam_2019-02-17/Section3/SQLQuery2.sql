
SELECT FirstName + ' ' + LastName AS FullName
  FROM Students AS s
  LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
 WHERE se.ExamId IS NULL 
ORDER BY FullName

SELECT TOP(10) t.FirstName, t.LastName, COUNT(st.StudentId) AS StudentsCount
  FROM Teachers AS t
  JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName
ORDER BY StudentsCount DESC, t.FirstName, t.LastName

SELECT TOP(10) s.FirstName, s.LastName, FORMAT(AVG(se.Grade), 'N2') AS Grade
  FROM Students AS s
  JOIN StudentsExams AS sE ON se.StudentId = s.Id
GROUP BY s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName


SELECT DISTINCT k.FirstName, k.LastName, k.Grade
  FROM
  (
	SELECT 
			 s.FirstName
			,s.LastName
			,ROW_NUMBER() OVER (PARTITION  BY s.FirstName, s.LastName ORDER BY ss.Grade DESC) AS GradeRank
			,ss.Grade
	  FROM Students AS s
	  JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
  ) AS k
  WHERE k.GradeRank = 2
  ORDER BY k.FirstName,k.LastName


SELECT FirstName + ' ' + ISNULL(MiddleName + ' ', '') + LastName AS FullName
  FROM Students AS s
  LEFT JOIN StudentsSubjects AS ss ON ss.StudentId = s.Id
  WHERE ss.SubjectId IS NULL
ORDER BY FullName
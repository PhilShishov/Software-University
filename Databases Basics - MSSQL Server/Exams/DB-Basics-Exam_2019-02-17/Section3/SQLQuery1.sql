SELECT FirstName, LastName, Age FROM Students
WHERE Age >= 12
ORDER BY FirstName, LastName

SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS FullName, [Address] FROM Students
WHERE Address LIKE '%ROAD%'
ORDER BY FirstName, LastName, Address

SELECT FirstName, Address, Phone  FROM Students
WHERE Phone LIKE '42%' AND MiddleName IS NOT NULL
ORDER BY FirstName

SELECT FirstName, LastName, COUNT(st.TeacherId) AS TeachersCount FROM Students AS s
JOIN StudentsTeachers AS st ON st.StudentId = s.Id
GROUP BY FirstName, LastName

SELECT 
		 t.FirstName + ' ' + t.LastName AS FullName 
		,s.Name + '-' + CAST(s.Lessons AS varchar) AS Subjects
		,COUNT(st.StudentId) AS Students
  FROM Teachers AS t
  JOIN Subjects AS s ON s.Id = t.SubjectId
  JOIN StudentsTeachers AS st ON st.TeacherId = t.Id
GROUP BY t.FirstName, t.LastName, s.Name, s.Lessons
ORDER BY Students DESC, FullName, s.Name

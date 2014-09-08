USE Company
SELECT dep.Name AS [Department], COUNT(dep.Id) AS [Employees Count] FROM Departments dep 
INNER JOIN Employees emp
ON dep.Id = emp.DepartmentId
GROUP BY dep.Name, dep.Id
ORDER BY [Employees Count] DESC
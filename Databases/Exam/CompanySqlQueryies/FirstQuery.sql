USE Company
SELECT emp.FirstName + ' ' + emp.LastName AS [Full Name], emp.YearSalary AS [Salary] From Employees emp
WHERE emp.YearSalary BETWEEN 100000 AND 150000
ORDER BY emp.YearSalary ASC
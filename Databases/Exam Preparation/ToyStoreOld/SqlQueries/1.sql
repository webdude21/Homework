USE ToyStore
SELECT t.Name, t.Price FROM Toys t
WHERE t.Price > 10 AND t.Type = 'puzzle'
ORDER BY t.Price ASC
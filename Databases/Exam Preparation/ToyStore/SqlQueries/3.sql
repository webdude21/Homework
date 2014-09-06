USE ToyStore
SELECT t.Name, t.Price, t.Color FROM Toys t
JOIN Categories cat
ON t.Categories_Id = cat.Id
WHERE cat.Name = 'boys'
USE ToyStore
SELECT man.Name, COUNT(t.Id) AS [Toys Count] FROM Manufacturers man
JOIN Toys t
ON man.Id = t.Manufacturer_Id
JOIN AgeRanges ag
ON ag.Id = t.AgeRanges_Id
WHERE ag.MinAge >= 5 AND ag.MaxAge <= 10
GROUP BY man.Name
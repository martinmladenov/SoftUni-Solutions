SELECT i.Name, i.Price, i.MinLevel, gt.Name
FROM Items i
LEFT JOIN GameTypeForbiddenItems f ON i.Id = f.ItemId
LEFT JOIN GameTypes gt ON f.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name ASC
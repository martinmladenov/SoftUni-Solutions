SELECT curr.CurrencyCode, curr.Description, COUNT(c.CountryCode) AS NumberOfCountries
FROM Currencies curr
LEFT JOIN Countries c ON c.CurrencyCode = curr.CurrencyCode
GROUP BY curr.CurrencyCode, curr.Description
ORDER BY NumberOfCountries DESC, curr.Description ASC
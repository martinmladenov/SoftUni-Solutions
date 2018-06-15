SELECT ContinentCode, CurrencyCode, Count	
FROM 
(SELECT ContinentCode, CurrencyCode,
COUNT(CountryName) AS Count,
DENSE_RANK() OVER (PARTITION BY ContinentCode order by COUNT(CurrencyCode) desc) as Rank
FROM Countries
GROUP BY ContinentCode, CurrencyCode) AS CountriesCurrencies
WHERE Rank = 1 AND Count > 1
ORDER BY ContinentCode
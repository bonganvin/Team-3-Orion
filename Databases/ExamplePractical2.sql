-- Practical 2 Scripts in Slides / Class Examples (Uses SocialHire.SQL)

-- SLIDE 3 -- Retrieving Data
-----------------------------------------
SELECT * FROM Client

SELECT First_Name FROM Client

SELECT First_Name, Last_Name
FROM Client


-- SLIDE 4 -- Restricting Data
-----------------------------------------
SELECT First_Name FROM Client
WHERE First_Name = 'Joan'

SELECT Client_ID, First_Name FROM Client
WHERE Client_ID = 1

SELECT Client_ID, First_Name FROM Client
WHERE Client_ID IS NULL


-- SLIDE 6 -- Restricting Data - Compound Conditions
-----------------------------------------
SELECT Client_ID, FIrst_Name, Last_Name
FROM Client
WHERE Client_ID > 10 AND First_Name = 'Louis'

SELECT Client_ID, First_Name, Last_Name
FROM Client
WHERE Client_ID <> 10 AND First_Name <> 'Louis' -- the <> operator

SELECT Client_ID, First_Name, Last_Name
FROM Client
WHERE NOT (Client_ID = 10) -- using the word NOT


-- SLIDE 7 --

SELECT Client_ID, First_Name, Last_Name
FROM Client
WHERE Client_ID >= 10 AND Client_ID <= 20

SELECT Client_ID, First_Name, Last_Name
FROM Client
WHERE Client_ID BETWEEN 10 AND 20 -- using the BETWEEN condition


-- SLIDE 8 --

SELECT * FROM Client
WHERE Client_ID IN (1,5,7)

SELECT * FROM Client
WHERE Physical_Address LIKE ('%Church%')


-- SLIDE 9 --

SELECT DISTINCT(City_Name) FROM City


-- SLIDE 10 -- Calculated / Computed Columns
-----------------------------------------
SELECT *, Rate_Percentage +10 as NewChargeRate FROM Charge_Rate


-- SLIDE 11 -- Functions
-----------------------------------------
SELECT SUM (Rate_Level) AS TotalRate FROM Client_Rating
SELECT AVG (Rate_Level) AS AveragelRate FROM Client_Rating
SELECT MAX (Rate_Level) AS MaxRate FROM Client_Rating
SELECT MIN (Rate_Level) AS MinRate FROM Client_Rating


-- SLIDE 12 -- SORTING Results – ORDER BY
-----------------------------------------
SELECT * FROM Client
ORDER BY Last_Name

SELECT * FROM Client
ORDER BY Last_Name DESC

-- SLIDE 13 -- GROUPING Results – GROUP BY
-----------------------------------------

SELECT Complaint_Nature FROM Complaint

SELECT Complaint_Nature FROM Complaint
GROUP BY Complaint_Nature
ORDER BY Complaint_Nature



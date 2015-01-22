-- 1

SELECT * FROM Customers;


-- 2

SELECT DISTINCT 
  C.* 
FROM 
  Customers C,
  Orders O
WHERE
  O.CUSTOMER_ID = C.ID
;


-- 3

SELECT DISTINCT
  C.*
FROM 
  Customers C 
    LEFT OUTER JOIN 
  Orders O
    ON O.CUSTOMER_ID = C.ID
WHERE 
  O.ID IS NULL
;


-- 4

  -- Customer.ID, Orders.ID, Orders.CUSTOMER_ID
  -- The ID fields are presumably unique keys for the table, and indexing them would allow random access retrieval without table scans.
  -- Indexing Orders.CUSTOMER_ID allows joins to the Customers table to be evaluated by reading the indexes only.


-- 5

SELECT 
  C.Name, 
  C.Email, 
  COUNT(O.ID) as NumberOfOrders
FROM 
  Customers C, Orders O
WHERE
  O.CUSTOMER_ID = C.ID
GROUP BY
  C.Id,
  C.Name, 
  C.Email


-- 6

SELECT 
  C.Name, 
  C.Email, 
  COUNT(O.ID) as NumberOfOrders
FROM 
  Customers C, Orders O
WHERE
  O.CUSTOMER_ID = C.ID
GROUP BY
  C.Id,
  C.Name, 
  C.Email
HAVING
  COUNT(O.ID) BETWEEN 2 AND 5
;
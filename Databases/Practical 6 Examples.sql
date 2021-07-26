--- Use DBSocialHire
---Slide 3: String functions
select concat(first_name, last_name) from Client
select concat(first_name, ' ', last_name) from Client
select first_name + '' + last_name

select left(office_number,3) from Client
select right(Email_Address,4) from Client

--- Slide 4: L/RTRIM could not find a suitable example in the database

-- Slide 5: Numeric values
 

select inp_date, avg(inp_amount) from inpayment
group by inp_date

-- SUM, MIN, MAX
select sum(inp_amount) from InPayment
select inp_date, sum(inp_amount) from inpayment
group by inp_date

-- Slide 6: COUNT, DISTINCT, ROUND
select count(province_name) from province

select distinct (province_name) from province

select Out_Amount * 0.75 as NewOutAmount, round(out_amount * 0.75,0) as RoundedAmount
from OutPayment

-- Slide 7: date / time functions
select date_complaint, date_resolved, datediff(ww,date_complaint,date_resolved) as DateDifference
from complaint
--where datediff(ww,date_complaint,date_resolved)> 0

-- Slide 8: More date functions
select DATENAME (dw, date_complaint) as Weekday
from Complaint

select DATEPART (dw, date_complaint) as Weekday
from Complaint

select DAY(date_complaint) 
from complaint

select getdate() as DateToday, date_complaint
from complaint

-- Slide 9: CAST and COVERT
select cast(date_complaint AS int) as NewDate
from complaint

-- Slide 12: GROUP BY and HAVING
select inp_date, sum(inp_amount) from inpayment
group by inp_date
having sum(inp_amount) > 100

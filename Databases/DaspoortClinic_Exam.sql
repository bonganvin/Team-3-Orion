Use Master
Go
If Exists (Select * from sys.databases where name = 'Daspoort_Clinic_SemesterTest')
DROP DATABASE Daspoort_Clinic_SemesterTest
Go
Create Database Daspoort_Clinic_SemesterTest
Go

Use Daspoort_Clinic_SemesterTest
Go


Create table Title
(Title_ID int primary key identity(1,1),
Name varchar(10))

Insert into Title values ('Mr')
Insert into Title values ('Mrs')
Insert into Title values ('Miss')
Insert into Title values ('Dr')
Insert into Title values ('Prof')
Insert into Title  values ('Rev')
Insert into Title values ('Other')

Create table Allergy
(Allergy_ID int primary key identity(1,1),
Allergy_Name varchar(50))

Insert into Allergy values ('Milk')
Insert into Allergy values ('Pollen')
Insert into Allergy values ('Cat')
Insert into Allergy values ('Perfume')
Insert into Allergy values ('House dust mite')
Insert into Allergy values ('Tetracycline')
Insert into Allergy values ('Peanuts')
Insert into Allergy values ('Dilantin')
Insert into Allergy values ('Penicillin')
Insert into Allergy values ('Cephalosporins')
Insert into Allergy values ('Local anesthetics')
Insert into Allergy values ('Garlic')
Insert into Allergy values ('Aspartame')
Insert into Allergy values ('Soy')
Insert into Allergy values ('Egg')


Create table Patient
(Patient_No int primary key ,
Name varchar(50) not null,
Surname varchar(50) not null,
Title int references Title(Title_ID) ,
CitizenShip varchar(25),
ID_Number varchar(13) default 'N/A' ,
Passport_No varchar(20) default 'N/A',
Patient_Address varchar(150),
TelePhone varchar(10),
Gender varchar(10),
Date_Of_Birth varchar(20))

Insert into Patient  values (1200001,'Kagisho','Mokgalaka',1,'South African','9101232595083','','212 Mazabuka Troye street Sunnyside','0787553424','Male','19910203')
Insert into Patient  values (1200002,'Tom','Tonga',1,'South African','9101232595083','','55 Hollywood Heights Troye street Sunnyside','0739694471','Male','19900223')
Insert into Patient  values (1200003,'Milton','Tonga',1,'South African','6501232595083','','55 Hollywood Heights Troye street Sunnyside','0839521707','Male','19650812')
Insert into Patient values (1200004,'Muhammed','Gaffer',1,'South African','7212312213086','','1328 Elbeneza Hatfield street Pretoria','0112364568','Male','19721231')
Insert into Patient values (1200005,'Lovedale','Maduna',1,'South African','6909235515085','','101 Fairview Village Hatfield','0879800843','Female','19690923')
Insert into Patient values (1200006,'Maite','Bentley',1,'Zambian','','P763N09','12 The Gables Prospect street','084115993','Female','19721231')
Insert into Patient values (1200007,'Chris','Kirkwood',1,'South African','8901034877980','','190 Life Good 7th street','0157840012','Male','19890103')
Insert into Patient values (1200008,'Sbongile','Whitten',1,'Zimbabwean','','788U890','234 Prospect street Amazimtoti','0826774123','Female','19721231')
Insert into Patient values (1200009,'Pieter','Grobler',1,'Dutch','','0023ID8','Heaven Gold No.89 ','0436754322','Male','19650621')
Insert into Patient values (1200010,'Shelly','Cashman',1,'American','','551298PP','P45 The Fields Mountain street','0785661880','Female','19550912')
Insert into Patient values (1200011,'Surette','Warnich',1,'Swiss','','9989SS89','8 The Boulders unkn street','0112364568','Female','19850928')
Insert into Patient values (1200012,'Elizabeth','Maepa',1,'South African','6909238905070','','76 Ga-Masha','0726568712','Female','19690923')
Insert into Patient values (1200013,'Piet','Morris',1,'South African','7912126753100','','78 The East Gate Lynwood road','0746779012','Male','19791212')
Insert into Patient values (1200014,'April','May',1,'Zambian','','P889N55','X34 Elbeneza Hatfield street','0112364568','Male','19700212')
Insert into Patient values (1200015,'Esmeron','Series',1,'South African','9609171175087','','90 Sgodiphola Mashishing','0132351988','Male','19960917')
Insert into Patient values (1200016,'Frank','Lampard',1,'English','','EXJ99876','1101 The Boulders Thomas street','0726002122','Male','19790720')
Insert into Patient values (1200017,'Steven','Gerald',1,'South African','8902126755568','','45 Mellow park south','0542563200','Male','19890212')
Insert into Patient values (1200018,'Portia','Modise',1,'Swiss','','SW34232N','123 Tramshed Square Mopanie street','0895563141','Female','19550522')
Insert into Patient values (1200019,'Emilly','Baron',1,'South African','9307090025608','','No. 78 No Home Address','0113695596','Female','19930709')


Create table PatientAllergy
(Patient_No int references Patient(Patient_No),
Allergy_ID int references Allergy(Allergy_ID))

insert into PatientAllergy values (1200002,4)
Insert into PatientAllergy values(1200001,1)
Insert into PatientAllergy values (1200001,3)
insert into PatientAllergy values (1200002,5)
Insert into PatientAllergy values(1200001,11)
Insert into PatientAllergy values (1200003,15)
Insert into PatientAllergy values (1200003,4)
Insert into PatientAllergy values (1200003,10)
Insert into PatientAllergy values (1200012,1)
Insert into PatientAllergy values (1200012,11)
Insert into PatientAllergy values (1200012,9)
Insert into PatientAllergy values (1200009,10)
Insert into PatientAllergy values (1200015,2)
Insert into PatientAllergy values (1200015,7)
Insert into PatientAllergy values (1200009,3)
Insert into PatientAllergy values (1200014,6)
Insert into PatientAllergy values (1200014,8)
Insert into PatientAllergy values (1200005,6)
Insert into PatientAllergy values (1200008,6)
Insert into PatientAllergy values (1200011,8)
Insert into PatientAllergy values (1200004,2)

Create table Consultation
(Consult_No int primary key identity(1,1),
Con_Weight decimal(5),
Con_Hist_Height decimal(5),
Con_Hist_BMI decimal(5),
Con_Hist_UrineTest varchar(20) default 'N/A',
Con_Hist_Temperature decimal(5) default 0,
Con_Hist_HeartRate decimal(5) default 0,
Con_Hist_Waist decimal(5) default 0,
Con_Hist_BloodPressure varchar(10)default 'N/A',
Con_Hist_BloodGlucose decimal(5) default 0,
Con_Hist_Oedema varchar(20) default 'N/A',
Con_Hist_EpilepsyBloods decimal(5) default 0,
Con_Consult_Date varchar(30),
Con_Note varchar(150) default 'N/A',
Patient_No int references Patient(Patient_No))

Insert into Consultation  values (65,1.85,94.4,'pH',37,75,32,60,0,'N/A',0,'02-02-2012 11:48 AM','N/A',1200001)
Insert into Consultation  values (70,1.92,103.2,'pH',41,79,34,63,0,'N/A',0,'09-06-2012 11:48 AM','N/A',1200002)
Insert into Consultation  values (69,1.88,96.2,'pH',34,70,34,62,0,'N/A',0,'15-06-2011 3:12 PM','N/A',1200003)
Insert into Consultation values (88,1.55,111.4,'HPN',40,71,36,75,0,'N/A',0,'02-02-2011 08:55 AM','N/A',1200015)
Insert into Consultation  values (56,1.09,89.2,'JP',41,82,30,67,0,'N/A',0,'12-12-2012 1:32 PM','N/A',1200007)
Insert into Consultation values (76,1.70,89.9,'Nic',39,76,41,70,0,'N/A',0,'19-06-2012 3:12 PM','N/A',1200009)
Insert into Consultation values (77,1.73,99.4,'Nic',37,78,36,68,0,'N/A',0,'21-01-2013 9:55 AM','N/A',1200012)
Insert into Consultation  values (62,1.96,101.7,'pH',55,86,36,60,0,'N/A',0,'09-01-2013 3:23 PM','N/A',1200011)
Insert into Consultation values (69,7.88,96.2,'pH',36,74,34,62,0,'N/A',0,'15-02-2013 2:54 PM','N/A',1200003)




Create table Condition_Type
(Con_Type_ID int primary key identity(1,1),
Con_Type_Name varchar(20))

Insert into Condition_Type values ('Disease')
Insert into Condition_Type values ('Injury')
Insert into Condition_Type values ('Medical Status')

Create table Condition 
(Con_ID int identity(1,1) primary key,
Con_Name varchar(50),
Con_Priority varchar(10),
Con_Chronic varchar(10),
Con_Type int references Condition_Type(Con_Type_ID))

Insert into Condition values ('Chronic kidney disease','Low','True',1)
Insert into Condition values ('Broken tibia','Low','False',2)
Insert into Condition values ('Pregnant','Low','False',3)
Insert into Condition values ('Asthma','Medium','True',1)
Insert into Condition values ('Diabetes mellitus type 1, in adults','Low','False',1)
Insert into Condition values ('Fever','Low','False',1)
Insert into Condition values ('Stroke','Low','False',1)
Insert into Condition values ('Malaria','Low','False',1)


Create table Symptom
(Symptom_ID int primary key identity(1,1),
Symptom_Name varchar(50))

Insert into Symptom values ('Dyspnoena or shortness of breath')
Insert into Symptom values ('Cough')
Insert into Symptom values ('Hypertension')
Insert into Symptom values ('Diabetes mellitus')
Insert into Symptom values ('Hunger')
Insert into Symptom values ('Thirst')
Insert into Symptom values ('Weight loss')
Insert into Symptom values ('ketoacidosis')
Insert into Symptom values ('Difficulty speaking or understanding')
Insert into Symptom values ('Dizzinessm loss of balance or unsteady gait')
Insert into Symptom values ('Headache')
Insert into Symptom values ('Flu-like symptoms')
Insert into Symptom values ('Fever')
Insert into Symptom values ('Muscle joint pains')
Insert into Symptom values ('Nausea and vomitting')


Create table Diagnosis
(Consult_No int references Consultation(Consult_No),
Con_ID int references Condition(Con_ID))

Insert into Diagnosis values(1,6)
Insert into Diagnosis values(1,8)
Insert into Diagnosis values(2,6)
Insert into Diagnosis values(3,4)
Insert into Diagnosis values(4,1)


Create table Condition_Symptom
(Con_ID int references Condition(Con_ID) ,
Symptom_ID int references Symptom(Symptom_ID))
--constraint CS_ID primary key (Con_ID,Symptom_ID))

Insert into Condition_Symptom values (4,1)
Insert into Condition_Symptom values (4,2)
Insert into Condition_Symptom values (1,3)
Insert into Condition_Symptom values (1,4)
Insert into Condition_Symptom values (5,5)
Insert into Condition_Symptom values (5,6)
Insert into Condition_Symptom values (5,7)
Insert into Condition_Symptom values (5,8)
Insert into Condition_Symptom values (7,9)
Insert into Condition_Symptom values (7,10)
Insert into Condition_Symptom values (7,11)
Insert into Condition_Symptom values (8,12)
Insert into Condition_Symptom values (8,13)
Insert into Condition_Symptom values (8,14)
Insert into Condition_Symptom values (8,15)
Insert into Condition_Symptom values (7,15)


Create table Prescription
(Presc_ID int primary key identity(1,1),
Patient_No int references Patient(Patient_No))

Insert into Prescription values (1200001)
Insert into Prescription values (1200002)
Insert into Prescription values (1200003)
Insert into Prescription values (1200004)
Insert into Prescription values (1200010)
Insert into Prescription values (1200010)

Create table Prescription_Note
(PNote_ID int primary key identity(1,1),
Diagnosis varchar(150),
Treatment varchar(150) ,
Presc_ID int references Prescription(Presc_ID))

Insert into Prescription_Note values ('Chronic kidney disease','Lamivudine Tablets 150MG',1)
Insert into Prescription_Note values ('Broken tibia','Water for injection',2)
Insert into Prescription_Note values ('Malaria','Calcium gluconate 10%',3)


Create table Medication_Type
(Med_Type_ID int primary key identity(1,1),
Med_Type_Name varchar(150))

Insert into Medication_Type values ('Small Volume Parenteral')
Insert into Medication_Type values ('Dry Drugs')
Insert into Medication_Type values ('Eye, Ear, and Nose Drops & Asthma Spray')
Insert into Medication_Type values ('Medical Liquids')
Insert into Medication_Type values ('TB Drugs')
Insert into Medication_Type values ('Antibiotic')
Insert into Medication_Type values ('Solid Dosage Form-Anti-Retrovirals')
Insert into Medication_Type values ('Oral')
Insert into Medication_Type values ('Procaine Injection')


Create table Medication
(Med_ID int primary key identity(1,1),
Med_Name varchar(250),
Unit varchar(10),
Quantity_Bought int,
QtyAvailable int,
Min_Stock_Level int,
Med_Type int references Medication_Type(Med_Type_ID))

Insert into Medication values ('Lamivudine Tablets 150MG','6s',256,256,10,7)
Insert into Medication values ('Zidovudine Tablets 300MG','14s',500,500,10,7)
Insert into Medication values ('Calcium gluconate 10%','10ml',212,212,5,1)
Insert into Medication values ('Water for injection','10ml',150,150,10,4)
Insert into Medication values ('Calamine Lotion BP','100ml',100,100,10,3)
Insert into Medication values ('Acetic acid 2% in 455 alcohol ear solution','10ml',50,50,5,3)
Insert into Medication values ('Paracetamol 120mg/5ml','50ml',320,320,10,4)
Insert into Medication values ('Ethambutol Tablets 400mg','84',100,100,10,5)
Insert into Medication values ('Amoxycillin 125mg/5ml','100ml',50,50,5,6)
Insert into Medication values ('Phenoxymethyl penicillin 250mg/5ml','100ml',60,60,10,6)
Insert into Medication values ('Methydopa 250mg','50ml',120,120,10,8)
Insert into Medication values ('Erythromycin 500mg','84',100,100,10,9)
Insert into Medication values ('Aspirin Soluble','180ml',523,523,5,8)
Insert into Medication values ('Phenoxymethyl penicillin 150mg/5ml','100ml',26,26,5,3)
 
Create table Prescribed_Medication
(Presc_ID int references Prescription(Presc_ID),
Med_ID int references Medication(Med_ID),
Prescr_Med_Quantity int,
Dosage varchar(100))

Insert into Prescribed_Medication values (1,3,2,'5 spoons per day')
Insert into Prescribed_Medication values (1,2,5,'5 nazal per day')
Insert into Prescribed_Medication values (2,2,20,'3 spoons per day')
Insert into Prescribed_Medication values (2,5,12,'2 times every night')

Create table Sick_Note
(SNote_ID int primary key identity(1,1),
Desription varchar(200),
Note_Date varchar(30),
BookedFrom varchar(20),
BookTo varchar(20),
Patient_No int references Patient(Patient_No))
Go

Insert into Sick_Note values ('Angina, heart disease', '2012-09-12','2012-09-12','2012-09-30',1200001)



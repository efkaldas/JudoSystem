CREATE TABLE Judge(
	id int AUTO_INCREMENT PRIMARY KEY,
	firstname Varchar(256) NOT NULL,
	lastname varchar(256) NOT NULL,
	genderId int NOT NULL,
	birthYears varchar(256) NOT NULL,
	qualificationId int NOT NULL,
	FOREIGN KEY (genderId) REFERENCES Gender(id),
	FOREIGN KEY (qualificationId) REFERENCES Judge_qualification(id)
)

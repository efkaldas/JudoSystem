CREATE TABLE Judoka(
	id int AUTO_INCREMENT PRIMARY KEY,
	firstname varchar(256) NOT NULL,
	lastname nvarchar(256) NOT NULL,
	genderId int NOT NULL,
	birthYears nvarchar(256) NOT NULL,
	danKyuId int NOT NULL,
	FOREIGN KEY (genderId) REFERENCES Gender(id),
	FOREIGN KEY (danKyuId) REFERENCES DanKyu(id)
)

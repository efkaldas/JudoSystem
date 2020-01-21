CREATE TABLE Organizations(
	id int AUTO_INCREMENT PRIMARY KEY,
	name varchar(256) NOT NULL,
	country nvarchar(256) NOT NULL,
	city nvarchar(256) NOT NULL,
	typeId int,
	FOREIGN KEY (typeId) REFERENCES Organization_Types(id)
)

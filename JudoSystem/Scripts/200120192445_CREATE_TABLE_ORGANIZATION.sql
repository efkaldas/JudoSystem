CREATE TABLE Organization(
	id int AUTO_INCREMENT PRIMARY KEY,
	name varchar(256) NOT NULL,
	country varchar(256) NOT NULL,
	city varchar(256) NOT NULL,
	typeId int
)

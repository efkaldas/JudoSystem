CREATE TABLE User(
	id int AUTO_INCREMENT PRIMARY KEY,
	role int not null,
	parentUser int default 0,
	email varchar(256) not null,
	firstname varchar(256) not null,
	lastname varchar(256) not null,
	phoneNumber varchar(256) not null,
	status int default 0,
	organizationId int,
	password varchar(256) not null,
	dateCreated TIMESTAMP not null,
	dateUpdated TIMESTAMP not null
)
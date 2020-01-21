CREATE TABLE Users(
	id int AUTO_INCREMENT PRIMARY KEY,
	role int not null,
	parentUser int default 0,
	email nvarchar(256) not null,
	firstname nvarchar(256) not null,
	lastname nvarchar(256) not null,
	phoneNumber nvarchar(256) not null,
	status int default 0,
	organizationId int,
	password nvarchar(256) not null,
	dateCreated TIMESTAMP not null,
	dateUpdated TIMESTAMP not null
)
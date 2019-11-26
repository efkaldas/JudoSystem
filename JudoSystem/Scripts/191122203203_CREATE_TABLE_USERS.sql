CREATE TABLE Users(
	id int AUTO_INCREMENT PRIMARY KEY,
	userRole int not null,
	userName nvarchar(256) not null,
	clubName nvarchar(256) not null,
	firstName nvarchar(256) not null,
	lastName nvarchar(256) not null,
	country nvarchar(256) not null,
	city nvarchar(256) not null,
	email nvarchar(256) not null,
	password nvarchar(256) not null,
	dateCreated TIMESTAMP not null,
	dateUpdated TIMESTAMP not null
)
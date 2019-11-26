CREATE TABLE Judokas(
	id int NOT NULL AUTO_INCREMENT,
	firstName varchar(256) NOT NULL,
	lastName varchar(256) NOT NULL,
	gender int(1) NOT NULL,
	danKyu int NOT NULL,
	birthYears int NOT NULL,
	userID int,
	PRIMARY KEY (id),
	FOREIGN KEY (userID) REFERENCES Users(id)
);

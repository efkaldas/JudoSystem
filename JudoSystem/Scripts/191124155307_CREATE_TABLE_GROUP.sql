CREATE TABLE age_Groups(
	id int NOT NULL AUTO_INCREMENT,
	title varchar(256) NOT NULL,
	gender int(1) NOT NULL,
	yearsFrom int NOT NULL,
	yearsTo int NOT NULL,
	eventID int,
	PRIMARY KEY (id),
	FOREIGN KEY (eventID) REFERENCES events(id)
);

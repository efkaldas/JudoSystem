CREATE TABLE Events(
	id int NOT NULL AUTO_INCREMENT,
	eventType int,
	title varchar(256) NOT NULL,
	description varchar(256) NOT NULL,
	entryFee decimal NOT NULL,
	registrationStartDate TIMESTAMP NOT NULL,
	registrationEndDate TIMESTAMP NOT NULL,
	eventStartDate TIMESTAMP NOT NULL,
	PRIMARY KEY (id)
);

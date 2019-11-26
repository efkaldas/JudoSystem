CREATE TABLE categories(
	id int NOT NULL AUTO_INCREMENT,
	title varchar(256) NOT NULL,
	groupID int,
	PRIMARY KEY (id),
	FOREIGN KEY (groupID) REFERENCES age_groups(id)
);

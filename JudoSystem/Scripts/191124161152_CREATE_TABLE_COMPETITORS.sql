CREATE TABLE competitors(
	id int NOT NULL AUTO_INCREMENT,
	categoryID int,
	judokaID int,
	PRIMARY KEY (id),
	FOREIGN KEY (categoryID) REFERENCES categories(id),
	FOREIGN KEY (judokaID) REFERENCES judokas(id)
);

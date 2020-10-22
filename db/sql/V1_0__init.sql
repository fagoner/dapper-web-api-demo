CREATE SCHEMA IF NOT EXISTS MOVIE;

USE MOVIE;

CREATE TABLE IF NOT EXISTS  MOVIE.ACTOR(
  id INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
  name  VARCHAR(100) NOT NULL
);

INSERT INTO MOVIE.ACTOR (name) values
("Russell Crowe"),
("Joaquin Phoenix"),
("Connie Nielsen"),
("Oliver Reed"),
("Richard Harris"),
("Derek Jacobi"),
("Djimon Hounsou"),
("David Schofield"),
("John Shrapnel"),
("Tomas Arana"),
("Ralf Moeller"),
("Spencer Treat Clark"),
("David Hemmings"),
("Tommy Flanagan"),
("Sven-Ole Thorsen");


-- DROP MOVIE.ACTOR


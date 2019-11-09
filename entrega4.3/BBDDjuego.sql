
DROP DATABASE IF EXISTS BBDDjuego;
CREATE DATABASE BBDDjuego;

USE BBDDjuego;

CREATE TABLE Partida (
id INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
ganador VARCHAR(20) NOT NULL,
tiempo INTEGER NOT NULL,
fecha VARCHAR(10) NOT NULL,
dificultad CHAR NOT NULL
)ENGINE = InnoDB;

CREATE TABLE Jugador (
id INTEGER PRIMARY KEY NOT NULL AUTO_INCREMENT,
nombre VARCHAR(20) NOT NULL,
contra VARCHAR(20) NOT NULL,
puntuacionMax INTEGER NOT NULL
)ENGINE = InnoDB;

CREATE TABLE Relacion (
idPartida INTEGER NOT NULL,
idJugador INTEGER NOT NULL,
puntuacion INTEGER NOT NULL,
FOREIGN KEY (idJugador) REFERENCES Jugador(id),
FOREIGN KEY (idPartida) REFERENCES Partida(id)
)ENGINE = InnoDB;

-- Introduzco datos en la BD
INSERT INTO Partida(id, ganador, tiempo, fecha, dificultad) VALUES(NULL, "Yo", 500, "14/08/1969","f");
INSERT INTO Partida(id, ganador, tiempo, fecha, dificultad) VALUES(NULL, "Tu", 100, "14/08/1969","f");
INSERT INTO Partida(id, ganador, tiempo, fecha, dificultad) VALUES(NULL, "Él", 200, "02/07/1971","d");
INSERT INTO Partida(id, ganador, tiempo, fecha, dificultad) VALUES(NULL, "Ella", 169, "02/07/1972","d");
INSERT INTO Partida(id, ganador, tiempo, fecha, dificultad) VALUES(NULL, "Él", 420, "02/07/1972","d");

INSERT INTO Jugador VALUES(NULL, "Yo", "1234", 400);
INSERT INTO Jugador VALUES(NULL, "Tu", "12345", 500);
INSERT INTO Jugador VALUES(NULL, "Él", "123456", 200);
INSERT INTO Jugador VALUES(NULL, "Ella", "123458", 300);

INSERT INTO Relacion VALUES(1, 1, 400);
INSERT INTO Relacion VALUES(1, 2, 350);
INSERT INTO Relacion VALUES(2, 2, 500);
INSERT INTO Relacion VALUES(2, 3, 50);
INSERT INTO Relacion VALUES(2, 4, 200);
INSERT INTO Relacion VALUES(3, 3, 200);
INSERT INTO Relacion VALUES(3, 1, 100);
INSERT INTO Relacion VALUES(4, 4, 300);
INSERT INTO Relacion VALUES(4, 3, 150);
INSERT INTO Relacion VALUES(4, 1, 100);
INSERT INTO Relacion VALUES(5, 3, 100);
INSERT INTO Relacion VALUES(5, 4, 10);
INSERT INTO Relacion VALUES(5, 1, 99);


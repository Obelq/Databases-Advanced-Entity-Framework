USE MinionsDB

CREATE TABLE Minions(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(25),
Age INT,
TownId INT
);

CREATE TABLE Towns(
Id INT PRIMARY KEY IDENTITY,
TownName VARCHAR(25),
CountryName VARCHAR(25)
);

CREATE TABLE Villains(
Id INT PRIMARY KEY IDENTITY,
Name VARCHAR(25),
EvilnessFactor VARCHAR(20) CHECK(EvilnessFactor IN ('good', 'bad', 'evil', 'super evil'))
);

CREATE TABLE MinionsVillains(
MinionId INT,
VillainId INT,
CONSTRAINT PK_Minion_Villain PRIMARY KEY(MinionId, VillainId),
CONSTRAINT FK_MinionsVillains_Minions FOREIGN KEY(MinionId)
REFERENCES Minions(Id),
CONSTRAINT FK_MinionsVillains_Villains FOREIGN KEY(VillainId)
REFERENCES Villains(Id)
);

INSERT INTO Minions(Name,Age,TownId)
VALUES('Rex', 3, 1), ('Reni', 5, 2), ('Raze', 14, 1), ('Zexy', 12, 1), ('Zert', 8, 3);

INSERT INTO Towns(TownName, CountryName)
VALUES('Sofia', 'Bulgaria'), ('Budapest', 'Hungary'), ('Vienna', 'Austria'), ('Bukurest', 'Rumania'), ('Brazil', 'Brazil');

INSERT INTO Villains(Name, EvilnessFactor)
VALUES('Voltron', 'good'), ('Voldemor', 'super evil'), ('Lucifer', 'super evil'), ('Ratatui', 'evil'), ('Saouron', 'bad');

INSERT INTO MinionsVillains
VALUES(1, 2), (3, 4) , (1, 5), (2, 4), (4, 1), (5, 3),(1, 1), (1, 4) , (2, 1), (2, 2), (2, 5);

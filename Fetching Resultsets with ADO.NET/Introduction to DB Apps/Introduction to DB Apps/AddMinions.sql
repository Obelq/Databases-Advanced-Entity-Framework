USE MinionsDB

INSERT INTO Minions(Name, Age, TownId)
VALUES(@MinionName, @Age, @TownId);

INSERT INTO MinionsVillains
VALUES ((SELECT TOP 1 Id FROM Minions WHERE Name = @MinionName), @VillainId)

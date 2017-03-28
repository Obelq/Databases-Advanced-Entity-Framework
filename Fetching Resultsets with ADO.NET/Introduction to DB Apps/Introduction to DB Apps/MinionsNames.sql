USE MinionsDB

SELECT v.Name, m.Name, m.Age FROM Villains AS v
	LEFT JOIN MinionsVillains as mv
		ON v.Id = mv.VillainId
	LEFT JOIN Minions AS m
		ON mv.MinionId = m.Id
	WHERE v.Id = @VillianId

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Introduction_to_DB_Apps
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDatabase();

            var connection = new SqlConnection(@"Server=.;Database=MinionsDB;
   Integrated Security = true;");

            //InitialSetup(connection);

            //VillainsNames(connection);

            //MinionsNames(connection);

            //AddMinions(connection);

            //UpTownName(connection);

            //RemoveVillain(connection);

            //PrintMinionsNames(connection);

            //IncMinionsAge(connection);

            IncreaseAgeProcedure(connection);


        }

        private static void IncreaseAgeProcedure(SqlConnection connection)
        {
            /*var createProcedure = @"CREATE PROCEDURE usp_GetOlder(@Id INT)
AS
BEGIN
	UPDATE Minions SET Age += 1
	WHERE Id = @Id
END";*/

            connection.Open();
            using (connection)
            {
                int id = int.Parse(Console.ReadLine());
                var procCommand = new SqlCommand(@"EXEC usp_GetOlder @Id", connection);
                procCommand.Parameters.AddWithValue("@Id", id);
                procCommand.ExecuteNonQuery();

                var selectCommand = new SqlCommand(@"SELECT Name, Age FROM Minions WHERE Id = @Id", connection);
                selectCommand.Parameters.AddWithValue("@Id", id);
                
                var reader = selectCommand.ExecuteReader();
                using (reader)
                {
                    reader.Read();
                    Console.WriteLine(reader[0] + " " + reader[1]);
                }
            }
        }

        private static void IncMinionsAge(SqlConnection connection)
        {
            var ids = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            connection.Open();
            var idsJoined = string.Join(", ", ids);
            using (connection)
            {
                var updateCommand = new SqlCommand($"UPDATE Minions SET  Name = UPPER(LEFT(Name,1)) + LOWER(SUBSTRING(Name, 2, 50)) WHERE Id IN ({idsJoined}); UPDATE Minions SET  Age += 1 WHERE Id IN ({idsJoined});", connection);
                updateCommand.ExecuteNonQuery();

                var minionsCommand = new SqlCommand(@"SELECT Name, Age FROM Minions", connection);
                var reader = minionsCommand.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + " "+ reader[1]);
                    }
                }
            }
            
        }

        private static void PrintMinionsNames(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                var command = new SqlCommand(@"SELECT Name FROM Minions", connection);
                var reader = command.ExecuteReader();
                using (reader)
                {
                    var names = new List<string>();
                    while (reader.Read())
                    {
                        names.Add(reader["Name"].ToString());
                    }

                    int low = 0;
                    int high = names.Count - 1;
                    for (int i = 0;;i++)
                    {
                        if (low > high)
                        {
                            break;
                        }
                        if (i % 2 == 0)
                        {
                            Console.WriteLine(names[low]);
                            low++;
                        }
                        else
                        {
                            Console.WriteLine(names[high]);
                            high--;
                        }
                        
                    }
                }
            }
            

        }

        private static void RemoveVillain(SqlConnection connection)
        {
            connection.Open();
            using (connection)
            {
                int id = int.Parse(Console.ReadLine());
                var existCommand = new SqlCommand(@"SELECT Id FROM Villains WHERE Id = @Id", connection);
                existCommand.Parameters.AddWithValue("@Id", id);
                int existOrNot = (int?)existCommand.ExecuteScalar() ?? -1;
                if (existOrNot == -1)
                {
                    Console.WriteLine("No such villain was found");
                    return;
                }
                var deleteConnectionsCommand = new SqlCommand(@"DELETE FROM MinionsVillains WHERE VillainId = @VillainId", connection);
                deleteConnectionsCommand.Parameters.AddWithValue("@VillainId", id);
                var minionsReleased = deleteConnectionsCommand.ExecuteNonQuery();

                var nameCommand = new SqlCommand(@"SELECT Name FROM Villains WHERE Id = @VillainId", connection);
                nameCommand.Parameters.AddWithValue("@VillainId", id);
                var name = nameCommand.ExecuteScalar();

                var deleteVillainCommand = new SqlCommand(@"DELETE FROM Villains WHERE Id = @VillainId", connection);
                deleteVillainCommand.Parameters.AddWithValue("@VillainId", id);
                deleteVillainCommand.ExecuteNonQuery();
                Console.WriteLine($"{name} was deleted");
                Console.WriteLine($"{minionsReleased} minions released");
            }
            
        }

        private static void UpTownCasing(SqlConnection connection)
        {
            var country = Console.ReadLine();
            var updateStatement = @"UPDATE Towns SET TownName = UPPER(TownName) WHERE CountryName = @CountryName";
            var selectStatement = @"SELECT TownName FROM Towns WHERE CountryName = @CountryName";
            connection.Open();
            using (connection)
            {
                var updateCommand = new SqlCommand(updateStatement, connection);
                updateCommand.Parameters.AddWithValue("@CountryName", country);
                int affectedRows = updateCommand.ExecuteNonQuery();
                if (affectedRows == 0)
                {
                    Console.WriteLine("No town names were affected.");
                    return;
                }
                Console.WriteLine($"{affectedRows} town names were affected.");

                var selectCommand = new SqlCommand(selectStatement, connection);
                selectCommand.Parameters.AddWithValue("@CountryName", country);
                var reader = selectCommand.ExecuteReader();
                using (reader)
                {
                    Console.Write("[");
                    var names = new List<string>();

                    while (reader.Read())
                    {
                        names.Add(reader[0].ToString());
                    }
                    Console.Write(string.Join(", ", names));
                    Console.Write("]");
                    Console.WriteLine();
                }
            }
        }

        private static void AddMinions(SqlConnection connection)
        {
            var input = Console.ReadLine().Split(' ').Skip(1).ToArray();
            var minionName = input[0].ToString();
            int age = int.Parse(input[1]);
            string town = input[2];
            string villain = Console.ReadLine().Split(' ').ToArray()[1];
            var query = File.ReadAllText(@"../../AddMinions.sql");
            var checkTownQuery = "SELECT Id FROM Towns WHERE TownName = @TownName";
            var checkVillain = "SELECT Id FROM Villains WHERE Name = @VillainName";
            connection.Open();
            using (connection)
            {
                var townChecker = new SqlCommand(checkTownQuery, connection);
                townChecker.Parameters.AddWithValue("@TownName", town);
                int townId = (int?)townChecker.ExecuteScalar() ?? -1;
                var villainChecker = new SqlCommand(checkVillain, connection);
                villainChecker.Parameters.AddWithValue("@VillainName", villain);
                int villainId = (int?)villainChecker.ExecuteScalar() ?? -1;

                if (townId == -1)
                {
                    var townAdd = new SqlCommand(@"INSERT INTO Towns(TownName, CountryName) VALUES(@TownName, 'Nowhere');", connection);
                    townAdd.Parameters.AddWithValue("@TownName", town);
                    townAdd.ExecuteNonQuery();
                    townId = (int?)townChecker.ExecuteScalar() ?? -1;
                    Console.WriteLine($"Town {town} was added to the database.");
                }
                if (villainId == -1)
                {
                    var villainAdd = new SqlCommand(@"INSERT INTO Villains(Name, EvilnessFactor) VALUES(@VillainName, 'evil');", connection);
                    villainAdd.Parameters.AddWithValue("@VillainName", villain);
                    villainAdd.ExecuteNonQuery();
                    villainId = (int?)villainChecker.ExecuteScalar() ?? -1;
                    Console.WriteLine($"Villain {villain} was added to the database.");
                }


                var command = new SqlCommand(query, connection);
                
                command.Parameters.AddWithValue("@MinionName", minionName);
                command.Parameters.AddWithValue("@Age", age);
                command.Parameters.AddWithValue("@TownId", townId);
                command.Parameters.AddWithValue("@VillainId", villainId);
                command.ExecuteNonQuery();
                Console.WriteLine($"Successfully added {minionName} to be minion of {villain}.");


            }
            

        }

        private static void MinionsNames(SqlConnection connection)
        {
            var id = int.Parse(Console.ReadLine());
            var query = File.ReadAllText(@"../../MinionsNames.sql");
            var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VillianId", id);

            connection.Open();
            using (connection)
            {
                var reader = command.ExecuteReader();
                using (reader)
                {
                    var arr = new List<string[]>();
                    while (reader.Read())
                    {
                        arr.Add(new string[] { (string)reader[0], reader[1].ToString(), reader[2].ToString()});
                    }
                    if (arr.Count == 0)
                    {
                        Console.WriteLine($"No villain with ID {id} exists in the database.");
                        return;
                    }
                    Console.WriteLine($"Villain: {arr[0][0]}");
                    var counter = 1;
                    if (arr[0][1] == "")
                    {
                        Console.WriteLine("(no minions)");
                        return;
                    }

                    foreach (var item in arr)
                    {
                        Console.WriteLine($"{counter}. {item[1]} {item[2]}");
                        counter++;
                    }
                    
                }
            }
        }

        static void VillainsNames(SqlConnection connection)
        {
        

            var query = File.ReadAllText(@"../../VillainsNames.sql");
            var command = new SqlCommand(query, connection);

            connection.Open();
            using (connection)
            {
                var reader = command.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["VillianName"]} {reader["MinionsCount"]}");
                    }
                }
                
            }
        }

        static void CreateDatabase()
        {
            SqlConnection dbCon = new SqlConnection(
    "Server=.; Integrated Security=true;");
            string sqlCreateDB = "CREATE DATABASE MinionsDB";
            var createDBCommand = new SqlCommand(sqlCreateDB, dbCon);

            dbCon.Open();
            using (dbCon)
            {

                createDBCommand.ExecuteNonQuery();
            }
        }

        static void InitialSetup(SqlConnection connection)
        {
            var query = File.ReadAllText(@"../../SQLQuery1.sql");
            var command = new SqlCommand(query, connection);


            connection.Open();
            using (connection)
            {
                command.ExecuteNonQuery();
            }
        }
    }
}

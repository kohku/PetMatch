using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetMatch.Web.Sql
{
    public class SqlPetMatchRepository : IPetMatchRepository
    {
        private string _connectionStringName;

        public SqlPetMatchRepository(string connectionStringName)
        {
            this._connectionStringName = connectionStringName;
        }

        public string ConnectionStringName
        {
            get { return this._connectionStringName; }
        }

        public void UpdatePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void InsertPet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public void DeletePet(Pet pet)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> GetPets(Guid? id, string name)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetBreed(PetBreed breed)
        {
            throw new NotImplementedException();
        }

        public void InsertPetBreed(PetBreed breed)
        {
            throw new NotImplementedException();
        }

        public void DeletePetBreed(PetBreed breed)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PetBreed> GetBreeds(Guid? id, Guid? animalId, string name)
        {
            List<PetBreed> results = new List<PetBreed>();

            results.Add(new PetBreed
            {
                Name="Mascota"
            });

            return results;
        }

        public void UpdatePetAnimal(PetAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("animal");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionStringName].ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("usp_UpdatePetAnimal", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                FillCommand(command, animal);

                command.ExecuteNonQuery();
            }
        }

        private void FillCommand(SqlCommand command, PetAnimal animal)
        {
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = false,
                ParameterName = "@ID",
                SqlDbType = SqlDbType.UniqueIdentifier,
                SqlValue = animal.ID
            });
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = false,
                ParameterName = "@Name",
                SqlDbType = SqlDbType.NVarChar,
                Size = 100,
                SqlValue = animal.Name
            });
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = true,
                ParameterName = "@DateCreated",
                SqlDbType = SqlDbType.DateTime,
                SqlValue = animal.DateCreated
            });
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = true,
                ParameterName = "@CreatedBy",
                SqlDbType = SqlDbType.NVarChar,
                Size = 512,
                SqlValue = animal.CreatedBy
            });
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = true,
                ParameterName = "@LastUpdated",
                SqlDbType = SqlDbType.DateTime,
                SqlValue = animal.LastUpdated
            });
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = true,
                ParameterName = "@LastUpdatedBy",
                SqlDbType = SqlDbType.NVarChar,
                Size = 512,
                SqlValue = animal.LastUpdatedBy
            });
            command.Parameters.Add(new SqlParameter
            {
                Direction = ParameterDirection.Input,
                IsNullable = false,
                ParameterName = "@Visible",
                SqlDbType = SqlDbType.Bit,
                SqlValue = animal.Visible
            });
        }

        public void InsertPetAnimal(PetAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("animal");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionStringName].ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("usp_InsertPetAnimal", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                FillCommand(command, animal);

                command.ExecuteNonQuery();
            }
        }

        public void DeletePetAnimal(PetAnimal animal)
        {
            if (animal == null)
                throw new ArgumentNullException("animal");

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionStringName].ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("usp_DeletePetAnimal", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.Add(new SqlParameter
                {
                    Direction = ParameterDirection.Input,
                    IsNullable = true,
                    ParameterName = "@ID",
                    SqlDbType = SqlDbType.UniqueIdentifier,
                    SqlValue = animal.ID
                });

                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<PetAnimal> GetPetAnimals(Guid? id, string name)
        {
            var animals = new List<PetAnimal>();

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings[this.ConnectionStringName].ConnectionString))
            {
                connection.Open();

                var command = new SqlCommand("usp_GetPetAnimals", connection)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                if (id.HasValue)
                {
                    command.Parameters.Add(new SqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        IsNullable = true,
                        ParameterName = "@ID",
                        SqlDbType = SqlDbType.UniqueIdentifier,
                        SqlValue = id.Value
                    });
                }

                if (!string.IsNullOrEmpty(name))
                {
                    command.Parameters.Add(new SqlParameter
                    {
                        Direction = ParameterDirection.Input,
                        IsNullable = true,
                        ParameterName = "@Name",
                        SqlDbType = SqlDbType.NVarChar,
                        Size = 100,
                        SqlValue = name.Contains("%") ? name : name + "%"
                    });
                }

                IDataReader reader = command.ExecuteReader();

                try
                {
                    while (reader.Read())
                    {
                        animals.Add(BuildPetAnimal(reader));
                    }
                }
                finally
                {
                    if (!reader.IsClosed)
                        reader.Close();
                }
            }

            return animals;
        }

        private PetAnimal BuildPetAnimal(IDataReader reader)
        {
            return new PetAnimal
            {
                ID = new Guid(reader["ID"].ToString()),
                Name = reader["Name"].ToString(),
                DateCreated = Convert.ToDateTime(reader["DateCreated"]),
                CreatedBy = reader["CreatedBy"].ToString(),
                LastUpdated = reader["LastUpdated"] != DBNull.Value ? Convert.ToDateTime(reader["LastUpdated"]) : default(DateTime?),
                LastUpdatedBy = reader["LastUpdatedBy"] != DBNull.Value ? reader["LastUpdatedBy"].ToString() : null,
                Visible = Convert.ToBoolean(reader["Visible"])
            };
        }
    }
}

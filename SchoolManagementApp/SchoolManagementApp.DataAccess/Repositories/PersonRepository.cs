using Microsoft.Data.SqlClient;
using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Models;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data;

namespace SchoolManagementApp.DataAccess.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(SchoolManagementDbContext context) : base(context)
        {
        }

        public new void Remove(Person person)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePerson", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramPersonId = new SqlParameter("@id", person.Id);
                cmd.Parameters.Add(paramPersonId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public new void Add(Person person)
        {
            using (SqlConnection sqlConnection = DALHelper.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand("AddPerson", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramFirstName = new SqlParameter("@firstName", person.FirstName);
                SqlParameter paramLastName = new SqlParameter("@lastName", person.LastName);
                SqlParameter paramAdresa = new SqlParameter("@address", person.Address);
                SqlParameter paramDob = new SqlParameter("@dateOfBirth", person.DateOfBirth);
                SqlParameter paramIdPersoana = new SqlParameter("@personId", SqlDbType.Int);
                paramIdPersoana.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(paramFirstName);
                sqlCommand.Parameters.Add(paramLastName);
                sqlCommand.Parameters.Add(paramAdresa);
                sqlCommand.Parameters.Add(paramDob);
                sqlCommand.Parameters.Add(paramIdPersoana);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                person.Id = (int)paramIdPersoana.Value;
            }
        }

        public new IEnumerable<Person> GetAll()
        {
            SqlConnection sqlConnection = DALHelper.Connection;
            try
            {
                SqlCommand sqlCommand = new SqlCommand("GetAllPersons", sqlConnection);

                List<Person> result = new List<Person>();

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Person person = new Person();
                    person.Id = (int)(reader[0]);
                    person.FirstName = reader.GetString(1);
                    person.LastName = reader.GetString(2);
                    person.DateOfBirth = reader.GetDateTime(3);
                    person.Address = reader.GetString(4);

                    result.Add(person);
                }
                reader.Close();

                return result;
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        public new Person GetById(int personId)
        {
            using (SqlConnection sqlConnection = DALHelper.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand("GetPersonById", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramPersonId = new SqlParameter("@PersonId", personId);
                sqlCommand.Parameters.Add(paramPersonId);

                Person result = new Person();

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    result.Id = (int)(reader[0]);
                    result.FirstName = reader.GetString(1);
                    result.LastName = reader.GetString(2);
                    result.DateOfBirth = reader.GetDateTime(3);
                    result.Address = reader.GetString(4);

                }
                reader.Close();

                return result;
            }
        }

        public new void Update(Person person)
        {
            using (SqlConnection sqlConnection = DALHelper.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand("ModifyPerson", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter paramPersonId = new SqlParameter("@personId", person.Id);
                SqlParameter paramFirstName = new SqlParameter("@firstName", person.FirstName);
                SqlParameter paramLastName = new SqlParameter("@lastName", person.LastName);
                SqlParameter paramAdress = new SqlParameter("@address", person.Address);
                SqlParameter paramDoB = new SqlParameter("@dateOfBirth", person.DateOfBirth);
                sqlCommand.Parameters.Add(paramPersonId);
                sqlCommand.Parameters.Add(paramFirstName);
                sqlCommand.Parameters.Add(paramLastName);
                sqlCommand.Parameters.Add(paramAdress);
                sqlCommand.Parameters.Add(paramDoB);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}


using Microsoft.Data.SqlClient;
using SchoolManagementApp.Domain;
using SchoolManagementApp.Domain.Models.StudentRelated;
using SchoolManagementApp.Domain.RepositoriesAbstractions;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SchoolManagementApp.DataAccess.Repositories
{
    internal class TeachingMaterialsRepository : RepositoryBase<TeachingMaterial>, ITeachingMaterialsRepository
    {
        public TeachingMaterialsRepository(SchoolManagementDbContext context) : base(context)
        {
        }

        public new void Remove(TeachingMaterial teachingMaterial)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteTeachingMaterial", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramPersonId = new SqlParameter("@id", teachingMaterial.Id);
                cmd.Parameters.Add(paramPersonId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public new void Update(TeachingMaterial teachingMaterial)
        {
            using (SqlConnection sqlConnection = DALHelper.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand("ModifyTeachingMaterial", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter("@name", teachingMaterial.Name);
                SqlParameter paramContent = new SqlParameter("@content", teachingMaterial.Content);
                SqlParameter paramCourseClassId = new SqlParameter("@courseClassId", teachingMaterial.CourseClassId);
                SqlParameter paramSemester = new SqlParameter("@semester", teachingMaterial.Semester);
                SqlParameter paramTeachingMaterialId = new SqlParameter("@teachingMaterialId", teachingMaterial.Id);

                sqlCommand.Parameters.Add(paramName);
                sqlCommand.Parameters.Add(paramContent);
                sqlCommand.Parameters.Add(paramCourseClassId);
                sqlCommand.Parameters.Add(paramSemester);
                sqlCommand.Parameters.Add(paramTeachingMaterialId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();
            }
        }

        public new void Add(TeachingMaterial teachingMaterial)
        {
            using (SqlConnection sqlConnection = DALHelper.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand("AddTeachingMaterial", sqlConnection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter("@name", teachingMaterial.Name);
                SqlParameter paramContent = new SqlParameter("@content", teachingMaterial.Content);
                SqlParameter paramCourseClassId = new SqlParameter("@courseClassId", teachingMaterial.CourseClassId);
                SqlParameter paramSemester = new SqlParameter("@semester", teachingMaterial.Semester);
                SqlParameter paramTeachingMaterialId = new SqlParameter("@teachingMaterialId", SqlDbType.Int);
                paramTeachingMaterialId.Direction = ParameterDirection.Output;

                sqlCommand.Parameters.Add(paramName);
                sqlCommand.Parameters.Add(paramContent);
                sqlCommand.Parameters.Add(paramCourseClassId);
                sqlCommand.Parameters.Add(paramSemester);
                sqlCommand.Parameters.Add(paramTeachingMaterialId);

                sqlConnection.Open();
                sqlCommand.ExecuteNonQuery();

                teachingMaterial.Id = (int)paramTeachingMaterialId.Value;
            }
        }

        public new IEnumerable<TeachingMaterial> GetAll()
        {
            //var teachingMaterials = GetRecords()
            //    .Include(c => c.CourseClass)
            //    .Include(c => c.CourseClass.CourseType)
            //    .Include(c => c.CourseClass.Class.Specialization)
            //    .Include(c => c.CourseClass.Class.Teacher.User.Person);

            //return teachingMaterials;

            using (SqlConnection sqlConnection = DALHelper.Connection)
            {
                SqlCommand sqlCommand = new SqlCommand("GetTeachingMaterials", sqlConnection);

                List<TeachingMaterial> result = new List<TeachingMaterial>();

                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                sqlConnection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    TeachingMaterial teachingMaterial = new TeachingMaterial();
                    teachingMaterial.Id = (int)reader[0];
                    teachingMaterial.Name = reader.GetString(1);
                    teachingMaterial.Content = reader.GetString(2);
                    teachingMaterial.CourseClassId = (int)reader[3];
                    teachingMaterial.Semester = (int)reader[4];
                    teachingMaterial.CourseClass = new CourseClass
                    {
                        Id = teachingMaterial.CourseClassId,
                        CourseTypeId = (int)reader[6],
                        ClassId = (int)reader[7],
                        HasCourse = (bool)reader[8],
                        CourseType = new Domain.Models.CourseType
                        {
                            Id = (int)reader[6],
                            Course = reader.GetString(10)
                        },
                        Class = new Class
                        {
                            Id = (int)reader[7],
                            Name = reader.GetString(12),
                            SpecializationId = (int)reader[13],
                            TeacherId = (int)reader[14],
                            Specialization = new Specialization
                            {
                                Id = (int)reader[13],
                                Name = reader.GetString(16)
                            },
                            Teacher = new Domain.Models.Teacher
                            {
                                Id = (int)reader[14],
                                UserId = (int)reader[18],
                                User = new Domain.Models.User
                                {
                                    Id = (int)reader[18],
                                    RoleId = (int)reader[20],
                                    Email = reader.GetString(21),
                                    PasswordHash = reader.GetString(22),
                                    personId = (int)reader[23],
                                    Person = new Domain.Models.Person
                                    {
                                        Id = (int)reader[23],
                                        FirstName = reader.GetString(25),
                                        LastName = reader.GetString(26),
                                        DateOfBirth = reader.GetDateTime(27),
                                        Address = reader.GetString(28)
                                    }
                                }
                            }
                        }
                    };

                    result.Add(teachingMaterial);
                }
                reader.Close();

                return result;
            }
        }

        public IEnumerable<TeachingMaterial> GetClassTeachingMaterials(int classId)
        {
            var teachingMaterials = GetAll().Where(c => c.CourseClass.ClassId == classId && c.CourseClass.HasCourse);

            return teachingMaterials;
        }

        public IEnumerable<TeachingMaterial> GetCourseClassTeachingMaterials(int courseClassId)
        {
            var teachingMaterials = GetAll().Where(c => c.CourseClassId == courseClassId);

            return teachingMaterials;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BL
{
   public class StudentBL : IStudentBL
    {
        IStudentDL studentdl;
        IConfiguration _configuration;



        public StudentBL(IStudentDL studentdl, IConfiguration _configuration)
        {
            this.studentdl = studentdl;
            this._configuration = _configuration;
        }
        //get
        public async Task<List<Student>> GetStudents()
        {
            return await studentdl.GetStudents();
        }
        //getById
        public async Task<Student> GetStudentById(int id)
        {
            Student s= await studentdl.GetStudentById(id);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, s.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            s.Token = tokenHandler.WriteToken(token);
            return s;
        }
        //public static List<Student> WithoutPasswords(List<Student> students)
        //{
        //    return students.Select(x => WithoutPassword(x)).ToList();
        //}

        //public static Student WithoutPassword(Student student)
        //{
        //    student.Password = null;
        //    return user;
        //}

        // post

        public async Task<int> PostStudent(Student new_student)
        {
            return await studentdl.PostStudent(new_student);

        }
        //put
        public async Task<Student> PutStudent(Student student)
        {
            return await studentdl.PutStudent(student);

        }
        //delete
        public async Task Deletestudent(int id)
        {
            await studentdl.Deletestudent(id);
        }
        //getById person
        public async Task<Person> GetPersonById(int id)
        {
           return await studentdl.GetPersonById(id);
        }
        //getPersonByIdNumber
        public async Task<Person> GetPersonByIdNumber(string idnum)
        {
            return await studentdl.GetPersonByIdNumber(idnum);
        }
        public async Task<int> PostPerson(Person new_person)
        {
            return await studentdl.PostPerson(new_person);
        }
        public async Task DeletePersont(int id)
        {
            await studentdl.DeletePerson(id);
        }
        public async Task<StudentYear> GetStudentYearstById(int id)
        {
            return await studentdl.GetStudentYearstById(id);
        }
        public async Task<int> PostStudentYears(StudentYear new_studentYear)
        {
            return await studentdl.PostStudentYears(new_studentYear);
        }
        public async Task DeleteStudentYears(int id)
        {
            await studentdl.DeleteStudentYears(id);
        }
        public async Task Delete()
        {
            List<Student> ls = await studentdl.getStudenByYear((int)new DateTime().Year);
            foreach (var student in ls)
            {
                studentdl.DeletePerson(student.Person.Id);
                foreach (var studYear in student.StudentYears)
                {
                    studentdl.DeleteStudentYears(studYear.Id);
                }
                studentdl.Deletestudent(student.Id);
            }

        }

        public async Task UploadingAStudentFile()
        {

        }


    }
}

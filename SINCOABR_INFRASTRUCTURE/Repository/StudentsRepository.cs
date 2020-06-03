using SINCOABR_CONTEXT.Context;
using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using SINCOABR_DOMAIN.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_INFRASTRUCTURE.Repository
{
    public class StudentsRepository : IStudentsRepository
    {

        public async Task<StudentDOT> getStudentByCode(string code)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var student = await context.Students.Where(x => x.code == code).FirstOrDefaultAsync();
                    var user = await context.Users.Where(c => c.email == student.email).FirstOrDefaultAsync();

                    StudentDOT studentDOT = new StudentDOT();

                    studentDOT.code = student.code;
                    studentDOT.birthDate = student.birthDate;
                    studentDOT.attending = student.attending;
                    studentDOT.attendingNumber = student.attendingNumber;
                    studentDOT.phone = student.phone;
                    studentDOT.address = student.address;
                    studentDOT.city = student.city;
                    studentDOT.email = student.email;

                    studentDOT.name = user.name;
                    studentDOT.latName = user.latName;
                    studentDOT.userId = user.userId.ToString();

                    return studentDOT;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> createStudent(Students model)
        {
            try
            {
                using (var context = new SincoABRContext() )
                {
                    context.Students.Add(model);
                    await context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<StudentDOT> updateStudent (StudentDOT model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {

                    var user = await context.Users.Where(c => c.email == model.email).FirstOrDefaultAsync();

                    user.name = model.name;
                    user.latName = model.latName;

                    context.Entry(user).State = EntityState.Modified;

                    Students students = new Students();

                    students.code = model.code;
                    students.birthDate = model.birthDate;
                    students.attending = model.attending;
                    students.attendingNumber = model.attendingNumber;
                    students.phone = model.phone;
                    students.address = model.address;
                    students.city = model.city;
                    students.email = model.email;

                    context.Entry(students).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<StudentDOT>> getStudents()
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var students = await context.Students.ToListAsync();


                    List<StudentDOT> studentsList = new List<StudentDOT>();

                    foreach (var item in students)
                    {
                        var user = await context.Users.Where(c => c.email == item.email).FirstOrDefaultAsync();

                        StudentDOT studentDOT = new StudentDOT();

                        studentDOT.code = item.code;
                        studentDOT.birthDate = item.birthDate;
                        studentDOT.attending = item.attending;
                        studentDOT.attendingNumber = item.attendingNumber;
                        studentDOT.phone = item.phone;
                        studentDOT.address = item.address;
                        studentDOT.city = item.city;
                        studentDOT.email = item.email;

                        studentDOT.name = user.name;
                        studentDOT.latName = user.latName;
                        studentDOT.userId = user.userId.ToString();

                        studentsList.Add(studentDOT);
                    }


                    return studentsList;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<ReportStudentModel>> reportEstudent()
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var reporStudents = await context.Students.Include(c => c.Users).ToListAsync();


                    List<ReportStudentModel> studentsList = new List<ReportStudentModel>();

                    foreach (var item in reporStudents)
                    {
                        var notes = await context.Notes.Include(c => c.Subjects).Where(c => c.code == item.code).ToListAsync();

                        foreach (var item1 in notes)
                        {
                            ReportStudentModel studentDOT = new ReportStudentModel();

                            studentDOT.code = item.code;
                            studentDOT.name = item.Users.name;
                            studentDOT.latName = item.Users.latName;
                            studentDOT.phone = item.phone;
                            studentDOT.email = item.email;
                            studentDOT.note = item1.note.ToString();
                            studentDOT.subjectName = item1.Subjects.name;
                            studentsList.Add(studentDOT);
                        }                        
                    }

                    return studentsList;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

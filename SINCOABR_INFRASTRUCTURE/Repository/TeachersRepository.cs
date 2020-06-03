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
    public class TeachersRepository : ITeachersRepository
    {
        public async Task<Teachers> createTeacher(Teachers model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    context.Teachers.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Teachers_SubjectsDOT> CreateTeachers_Subjects(Teachers_SubjectsDOT model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    Teachers_Subjects TeacherSubject = new Teachers_Subjects();

                    TeacherSubject.teachers_subjectsId = Guid.NewGuid();
                    TeacherSubject.subjectsId = model.subjectsId;
                    TeacherSubject.code = model.code;

                    context.Teachers_Subjects.Add(TeacherSubject);
                    await context.SaveChangesAsync();

                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<TeachersDOT> GetTeacherByCode(string code)
        {
            try
            {
                using (var context = new SincoABRContext())
                {

                    var teacher = await context.Teachers.Include(c => c.Users).Where(c => c.Users.state == true && c.code == code).FirstOrDefaultAsync();
                    var user = await context.Users.Where(c => c.email == teacher.email).FirstOrDefaultAsync();

                    TeachersDOT teachersDOT = new TeachersDOT();

                    if (teacher != null)
                    {
                        teachersDOT.code = teacher.code;
                        teachersDOT.birthDate = teacher.birthDate;
                        teachersDOT.qualification = teacher.qualification;
                        teachersDOT.phone = teacher.phone;
                        teachersDOT.specialization = teacher.specialization;
                        teachersDOT.email = teacher.email;

                        teachersDOT.name = user.name;
                        teachersDOT.latName = user.latName;
                        teachersDOT.userId = user.userId.ToString();
                    }
                    else
                    {
                        teachersDOT = null;
                    }


                    return teachersDOT;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<TeachersDOT>> GetTeachers()
        {
            try
            {
                using (var context = new SincoABRContext())
                {

                    var teachers = await context.Teachers.Include(c => c.Users).Where(c => c.Users.state == true).ToListAsync();

                    List<TeachersDOT> studentsList = new List<TeachersDOT>();


                    foreach (var item in teachers)
                    {
                        var user = await context.Users.Where(c => c.email == item.email).FirstOrDefaultAsync();

                        TeachersDOT teachersDOT = new TeachersDOT();
                        teachersDOT.code = item.code;
                        teachersDOT.birthDate = item.birthDate;
                        teachersDOT.qualification = item.qualification;
                        teachersDOT.phone = item.phone;
                        teachersDOT.specialization = item.specialization;
                        teachersDOT.email = item.email;

                        teachersDOT.name = user.name;
                        teachersDOT.latName = user.latName;
                        teachersDOT.userId = user.userId.ToString();
                        studentsList.Add(teachersDOT);
                    }

                    return studentsList;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<Teachers_SubjectsDOT>> GetTeachers_Subjects(string code)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var teachers_Subjects = await context.Teachers_Subjects.Where(x => x.code == code).ToListAsync();

                    List<Teachers_SubjectsDOT> teachers_SubjectsLsit = new List<Teachers_SubjectsDOT>();

                    foreach (var item in teachers_Subjects)
                    {
                        var subjet = await context.Subjects.Where(c => c.subjectsId == item.subjectsId).FirstOrDefaultAsync();
                        var teachers = await context.Teachers.Include(c => c.Users).Where(c => c.code == item.code).FirstOrDefaultAsync();

                        Teachers_SubjectsDOT teachers_SubjectsDOT = new Teachers_SubjectsDOT();

                        teachers_SubjectsDOT.code = item.code;
                        teachers_SubjectsDOT.teachers_subjectsId = item.teachers_subjectsId;
                        teachers_SubjectsDOT.subjectsId = item.subjectsId;

                        teachers_SubjectsDOT.subjectName = subjet.name;
                        teachers_SubjectsDOT.nameUser = teachers.Users.name;

                        teachers_SubjectsLsit.Add(teachers_SubjectsDOT);
                    }

                    return teachers_SubjectsLsit;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<TeachersDOT> UpdateTeacher(TeachersDOT model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    Teachers teacher = new Teachers();

                    teacher.code = model.code;
                    teacher.birthDate = model.birthDate;
                    teacher.qualification = model.qualification;
                    teacher.phone = model.phone;
                    teacher.specialization = model.specialization;
                    teacher.email = model.email;

                    context.Entry(teacher).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

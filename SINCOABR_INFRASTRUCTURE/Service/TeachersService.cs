using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using SINCOABR_DOMAIN.Service;
using SINCOABR_INFRASTRUCTURE.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_INFRASTRUCTURE.Service
{
    public class TeachersService : ITeachersService
    {
        private readonly TeachersRepository _TeachersRepository;
        private readonly UsersRepository _UsersRepository;

        public TeachersService()
        {
            _TeachersRepository = new TeachersRepository();
            _UsersRepository = new UsersRepository();
        }
        public async Task<Teachers> createTeacher(TeachersModel model)
        {            
            Users user = new Users();
            Teachers teacher = new Teachers();

            user.name = model.name;
            user.latName = model.latName;
            user.email = model.email;
            user.password = model.password;
            user.rolId = model.rolId;

            var userTask = await _UsersRepository.createUser(user);

            if (userTask != null)
            {
                teacher.code = model.code;
                teacher.birthDate = model.birthDate;
                teacher.qualification = model.qualification;
                teacher.phone = model.phone;
                teacher.specialization = model.specialization;
                teacher.email = userTask.email;

                teacher = await _TeachersRepository.createTeacher(teacher);
            }

            return teacher;
        }

        public async Task<Teachers_SubjectsDOT> CreateTeachers_Subjects(Teachers_SubjectsDOT model) => await _TeachersRepository.CreateTeachers_Subjects(model);

        public async Task<TeachersDOT> GetTeacherByCode(string code) =>  await  _TeachersRepository.GetTeacherByCode(code);

        public async Task<List<TeachersDOT>> GetTeachers()
        {
            return await _TeachersRepository.GetTeachers();
        }

        public async Task<List<Teachers_SubjectsDOT>> GetTeachers_Subjects(string code) => await _TeachersRepository.GetTeachers_Subjects(code);

        public async Task<TeachersDOT> UpdateTeacher(TeachersDOT model) => await _TeachersRepository.UpdateTeacher(model);
    }
}

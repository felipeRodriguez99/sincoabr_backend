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
    public class StudentsService : IStudentsService
    {
        private readonly StudentsRepository _StudentsRepository;
        private readonly UsersRepository _UsersRepository;

        public StudentsService()
        {
            _StudentsRepository = new StudentsRepository();
            _UsersRepository = new UsersRepository();
        }

        public async Task<StudentDOT> getStudentByCode(string code)
        {
            return await _StudentsRepository.getStudentByCode(code);
        }
        public async Task<bool> createStudent(StudentModel model)
        {
            bool result = false;
            Users user = new Users();
            Students student = new Students();

            user.name = model.name;
            user.latName = model.latName;
            user.email = model.email;
            user.password = model.password;
            user.rolId = model.rolId;

            var userTask = await _UsersRepository.createUser(user);

            if (userTask != null)
            {

                student.code = model.code;
                student.birthDate = model.birthDate;
                student.attending = model.attending;
                student.attendingNumber = model.attendingNumber;
                student.phone = model.phone;
                student.address = model.address;
                student.city = model.city;
                student.email = user.email;

                result = await _StudentsRepository.createStudent(student);
                
            }

            return result;

        }

        public async Task<StudentDOT> updateStudent(StudentDOT model) => await _StudentsRepository.updateStudent(model);

        public async Task<List<StudentDOT>> getStudents() => await _StudentsRepository.getStudents();

        public async Task<List<ReportStudentModel>> reportEstudent() => await _StudentsRepository.reportEstudent();
    }
}

using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_DOMAIN.Service
{
    public interface IStudentsService
    {
        Task<StudentDOT> getStudentByCode(string code);
        Task<bool> createStudent(StudentModel model);
        Task<StudentDOT> updateStudent(StudentDOT model);
        Task<List<ReportStudentModel>> reportEstudent();
        Task<List<StudentDOT>> getStudents();
    }
}

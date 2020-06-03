using System;
using SINCOABR_CONTEXT.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SINCOABR_CONTEXT.Models;

namespace SINCOABR_DOMAIN.Repository
{
    public interface IStudentsRepository
    {
        Task<StudentDOT> getStudentByCode(string code);
        Task<bool> createStudent(Students model);
        Task<StudentDOT> updateStudent(StudentDOT model);
        Task<List<ReportStudentModel>> reportEstudent();
        Task<List<StudentDOT>> getStudents();
    }
}

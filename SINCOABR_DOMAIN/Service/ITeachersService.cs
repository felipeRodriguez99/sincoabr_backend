using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_DOMAIN.Service
{
    public interface ITeachersService
    {
        Task<TeachersDOT> GetTeacherByCode(string code);
        Task<Teachers> createTeacher(TeachersModel model);
        Task<TeachersDOT> UpdateTeacher(TeachersDOT model);
        Task<List<TeachersDOT>> GetTeachers();
        Task<List<Teachers_SubjectsDOT>> GetTeachers_Subjects(string code);
        Task<Teachers_SubjectsDOT> CreateTeachers_Subjects(Teachers_SubjectsDOT model);
    }
}

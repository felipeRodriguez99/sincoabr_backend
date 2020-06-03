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
    public class SubjectsService : ISubjectsService
    {
        private readonly SubjectsRespository _SubjectsRespository;

        public SubjectsService()
        {
            _SubjectsRespository = new SubjectsRespository();
        }
        public async Task<Subjects> createSubjects(Subjects model) => await _SubjectsRespository.createSubjects(model);

        public async Task<List<SubjectDOT>> getSubjects()
        {
            return await _SubjectsRespository.getSubjects();
        }
    }
}

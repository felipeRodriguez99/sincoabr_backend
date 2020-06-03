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
    public class SubjectsRespository : ISubjectsRepository
    {
        public async Task<Subjects> createSubjects(Subjects model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    model.subjectsId = Guid.NewGuid();
                    context.Subjects.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<List<SubjectDOT>> getSubjects()
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var subjects = await context.Subjects.ToListAsync();

                    List<SubjectDOT> subjectList = new List<SubjectDOT>();

                    foreach (var item in subjects)
                    {
                        SubjectDOT subject = new SubjectDOT();

                        subject.subjectsId = item.subjectsId;
                        subject.name = item.name;
                        subject.score = item.score;
                        subjectList.Add(subject);
                    }

                    return subjectList;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}

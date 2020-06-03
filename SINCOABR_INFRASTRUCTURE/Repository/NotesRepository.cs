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
    public class NotesRepository : INotesRepository
    {
        public async Task<NotesDOT> CreateNote(NotesDOT model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    Notes note = new Notes();

                    note.noteId = Guid.NewGuid();
                    note.note = model.note;
                    note.createDate = DateTime.Now;
                    note.updateDate = DateTime.Now;
                    note.code = model.code;
                    note.subjectsId = model.subjectsId;
                    note.periodId = model.periodId;

                    context.Notes.Add(note);
                    await context.SaveChangesAsync();
                    return model;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<List<NotesDOT>> GetNote(string code)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    var notes = await context.Notes.Where(c => c.code == code).ToListAsync();
                    
                    List<NotesDOT> notesList = new List<NotesDOT>();

                    foreach (var item in notes)
                    {
                        var period = await context.Periods.Where(c => c.periodId == item.periodId).FirstOrDefaultAsync();
                        var subjet = await context.Subjects.Where(c => c.subjectsId == item.subjectsId).FirstOrDefaultAsync();

                        NotesDOT note = new NotesDOT();

                        note.noteId = item.noteId;
                        note.note = item.note;
                        note.createDate = item.createDate;
                        note.updateDate = item.updateDate;
                        note.code = item.code;
                        note.subjectsId = item.subjectsId;
                        note.periodId = item.periodId;

                        note.namePeriod = period.name;
                        note.nameSubject = subjet.name;

                        notesList.Add(note);
                    }

                    return notesList;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

            public async Task<NotesDOT> UpdateeNote(NotesDOT model)
        {
            try
            {
                using (var context = new SincoABRContext())
                {
                    Notes note = new Notes();

                    note.noteId = model.noteId;
                    note.note = model.note;
                    note.createDate = model.createDate;
                    note.updateDate = DateTime.Now;
                    note.code = model.code;
                    note.subjectsId = model.subjectsId;
                    note.periodId = model.periodId;

                    context.Entry(note).State = EntityState.Modified;
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

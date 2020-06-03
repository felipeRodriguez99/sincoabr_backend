using SINCOABR_CONTEXT.Entities;
using SINCOABR_CONTEXT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SINCOABR_DOMAIN.Repository
{
    public interface INotesRepository
    {
        Task<List<NotesDOT>> GetNote(string code);

        Task<NotesDOT> CreateNote (NotesDOT model);
        Task<NotesDOT> UpdateeNote (NotesDOT model);
    }
}

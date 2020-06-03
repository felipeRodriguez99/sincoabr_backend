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
    public class NotesService : INotesService
    {
        private readonly NotesRepository _NotesRepository;

        public NotesService()
        {
            _NotesRepository = new NotesRepository();
        }
        public async Task<NotesDOT> CreateNote(NotesDOT model)
        {
            return await _NotesRepository.CreateNote(model);
        }

        public async Task<List<NotesDOT>> GetNote(string code)
        {
            return await _NotesRepository.GetNote(code);
        }

        public async Task<NotesDOT> UpdateeNote(NotesDOT model)
        {
            return await _NotesRepository.UpdateeNote(model);
        }
    }
}

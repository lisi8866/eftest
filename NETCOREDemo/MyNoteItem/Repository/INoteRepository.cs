using MyNoteItem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNoteItem.Repository
{
  public  interface INoteRepository
    {
        Task<Note> GetByIdAsync(int id);
        Task<List<Note>> ListAsync();
        Task AddAsync(Note note);
        Task UpdateAsync(Note note); 
        Task DeleteAsync(Note note);
    }
}

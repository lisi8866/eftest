using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyNoteItem.Models;

namespace MyNoteItem.Repository
{
    public class NoteRepository : INoteRepository
    {
        private NoteContext context;
        public NoteRepository(NoteContext _context)
        {
            context = _context;
        }
        public Task AddAsync(Note note)
        {
            //context.Notes.Add(note);
            context.Notes.Attach(note);

            for (int k = 0; k < 10; k++)
            {
                Note note1 = new Note() { Title = note.Title+k.ToString(), Content = note.Content };

                context.Notes.Add(note1);
            }

            return context.SaveChangesAsync();
        }

        public Task<Note> GetByIdAsync(int id)
        {
            return context.Notes.FirstAsync(r => r.Id == id);

            //find  主建查寻找


            return context.Notes.FindAsync(id);

            //条件查找
           // return context.Notes.FirstOrDefaultAsync(r=>r.Id==id);
        }

        public Task<List<Note>> ListAsync()
        {
            //ar kk = context.Notes.Select(c => c.Id > 0).Skip(10).Take(10);

            return context.Notes.Where(c => c.Id > 0).OrderByDescending(m=>m.Id).Skip(10).Take(10).ToListAsync<Note>() ;

            return context.Notes.ToListAsync();
        }

       

        public Task UpdateAsync(Note note)
        {
            context.Entry(note).State = EntityState.Modified;
            //context.Entry(note).State = EntityState.Deleted;
          //  context.Update(note);
            return context.SaveChangesAsync();
        }
         public  Task DeleteAsync(Note note)
        {
            context.Entry(note).State = EntityState.Deleted;
            return context.SaveChangesAsync();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyNoteItem.Models;
using MyNoteItem.Repository;
using MyNoteItem.ViewModels;

namespace MyNoteItem.Controllers
{
    public class NoteController : Controller
    {
        private INoteRepository _noteRepository;
        public NoteController(INoteRepository noteRepository)  //依赖注入
        {
            _noteRepository = noteRepository;
        }
        public async Task<IActionResult> Index()  //首页
        {
            var  notes = await _noteRepository.ListAsync();
            return View(notes);
        }
        public async Task<IActionResult> Update(int id)//修改页面
        {
            var note = await _noteRepository.GetByIdAsync(id);
           
            return View(note);
        }
        [HttpPost]
        public async Task<IActionResult> Update(NoteModel model) //点击确定按钮post请求执行这个Update
        {
           
            await _noteRepository.UpdateAsync(new Note
            {   
                Id=model.Id,
                Title = model.Title,
                Content = model.Content,
                Create = DateTime.Now
            });
            return RedirectToAction("Index");
        }
        public IActionResult Add()//添加页面
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(NoteModel model)//点击确定按钮post请求执行这个Add
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _noteRepository.AddAsync(new Note{
                Title=model.Title,
                Content=model.Content,
                Create=DateTime.Now
            });
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Delete(int id)  //删除
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _noteRepository.DeleteAsync(new Note {
                Id =id
            });
            return RedirectToAction("Index");
        }
        
    }
}
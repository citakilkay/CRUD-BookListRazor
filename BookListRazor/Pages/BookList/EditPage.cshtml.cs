using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class EditPageModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public EditPageModel(ApplicationDbContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book EditBook { get; set; }
        public Book UpdateBook { get; set; }
        public async Task OnGet(int id)
        {
            EditBook = await _db.Books.FindAsync(id);
            
        }
        public async Task<IActionResult> OnPost(int id)
        {
            var myState = ModelState;
            
            if( ModelState.IsValid)
            {
                var book = await _db.Books.FindAsync(id);
                book.Name = EditBook.Name;
                book.Author = EditBook.Author;
                book.Page = EditBook.Page;
            }
            await _db.SaveChangesAsync();
            return RedirectToPage("/BookList/Index");
        }
    }
}

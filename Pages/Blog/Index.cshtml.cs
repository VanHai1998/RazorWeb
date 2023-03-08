using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_RAZORWEB.models;

namespace ASP_RAZORWEB.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly ASP_RAZORWEB.models.MyBlogContext _context;

        public IndexModel(ASP_RAZORWEB.models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get; set; } = default!;
        public const int ITEMS_PER_PAGE = 10;
        [BindProperty(SupportsGet = true, Name = "p")]
        public int currentpage { set; get; }
        public int countpages { set; get; }
        public async Task OnGetAsync(string SearchString)
        {
            // Article = await _context.articles.ToListAsync();

            var totalArticles = await _context.articles.CountAsync();
            countpages = (int)Math.Ceiling((double)totalArticles / ITEMS_PER_PAGE);
            if (currentpage < 1)
                currentpage = 1;
            if (currentpage > countpages)
                currentpage = countpages;
            var qr = (from a in _context.articles
                      orderby a.Created descending
                      select a).Skip((currentpage - 1) * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE);
            if (!string.IsNullOrEmpty(SearchString))
            {
                Article = qr.Where(a => a.Title.Contains(SearchString)).ToList();
            }
            else
            {
                Article = await qr.ToListAsync();
            }
        }
    }
}

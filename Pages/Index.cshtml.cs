﻿using ASP_RAZORWEB.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ASP_RAZORWEB.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly MyBlogContext _myBlogContext;
    public IndexModel(ILogger<IndexModel> logger, MyBlogContext myBlogContext)
    {
        _logger = logger;
        _myBlogContext = myBlogContext;
    }

    public void OnGet()
    {
        var posts = (from a in _myBlogContext.articles
                     orderby a.Created descending
                     select a).ToList();
        ViewData["posts"] = posts;

    }
}

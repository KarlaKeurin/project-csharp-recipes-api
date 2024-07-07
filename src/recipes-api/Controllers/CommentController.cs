using Microsoft.AspNetCore.Mvc;
using recipes_api.Services;
using recipes_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace recipes_api.Controllers;

[ApiController]
[Route("comment")]
public class CommentController : ControllerBase
{  
    public readonly ICommentService _service;
    
    public CommentController(ICommentService service)
    {
        this._service = service;        
    }

    [HttpPost]
    public IActionResult Create([FromBody]Comment comment)
    {
        var createComment = CreatedAtRoute("GetComment", new { name = comment.RecipeName }, comment);
        return createComment;
    }

    [HttpGet("{name}", Name = "GetComment")]
    public IActionResult Get(string name)
    {                
        var user = _service.GetComments(name);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);                    
    }
}
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TraversalApi.DAL.Context;
using TraversalApi.DAL.Entities;

namespace TraversalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        [HttpGet]
        public IActionResult VisitorList()
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.ToList();
                return Ok(values);
            }
        }
        [HttpPost]
        public IActionResult VisitorAdd(Visitor visitor)
        {
            using (var context = new VisitorContext())
            {
                context.Add(visitor);
                context.SaveChanges();
                return Ok();
                ; }
        }
        [HttpGet("{id}")]
        public IActionResult VisitorGet(int id)
        {
            using (var context = new VisitorContext())
            {
                var values = context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(values);
                }
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteVisitor(int id) 
        {
            using( var context = new VisitorContext())
                {
                var values =context.Visitors.Find(id);
                if (values == null)
                {
                    return NotFound();
                }
                else
                { 
                    context.Remove(values); 
                    context.SaveChanges();
                    return Ok();
                }
            }
        }
        [HttpPut]
        public IActionResult UpdateVisitor(Visitor visitor)
        {
            using (var context = new VisitorContext())

            {
                var values = context.Find<Visitor>(visitor.VisitorId);
                if (values == null)
                {
                    return NotFound();
                }
                else
                {
                    values.Name= visitor.Name;
                    values.Surname= visitor.Surname;
                    values.Mail = visitor.Mail;
                    values.City = visitor.City;
                    values.Country = visitor.Country;
                    context.Update(values);
                    context.SaveChanges();
                    return Ok();
                }


            }
        }
  }

}
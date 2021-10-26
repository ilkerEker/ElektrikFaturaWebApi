using ElektrikFaturaWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ElektrikFaturaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class faturaController : ControllerBase
    {
        private readonly MyDbContext _context;

        public faturaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/fatura
        [HttpGet]
        public JsonResult Getfaturalar()
        {
            return new JsonResult(_context.faturalar.OrderBy(x=>x.faturaid).ToList());
        }

        // GET: api/fatura/5
        [HttpGet("{id}")]
        public JsonResult Getfatura(long id)
        {
            var fatura =  _context.faturalar.Find(id);

            if (fatura == null)
            {
                return new JsonResult("Fatura Bulunamadı");
            }

            return new JsonResult(fatura);
        }

        // PUT: api/fatura/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public JsonResult Putfatura(fatura fatura)
        {
            
            _context.Entry(fatura).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return new JsonResult("Fatura Bulunamadı");
            }

            return new JsonResult("Fatura Bilgisi Güncellendi");
        }

        // POST: api/fatura
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public JsonResult Postfatura(fatura fatura)
        {
            _context.faturalar.Add(fatura);
             _context.SaveChanges();

            return new JsonResult("Yeni Fatura Eklendi"); //return CreatedAtAction("Getfatura", new { id = fatura.faturaid }, fatura);
        }

        // DELETE: api/fatura/5
        [HttpDelete("{id}")]
        public JsonResult Deletefatura(long id)
        {
            var fatura = _context.faturalar.Find(id);
            if (fatura == null)
            {
                return new JsonResult("Fatura Bulunamadı");
            }

            _context.faturalar.Remove(fatura);
            _context.SaveChanges();

            return new JsonResult("Fatura Silindi");
        }

        private bool faturaExists(long id)
        {
            return _context.faturalar.Any(e => e.faturaid == id);
        }
    }
}

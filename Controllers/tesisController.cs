using ElektrikFaturaWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ElektrikFaturaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tesisController : ControllerBase
    {
        private readonly MyDbContext _context;

        public tesisController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/tesis
        [HttpGet]
        public JsonResult  Gettesisler()
        {
            return new JsonResult(_context.tesisler.OrderBy(x=>x.tesisid).ToList());
        }

        // GET: api/tesis/5
        [HttpGet("{id}")]
        public JsonResult Gettesis(long id)
        {
            var tesis =  _context.tesisler.Find(id);

            if (tesis == null)
            {
                return new JsonResult("Tesis Bulunamadı");
            }

            return new JsonResult(tesis);
        }

        // PUT: api/tesis/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut]
        public  JsonResult Puttesis(tesis tesis)
        {
            //if (id != tesis.tesisid)
            //{
            //    return BadRequest();
            //}

            _context.Entry(tesis).State = EntityState.Modified;

            try
            {
                 _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                new JsonResult("Veri Güncellenemedi");
            }

            return new JsonResult("Başarıyla Güncellendi");
        }

        // POST: api/tesis
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public JsonResult Posttesis(tesis tesis)
        {
            _context.tesisler.Add(tesis);
            _context.SaveChanges();

            return new JsonResult("Başarıyla Eklendi"); //return new JsonResult(tesis);//    CreatedAtAction("Gettesis", new { id = tesis.tesisid }, tesis);
        }

        // DELETE: api/tesis/5
        [HttpDelete("{id}")]
        public JsonResult Deletetesis(long id)
        {
            var tesis = _context.tesisler.Find(id);
            if (tesis == null)
            {
                return new JsonResult("Kayıt Bulunamadı");
            }

            _context.tesisler.Remove(tesis);
            _context.SaveChanges();

            return new JsonResult("Başarıyla Silindi");
        }

        private bool tesisExists(long id)
        {
            return _context.tesisler.Any(e => e.tesisid == id);
        }
    }
}

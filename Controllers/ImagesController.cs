using System.IO;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers
{
    [Route("/api/[controller]")]
    [Authorize(Roles = "kees")]
    public class ImagesController : Controller {
        private readonly AllChargersDbContext context;

        public ImagesController(AllChargersDbContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public async Task<IActionResult> UploadTestImage(IFormFile file) {
            if (file.Length > 0) {
                using (var ms = new MemoryStream()) {
                    file.CopyTo(ms);
                    var testImage = new Image {
                        Img = ms.ToArray()
                    };
                    await context.Images.AddAsync(testImage);
                    await context.SaveChangesAsync();
                    return Ok(testImage.Id);
                }
            }
            return BadRequest();
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetTestImage(string id) {
            return File(context.Images.SingleOrDefault(t => t.Id == id).Img, "image/jpg");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestImage(string id) {
            if (context.Images.FirstOrDefault() == null) {
                return Ok();
            }
            context.Images.Remove(context.Images.First());
            await context.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteTestImages() {
            var toDeleteImages = context.Images.Include(t => t.Product).Where(v => v.Product == null);
            context.Images.RemoveRange(toDeleteImages);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
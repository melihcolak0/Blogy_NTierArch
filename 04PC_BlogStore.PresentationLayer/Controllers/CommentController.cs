using _04PC_BlogStore.BusinessLayer.Abstract;
using _04PC_BlogStore.EntityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json;

namespace _04PC_BlogStore.PresentationLayer.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;

        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetList();
            return View(values);
        }

        //[HttpGet]
        //public IActionResult CreateComment()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public IActionResult CreateComment(Comment comment)
        //{
        //    comment.IsValid = false;
        //    comment.CommentDate = DateTime.Now;
        //    _commentService.TInsert(comment);
        //    return RedirectToAction("Index");
        //}

        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            var value = _commentService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateComment(Comment comment)
        {
            comment.IsValid = false;
            comment.CommentDate = DateTime.Now;
            _commentService.TUpdate(comment);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Comment/Add")]
        public async Task<IActionResult> Add([FromForm] int articleId, [FromForm] string content)
        {
            // HuggingFace Kullanmadan Yorum Ekleme

            //if (string.IsNullOrWhiteSpace(content))
            //    return BadRequest("Yorum boş olamaz.");

            //var user = await _userManager.GetUserAsync(User);
            //if (user == null) return Unauthorized();

            //var comment = new Comment
            //{
            //    IsValid = true,
            //    ArticleId = articleId,
            //    CommentDetail = content,
            //    AppUserId = user.Id,
            //    CommentDate = DateTime.Now
            //};

            //_commentService.TInsert(comment);

            //return Ok();

            if (string.IsNullOrWhiteSpace(content))
                return BadRequest("Yorum boş olamaz.");

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            var scores = await AnalyzeToxicityAsync(content);
            bool isToxic = scores.Any(s => s.Value > 0.8); // örneğin herhangi bir toksik skor %80'den fazlaysa

            var comment = new Comment
            {
                IsValid = !isToxic,
                ArticleId = articleId,
                CommentDetail = content,
                AppUserId = user.Id,
                CommentDate = DateTime.Now
            };

            _commentService.TInsert(comment);

            return Ok(scores); // frontend'e gönder
        }

        // Yorum listesini kısmi view olarak dönen helper
        [HttpGet]
        [Route("Comment/List/{id}")]
        public IActionResult List(int id)
            => ViewComponent("_ArticleDetailCommentListComponent", new { id });


        //HuggingFace Toxic Bert
        public async Task<Dictionary<string, float>> AnalyzeToxicityAsync(string text)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "my_huggingface-api_key");

            var requestBody = new
            {
                inputs = text
            };

            var response = await client.PostAsJsonAsync("https://api-inference.huggingface.co/models/unitary/toxic-bert", requestBody);

            // JsonElement kullanıyoruz object yerine
            var result = await response.Content.ReadFromJsonAsync<List<List<Dictionary<string, JsonElement>>>>();

            var scores = new Dictionary<string, float>();

            foreach (var label in result[0])
            {
                string labelName = label["label"].GetString() ?? "";
                float scoreValue = label["score"].GetSingle();  // JsonElement'den float'a dönüşüm
                scores[labelName] = scoreValue;
            }

            return scores;
        }
    }
}

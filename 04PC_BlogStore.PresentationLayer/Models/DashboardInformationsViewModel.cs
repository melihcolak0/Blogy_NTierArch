using _04PC_BlogStore.EntityLayer.Entities;

namespace _04PC_BlogStore.PresentationLayer.Models
{
    public class DashboardInformationsViewModel
    {
        public int myTotalArticlesCount { get; set; }
        public int myTotalCommentsCount { get; set; }
        public int totalMemberCount { get; set; }
        public int totalArticleCount { get; set; }

        public List<Article> Last5Articles { get; set; }
        public List<Comment> Last5Comments { get; set; }
    }
}

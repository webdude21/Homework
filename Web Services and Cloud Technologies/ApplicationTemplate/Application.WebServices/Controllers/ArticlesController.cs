namespace Application.WebServices.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Application.Data.Contracts;
    using Application.Models;
    using Application.WebServices.DataModels;

    using Microsoft.AspNet.Identity;

    public class ArticlesController : BaseController
    {
        private const int PageSize = 10;

        public ArticlesController(IApplicationData applicationData)
            : base(applicationData)
        {
        }

        public ArticlesController() 
        {
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            return this.All(0, null);
        }

        [HttpGet]
        public IHttpActionResult All(int page)
        {
            return this.All(page, null);
        }

        [HttpGet]
        public IHttpActionResult ById(int id)
        {
            var article = this.ApplicationData.Articles.Find(id);

            if (article == null)
            {
                return this.NotFound();
            }

            return this.Ok(new ArticleModelDetail(article));
        }

        [HttpGet]
        public IHttpActionResult All(string category)
        {
            return this.All(0, category);
        }

        [HttpGet]
        public IHttpActionResult All(int page, string category)
        {
            return
                this.Ok(
                    this.ApplicationData.Articles.All()
                        .Where(
                            a =>
                            category == null
                            || a.Category.Name.Equals(category, StringComparison.InvariantCultureIgnoreCase))
                        .OrderByDescending(a => a.DateCreated)
                        .Skip(page * PageSize)
                        .Take(PageSize)
                        .Select(ArticleModel.FromArticle));
        }

        [Authorize]
        [HttpPost]
        public IHttpActionResult Create(ArticleModel articleModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }

            var userId = this.User.Identity.GetUserId();

            var category = this.GetCategory(articleModel);
            var tags = this.GetTags(articleModel);
            var article = new Article
                              {
                                  Title = articleModel.Title, 
                                  DateCreated = DateTime.Now, 
                                  Category = category, 
                                  Tags = tags, 
                                  Content = articleModel.Content, 
                                  AuthorId = userId, 
                              };

            var addedArticle = this.ApplicationData.Articles.Add(article);
            this.ApplicationData.SaveChanges();

            articleModel.Id = addedArticle.Id;
            articleModel.DateCreated = addedArticle.DateCreated;
            articleModel.Tags = addedArticle.Tags.Select(t => t.Name);

            return this.CreatedAtRoute("DefaultApi", new { id = articleModel.Id }, articleModel);
        }

        private Category GetCategory(ArticleModel model)
        {
            return this.ApplicationData.Categories.All().FirstOrDefault(c => c.Name == model.Category)
                   ?? this.ApplicationData.Categories.Add(new Category { Name = model.Category });
        }

        private HashSet<Tag> GetTags(ArticleModel model)
        {
            var allTags = new HashSet<Tag>();
            var newTags = model.Title.Split().ToList();
            newTags.AddRange(model.Tags);

            foreach (var tag in newTags)
            {
                var currentTag = this.ApplicationData.Tags.All().FirstOrDefault(t => t.Name == tag);
                allTags.Add(currentTag ?? this.ApplicationData.Tags.Add(new Tag { Name = tag }));
            }

            return allTags;
        }
    }
}
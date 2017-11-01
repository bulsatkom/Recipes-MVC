using Recepts.MVC.Data;
using Recepts.MVC.DataServices;
using Recepts.MVC.Models;
using Recepts.MVC.ModelsBinder;
using Recepts_MVC_DataServices;
using Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Recepts.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReceptForDayService receptForDayService;
        private readonly IKusmetiService kusmetiService;
        private readonly IProductService productService;
        private readonly INoviniService noviniService;
        private readonly ICommentService commentService;
        private readonly IChatService chatService;
        private readonly ICommentsForNoviniService commentsforNoviniService;

        public HomeController(IReceptForDayService ReceptForDayService, IKusmetiService kusmetiService,
            IProductService productService, INoviniService noviniService, ICommentService commentService,
            IChatService chatService, ICommentsForNoviniService commentsforNoviniService)
        {
            this.receptForDayService = ReceptForDayService;
            this.kusmetiService = kusmetiService;
            this.productService = productService;
            this.noviniService = noviniService;
            this.commentService = commentService;
            this.chatService = chatService;
            this.commentsforNoviniService = commentsforNoviniService;
        }
        
        public ActionResult Index()
        {
            var model = new Home_Index_ViewModel();
          
            var receptofday = this.receptForDayService.GetByDate();
            var latestRecepts = this.receptForDayService.TakeLatestRecepts();
            var mostViewRecepts = this.receptForDayService.TakeMostViewedRecepts();
            var novini = this.noviniService.TakeLatest5Novini();
            var dessertRecepts = this.receptForDayService.TakeMost3ViewDeserts();
            var supaRecepts = this.receptForDayService.TakeMost3ViewSupi();
            var osnovnoRecepts = this.receptForDayService.TakeMost3ViewOsnovni();
            var predQstieRecepts = this.receptForDayService.TakeMost3ViewPredQstiq();


            List<Recept_Of_Day> modelLatestRecepts = new List<Recept_Of_Day>();
            List<Recept_Of_Day> modelMostViewRecepts = new List<Recept_Of_Day>();
            List<NoviniModel> NoviniModel = new List<NoviniModel>();
            List<ReceptsFromCategory> DesertsModel = new List<ReceptsFromCategory>();
            List<ReceptsFromCategory> SupaModel = new List<ReceptsFromCategory>();
            List<ReceptsFromCategory> OsnovnoModel = new List<ReceptsFromCategory>();
            List<ReceptsFromCategory> PredQstieModel = new List<ReceptsFromCategory>();

            foreach (var supa in supaRecepts)
            {
                var supi4ka = new ReceptsFromCategory()
                {
                    Id = supa.Id,
                    Image = supa.Image,
                    Title = supa.Title,
                };
                SupaModel.Add(supi4ka);
            }

            foreach (var predqstie in predQstieRecepts)
            {
                var qstie = new ReceptsFromCategory()
                {
                    Id = predqstie.Id,
                    Image = predqstie.Image,
                    Title = predqstie.Title,
                };
                PredQstieModel.Add(qstie);
            }

            foreach (var osnovno in osnovnoRecepts)
            {
                var osnovnoto = new ReceptsFromCategory()
                {
                    Id = osnovno.Id,
                    Image = osnovno.Image,
                    Title = osnovno.Title,
                };
                OsnovnoModel.Add(osnovnoto);
            }

            foreach (var dessert in dessertRecepts)
            {
                var deserta = new ReceptsFromCategory()
                {
                    Id = dessert.Id,
                    Image = dessert.Image,
                    Title = dessert.Title,
                };
                DesertsModel.Add(deserta);
            }

            foreach (var novina in novini)
            {
                var Novinata = new NoviniModel()
                {
                    Id = novina.Id,
                    Image = novina.Image,
                    Title = novina.Title,
                };
                NoviniModel.Add(Novinata);
            }

            foreach (var recept in mostViewRecepts)
            {
                var receptata = new Recept_Of_Day(recept);
                modelMostViewRecepts.Add(receptata);
            }

            foreach (var recept in latestRecepts)
            {
                var receptata = new Recept_Of_Day(recept);
                modelLatestRecepts.Add(receptata);
            }

            if (receptofday != null)
            {
                model.ReceptOfDay = new Recept_Of_Day(receptofday);
            }

            model.KusmetOfDay = this.kusmetiService.GetKusmetForToday();
            model.LatestRecepts = modelLatestRecepts;
            model.MostViewRecepts = modelMostViewRecepts;
            model.Novini = NoviniModel;
            model.DessertRecepts = DesertsModel;
            model.OsnovnoRecepts = OsnovnoModel;
            model.PredQstieRecepts = PredQstieModel;
            model.SupaRecepts = SupaModel;

            return View(model);
        }

        [HttpPost]
        public ActionResult addcomment(Guid id, string Comment)
        {
            this.commentService.AddComment(id, Comment, this.User.Identity.Name);

            return RedirectToAction("Recipe", "Home", new { id = id });
        }

        public ActionResult Novini()
        {
            var novini = this.noviniService.TakeAllNovini().Select(x => new NoviniModel()
            {
                Id = x.Id,
                Title = x.Title,
                Image = x.Image
            }).ToList();

            var model = new NoviniViewModel();
            model.Novini = novini;

            return this.View(model);
        }

        public ActionResult Novina(Guid id)
        {
            var novina = this.noviniService.TakeNovinaById(id);
            var comments = this.commentsforNoviniService.GetCommentForNovina(id).Select(x => new CommentModel(x));

            var novinamodel = new NovinaModel()
            {
                Id = novina.Id,
                Date = novina.Date,
                Description = novina.Description,
                Image = novina.Image,
                Title = novina.Title
            };

            var model = new NovinaViewModel()
            {
                novina = novinamodel,
                Comments = comments
            };

            return this.View(model);
        }

        public ActionResult addcommentNovina(Guid id, string Comment)
        {
            this.commentsforNoviniService.AddCommentForNovina(id, Comment, this.User.Identity.Name);

            return RedirectToAction("Novina", "Home", new { id = id });
        }

        public ActionResult LiveChat()
        {
            var messages = this.chatService.GetLatest30Messages().ToList();
            var list = new List<ChatModel>();
            for(int i = messages.Count() - 1 ; i >= 0; i--)
            {
                list.Add(new ChatModel(messages[i]));
            }

            var model = new ChatViewModel();

            model.Messages = list;

            return this.View(model);
        }

        public ActionResult Recipes()
        {
            return this.View();
        }

        [HttpGet]
        [ChildActionOnly]
        public ActionResult AllRecipes()
        {            
                var recepts = this.receptForDayService.TakeAllRecepts().Select(x => new ReceptsFromCategory()
                {
                    Id = x.Id,
                    Image = x.Image,
                    Title = x.Title
                }).ToList();

                var model = new FilteredReceptsViewModel()
                {
                    Recepts = recepts
                };

            return this.PartialView("_FilteredRecipes", model);
        }

        [HttpPost]
        public ActionResult FilteredRecipes(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                var recepts = this.receptForDayService.TakeAllRecepts().Select(x => new ReceptsFromCategory()
                {
                    Id = x.Id,
                    Image = x.Image,
                    Title = x.Title
                }).ToList();

                var model = new FilteredReceptsViewModel()
                {
                    Recepts = recepts
                };

                return this.PartialView("_FilteredRecipes", model);
            }
            else
            {
                var recepts = this.receptForDayService.TakeAllReceptsBySearchTerm(searchTerm)
                    .Select(x => new ReceptsFromCategory()
                {
                    Id = x.Id,
                    Image = x.Image,
                    Title = x.Title
                }).ToList();

                var model = new FilteredReceptsViewModel()
                {
                    Recepts = recepts
                };

                return this.PartialView("_FilteredRecipes", model);
            }
        }

        public ActionResult Recipe(Guid id)
        {
            var receptbyid = this.receptForDayService.GetByID(id);
            List<ProductsForRecept> products = this.productService.GetProductForReceptById(id).Select(x => new ProductsForRecept()
            {
                Name = x.Name,
                Quantity = x.Quantity
            }).ToList();
            var receptsfromcategory = this.receptForDayService.TakeMostViewReceptsFromCategoryByRecept(receptbyid);

            var recept = new Recept_Of_Day(receptbyid);
            var receptsFromCategoryModel = new List<ReceptsFromCategory>();
            List<CommentModel> kommentari = this.commentService.GetCommentForRecept(id).Select(x => new CommentModel(x)).ToList();

            foreach (var recepta in receptsfromcategory)
            {
                receptsFromCategoryModel.Add(new ReceptsFromCategory()
                {
                    Id = recepta.Id,
                    Image = recepta.Image,
                    Title = recepta.Title
                }
                );                
            }

            var model = new ReceptsViewModel();

            model.Recept = recept;
            model.Products = products;
            model.MostViewReceptFromCategory = receptsFromCategoryModel;
            model.Comments = kommentari;

            if (this.Session[id.ToString()] == null)
            {
                this.receptForDayService.UpdateViewsById(id);
                this.Session.Add(id.ToString(), "imago");
            }

            return this.View(model);
        }
    }
}
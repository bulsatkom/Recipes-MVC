using Recepts.MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Recepts.MVC.ModelsBinder
{
    public class CommentModel
    {
        public CommentModel(Comment comment)
        {
            this.Content = comment.Content;
            this.Author = comment.Author;
            this.Date = comment.Date;
        }

        public CommentModel(CommentsForNovini comment)
        {
            this.Content = comment.Content;
            this.Author = comment.Author;
            this.Date = comment.Date;
        }

        public string Content { get; set; }

        public string Author { get; set; }

        public DateTime Date { get; set; }
    }
}
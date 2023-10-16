using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public class Comment : IComment
    {
        private string InvalidAuthorError = "Please specify the comment's author!";
        private string InvalidContentError = "Please specify the comment's content!";


        private string content;
        private string author;

        public Comment(string author, string content)
        {
            Author = author;
            Content = content;
        }


        public string Content
        {
            get
            {
                return content;
            }
            private set
            {
                Validator.ValidateStringNotNullOrEmpty(value, InvalidContentError);
                content = value;
            }
        }

        public string Author
        {
            get
            {
                return author;
            }
            private set
            {
                Validator.ValidateStringNotNullOrEmpty(value, InvalidAuthorError);
                author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"  {Content}");
            sb.AppendLine($"    by {Author}");
            return sb.ToString();
        }
    }
}

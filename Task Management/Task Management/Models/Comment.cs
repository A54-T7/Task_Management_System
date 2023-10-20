using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    public class Comment : IComment
    {
        //private string InvalidAuthorError = "Please specify the comment's author!";
        //private string InvalidContentError = "Please specify the comment's content!";

        private const string CommentHeader = "    ----------";

        private const int AuthorMinLength = 5;
        private const int AuthorMaxLength = 15;
        private const string AuthorErrorMessage = "Author must be between 5 and 15 characters long!";

        private const int ContentMinLength = 1;
        private const int ContentMaxLength = 10000;
        private const string ContentErrorMessage = "Content could be in range between 1 and 10000 character!";

        private string content;
        private string author;

        public Comment(string content, string author)
        {
            Content = content;
            Author = author;
        }


        public string Content
        {
            get
            {
                return content;
            }
            private set
            {
                Validator.ValidateStringRange(value, ContentMinLength, ContentMaxLength, ContentErrorMessage);
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
                Validator.ValidateStringRange(value, AuthorMinLength, AuthorMaxLength, AuthorErrorMessage);
                author = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(CommentHeader);
            sb.AppendLine($"  {Content}");
            sb.AppendLine($"    by {Author}");
            sb.Append(CommentHeader);

            return sb.ToString();

        }
    }
}

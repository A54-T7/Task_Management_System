using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_Management.Models.Contracts;

namespace Task_Management.Models
{
    internal class Feedback
    {
/* Feedbacks must have an ID, a title, a description, a rating, a status, a list of
comments and a list of changes history.
    • Title is a string between 10 and 50 symbols.
    • Description is a string between 10 and 500 symbols.
    • Rating is an integer.
    • Status is one of the following: New, Unscheduled, Scheduled, or Done.
    • Comments is a list of comments (string messages with author).
    • History is a list of all changes(string messages) that were done to the
feedback. */
    }
}

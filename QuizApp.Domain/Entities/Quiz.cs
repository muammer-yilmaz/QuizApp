using QuizApp.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

    }
}

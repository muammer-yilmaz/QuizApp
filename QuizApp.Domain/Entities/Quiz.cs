﻿using QuizApp.Domain.Common;
using QuizApp.Domain.Entities.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QuizApp.Domain.Entities
{
    public class Quiz : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        [JsonIgnore]
        public AppUser User { get; set; }
        public ICollection<Question> Questions { get; set; }

    }
}

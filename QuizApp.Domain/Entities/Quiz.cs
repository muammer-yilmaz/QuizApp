﻿using QuizApp.Domain.Common;
using QuizApp.Domain.Entities.Identity;
using System.Text.Json.Serialization;

namespace QuizApp.Domain.Entities;

public class Quiz : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string UserId { get; set; }
    [JsonIgnore]
    public AppUser User { get; set; }
    public int Score { get; set; }
    public string CategoryId { get; set; }
    [JsonIgnore]
    public Category Category { get; set; }
    public bool IsVisible { get; set; }
    public ICollection<Question> Questions { get; set; }

}

﻿namespace SPA_Example.Architecture.Domain.Entities.LearningUnits
{
    public class Course : BaseEntity
    {
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
    }
}
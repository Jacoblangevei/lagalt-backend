﻿namespace Lagalt_Backend.Data.Models.ProjectModels
{
    public class ProjectTag
    {
        public int? ProjectId { get; set; }
        public Project? Projects { get; set; }
        public int? TagId { get; set; }
        public Tag? Tags { get; set; }
    }
}

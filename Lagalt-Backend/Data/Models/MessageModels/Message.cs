﻿using Lagalt_Backend.Data.Models.UserModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lagalt_Backend.Data.Models.ProjectModels;
using System.Reflection.Metadata;
using Newtonsoft.Json;

namespace Lagalt_Backend.Data.Models.MessageModels
{
    [Table(nameof(Message))]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }
        [Required]
        [StringLength(100)]
        public string Subject { get; set; }
        public int? ParentId { get; set; }
        public Message? Parent { get; set; }    
        [StringLength(255)]
        public string MessageContent { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }

        [ForeignKey("ProjectId")]
        public int? ProjectId { get; set;}
        public Project? Project { get; set; }
        [JsonIgnore]
        public ICollection<Message> Replies  { get; set; }
    }
}

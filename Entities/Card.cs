﻿namespace NG_2023_Kanban.Entities
{
    public class Card : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Column { get; set; }
        public int SenderId { get; set; }
        public int BoardId { get; set; }

        public virtual User Sender { get; set; }
        public virtual Board Board { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
    }
}

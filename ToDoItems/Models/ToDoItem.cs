using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoItems.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }

        public bool IsOverdue => DueDate < DateTime.Now;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.Models
{
    public class Category
    {
        //Polzvame kombinaciq ot ICollection<> IEnumerable<> i List<> za da mojem da vzemem samo tova koeto ni e nujno
        public Category(int id, string name, IEnumerable<int> posts)
        {
            this.Id = id;
            this.Name = name;

            //previm nova kolekciq i ako pravim promqna ot vun nqma da se otrazi na tazi kolekciq
            this.PostIds = new List<int>(posts);
        }

        public int Id { get; set; }

        public string Name { get; set; }
        
        public ICollection<int> PostIds { get; set; }
    }
}

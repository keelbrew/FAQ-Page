

namespace Project6Wight.Models
{
    public class FAQ
    {
        //sets the faw id prop
        public int FAQId { get; set; }
        //sets the question prop
        public string Question { get; set; }
        //sets the answer prop
        public string Answer { get; set; }
        //brings in the foreign key for topicidc
        public string TopicId { get; set; }
        //brings in the foreign key for topic
        public Topic Topic { get; set; }
        //brings in the category id
        public string CategoryId { get; set; }
        //brings in the category
        public Category Category { get; set; }
    }
}

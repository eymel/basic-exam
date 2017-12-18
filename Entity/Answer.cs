namespace Entity
{
    public class Answer
    {

        public int ID { get; set; }
        public string Content { get; set; }
        public bool? IsRight { get; set; }
        public int QuestionID { get; set; }
        public Question Question { get; set; }
    }
}
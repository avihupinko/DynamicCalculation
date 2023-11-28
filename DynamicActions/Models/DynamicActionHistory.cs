namespace DynamicActions.Models
{
    public class DynamicActionHistory
    {
        public int Id { get; set; }

        public string X { get; set; }
        public string Y { get; set; }
        public string Result { get; set; }

        public DateTime Created { get; set; }

        public int DynamicActionId { get; set; }

        public virtual DynamicAction DynamicAction { get; set; }
    }
}

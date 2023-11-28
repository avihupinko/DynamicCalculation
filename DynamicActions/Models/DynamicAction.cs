namespace DynamicActions.Models
{
    public class DynamicAction
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Expression { get; set; }
        public DynamicActionType DynamicActionType { get; set; }

        public DateTime Created { get; set; }
    }

    public enum DynamicActionType
    {
        Numeric,
        Text
    }
}

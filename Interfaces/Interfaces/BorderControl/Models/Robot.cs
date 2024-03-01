namespace BorderControl.Models
{
    public class Robot : BaseEntity
    {
        public string Model { get; init; }

        public Robot(string id, string model) 
        {
            Id = id;
            Model = model;
        }
    }
}

namespace BorderControl.Models
{
    public class BorderControl
    {
        private List<BaseEntity> entities; // Robots + Citizens

        public List<BaseEntity> EntitiesToBeChecked
        {
            get => entities;
        }

        public BorderControl()
        {
            entities = new();
        }

        public void AddEntityForBorderCheck(BaseEntity entity)
        {
            entities.Add(entity);
        }

    }
}

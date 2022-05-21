namespace bookingAPI.Data.DomainObjects
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}

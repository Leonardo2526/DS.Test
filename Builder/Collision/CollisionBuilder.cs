namespace Builder
{
    class CollisionBuilder
    {
        protected Collision Collision { get; set; } = new Collision();

        public CollisionModelBuilder GetCollisionModel() => new CollisionModelBuilder(Collision);
        public BypassModelBuilder GetBypassModel() => new BypassModelBuilder(Collision);

        public static implicit operator Collision(CollisionBuilder cb)
        {
            return cb.Collision;
        }
    }
}

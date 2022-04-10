namespace Builder
{
    class CollisionModelBuilder : CollisionBuilder
    {
        protected CollisionModel CollisionModel { get; set; } = new CollisionModel();

        public CollisionModelBuilder(Collision collision)
        {
            this.Collision = collision;
            Collision.CollisionModel = CollisionModel;
        }

        public CollisionModelBuilder NameOf(string name)
        {
            CollisionModel.NameCollision = name;
            return this;
        }

    }
}
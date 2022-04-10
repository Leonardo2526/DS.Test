namespace Builder
{
    class BypassModelBuilder : CollisionBuilder
    {
        protected BypassModel BypassModel { get; set; } = new BypassModel();

        public BypassModelBuilder(Collision collision)
        {
            this.Collision = collision;
            Collision.BypassModel = BypassModel;
        }

        public BypassModelBuilder NameOf(string name)
        {
            BypassModel.NameBypass = name;
            return this;
        }

    }
}
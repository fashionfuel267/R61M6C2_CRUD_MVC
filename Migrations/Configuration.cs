namespace R61M6C2_w01.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<R61M6C2_w01.Models.TaskContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(R61M6C2_w01.Models.TaskContext context)
        {
           
        }
    }
}

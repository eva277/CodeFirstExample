namespace WpfApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCampos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientes", "Movil", c => c.String(maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientes", "Movil");
        }
    }
}

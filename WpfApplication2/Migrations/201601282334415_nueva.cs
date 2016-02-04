namespace WpfApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nueva : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        FechaCreacion = c.DateTime(nullable: false),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.LineaPedidoes",
                c => new
                    {
                        LineaPedidoId = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Unidades = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LineaPedidoId)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LineaPedidoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.LineaPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LineaPedidoes", new[] { "ProductoId" });
            DropIndex("dbo.LineaPedidoes", new[] { "PedidoId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropTable("dbo.Productoes");
            DropTable("dbo.LineaPedidoes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.Clientes");
        }
    }
}

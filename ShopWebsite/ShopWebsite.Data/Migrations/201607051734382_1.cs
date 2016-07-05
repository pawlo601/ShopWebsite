namespace ShopWebsite.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Product.Curriencies",
                c => new
                    {
                        currency_id = c.Int(nullable: false, identity: true),
                        currency_name = c.String(nullable: false, maxLength: 10),
                        currency_shortcut = c.String(nullable: false, maxLength: 5),
                        exchange_to_dolar = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.currency_id);
            
            CreateTable(
                "Discount.Discounts",
                c => new
                    {
                        discount_id = c.Int(nullable: false, identity: true),
                        name_of_discount = c.String(nullable: false, maxLength: 20),
                        is_for_product = c.Boolean(nullable: false),
                        is_for_customer = c.Boolean(nullable: false),
                        is_for_order = c.Boolean(nullable: false),
                        is_percentage = c.Boolean(nullable: false),
                        value_of_discount = c.Double(nullable: false),
                        start_discount = c.DateTime(nullable: false),
                        end_discount = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.discount_id);
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Level = c.String(),
                        Logger = c.String(),
                        Message = c.String(),
                        Exception = c.String(),
                        InnerException = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "User.Permissions",
                c => new
                    {
                        permission_id = c.Int(nullable: false, identity: true),
                        description = c.String(nullable: false, maxLength: 25),
                    })
                .PrimaryKey(t => t.permission_id);
            
            CreateTable(
                "User.Roles",
                c => new
                    {
                        role_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 15),
                        description = c.String(nullable: false, maxLength: 25),
                        isSysAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.role_id);
            
            CreateTable(
                "User.Users",
                c => new
                    {
                        user_id = c.Int(nullable: false, identity: true),
                        email = c.String(nullable: false, maxLength: 25),
                        access_failed_count = c.Int(nullable: false),
                        lockout_ends_date_time_utc = c.DateTime(nullable: false),
                        phone_number = c.String(nullable: false, maxLength: 15),
                        contact_title = c.String(maxLength: 10),
                        Discriminator = c.String(maxLength: 128),
                        ContactAddress_Id = c.Int(nullable: false),
                        ResidentialAddress_Id = c.Int(),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("User.Addresses", t => t.ContactAddress_Id, cascadeDelete: true)
                .ForeignKey("User.Addresses", t => t.ResidentialAddress_Id)
                .Index(t => t.ContactAddress_Id)
                .Index(t => t.ResidentialAddress_Id);
            
            CreateTable(
                "User.Addresses",
                c => new
                    {
                        address_id = c.Int(nullable: false, identity: true),
                        street = c.String(nullable: false, maxLength: 20),
                        number_of_building = c.String(nullable: false, maxLength: 10),
                        city = c.String(nullable: false, maxLength: 20),
                        postal_code = c.String(nullable: false, maxLength: 10),
                        country = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.address_id);
            
            CreateTable(
                "User.Passwords",
                c => new
                    {
                        password_id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(nullable: false),
                        hashed_password = c.String(nullable: false),
                        password_salt = c.String(nullable: false),
                        create_time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.password_id)
                .ForeignKey("User.Users", t => t.user_id, cascadeDelete: true)
                .Index(t => t.user_id);
            
            CreateTable(
                "Discount.Customer_Discounts",
                c => new
                    {
                        main_discount_id = c.Int(nullable: false, identity: true),
                        customer_id = c.Int(nullable: false),
                        Discount_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.main_discount_id)
                .ForeignKey("Discount.Discounts", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("User.Users", t => t.customer_id, cascadeDelete: true)
                .Index(t => t.customer_id)
                .Index(t => t.Discount_Id);
            
            CreateTable(
                "Order.Orders",
                c => new
                    {
                        order_id = c.Int(nullable: false, identity: true),
                        value_of_order = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Customer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.order_id)
                .ForeignKey("User.Users", t => t.Customer_Id)
                .Index(t => t.Customer_Id);
            
            CreateTable(
                "Order.Items",
                c => new
                    {
                        item_id = c.Int(nullable: false, identity: true),
                        product_id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.item_id)
                .ForeignKey("Order.Orders", t => t.Order_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "Order.Order_Status",
                c => new
                    {
                        order_status_id = c.Int(nullable: false, identity: true),
                        time_of_change = c.DateTime(nullable: false),
                        Status_Id = c.Int(nullable: false),
                        Order_Id = c.Int(),
                    })
                .PrimaryKey(t => t.order_status_id)
                .ForeignKey("Order.Statuses", t => t.Status_Id, cascadeDelete: true)
                .ForeignKey("Order.Orders", t => t.Order_Id)
                .Index(t => t.Status_Id)
                .Index(t => t.Order_Id);
            
            CreateTable(
                "Order.Statuses",
                c => new
                    {
                        status_id = c.Int(nullable: false, identity: true),
                        status_name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.status_id);
            
            CreateTable(
                "Discount.Order_Discounts",
                c => new
                    {
                        main_discount_id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        Discount_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.main_discount_id)
                .ForeignKey("Discount.Discounts", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("Order.Orders", t => t.order_id, cascadeDelete: true)
                .Index(t => t.order_id)
                .Index(t => t.Discount_Id);
            
            CreateTable(
                "User.Company_Information",
                c => new
                    {
                        company_information_id = c.Int(nullable: false, identity: true),
                        company_name = c.String(nullable: false, maxLength: 30),
                        regon = c.String(nullable: false, maxLength: 15),
                        tax_id = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.company_information_id);
            
            CreateTable(
                "User.Personal_Information",
                c => new
                    {
                        personal_information_id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 15),
                        surname = c.String(nullable: false, maxLength: 30),
                        birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.personal_information_id);
            
            CreateTable(
                "Product.Products",
                c => new
                    {
                        product_id = c.Int(nullable: false, identity: true),
                        name_of_product = c.String(nullable: false, maxLength: 30),
                        description_of_product = c.String(nullable: false, maxLength: 100),
                        discount_on_product = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cost_Id = c.Int(nullable: false),
                        Quantity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.product_id)
                .ForeignKey("Product.Costs", t => t.Cost_Id, cascadeDelete: true)
                .ForeignKey("Product.Quantities", t => t.Quantity_Id, cascadeDelete: true)
                .Index(t => t.Cost_Id)
                .Index(t => t.Quantity_Id);
            
            CreateTable(
                "Product.Costs",
                c => new
                    {
                        cost_id = c.Int(nullable: false, identity: true),
                        tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.cost_id);
            
            CreateTable(
                "Product.Prices",
                c => new
                    {
                        price_id = c.Int(nullable: false, identity: true),
                        value_of_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Currency_Id = c.Int(nullable: false),
                        Cost_Id = c.Int(),
                    })
                .PrimaryKey(t => t.price_id)
                .ForeignKey("Product.Curriencies", t => t.Currency_Id, cascadeDelete: true)
                .ForeignKey("Product.Costs", t => t.Cost_Id)
                .Index(t => t.Currency_Id)
                .Index(t => t.Cost_Id);
            
            CreateTable(
                "Discount.Product_Discounts",
                c => new
                    {
                        main_discount_id = c.Int(nullable: false, identity: true),
                        product_id = c.Int(nullable: false),
                        Discount_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.main_discount_id)
                .ForeignKey("Discount.Discounts", t => t.Discount_Id, cascadeDelete: true)
                .ForeignKey("Product.Products", t => t.product_id, cascadeDelete: true)
                .Index(t => t.product_id)
                .Index(t => t.Discount_Id);
            
            CreateTable(
                "Product.Quantities",
                c => new
                    {
                        quantity_id = c.Int(nullable: false, identity: true),
                        quantity_value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.quantity_id)
                .ForeignKey("Product.Units", t => t.Unit_Id, cascadeDelete: true)
                .Index(t => t.Unit_Id);
            
            CreateTable(
                "Product.Units",
                c => new
                    {
                        unit_id = c.Int(nullable: false, identity: true),
                        unit_name1 = c.String(nullable: false, maxLength: 10),
                        unit_shortcut = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.unit_id);
            
            CreateTable(
                "User.Link_Users_Roles",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.user_id, t.role_id })
                .ForeignKey("User.Users", t => t.user_id, cascadeDelete: true)
                .ForeignKey("User.Roles", t => t.role_id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "User.Link_Permissions_Roles",
                c => new
                    {
                        permission_id = c.Int(nullable: false),
                        role_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.permission_id, t.role_id })
                .ForeignKey("User.Permissions", t => t.permission_id, cascadeDelete: true)
                .ForeignKey("User.Roles", t => t.role_id, cascadeDelete: true)
                .Index(t => t.permission_id)
                .Index(t => t.role_id);
            
            CreateTable(
                "User.Company",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        Information_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("User.Users", t => t.user_id)
                .ForeignKey("User.Company_Information", t => t.Information_Id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.Information_Id);
            
            CreateTable(
                "User.Individual_Client",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        Information_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("User.Users", t => t.user_id)
                .ForeignKey("User.Personal_Information", t => t.Information_Id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.Information_Id);
            
            CreateTable(
                "User.Employee",
                c => new
                    {
                        user_id = c.Int(nullable: false),
                        Information_Id = c.Int(nullable: false),
                        position = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.user_id)
                .ForeignKey("User.Users", t => t.user_id)
                .ForeignKey("User.Personal_Information", t => t.Information_Id, cascadeDelete: true)
                .Index(t => t.user_id)
                .Index(t => t.Information_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("User.Employee", "Information_Id", "User.Personal_Information");
            DropForeignKey("User.Employee", "user_id", "User.Users");
            DropForeignKey("User.Individual_Client", "Information_Id", "User.Personal_Information");
            DropForeignKey("User.Individual_Client", "user_id", "User.Users");
            DropForeignKey("User.Company", "Information_Id", "User.Company_Information");
            DropForeignKey("User.Company", "user_id", "User.Users");
            DropForeignKey("Product.Products", "Quantity_Id", "Product.Quantities");
            DropForeignKey("Product.Quantities", "Unit_Id", "Product.Units");
            DropForeignKey("Discount.Product_Discounts", "product_id", "Product.Products");
            DropForeignKey("Discount.Product_Discounts", "Discount_Id", "Discount.Discounts");
            DropForeignKey("Product.Products", "Cost_Id", "Product.Costs");
            DropForeignKey("Product.Prices", "Cost_Id", "Product.Costs");
            DropForeignKey("Product.Prices", "Currency_Id", "Product.Curriencies");
            DropForeignKey("User.Link_Permissions_Roles", "role_id", "User.Roles");
            DropForeignKey("User.Link_Permissions_Roles", "permission_id", "User.Permissions");
            DropForeignKey("Order.Orders", "Customer_Id", "User.Users");
            DropForeignKey("Discount.Order_Discounts", "order_id", "Order.Orders");
            DropForeignKey("Discount.Order_Discounts", "Discount_Id", "Discount.Discounts");
            DropForeignKey("Order.Order_Status", "Order_Id", "Order.Orders");
            DropForeignKey("Order.Order_Status", "Status_Id", "Order.Statuses");
            DropForeignKey("Order.Items", "Order_Id", "Order.Orders");
            DropForeignKey("Discount.Customer_Discounts", "customer_id", "User.Users");
            DropForeignKey("Discount.Customer_Discounts", "Discount_Id", "Discount.Discounts");
            DropForeignKey("User.Link_Users_Roles", "role_id", "User.Roles");
            DropForeignKey("User.Link_Users_Roles", "user_id", "User.Users");
            DropForeignKey("User.Users", "ResidentialAddress_Id", "User.Addresses");
            DropForeignKey("User.Passwords", "user_id", "User.Users");
            DropForeignKey("User.Users", "ContactAddress_Id", "User.Addresses");
            DropIndex("User.Employee", new[] { "Information_Id" });
            DropIndex("User.Employee", new[] { "user_id" });
            DropIndex("User.Individual_Client", new[] { "Information_Id" });
            DropIndex("User.Individual_Client", new[] { "user_id" });
            DropIndex("User.Company", new[] { "Information_Id" });
            DropIndex("User.Company", new[] { "user_id" });
            DropIndex("User.Link_Permissions_Roles", new[] { "role_id" });
            DropIndex("User.Link_Permissions_Roles", new[] { "permission_id" });
            DropIndex("User.Link_Users_Roles", new[] { "role_id" });
            DropIndex("User.Link_Users_Roles", new[] { "user_id" });
            DropIndex("Product.Quantities", new[] { "Unit_Id" });
            DropIndex("Discount.Product_Discounts", new[] { "Discount_Id" });
            DropIndex("Discount.Product_Discounts", new[] { "product_id" });
            DropIndex("Product.Prices", new[] { "Cost_Id" });
            DropIndex("Product.Prices", new[] { "Currency_Id" });
            DropIndex("Product.Products", new[] { "Quantity_Id" });
            DropIndex("Product.Products", new[] { "Cost_Id" });
            DropIndex("Discount.Order_Discounts", new[] { "Discount_Id" });
            DropIndex("Discount.Order_Discounts", new[] { "order_id" });
            DropIndex("Order.Order_Status", new[] { "Order_Id" });
            DropIndex("Order.Order_Status", new[] { "Status_Id" });
            DropIndex("Order.Items", new[] { "Order_Id" });
            DropIndex("Order.Orders", new[] { "Customer_Id" });
            DropIndex("Discount.Customer_Discounts", new[] { "Discount_Id" });
            DropIndex("Discount.Customer_Discounts", new[] { "customer_id" });
            DropIndex("User.Passwords", new[] { "user_id" });
            DropIndex("User.Users", new[] { "ResidentialAddress_Id" });
            DropIndex("User.Users", new[] { "ContactAddress_Id" });
            DropTable("User.Employee");
            DropTable("User.Individual_Client");
            DropTable("User.Company");
            DropTable("User.Link_Permissions_Roles");
            DropTable("User.Link_Users_Roles");
            DropTable("Product.Units");
            DropTable("Product.Quantities");
            DropTable("Discount.Product_Discounts");
            DropTable("Product.Prices");
            DropTable("Product.Costs");
            DropTable("Product.Products");
            DropTable("User.Personal_Information");
            DropTable("User.Company_Information");
            DropTable("Discount.Order_Discounts");
            DropTable("Order.Statuses");
            DropTable("Order.Order_Status");
            DropTable("Order.Items");
            DropTable("Order.Orders");
            DropTable("Discount.Customer_Discounts");
            DropTable("User.Passwords");
            DropTable("User.Addresses");
            DropTable("User.Users");
            DropTable("User.Roles");
            DropTable("User.Permissions");
            DropTable("dbo.Log");
            DropTable("Discount.Discounts");
            DropTable("Product.Curriencies");
        }
    }
}

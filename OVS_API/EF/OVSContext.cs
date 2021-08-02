using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace OVS_API.EF
{
    public partial class OVSContext : DbContext
    {
        public OVSContext()
        {
        }

        public OVSContext(DbContextOptions<OVSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<CartLine> CartLines { get; set; }
        public virtual DbSet<CashRegister> CashRegisters { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<CreditNote> CreditNotes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerType> CustomerTypes { get; set; }
        public virtual DbSet<Date> Dates { get; set; }
        public virtual DbSet<DateTimeSlot> DateTimeSlots { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<JobInstance> JobInstances { get; set; }
        public virtual DbSet<JobInstanceTask> JobInstanceTasks { get; set; }
        public virtual DbSet<JobStatus> JobStatuses { get; set; }
        public virtual DbSet<JobTask> JobTasks { get; set; }
        public virtual DbSet<JobTaskStatus> JobTaskStatuses { get; set; }
        public virtual DbSet<JobTaskType> JobTaskTypes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderLine> OrderLines { get; set; }
        public virtual DbSet<OrderPayment> OrderPayments { get; set; }
        public virtual DbSet<OrderPaymentStatus> OrderPaymentStatuses { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<PaymentType> PaymentTypes { get; set; }
        public virtual DbSet<Price> Prices { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<ProductSpecial> ProductSpecials { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
        public virtual DbSet<QuoteLine> QuoteLines { get; set; }
        public virtual DbSet<QuoteStatus> QuoteStatuses { get; set; }
        public virtual DbSet<RawMaterial> RawMaterials { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeLineUnit> RecipeLineUnits { get; set; }
        public virtual DbSet<RecipleLine> RecipleLines { get; set; }
        public virtual DbSet<RequestQuote> RequestQuotes { get; set; }
        public virtual DbSet<ReturnOrderRequest> ReturnOrderRequests { get; set; }
        public virtual DbSet<ReturnOrderRequestOrderLine> ReturnOrderRequestOrderLines { get; set; }
        public virtual DbSet<ReturnSaleRequest> ReturnSaleRequests { get; set; }
        public virtual DbSet<ReturnSaleRequestSaleLine> ReturnSaleRequestSaleLines { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SaleLine> SaleLines { get; set; }
        public virtual DbSet<SalePayment> SalePayments { get; set; }
        public virtual DbSet<SalePaymentStatus> SalePaymentStatuses { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftBranch> ShiftBranches { get; set; }
        public virtual DbSet<ShiftBranchEmployee> ShiftBranchEmployees { get; set; }
        public virtual DbSet<ShiftType> ShiftTypes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Special> Specials { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<SupplierOrder> SupplierOrders { get; set; }
        public virtual DbSet<SupplierOrderLine> SupplierOrderLines { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TimeSlot> TimeSlots { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccessPermission> UserAccessPermissions { get; set; }
        public virtual DbSet<Wishlist> Wishlists { get; set; }
        public virtual DbSet<WishlistProduct> WishlistProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=DefaultConnection");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.ToTable("Branch");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID");

                entity.Property(e => e.BranchAddress)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Branch_Address");

                entity.Property(e => e.BranchLocationStorageCapacity).HasColumnName("Branch_Location_Storage_Capacity");

                entity.Property(e => e.BranchName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Branch_Name");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("Cart_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.UserAccessPermissionId).HasColumnName("User_Access_Permission_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Cart__Customer_I__5441852A");


                entity.HasOne(d => d.User)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Cart__User_ID__534D60F1");
            });

            modelBuilder.Entity<CartLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Cart_Line");

                entity.Property(e => e.CartId).HasColumnName("Cart_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Cart)
                    .WithMany()
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__Cart_Line__Cart___571DF1D5");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Cart_Line__Produ__5812160E");
            });

            modelBuilder.Entity<CashRegister>(entity =>
            {
                entity.HasKey(e => e.RegisterId)
                    .HasName("PK__Cash_Reg__E454148E4DE9BD42");

                entity.ToTable("Cash_Register");

                entity.Property(e => e.RegisterId).HasColumnName("Register_ID");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID");

                entity.Property(e => e.CashRegisterName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Cash_Register_Name");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.CashRegisters)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Cash_Regi__Branc__412EB0B6");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("Colour");

                entity.Property(e => e.ColourId).HasColumnName("Colour_ID");

                entity.Property(e => e.ColourDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Colour_Description");

                entity.Property(e => e.ProductSizeId).HasColumnName("Product_Size_ID");

                entity.HasOne(d => d.ProductSize)
                    .WithMany(p => p.Colours)
                    .HasForeignKey(d => d.ProductSizeId)
                    .HasConstraintName("FK__Colour__Product___3A81B327");
            });

            modelBuilder.Entity<CreditNote>(entity =>
            {
                entity.ToTable("Credit_Note");

                entity.Property(e => e.CreditNoteId).HasColumnName("Credit_Note_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.ReturnOrderRequestId).HasColumnName("Return_Order_Request_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditNotes)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Credit_No__Custo__72C60C4A");

                entity.HasOne(d => d.ReturnOrderRequest)
                    .WithMany(p => p.CreditNotes)
                    .HasForeignKey(d => d.ReturnOrderRequestId)
                    .HasConstraintName("FK__Credit_No__Retur__73BA3083");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerCellphoneNumber)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Cellphone_Number");

                entity.Property(e => e.CustomerDateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Customer_Date_Of_Birth");

                entity.Property(e => e.CustomerEmailAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Email_Address");

                entity.Property(e => e.CustomerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPhysicalAddress)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Physical_Address");

                entity.Property(e => e.CustomerSurname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Surname");

                entity.Property(e => e.CustomerTypeId).HasColumnName("Customer_Type_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.CustomerType)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.CustomerTypeId)
                    .HasConstraintName("FK__Customer__Custom__4F7CD00D");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Customer__User_I__5070F446");
            });

            modelBuilder.Entity<CustomerType>(entity =>
            {
                entity.ToTable("Customer_Type");

                entity.Property(e => e.CustomerTypeId).HasColumnName("Customer_Type_ID");

                entity.Property(e => e.CustomerTypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Type_Description");

                entity.Property(e => e.DiscountId).HasColumnName("Discount_ID");

                entity.HasOne(d => d.Discount)
                    .WithMany(p => p.CustomerTypes)
                    .HasForeignKey(d => d.DiscountId)
                    .HasConstraintName("FK__Customer___Disco__4CA06362");
            });

            modelBuilder.Entity<Date>(entity =>
            {
                entity.ToTable("Date");

                entity.Property(e => e.DateId)
                    .ValueGeneratedNever()
                    .HasColumnName("Date_ID");

                entity.Property(e => e.DateDescription)
                    .HasColumnType("date")
                    .HasColumnName("Date_Description");
            });

            modelBuilder.Entity<DateTimeSlot>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Date_Time_Slot");

                entity.Property(e => e.DateId).HasColumnName("Date_ID");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.Property(e => e.TimeSlotId).HasColumnName("Time_Slot_ID");

                entity.HasOne(d => d.Date)
                    .WithMany()
                    .HasForeignKey(d => d.DateId)
                    .HasConstraintName("FK__Date_Time__Date___3E52440B");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Date_Time__Shift__3C69FB99");

                entity.HasOne(d => d.TimeSlot)
                    .WithMany()
                    .HasForeignKey(d => d.TimeSlotId)
                    .HasConstraintName("FK__Date_Time__Time___3D5E1FD2");
            });

            modelBuilder.Entity<Discount>(entity =>
            {
                entity.ToTable("Discount");

                entity.Property(e => e.DiscountId).HasColumnName("Discount_ID");

                entity.Property(e => e.DiscountDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Discount_Description");

                entity.Property(e => e.DiscountName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Discount_Name");

                entity.Property(e => e.DiscountPercentage)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Discount_Percentage");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.EmployeeEmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Email_Address");

                entity.Property(e => e.EmployeeName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Name");

                entity.Property(e => e.EmployeePhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Phone_Number");

                entity.Property(e => e.EmployeeSurname)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Surname");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("Employee_Type_ID");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.HasOne(d => d.EmployeeType)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.EmployeeTypeId)
                    .HasConstraintName("FK__Employee__Employ__173876EA");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Employee__User_I__182C9B23");
            });

            modelBuilder.Entity<EmployeeType>(entity =>
            {
                entity.ToTable("Employee_Type");

                entity.Property(e => e.EmployeeTypeId).HasColumnName("Employee_Type_ID");

                entity.Property(e => e.EmployeeTypeDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Employee_Type_Description");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.ToTable("Job");

                entity.Property(e => e.JobId).HasColumnName("Job_ID");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Job_Description");

                entity.Property(e => e.JobStatusId).HasColumnName("Job_Status_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.JobStatusId)
                    .HasConstraintName("FK__Job__Job_Status___37703C52");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Jobs)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Job__Product_ID__3864608B");
            });

            modelBuilder.Entity<JobInstance>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Job_Instance");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.JobId).HasColumnName("Job_ID");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Job_Insta__Branc__41EDCAC5");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Job_Insta__Emplo__40058253");

                entity.HasOne(d => d.Job)
                    .WithMany()
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Job_Insta__Job_I__3F115E1A");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Job_Insta__Shift__40F9A68C");
            });

            modelBuilder.Entity<JobInstanceTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Job_Instance_Task");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.JobId).HasColumnName("Job_ID");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.TaskId).HasColumnName("Task_ID");

                entity.HasOne(d => d.Job)
                    .WithMany()
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Job_Insta__Job_I__43D61337");

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__Job_Insta__Task___44CA3770");
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.ToTable("Job_Status");

                entity.Property(e => e.JobStatusId).HasColumnName("Job_Status_ID");

                entity.Property(e => e.JobStatusDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Job_Status_Description");
            });

            modelBuilder.Entity<JobTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Job_task");

                entity.Property(e => e.JobId).HasColumnName("Job_ID");

                entity.Property(e => e.JobTaskStatusId).HasColumnName("Job_Task_Status_ID");

                entity.Property(e => e.JobTaskTypeId).HasColumnName("Job_Task_Type_ID");

                entity.Property(e => e.TaskId).HasColumnName("Task_ID");

                entity.HasOne(d => d.Job)
                    .WithMany()
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK__Job_task__Job_ID__3A4CA8FD");

                entity.HasOne(d => d.JobTaskStatus)
                    .WithMany()
                    .HasForeignKey(d => d.JobTaskStatusId)
                    .HasConstraintName("FK__Job_task__Job_Ta__3C34F16F");

                entity.HasOne(d => d.JobTaskType)
                    .WithMany()
                    .HasForeignKey(d => d.JobTaskTypeId)
                    .HasConstraintName("FK__Job_task__Job_Ta__3D2915A8");

                entity.HasOne(d => d.Task)
                    .WithMany()
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK__Job_task__Task_I__3B40CD36");
            });

            modelBuilder.Entity<JobTaskStatus>(entity =>
            {
                entity.ToTable("Job_Task_Status");

                entity.Property(e => e.JobTaskStatusId).HasColumnName("Job_Task_Status_ID");
            });

            modelBuilder.Entity<JobTaskType>(entity =>
            {
                entity.ToTable("Job_Task_Type");

                entity.Property(e => e.JobTaskTypeId).HasColumnName("Job_Task_Type_ID");

                entity.Property(e => e.JobTaskTypeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Job_Task_Type_Description");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Date");

                entity.Property(e => e.OrderFinalizastionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Finalizastion_Date");

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Order__Customer___6383C8BA");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Order__Employee___656C112C");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK__Order__Order_Sta__6477ECF3");
            });

            modelBuilder.Entity<OrderLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_Line");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Lin__Order__6754599E");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Order_Lin__Produ__68487DD7");
            });

            modelBuilder.Entity<OrderPayment>(entity =>
            {
                entity.ToTable("Order_Payment");

                entity.Property(e => e.OrderPaymentId).HasColumnName("Order_Payment_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.OrderPaymentAmount).HasColumnName("Order_Payment_Amount");

                entity.Property(e => e.OrderPaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Order_Payment_Date");

                entity.Property(e => e.OrderPaymentStatus).HasColumnName("Order_Payment_Status");

                entity.Property(e => e.PaymentTypeId).HasColumnName("Payment_Type_ID");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderPayments)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Order_Pay__Order__17F790F9");

                entity.HasOne(d => d.OrderPaymentStatusNavigation)
                    .WithMany(p => p.OrderPayments)
                    .HasForeignKey(d => d.OrderPaymentStatus)
                    .HasConstraintName("FK__Order_Pay__Order__17036CC0");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.OrderPayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK__Order_Pay__Payme__160F4887");
            });

            modelBuilder.Entity<OrderPaymentStatus>(entity =>
            {
                entity.ToTable("Order_Payment_Status");

                entity.Property(e => e.OrderPaymentStatusId).HasColumnName("Order_Payment_Status_ID");

                entity.Property(e => e.OrderPaymentStatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_Payment_Status_Description");
            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.ToTable("Order_Status");

                entity.Property(e => e.OrderStatusId).HasColumnName("Order_Status_ID");

                entity.Property(e => e.OrderStatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Order_Status_Description");
            });

            modelBuilder.Entity<PaymentType>(entity =>
            {
                entity.ToTable("Payment_Type");

                entity.Property(e => e.PaymentTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Payment_Type_ID");

                entity.Property(e => e.PaymentTypeDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Payment_Type_Description");

                entity.Property(e => e.PaymentTypeName)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Payment_Type_Name");
            });

            modelBuilder.Entity<Price>(entity =>
            {
                entity.ToTable("Price");

                entity.Property(e => e.PriceId).HasColumnName("Price_ID");

                entity.Property(e => e.PriceAmount).HasColumnName("Price_Amount");

                entity.Property(e => e.PriceDate)
                    .HasColumnType("date")
                    .HasColumnName("Price_Date");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Description");

                entity.Property(e => e.ProductImage)
                    .IsRequired()
                    .HasColumnName("Product_Image");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Name");

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_Type_ID");

                entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity_on_hand");

                entity.HasOne(d => d.ProductType)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTypeId)
                    .HasConstraintName("FK__Product__Product__2A4B4B5E");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.ToTable("Product_Category");

                entity.Property(e => e.ProductCategoryId).HasColumnName("Product_Category_ID");

                entity.Property(e => e.ProductCategoryName)
                    .IsRequired()
                    .HasMaxLength(1024)
                    .IsUnicode(false)
                    .HasColumnName("Product_Category_Name");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.ToTable("Product_Size");

                entity.Property(e => e.ProductSizeId).HasColumnName("Product_Size_ID");

                entity.Property(e => e.PriceId).HasColumnName("Price_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.HasOne(d => d.Price)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.PriceId)
                    .HasConstraintName("FK__Product_S__Price__32E0915F");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Product_S__Produ__33D4B598");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .HasConstraintName("FK__Product_S__Size___34C8D9D1");
            });

            modelBuilder.Entity<ProductSpecial>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Product_Special");

                entity.Property(e => e.PriceAmount).HasColumnName("Price_Amount");

                entity.Property(e => e.ProductSizeId).HasColumnName("Product_Size_ID");

                entity.Property(e => e.SpecialId).HasColumnName("Special_ID");

                entity.HasOne(d => d.ProductSize)
                    .WithMany()
                    .HasForeignKey(d => d.ProductSizeId)
                    .HasConstraintName("FK__Product_S__Produ__36B12243");

                entity.HasOne(d => d.Special)
                    .WithMany()
                    .HasForeignKey(d => d.SpecialId)
                    .HasConstraintName("FK__Product_S__Speci__37A5467C");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("Product_Type");

                entity.Property(e => e.ProductTypeId).HasColumnName("Product_Type_ID");

                entity.Property(e => e.ProductCategoryId).HasColumnName("Product_Category_ID");

                entity.Property(e => e.ProductTypeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Product_Type_Name");

                entity.HasOne(d => d.ProductCategory)
                    .WithMany(p => p.ProductTypes)
                    .HasForeignKey(d => d.ProductCategoryId)
                    .HasConstraintName("FK__Product_T__Produ__276EDEB3");
            });

            modelBuilder.Entity<QuoteLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Quote_Line");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.RequestQuoteId).HasColumnName("Request_Quote_ID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Quote_Lin__Produ__7A672E12");

                entity.HasOne(d => d.RequestQuote)
                    .WithMany()
                    .HasForeignKey(d => d.RequestQuoteId)
                    .HasConstraintName("FK__Quote_Lin__Reque__7B5B524B");
            });

            modelBuilder.Entity<QuoteStatus>(entity =>
            {
                entity.ToTable("Quote_Status");

                entity.Property(e => e.QuoteStatusId).HasColumnName("Quote_Status_ID");

                entity.Property(e => e.QuoteStatusDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Quote_Status_Description");
            });

            modelBuilder.Entity<RawMaterial>(entity =>
            {
                entity.ToTable("Raw_Material");

                entity.Property(e => e.RawMaterialId).HasColumnName("Raw_Material_ID");

                entity.Property(e => e.QuantityOnHand).HasColumnName("Quantity_on_hand");

                entity.Property(e => e.RawMaterialDescription)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Raw_material_description");

                entity.Property(e => e.RawMaterialName)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Raw_Material_Name");

                entity.Property(e => e.UnitId).HasColumnName("Unit_ID");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.RawMaterials)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__Raw_Mater__Unit___2180FB33");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.RecipeId).HasColumnName("Recipe_ID");

                entity.Property(e => e.QuantityProduced).HasColumnName("Quantity_produced");

                entity.Property(e => e.RecipeDescription)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Description");

                entity.Property(e => e.RecipeName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Recipe_Name");
            });

            modelBuilder.Entity<RecipeLineUnit>(entity =>
            {
                entity.ToTable("Recipe_Line_Unit");

                entity.Property(e => e.RecipeLineUnitId).HasColumnName("Recipe_Line_unit_ID");
            });

            modelBuilder.Entity<RecipleLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Reciple_Line");

                entity.Property(e => e.RawMaterialId).HasColumnName("Raw_Material_ID");

                entity.Property(e => e.RecipeId).HasColumnName("Recipe_ID");

                entity.Property(e => e.RecipeLineUnitId).HasColumnName("Recipe_Line_unit_ID");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany()
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("FK__Reciple_L__Raw_M__2BFE89A6");

                entity.HasOne(d => d.Recipe)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("FK__Reciple_L__Recip__2B0A656D");

                entity.HasOne(d => d.RecipeLineUnit)
                    .WithMany()
                    .HasForeignKey(d => d.RecipeLineUnitId)
                    .HasConstraintName("FK__Reciple_L__Recip__2CF2ADDF");
            });

            modelBuilder.Entity<RequestQuote>(entity =>
            {
                entity.ToTable("Request_Quote");

                entity.Property(e => e.RequestQuoteId).HasColumnName("Request_Quote_ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.QuoteStatusId).HasColumnName("Quote_Status_ID");

                entity.HasOne(d => d.QuoteStatus)
                    .WithMany(p => p.RequestQuotes)
                    .HasForeignKey(d => d.QuoteStatusId)
                    .HasConstraintName("FK__Request_Q__Quote__787EE5A0");
            });

            modelBuilder.Entity<ReturnOrderRequest>(entity =>
            {
                entity.ToTable("Return_Order_Request");

                entity.Property(e => e.ReturnOrderRequestId).HasColumnName("Return_Order_Request_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.RequestOrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Request_Order_Date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReturnOrderRequests)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Return_Or__Custo__6B24EA82");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ReturnOrderRequests)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Return_Or__Order__6C190EBB");
            });

            modelBuilder.Entity<ReturnOrderRequestOrderLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Return_Order_Request_Order_Line");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ReturnReason)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Return_Reason");

                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Return_Or__Custo__6E01572D");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__Return_Or__Order__6EF57B66");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Return_Or__Produ__6FE99F9F");
            });

            modelBuilder.Entity<ReturnSaleRequest>(entity =>
            {
                entity.ToTable("Return_Sale_Request");

                entity.Property(e => e.ReturnSaleRequestId).HasColumnName("Return_Sale_Request_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.ReturnRequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Return_Request_Date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ReturnSaleRequests)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Return_Sa__Custo__03F0984C");
            });

            modelBuilder.Entity<ReturnSaleRequestSaleLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Return_Sale_Request_Sale_Line");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.ReturnSaleReason)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Return_Sale_Reason");

                entity.Property(e => e.ReturnSaleRequestId).HasColumnName("Return_Sale_Request_ID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Return_Sa__Produ__06CD04F7");

                entity.HasOne(d => d.ReturnSaleRequest)
                    .WithMany()
                    .HasForeignKey(d => d.ReturnSaleRequestId)
                    .HasConstraintName("FK__Return_Sa__Retur__05D8E0BE");

                entity.HasOne(d => d.SaleNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Sale)
                    .HasConstraintName("FK__Return_Sal__Sale__07C12930");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("Sale");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.RequestQuoteId).HasColumnName("Request_Quote_ID");

                entity.Property(e => e.SaleDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Sale_Date");

                entity.HasOne(d => d.RequestQuote)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.RequestQuoteId)
                    .HasConstraintName("FK__Sale__Request_Qu__7E37BEF6");
            });

            modelBuilder.Entity<SaleLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Sale_Line");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Sale_Line__Produ__01142BA1");

                entity.HasOne(d => d.Sale)
                    .WithMany()
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK__Sale_Line__Sale___00200768");
            });

            modelBuilder.Entity<SalePayment>(entity =>
            {
                entity.ToTable("Sale_Payment");

                entity.Property(e => e.SalePaymentId).HasColumnName("Sale_Payment_ID");

                entity.Property(e => e.PaymentTypeId).HasColumnName("Payment_Type_ID");

                entity.Property(e => e.RegisterId).HasColumnName("Register_ID");

                entity.Property(e => e.SaleId).HasColumnName("Sale_ID");

                entity.Property(e => e.SalePaymentAmount).HasColumnName("Sale_Payment_Amount");

                entity.Property(e => e.SalePaymentDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Sale_Payment_Date");

                entity.Property(e => e.SalePaymentStatus).HasColumnName("Sale_Payment_Status");

                entity.HasOne(d => d.PaymentType)
                    .WithMany(p => p.SalePayments)
                    .HasForeignKey(d => d.PaymentTypeId)
                    .HasConstraintName("FK__Sale_Paym__Payme__10566F31");

                entity.HasOne(d => d.Register)
                    .WithMany(p => p.SalePayments)
                    .HasForeignKey(d => d.RegisterId)
                    .HasConstraintName("FK__Sale_Paym__Regis__114A936A");

                entity.HasOne(d => d.Sale)
                    .WithMany(p => p.SalePayments)
                    .HasForeignKey(d => d.SaleId)
                    .HasConstraintName("FK__Sale_Paym__Sale___0F624AF8");

                entity.HasOne(d => d.SalePaymentStatusNavigation)
                    .WithMany(p => p.SalePayments)
                    .HasForeignKey(d => d.SalePaymentStatus)
                    .HasConstraintName("FK__Sale_Paym__Sale___0E6E26BF");
            });

            modelBuilder.Entity<SalePaymentStatus>(entity =>
            {
                entity.ToTable("Sale_Payment_Status");

                entity.Property(e => e.SalePaymentStatusId)
                    .ValueGeneratedNever()
                    .HasColumnName("Sale_Payment_Status_ID");

                entity.Property(e => e.SalePaymentStatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Sale_Payment_Status_Desc");
            });

            modelBuilder.Entity<Shift>(entity =>
            {
                entity.ToTable("Shift");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.Property(e => e.ShiftTypeId).HasColumnName("Shift_Type_ID");

                entity.HasOne(d => d.ShiftType)
                    .WithMany(p => p.Shifts)
                    .HasForeignKey(d => d.ShiftTypeId)
                    .HasConstraintName("FK__Shift__Shift_Typ__1CF15040");
            });

            modelBuilder.Entity<ShiftBranch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Shift_Branch");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Shift_Bra__Branc__440B1D61");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Shift_Bra__Shift__4316F928");
            });

            modelBuilder.Entity<ShiftBranchEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Shift_Branch_Employee");

                entity.Property(e => e.BranchId).HasColumnName("Branch_ID");

                entity.Property(e => e.EmployeeId).HasColumnName("Employee_ID");

                entity.Property(e => e.ShiftId).HasColumnName("Shift_ID");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__Shift_Bra__Branc__46E78A0C");

                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__Shift_Bra__Emplo__47DBAE45");

                entity.HasOne(d => d.Shift)
                    .WithMany()
                    .HasForeignKey(d => d.ShiftId)
                    .HasConstraintName("FK__Shift_Bra__Shift__45F365D3");
            });

            modelBuilder.Entity<ShiftType>(entity =>
            {
                entity.ToTable("Shift_Type");

                entity.Property(e => e.ShiftTypeId).HasColumnName("Shift_Type_ID");

                entity.Property(e => e.ShiftTypeDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Shift_Type_Description");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("Size");

                entity.Property(e => e.SizeId).HasColumnName("Size_ID");

                entity.Property(e => e.SizeDescription)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Size_Description");
            });

            modelBuilder.Entity<Special>(entity =>
            {
                entity.ToTable("Special");

                entity.Property(e => e.SpecialId).HasColumnName("Special_ID");

                entity.Property(e => e.EndDate)
                    .HasColumnType("date")
                    .HasColumnName("End_Date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasColumnName("Start_Date");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("Supplier");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.SupplierAddress)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_Address");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_Name");

                entity.Property(e => e.SupplierPhoneNumber)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_Phone_Number");
            });

            modelBuilder.Entity<SupplierOrder>(entity =>
            {
                entity.ToTable("Supplier_Order");

                entity.Property(e => e.SupplierOrderId).HasColumnName("Supplier_Order_ID");

                entity.Property(e => e.SupplierId).HasColumnName("Supplier_ID");

                entity.Property(e => e.SupplierOrderDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Supplier_Order_Description");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierOrders)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__Supplier___Suppl__1CBC4616");
            });

            modelBuilder.Entity<SupplierOrderLine>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Supplier_Order_Line");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.RawMaterialId).HasColumnName("Raw_Material_ID");

                entity.Property(e => e.SupplierOrderId).HasColumnName("Supplier_Order_ID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Supplier___Produ__245D67DE");

                entity.HasOne(d => d.RawMaterial)
                    .WithMany()
                    .HasForeignKey(d => d.RawMaterialId)
                    .HasConstraintName("FK__Supplier___Raw_M__25518C17");

                entity.HasOne(d => d.SupplierOrder)
                    .WithMany()
                    .HasForeignKey(d => d.SupplierOrderId)
                    .HasConstraintName("FK__Supplier___Suppl__236943A5");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.TaskId).HasColumnName("Task_ID");

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Task_Description");
            });

            modelBuilder.Entity<TimeSlot>(entity =>
            {
                entity.ToTable("Time_Slot");

                entity.Property(e => e.TimeSlotId).HasColumnName("Time_Slot_ID");

                entity.Property(e => e.EndingTime).HasColumnName("Ending_time");

                entity.Property(e => e.StartingTime).HasColumnName("Starting_time");
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.UnitId).HasColumnName("Unit_ID");

                entity.Property(e => e.UnitQuantity).HasColumnName("Unit_Quantity");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.UserAccessPermissionId).HasColumnName("User_Access_Permission_ID");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("User_Name");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("User_Password");

                entity.HasOne(d => d.UserAccessPermission)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserAccessPermissionId)
                    .HasConstraintName("FK__User__User_Acces__1273C1CD");
            });

            modelBuilder.Entity<UserAccessPermission>(entity =>
            {
                entity.ToTable("User_Access_Permission");

                entity.Property(e => e.UserAccessPermissionId).HasColumnName("User_Access_Permission_ID");

                entity.Property(e => e.UserRoleDescription)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("User_Role_Description");

                entity.Property(e => e.UserRoleName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("User_Role_Name");
            });

            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.ToTable("Wishlist");

                entity.Property(e => e.WishlistId).HasColumnName("Wishlist_ID");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Wishlists)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Wishlist__Custom__5AEE82B9");
            });

            modelBuilder.Entity<WishlistProduct>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Wishlist_Product");

                entity.Property(e => e.ProductId).HasColumnName("Product_ID");

                entity.Property(e => e.WishlistId).HasColumnName("Wishlist_ID");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Wishlist___Produ__5CD6CB2B");

                entity.HasOne(d => d.Wishlist)
                    .WithMany()
                    .HasForeignKey(d => d.WishlistId)
                    .HasConstraintName("FK__Wishlist___Wishl__5DCAEF64");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

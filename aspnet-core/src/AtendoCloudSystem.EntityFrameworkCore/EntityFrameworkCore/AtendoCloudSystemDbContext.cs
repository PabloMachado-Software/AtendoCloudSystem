using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using AtendoCloudSystem.Authorization.Roles;
using AtendoCloudSystem.Authorization.Users;
using AtendoCloudSystem.MultiTenancy;
using AtendoCloudSystem.Events;
using AtendoCloudSystem.Menus;
using AtendoCloudSystem.Orders;
using AtendoCloudSystem.Tables;
using AtendoCloudSystem.Payments;

namespace AtendoCloudSystem.EntityFrameworkCore
{
    public class AtendoCloudSystemDbContext : AbpZeroDbContext<Tenant, Role, User, AtendoCloudSystemDbContext>
    {
        /* Define a DbSet for each entity of the application */

        public virtual DbSet<Event> Events { get; set; }

        public virtual DbSet<EventRegistration> EventRegistrations { get; set; }

        public virtual DbSet<Table> Tables { get; set; }

        public virtual DbSet<Menu> Menus { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItens> OrdersItens { get; set; }

        public virtual DbSet<Payment> Payments { get; set; }

        public AtendoCloudSystemDbContext(DbContextOptions<AtendoCloudSystemDbContext> options)
            : base(options)
        {
        }
    }
}

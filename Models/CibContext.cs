using ApiGq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace GraphApi
{
    public class CibContext : DbContext
    {
        public CibContext(DbContextOptions<CibContext> options) : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyMember> CompanyMembers { get; set; }
        public DbSet<CompanyMemberPermission> CompanyMemberPermissions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SubProduct> SubProducts { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Inn { get; set; }
        public string Status { get; set; }
       
        public DateTime EstablishmentDate { get; set; }
        public ICollection<CompanyMember> CompanyMembers { get; set; }

        public string IdNew()=>Injector.Crypt.FunctionTest(Id);
        
    }
    public class CompanyMember
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Pin { get; set; }
        public string Status { get; set; }
        public CompanyMemberRole Role { get; set; }
        public DateTime MembershipDate { get; set; }
        public ICollection<CompanyMemberPermission> Permissions { get; set; }
    }
    public enum CompanyMemberRole
    {
        Admin,
        Accountant
    }
    public class CompanyMemberPermission
    {
        public int Id { get; set; }
        public string ProductCode { get; set; }
        public string SubProductCode { get; set; }
        public string Status { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public ICollection<SubProduct> SubProducts { get; set; }
    }
    public class SubProduct
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Product Product { get; set; }

    }

    //public class SubProductType : ObjectType<SubProduct>
    //{

    //    protected override void Configure(IObjectTypeDescriptor<SubProduct> descriptor)
    //    {
    //        descriptor
    //            .Field(f => f.Id * 2)
    //            .Type<IntType>();
    //    }

    //}
    //public class CompanyType : ObjectType<Company>
    //{

    //    protected override void Configure(IObjectTypeDescriptor<Company> descriptor)
    //    {
    //        descriptor
    //            .Field("NewField")
    //            .Resolve(context =>
    //            {
    //                context.
    //                return FunctionTest($"xxxx{context.ContextData.}");
    //            });
    //    }
    //    public string FunctionTest(string field) => field + "Desencriptar";
    //}


}

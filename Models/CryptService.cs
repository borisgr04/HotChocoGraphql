namespace GraphApi
{
    public class CryptService 
    {
        public string FunctionTest(int field) => $"{field} New";
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

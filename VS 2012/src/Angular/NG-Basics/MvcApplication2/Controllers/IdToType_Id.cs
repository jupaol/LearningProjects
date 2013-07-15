using Omu.ValueInjecter;

namespace MvcApplication2.Controllers
{
    public class IdToType_Id : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.Source.Type.Name + "Id" && c.TargetProp.Name == "Id";
            // where source prop is "Id" and target prop is Source type name + "_Id"  ( Id - Foo_Id; Id - Bar_Id )
        }
    }
}
using StructureMap;

namespace FT.Subdown.Core.Containers
{
    public static class Bootstrap
    {
        public static void Run()
        {
            ObjectFactory.Initialize(expression => expression.AddRegistry(new SubdownContainer()));
        }
    }
}


namespace fwptt.TestProject.Run.Data
{
    public partial class TestCSharpCodeGenerator
    {
        public RecordedTestDefinition TestDefinition { get; set; }

        public static string GenerateCode(RecordedTestDefinition testDefinition)
        {
            var newGen = new TestCSharpCodeGenerator { TestDefinition = testDefinition };
            return newGen.TransformText();
        }
    }
}

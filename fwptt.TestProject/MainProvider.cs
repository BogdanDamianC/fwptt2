using fwptt.TestProject.Project.Interfaces;

namespace fwptt.TestProject
{
    public static class MainProvider
    {
        public static ITestProjectHost Current { get; set; }
    }
}

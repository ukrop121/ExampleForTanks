using System;

namespace AutomatedTests
{
    public class TestEnvironment
    {
        public enum TestEnviroments
        {
            Test, Test2
        }

        public static string GetTestEnvironmentPath(TestEnviroments enviroment)
        {
            string fileName;
            switch (enviroment)
            {
                    case TestEnviroments.Test:
                    fileName = "test.xml";
                        break;
                    case TestEnviroments.Test2:
                        fileName = "test2.xml";
                        break;
                default:
                    throw new NotImplementedException("Confiduration file  for " + enviroment + " is not defined in current method");
            }
            return @".\" + fileName;
        }
    }
}

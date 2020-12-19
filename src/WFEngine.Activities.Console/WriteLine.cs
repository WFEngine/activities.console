using System.Linq;
using WFEngine.Activities.Core;
using WFEngine.Activities.Core.Helper;
using WFEngine.Activities.Core.Model;

namespace WFEngine.Activities.Console
{
    public class WriteLine : WFActivity
    {
        public override WFResponse Run()
        {
            WFArgument messageArgument = Arguments.FirstOrDefault(x => x.Name == "Message");
            var argumentValue = messageArgument.GetFirstArgumentFromJson<string>().ReplaceToVariables(Variables);
            System.Console.WriteLine(argumentValue);
            return new WFResponse();
        }
    }
}

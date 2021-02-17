using System.Linq;
using System.Text.RegularExpressions;
using WFEngine.Activities.Core;
using WFEngine.Activities.Core.Helper;
using WFEngine.Activities.Core.Model;

namespace WFEngine.Activities.Console
{
    public class Write : WFActivity
    {
        public override WFResponse Run()
        {
            WFArgument messageArgument = Arguments.FirstOrDefault(x => x.Name == "Message");
            var argumentValue = messageArgument.GetFirstArgumentFromJson<string>().ReplaceToVariables(Variables);
            System.Console.WriteLine(Regex.Unescape(argumentValue));
            return new WFResponse();
        }
    }
}

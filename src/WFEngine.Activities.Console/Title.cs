using System.Linq;
using WFEngine.Activities.Core;
using WFEngine.Activities.Core.Helper;

namespace WFEngine.Activities.Console
{
    public class Title : WFActivity
    {
        public override WFResponse Run()
        {
            var titleArgument = Arguments.FirstOrDefault(x => x.Name == "Title");
            if (titleArgument.ArgumentType != typeof(string).FullName)
                throw new System.Exception();
            var argumentValue = titleArgument.GetFirstArgumentFromJson<string>().ReplaceToVariables(Variables);           
            System.Console.Title = argumentValue;
            return new WFResponse();
        }
    }
}

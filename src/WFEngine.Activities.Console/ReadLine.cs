using System;
using System.Linq;
using WFEngine.Activities.Core;
using WFEngine.Activities.Core.Helper;
using WFEngine.Activities.Core.Model;

namespace WFEngine.Activities.Console
{
    public class ReadLine : WFActivity
    {
        public override WFResponse Run()
        {
            WFArgument returnValueArgument = Arguments.FirstOrDefault(x => x.Name == "ReturnValue");
            if (returnValueArgument == null)
            {
                System.Console.ReadLine();
                return new WFResponse();
            }
            var argumentValue = returnValueArgument.GetFirstArgumentFromJson<string>();
            var variable = VariableHelper.FindVariable(argumentValue, Variables);
            if (variable == default)
                throw new System.Exception();
            Type variableType = Type.GetType(variable.Type);
            variable.Value = Convert.ChangeType(System.Console.ReadLine(), variableType);
            return new WFResponse();
        }
    }
}

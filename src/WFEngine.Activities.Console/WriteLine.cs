using System;
using System.Linq;
using WFEngine.Activities.Core;
using WFEngine.Activities.Core.Model;

namespace WFEngine.Activities.Console
{
    public class WriteLine : WFActivity
    {
        public override string CompileActivity()
        {
            WFArgument message = Arguments.FirstOrDefault(x => x.Name == "Message");
            if (message == null)
                throw new ArgumentNullException(nameof(message));
            string code = "";
            if (message.IsVariable)
                code = $"System.Console.WriteLine({message.Value});";
            else
            {
                if (message.ArgumentType != typeof(string).FullName)
                    throw new Exception();
                else
                {
                    var value = (Newtonsoft.Json.Linq.JArray)message.Value;
                    code = $"System.Console.WriteLine(\"{value.First.ToString()}\");";
                }
            }
            return code;
        }
    }
}

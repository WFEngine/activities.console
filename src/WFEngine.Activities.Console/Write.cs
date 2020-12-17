using System;
using System.Linq;
using WFEngine.Activities.Core;
using WFEngine.Activities.Core.Model;

namespace WFEngine.Activities.Console
{
    public class Write :WFActivity
    {
        public override void Run()
        {
            WFArgument message = Arguments.FirstOrDefault(x => x.Name == "Message");
            var jsonValue = (Newtonsoft.Json.Linq.JArray)message.Value;
            var value = (System.String)Convert.ChangeType(jsonValue.First, typeof(System.String));
            if (value.Contains("$"))
            {
                do
                {
                    var index = value.IndexOf("$");
                    if (value.Length - 1 != index)
                    {
                        var afterItem = value[index + 1];
                        if (afterItem.ToString() != "$")
                        {
                            foreach (var variable in Variables)
                            {
                                value = value.Replace($"${variable.Name}", $"{Convert.ChangeType(variable.Value, typeof(System.String))}");
                            }
                        }
                    }
                } while (value.Contains("$"));
            }
            System.Console.Write(value);
        }
    }
}

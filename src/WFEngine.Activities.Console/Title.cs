using System;
using System.Linq;
using WFEngine.Activities.Core;

namespace WFEngine.Activities.Console
{
    public class Title : WFActivity
    {
        public override void Run()
        {
            var title = Arguments.FirstOrDefault();
            if (title.ArgumentType != typeof(string).FullName)
                throw new System.Exception();
            var jsonValue = (Newtonsoft.Json.Linq.JArray)title.Value;
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

            System.Console.Title = value;
        }
    }
}

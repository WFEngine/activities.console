using WFEngine.Activities.Core;

namespace WFEngine.Activities.Console
{
    public class Clear : WFActivity
    {
        public override WFResponse Run()
        {
            System.Console.Clear();
            return new WFResponse();
        }
    }
}

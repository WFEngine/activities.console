using WFEngine.Activities.Core;

namespace WFEngine.Activities.Console
{
    public class Clear : WFActivity
    {
        public override void Run()
        {
            System.Console.Clear();
        }
    }
}

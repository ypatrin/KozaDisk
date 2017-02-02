using DevExpress.XtraPrinting;

public class MyCommandHandler : ICommandHandler
{
    public virtual void HandleCommand(PrintingSystemCommand command, object[] args, IPrintControl control, ref bool handled)
    {
        //Ensure the default action isn't fired by setting Handled to True
        handled = true;
    }

    public virtual bool CanHandleCommand(PrintingSystemCommand command, IPrintControl control)
    {
        //This handler overrides the Find command.
        return command == PrintingSystemCommand.Find;
    }
}

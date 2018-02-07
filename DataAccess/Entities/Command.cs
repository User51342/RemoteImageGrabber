namespace RemoteImageGrabber.DataAccess.Entities
{
    public class Command : BaseEntity
    {
        #region Properties
        public string CommandName { get; set; }
        public string Value { get; set; }
        #endregion

        #region Construction / Initialization / Deconstruction
        public Command()
        {
            
        }

        public Command(string commandName, string value) 
        {
            CommandName = commandName;
            Value = value;
        }
        #endregion

    }
}

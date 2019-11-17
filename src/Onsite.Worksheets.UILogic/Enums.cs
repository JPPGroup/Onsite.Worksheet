namespace Onsite.Worksheets.UILogic
{
    public enum NetworkStatus
    {
        Connected = 1,
        Disconnected = 2
    }

    public enum RemoteStatus
    {
        Ok = 1,
        Failing = 2,
        Unavailable = 3,
        Terminal = 4
    }

    public enum QueueStatus
    {
        Empty = 1,
        Sync = 2
    }
}
namespace Slack.NetStandard.Endpoint
{
    public enum SlackRequestType
    {
        Event,
        Interaction,
        Command,
        NotVerifiedRequest,
        UnknownRequest
    }
}
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.EventsApi.CallbackEvents;
using Slack.NetStandard.Interaction;
using Slack.NetStandard.Socket;

namespace Slack.NetStandard.Endpoint
{
    public static class SlackEndpointExtension
    {
        public static SlackInformation ToSlackInformation(this Envelope envelope)
        {
            return envelope.Payload switch
            {
                SlashCommand command => new SlackInformation(command),
                EventCallback evt => new SlackInformation(evt),
                InteractionPayload payload => new SlackInformation(payload),
                _ => new SlackInformation(SlackRequestType.UnknownRequest)
            };
        }
    }
}

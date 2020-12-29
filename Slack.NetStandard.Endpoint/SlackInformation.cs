using System;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.Endpoint
{
    public class SlackInformation
    {
        public SlackRequestType Type { get; set; }
        public Event Event { get; set; }
        public InteractionPayload Interaction { get; set; }
        public SlashCommand Command { get; set; }
    }

    public enum SlackRequestType
    {
        Event,
        Interaction,
        Command
    }
}

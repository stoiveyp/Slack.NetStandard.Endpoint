using System;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.Endpoint
{
    public class SlackInformation
    {
        public SlackInformation(SlackRequestType type)
        {
            Type = type;
        }

        public SlackInformation(Event @event)
        {
            Type = SlackRequestType.Event;
            Event = @event;
        }

        public SlackInformation(InteractionPayload payload)
        {
            Type = SlackRequestType.Interaction;
            Interaction = payload;
        }

        public SlackInformation(SlashCommand command)
        {
            Type = SlackRequestType.Command;
            Command = command;
        }

        public SlackRequestType Type { get; set; }
        public Event Event { get; set; }
        public InteractionPayload Interaction { get; set; }
        public SlashCommand Command { get; set; }
    }
}

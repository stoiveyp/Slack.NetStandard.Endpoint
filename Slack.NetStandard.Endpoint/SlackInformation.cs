using System;
using System.Collections.Generic;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.Endpoint
{
    public class SlackInformation
    {
        public SlackInformation(SlackRequestType type, object context = null)
        {
            Type = type;
            Context = context;
        }

        public SlackInformation(Event @event, object context = null):this(SlackRequestType.Event, context)
        {
            Event = @event;
        }

        public SlackInformation(InteractionPayload payload, object context = null):this(SlackRequestType.Interaction, context)
        {
            Interaction = payload;
        }

        public SlackInformation(SlashCommand command, object context = null):this(SlackRequestType.Command, context)
        {
            Command = command;
        }

        public SlackRequestType Type { get; set; }
        public Event Event { get; set; }
        public InteractionPayload Interaction { get; set; }
        public SlashCommand Command { get; set; }
        public Dictionary<string, object> Items { get; } = new ();
        public object Context { get; set; }
    }
}

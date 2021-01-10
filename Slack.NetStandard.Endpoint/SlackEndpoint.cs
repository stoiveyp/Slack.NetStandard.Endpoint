using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.Endpoint
{
    public abstract class SlackEndpoint<TRequest>
    {
        public Task<SlackInformation> Process(TRequest request)
        {
            return GenerateInformation(request);
        }

        protected abstract Task<SlackInformation> GenerateInformation(TRequest request);

        protected SlackInformation InformationFromBodyAndContentType(string contentType, string body)
        {
            return contentType switch
            {
                "application/json" => new SlackInformation(JsonConvert.DeserializeObject<Event>(body)),
                "application/x-www-form-urlencoded" => body.StartsWith("payload=") ?
                    new SlackInformation(JsonConvert.DeserializeObject<InteractionPayload>(HttpUtility.UrlDecode(body.Substring(8)))) :
                    new SlackInformation(new SlashCommand(body)),
                _ => new SlackInformation(SlackRequestType.UnknownRequest)
            };
        }
    }
}

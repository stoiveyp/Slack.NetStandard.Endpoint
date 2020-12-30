using System.Threading.Tasks;

namespace Slack.NetStandard.Endpoint
{
    public abstract class SlackEndpoint<TRequest>
    {
        public Task<SlackInformation> Process(TRequest request)
        {
            return GenerateInformation(request);
        }

        protected abstract Task<SlackInformation> GenerateInformation(TRequest request);
    }
}

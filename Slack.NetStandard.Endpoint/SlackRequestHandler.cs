using System;
using System.Threading.Tasks;
using Slack.NetStandard.EventsApi;
using Slack.NetStandard.Interaction;

namespace Slack.NetStandard.Endpoint
{
    public abstract class SlackRequestHandler<TRequest,TResponse>
    {
        public async Task<TResponse> Process(TRequest request)
        {
            var info = await GenerateInformation(request);
            if (info == null)
            {
                return await InvalidRequestResponse(request);
            }

            return info.Type switch
            {
                SlackRequestType.Event => await ProcessEvent(info.Event),
                SlackRequestType.Interaction => await ProcessInteraction(info.Interaction),
                SlackRequestType.Command => await ProcessCommand(info.Command),
                _ => await InvalidRequestResponse(request)
            };
        }

        protected abstract Task<SlackInformation> GenerateInformation(TRequest request);

        private Task<TResponse> ProcessInteraction(InteractionPayload infoInteraction)
        {
            return HandleInteraction(infoInteraction);
        }

        private Task<TResponse> ProcessEvent(Event infoEvent)
        {
            return infoEvent switch
            {
                UrlVerification verification => DefaultOKResponse(verification.Challenge),
                AppRateLimited rateLimited => HandleEventRateLimited(rateLimited),
                EventCallback callback => HandleEventCallback(callback),
                _ => DefaultOKResponse()
            };
        }

        private Task<TResponse> ProcessCommand(SlashCommand infoCommand)
        {
            return infoCommand.IsSslCheck ? DefaultOKResponse() : HandleCommand(infoCommand);
        }


        protected abstract Task<TResponse> HandleCommand(SlashCommand infoCommand);

        protected abstract Task<TResponse> HandleInteraction(InteractionPayload infoInteraction);

        protected virtual Task<TResponse> HandleEventRateLimited(AppRateLimited infoEvent)
        {
            return DefaultOKResponse();
        }

        protected abstract Task<TResponse> HandleEventCallback(EventCallback infoEvent);

        protected abstract Task<TResponse> DefaultOKResponse(string body = null);

        protected abstract Task<TResponse> InvalidRequestResponse(TRequest request);
    }
}

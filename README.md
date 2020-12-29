# Slack.NetStandard.Endpoint
Small library used to build single Slack endpoints - allowing simpler wiring of Slack apps by examining the full request and deserializing appropriately


## Overview

Slack has several different ways of sending data:

*  Events API
*  Interaction Payloads
*  Slash Commands

Slack apps deal with the input from these requests but each sends the data in slightly different ways. 

The idea of the endpoint libraries is that they will examine the HTTP Request being sent in and handle different deserialization methods as well as common cases (such as when Slack sends verification requests intermittently)

This allows the application code to worry less about application code to get up and running with Slack and more on the app itself.

Current implementations:

*  Lambda API Proxy [GitHub](https://github.com/stoiveyp/Slack.NetStandard.Endpoint.ApiGatewayLambdaProxy) / [NuGet](https://nuget.org/packages/Slack.NetStandard.Endpoint.ApiGatewayLambdaProxy)
*  Web API Middleware (coming soon)

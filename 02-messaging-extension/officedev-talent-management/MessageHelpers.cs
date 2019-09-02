/*
 * Copyright (c) Microsoft Corporation. All rights reserved.
 * Licensed under the MIT license.
 */
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Connector.Teams.Models;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace officedev_talent_management
{
  public class MessageHelpers
  {
    public static string CreateHelpMessage(string firstLine)
    {
      var sb = new StringBuilder();
      sb.AppendLine(firstLine);
      sb.AppendLine();
      return sb.ToString();
    }

    public static async Task SendOneToOneWelcomeMessage(
      ConnectorClient connector,
      TeamsChannelData channelData,
      ChannelAccount botAccount, ChannelAccount userAccount,
      string tenantId)
    {
      string welcomeMessage = CreateHelpMessage($"The team {channelData.Team.Name} has the Invnetory Management bot- helping your team to order inventories and find suppliers.");

      // create or get existing chat conversation with user
      var response = connector.Conversations.CreateOrGetDirectConversation(botAccount, userAccount, tenantId);

      // Construct the message to post to conversation
      Activity newActivity = new Activity()
      {
        Text = welcomeMessage,
        Type = ActivityTypes.Message,
        Conversation = new ConversationAccount
        {
          Id = response.Id
        },
      };

      // Post the message to chat conversation with user
      await connector.Conversations.SendToConversationAsync(newActivity);
    }

    public static async Task SendMessage(IDialogContext context, string message)
    {
      await context.PostAsync(message);
    }

  }
}
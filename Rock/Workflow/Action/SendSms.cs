﻿// <copyright>
// Copyright 2013 by the Spark Development Network
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;

using Rock.Attribute;
using Rock.Communication;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Workflow.Action
{
    /// <summary>
    /// Sends email
    /// </summary>
    [Description( "Sends an email.  The recipient can either be a person or email address determined by the 'To Attribute' value, or an email address entered in the 'To' field." )]
    [Export( typeof( ActionComponent ) )]
    [ExportMetadata( "ComponentName", "Send Email" )]

    [DefinedValueField( Rock.SystemGuid.DefinedType.COMMUNICATION_SMS_FROM, "From", "The phone number to send message from", true, false, "", "", 0 )]
    [WorkflowTextOrAttribute( "Recipient", "Attribute Value", "The phone number or an attribute that contains the person or phone number that message should be sent to", true, "", "", 1, "To" )]
    [WorkflowTextOrAttribute( "Message", "Attribute Value", "The message or an attribute that contains the message that should be sent", true, "", "", 2, "Message" )]
    public class SendSms : ActionComponent
    {
        /// <summary>
        /// Executes the specified workflow.
        /// </summary>
        /// <param name="rockContext">The rock context.</param>
        /// <param name="action">The action.</param>
        /// <param name="entity">The entity.</param>
        /// <param name="errorMessages">The error messages.</param>
        /// <returns></returns>
        public override bool Execute( RockContext rockContext, WorkflowAction action, Object entity, out List<string> errorMessages )
        {
            errorMessages = new List<string>();

            int? fromId = null;
            Guid? fromGuid = GetAttributeValue( action, "From" ).AsGuidOrNull();
            if (fromGuid.HasValue)
            {
                var fromValue = DefinedValueCache.Read(fromGuid.Value, rockContext);
                if (fromValue != null)
                {
                    fromId = fromValue.Id;
                }
            }

            var recipients = new List<string>();
            string toValue = GetAttributeValue( action, "To" );
            Guid guid = toValue.AsGuid();
            if ( !guid.IsEmpty() )
            {
                var attribute = AttributeCache.Read( guid, rockContext );
                if ( attribute != null )
                {
                    string toAttributeValue = action.GetWorklowAttributeValue( guid );
                    if ( !string.IsNullOrWhiteSpace( toAttributeValue ) )
                    {
                        switch ( attribute.FieldType.Class )
                        {
                            case "Rock.Field.Types.TextFieldType":
                                {
                                    recipients.Add( toAttributeValue );
                                    break;
                                }
                            case "Rock.Field.Types.PersonFieldType":
                                {
                                    Guid personAliasGuid = toAttributeValue.AsGuid();
                                    if ( !personAliasGuid.IsEmpty() )
                                    {
                                        var phoneNumber = new PersonAliasService( rockContext ).Queryable()
                                            .Where( a => a.Guid.Equals( personAliasGuid ) )
                                            .SelectMany( a => a.Person.PhoneNumbers )
                                            .Where( p => p.IsMessagingEnabled)
                                            .FirstOrDefault();

                                        if (phoneNumber != null)
                                        {
                                            string smsNumber = phoneNumber.Number;
                                            if ( !string.IsNullOrWhiteSpace( phoneNumber.CountryCode ) )
                                            {
                                                smsNumber = "+" + phoneNumber.CountryCode + phoneNumber.Number;
                                            }
                                            recipients.Add( smsNumber );
                                        }
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
            else
            {
                if ( !string.IsNullOrWhiteSpace( toValue ) )
                {
                    recipients.Add( toValue );
                }
            }

            string message = GetAttributeValue( action, "Message" );
            Guid messageGuid = message.AsGuid();
            if ( !messageGuid.IsEmpty() )
            {
                var attribute = AttributeCache.Read( messageGuid, rockContext );
                if ( attribute != null )
                {
                    string messageAttributeValue = action.GetWorklowAttributeValue( messageGuid );
                    if ( !string.IsNullOrWhiteSpace( messageAttributeValue ) )
                    {
                        if ( attribute.FieldType.Class == "Rock.Field.Types.TextFieldType" )
                        {
                            message = messageAttributeValue;
                        }
                    }
                }
            }

            if ( recipients.Any() && fromId.HasValue && !string.IsNullOrWhiteSpace(message) )
            {
                var mergeFields = GetMergeFields( action );

                var channelData = new Dictionary<string, string>();
                channelData.Add( "FromValue", fromId.Value.ToString());
                channelData.Add( "Message", message.ResolveMergeFields( mergeFields ) );

                var channelEntity = EntityTypeCache.Read( Rock.SystemGuid.EntityType.COMMUNICATION_CHANNEL_SMS.AsGuid(), rockContext );
                if ( channelEntity != null )
                {
                    var channel = ChannelContainer.GetComponent( channelEntity.Name );
                    if ( channel != null && channel.IsActive )
                    {
                        var transport = channel.Transport;
                        if ( transport != null && transport.IsActive )
                        {
                            var appRoot = GlobalAttributesCache.Read( rockContext ).GetValue( "InternalApplicationRoot" );
                            transport.Send( channelData, recipients, appRoot, string.Empty );
                        }
                    }
                }
            }

            return true;
        }
    }
}
﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
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
using System.Linq;
using Rock.Communication;

namespace Rock
{
    /// <summary>
    /// Medium Container Extensions that don't reference Rock
    /// </summary>
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Gets the medium components with active transports.
        /// </summary>
        /// <param name="mediumContainer">The medium container.</param>
        /// <returns></returns>
        public static IEnumerable<MediumComponent> GetMediumComponentsWithActiveTransports( this MediumContainer mediumContainer )
        {
            return mediumContainer.Components.Select( a => a.Value.Value ).Where( x => x.Transport != null && x.Transport.IsActive );
        }

        /// <summary>
        /// Determines whether a transport is active for the specified unique identifier.
        /// </summary>
        /// <param name="mediumContainer">The medium container.</param>
        /// <param name="guid">The unique identifier.</param>
        /// <returns>
        ///   <c>true</c> if an active transport exists for the specified unique identifier; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasActiveTransport( this MediumContainer mediumContainer, Guid guid )
        {
            return mediumContainer.GetMediumComponentsWithActiveTransports().Any( a => a.EntityType.Guid == guid );
        }

        /// <summary>
        /// Determines whether an active SMS transport exists.
        /// </summary>
        /// <param name="mediumContainer">The medium container.</param>
        /// <returns>
        ///   <c>true</c> if an active SMS transport exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasActiveSmsTransport( this MediumContainer mediumContainer)
        {
            return mediumContainer.HasActiveTransport( Rock.SystemGuid.EntityType.COMMUNICATION_MEDIUM_SMS.AsGuid() );
        }

        /// <summary>
        /// Determines whether an active email transport exists.
        /// </summary>
        /// <param name="mediumContainer">The medium container.</param>
        /// <returns>
        ///   <c>true</c> if an active email transport exists; otherwise, <c>false</c>.
        /// </returns>
        public static bool HasActiveEmailTransport( this MediumContainer mediumContainer)
        {
            return mediumContainer.HasActiveTransport( Rock.SystemGuid.EntityType.COMMUNICATION_MEDIUM_EMAIL.AsGuid() );
        }
    }
}
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

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// Allow configuring multiple launch workflow buttons on a grid with custom routes and button icons
    /// </summary>
    public class WorkflowLaunchConfig
    {
        /// <summary>
        /// Gets or sets the route. This will be formatted using an EntitySetId in position {0}.
        /// Example: /CustomLaunchRoute/{0}
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public string Route { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class.
        /// Example: fa fa-custom
        /// </summary>
        /// <value>
        /// The icon CSS class.
        /// </value>
        public string IconCssClass { get; set; }
    }
}

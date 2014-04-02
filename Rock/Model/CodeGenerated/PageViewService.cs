//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
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
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// PageView Service class
    /// </summary>
    public partial class PageViewService : Service<PageView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PageViewService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public PageViewService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( PageView item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class PageViewExtensionMethods
    {
        /// <summary>
        /// Clones this PageView object to a new PageView object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static PageView Clone( this PageView source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as PageView;
            }
            else
            {
                var target = new PageView();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another PageView object to this PageView object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this PageView target, PageView source )
        {
            target.PageId = source.PageId;
            target.SiteId = source.SiteId;
            target.PersonAliasId = source.PersonAliasId;
            target.DateTimeViewed = source.DateTimeViewed;
            target.UserAgent = source.UserAgent;
            target.ClientType = source.ClientType;
            target.Url = source.Url;
            target.PageTitle = source.PageTitle;
            target.SessionId = source.SessionId;
            target.IpAddress = source.IpAddress;
            target.Id = source.Id;
            target.Guid = source.Guid;

        }
    }
}

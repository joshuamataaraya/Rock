// <copyright>
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
using System.Collections.Generic;
using System.Linq;
using Rock.Model;

namespace Rock
{
    /// <summary>
    /// Rock.Model.PhoneNumber Extensions
    /// </summary>
    public static partial class ExtensionMethods
    {
        /// <summary>
        /// Converts to a string that is correctly formatted to be used as an SMS phone number.
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns></returns>
        public static string ToSmsNumber( this PhoneNumber phoneNumber )
        {
            if(phoneNumber == null )
            {
                return null;
            }

            string smsNumber = phoneNumber.Number;
            if ( !string.IsNullOrWhiteSpace( phoneNumber.CountryCode ) )
            {
                smsNumber = "+" + phoneNumber.CountryCode + phoneNumber.Number;
            }
            return smsNumber;
        }
    }
}

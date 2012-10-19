//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//
using System;
using System.Collections.Generic;
using System.Dynamic;

using Rock.Data;

namespace Rock.Cms
{
    /// <summary>
    /// Data Transfer Object for Page object
    /// </summary>
    public partial class PageDto : IDto
    {

#pragma warning disable 1591
        public string Name { get; set; }
        public string Title { get; set; }
        public bool IsSystem { get; set; }
        public int? ParentPageId { get; set; }
        public int? SiteId { get; set; }
        public string Layout { get; set; }
        public bool RequiresEncryption { get; set; }
        public bool EnableViewState { get; set; }
        public bool MenuDisplayDescription { get; set; }
        public bool MenuDisplayIcon { get; set; }
        public bool MenuDisplayChildPages { get; set; }
        public DisplayInNavWhen DisplayInNavWhen { get; set; }
        public int Order { get; set; }
        public int OutputCacheDuration { get; set; }
        public string Description { get; set; }
        public bool IncludeAdminFooter { get; set; }
        public string IconUrl { get; set; }
        public int Id { get; set; }
        public Guid Guid { get; set; }
#pragma warning restore 1591

        /// <summary>
        /// Instantiates a new DTO object
        /// </summary>
        public PageDto ()
        {
        }

        /// <summary>
        /// Instantiates a new DTO object from the entity
        /// </summary>
        /// <param name="page"></param>
        public PageDto ( Page page )
        {
            CopyFromModel( page );
        }

        /// <summary>
        /// Creates a dictionary object.
        /// </summary>
        /// <returns></returns>
        public virtual Dictionary<string, object> ToDictionary()
        {
            var dictionary = new Dictionary<string, object>();
            dictionary.Add( "Name", this.Name );
            dictionary.Add( "Title", this.Title );
            dictionary.Add( "IsSystem", this.IsSystem );
            dictionary.Add( "ParentPageId", this.ParentPageId );
            dictionary.Add( "SiteId", this.SiteId );
            dictionary.Add( "Layout", this.Layout );
            dictionary.Add( "RequiresEncryption", this.RequiresEncryption );
            dictionary.Add( "EnableViewState", this.EnableViewState );
            dictionary.Add( "MenuDisplayDescription", this.MenuDisplayDescription );
            dictionary.Add( "MenuDisplayIcon", this.MenuDisplayIcon );
            dictionary.Add( "MenuDisplayChildPages", this.MenuDisplayChildPages );
            dictionary.Add( "DisplayInNavWhen", this.DisplayInNavWhen );
            dictionary.Add( "Order", this.Order );
            dictionary.Add( "OutputCacheDuration", this.OutputCacheDuration );
            dictionary.Add( "Description", this.Description );
            dictionary.Add( "IncludeAdminFooter", this.IncludeAdminFooter );
            dictionary.Add( "IconUrl", this.IconUrl );
            dictionary.Add( "Id", this.Id );
            dictionary.Add( "Guid", this.Guid );
            return dictionary;
        }

        /// <summary>
        /// Creates a dynamic object.
        /// </summary>
        /// <returns></returns>
        public virtual dynamic ToDynamic()
        {
            dynamic expando = new ExpandoObject();
            expando.Name = this.Name;
            expando.Title = this.Title;
            expando.IsSystem = this.IsSystem;
            expando.ParentPageId = this.ParentPageId;
            expando.SiteId = this.SiteId;
            expando.Layout = this.Layout;
            expando.RequiresEncryption = this.RequiresEncryption;
            expando.EnableViewState = this.EnableViewState;
            expando.MenuDisplayDescription = this.MenuDisplayDescription;
            expando.MenuDisplayIcon = this.MenuDisplayIcon;
            expando.MenuDisplayChildPages = this.MenuDisplayChildPages;
            expando.DisplayInNavWhen = this.DisplayInNavWhen;
            expando.Order = this.Order;
            expando.OutputCacheDuration = this.OutputCacheDuration;
            expando.Description = this.Description;
            expando.IncludeAdminFooter = this.IncludeAdminFooter;
            expando.IconUrl = this.IconUrl;
            expando.Id = this.Id;
            expando.Guid = this.Guid;
            return expando;
        }

        /// <summary>
        /// Copies the model property values to the DTO properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyFromModel( IEntity model )
        {
            if ( model is Page )
            {
                var page = (Page)model;
                this.Name = page.Name;
                this.Title = page.Title;
                this.IsSystem = page.IsSystem;
                this.ParentPageId = page.ParentPageId;
                this.SiteId = page.SiteId;
                this.Layout = page.Layout;
                this.RequiresEncryption = page.RequiresEncryption;
                this.EnableViewState = page.EnableViewState;
                this.MenuDisplayDescription = page.MenuDisplayDescription;
                this.MenuDisplayIcon = page.MenuDisplayIcon;
                this.MenuDisplayChildPages = page.MenuDisplayChildPages;
                this.DisplayInNavWhen = page.DisplayInNavWhen;
                this.Order = page.Order;
                this.OutputCacheDuration = page.OutputCacheDuration;
                this.Description = page.Description;
                this.IncludeAdminFooter = page.IncludeAdminFooter;
                this.IconUrl = page.IconUrl;
                this.Id = page.Id;
                this.Guid = page.Guid;
            }
        }

        /// <summary>
        /// Copies the DTO property values to the entity properties
        /// </summary>
        /// <param name="model">The model.</param>
        public void CopyToModel ( IEntity model )
        {
            if ( model is Page )
            {
                var page = (Page)model;
                page.Name = this.Name;
                page.Title = this.Title;
                page.IsSystem = this.IsSystem;
                page.ParentPageId = this.ParentPageId;
                page.SiteId = this.SiteId;
                page.Layout = this.Layout;
                page.RequiresEncryption = this.RequiresEncryption;
                page.EnableViewState = this.EnableViewState;
                page.MenuDisplayDescription = this.MenuDisplayDescription;
                page.MenuDisplayIcon = this.MenuDisplayIcon;
                page.MenuDisplayChildPages = this.MenuDisplayChildPages;
                page.DisplayInNavWhen = this.DisplayInNavWhen;
                page.Order = this.Order;
                page.OutputCacheDuration = this.OutputCacheDuration;
                page.Description = this.Description;
                page.IncludeAdminFooter = this.IncludeAdminFooter;
                page.IconUrl = this.IconUrl;
                page.Id = this.Id;
                page.Guid = this.Guid;
            }
        }
    }
}

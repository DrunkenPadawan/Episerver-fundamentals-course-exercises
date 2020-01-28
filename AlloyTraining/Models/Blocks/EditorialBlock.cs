using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Blocks
{
    [ContentType(DisplayName = "Editorial", 
        GUID = "9d641695-1669-40c5-a185-bcaf3695effb",
        Description = "Use this for a rich editorial text that will be reused in multiple places.")]
    [SiteBlockIcon]
    public class EditorialBlock : BlockData
    {
                [CultureSpecific]
                [Display(
                    Name = "Main body",
                    Description = "Name field's description",
                    GroupName = SystemTabNames.Content,
                    Order = 1)]
                public virtual XhtmlString MainBody { get; set; }
    }
}
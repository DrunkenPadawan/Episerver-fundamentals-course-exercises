using System;
using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace AlloyTraining.Models.Media
{
    [ContentType(DisplayName = "Any File", GUID = "1069c854-7f20-4efc-bed8-15e9bdd02910", Description = "Use this to upload any type of file.")]
    /*[MediaDescriptor(ExtensionString = "pdf,doc,docx")]*/
    public class AnyFile : MediaData
    {
    }
}
//-----------------------------------------------------------------------
// <copyright file="CollectionModelDescription.cs" company="Unknown">
// Copyright (c) Pnoleto. All rights reserved.
// </copyright>
// <author>Pnoleto<author>
//-----------------------------------------------------------------------
namespace WebAPI.Areas.HelpPage.ModelDescriptions
{
    public class CollectionModelDescription : ModelDescription
    {
        public ModelDescription ElementDescription { get; set; }
    }
}
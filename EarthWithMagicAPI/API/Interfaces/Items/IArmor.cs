// <copyright file="IArmor.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace EarthWithMagicAPI.API.Interfaces.Items
{
    /// <summary>
    /// Implemented by all armors.
    /// </summary>
    public abstract class IArmor : IItem
    {

        public IArmor(string name, double weight, string imagePath, string documentationPath) : base(name, weight, imagePath, documentationPath)
        {
        }
    }
}
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Total.cs" company="Software Inc.">
//   A.Robson
// </copyright>
// <summary>
//   The total discs and cost for an artist.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace RecordDAL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// The total values of discs and cost.
    /// </summary>
    public class Total
    {
        /// <summary>
        /// Gets or sets the artist id.
        /// </summary>
        public int ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public int TotalDiscs { get; set; }

        /// <summary>
        /// Gets or sets the total.
        /// </summary>
        public decimal TotalCost { get; set; }
    }
}

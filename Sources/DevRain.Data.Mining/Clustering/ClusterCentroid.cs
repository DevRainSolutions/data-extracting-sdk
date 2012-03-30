// ============================================================================
// <copyright file="ExcelCreator.cs" company="DevRain">
//     Copyright (c) DevRain 2011. All rights reserved.
// </copyright>
// <author>Oleksandr Krakovetskyi</author>
// <date>11.02.2011</date>
// ============================================================================

namespace DevRain.Data.Mining
{
    public class ClusterCentroid : ClusterPoint
    {
        /// <summary>
        /// Basic constructor
        /// </summary>
        /// <param name="x">Centroid x-coord</param>
        /// <param name="y">Centroid y-coord</param>
        public ClusterCentroid(double x, double y)
            : base(x, y)
        {
        }
    }
}

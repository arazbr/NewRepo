﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCICT.Microsoft.Office.Word.ContentReader
{
    /// <summary>
    /// Provides tools to detect the kind of the overlap between two intervals
    /// </summary>
    public static class IntervalOverlap
    {
        /// <summary>
        /// Detects kind of the overlap that the specified two ranges have.
        /// </summary>
        /// <param name="start1">The inclusive start of the first interval.</param>
        /// <param name="end1">The exclusive end of the first interval.</param>
        /// <param name="start2">The inclusive start of the second interval.</param>
        /// <param name="end2">The exclusive end of the second interval.</param>
        /// <returns></returns>
        public static IntervalOverlapKinds Detect(int start1, int end1, int start2, int end2)
        {
            IntervalOverlapKinds relation = IntervalOverlapKinds.FirstAfterSecond;

            if (start2 <= start1 && end1 <= end2)
            {
                // (--)
                relation = IntervalOverlapKinds.FirstInsideSecond;
            }
            else if (start1 <= start2 && end2 <= end1)
            {
                // -()-
                relation = IntervalOverlapKinds.FirstIncludesSecond;
            }
            else if (start1 < start2 && start2 < end1 && end1 <= end2)
            {
                // -(-)
                relation = IntervalOverlapKinds.FirstBeforeAndInsideSecond;
            }
            else if (start2 <= start1 && start1 < end2 && end1 > end2)
            {
                // (-)-
                relation = IntervalOverlapKinds.FirstInsideAndAfterSecond;
            }
            else if (start1 < start2 && end1 <= start2)
            {
                // --()
                relation = IntervalOverlapKinds.FirstBeforeSecond;
            }
            else if (start1 >= end2)
            {
                // ()--
                relation = IntervalOverlapKinds.FirstAfterSecond;
            }
            else
            {
                throw new Exception("Could not detect interval overlapping kinds");
            }

            return relation;
        }

        /// <summary>
        /// Gets the sign corresponding to the given overlap kind.
        /// -- means the first interval, and
        /// () means the second interval.
        /// </summary>
        /// <param name="overlapKind">Kind of the overlap.</param>
        /// <returns></returns>
        public static string GetSign(IntervalOverlapKinds overlapKind)
        {
            switch (overlapKind)
            {
                case IntervalOverlapKinds.FirstInsideSecond:
                    return "(--)";
                case IntervalOverlapKinds.FirstIncludesSecond:
                    return "-()-";
                case IntervalOverlapKinds.FirstBeforeAndInsideSecond:
                    return "-(-)";
                case IntervalOverlapKinds.FirstInsideAndAfterSecond:
                    return "(-)-";
                case IntervalOverlapKinds.FirstBeforeSecond:
                    return "--()";
                case IntervalOverlapKinds.FirstAfterSecond:
                    return "()--";
                default:
                    throw new Exception("Unknown interval overlap type!");
            }
        }

    }
}

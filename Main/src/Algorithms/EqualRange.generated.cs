﻿using System;
using System.Collections.Generic;

namespace CodeJam
{
	partial class Algorithms
	{

		#region float
		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [0, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [0, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<float> list, float value)
			=> list.EqualRange(value, 0);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [from, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<float> list, float value, int from)
			=> list.EqualRange(value, from, list.Count);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, to - 1] such that list[i] >= value or "to" if no such i exists
		///		j is the smallest index in the range [from, to - 1] such that list[i] > value or "to" if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <param name="to">The upper bound for the index (not included)</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<float> list, float value, int from, int to)
		{
			ValidateIndicesRange(from, to, list.Count);
			var upperBoundFrom = from;
			var upperBoundTo = to;

			// the loop locates the lower bound at the same time restricting the range for upper bound search
			while (from < to)
			{
				var median = from + (to - from) / 2;
				if (list[median] < value)
				{
					from = median + 1;
					upperBoundFrom = from;
				}
				else if (list[median] == value)
				{
					to = median;
					upperBoundFrom = to + 1;
				}
				else
				{
					to = median;
					upperBoundTo = to;
				}
			}
			return TupleStruct.Create(from, UpperBoundCore(list, value, upperBoundFrom, upperBoundTo));
		}
		#endregion

		#region double
		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [0, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [0, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<double> list, double value)
			=> list.EqualRange(value, 0);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [from, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<double> list, double value, int from)
			=> list.EqualRange(value, from, list.Count);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, to - 1] such that list[i] >= value or "to" if no such i exists
		///		j is the smallest index in the range [from, to - 1] such that list[i] > value or "to" if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <param name="to">The upper bound for the index (not included)</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<double> list, double value, int from, int to)
		{
			ValidateIndicesRange(from, to, list.Count);
			var upperBoundFrom = from;
			var upperBoundTo = to;

			// the loop locates the lower bound at the same time restricting the range for upper bound search
			while (from < to)
			{
				var median = from + (to - from) / 2;
				if (list[median] < value)
				{
					from = median + 1;
					upperBoundFrom = from;
				}
				else if (list[median] == value)
				{
					to = median;
					upperBoundFrom = to + 1;
				}
				else
				{
					to = median;
					upperBoundTo = to;
				}
			}
			return TupleStruct.Create(from, UpperBoundCore(list, value, upperBoundFrom, upperBoundTo));
		}
		#endregion

		#region TimeSpan
		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [0, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [0, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<TimeSpan> list, TimeSpan value)
			=> list.EqualRange(value, 0);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [from, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<TimeSpan> list, TimeSpan value, int from)
			=> list.EqualRange(value, from, list.Count);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, to - 1] such that list[i] >= value or "to" if no such i exists
		///		j is the smallest index in the range [from, to - 1] such that list[i] > value or "to" if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <param name="to">The upper bound for the index (not included)</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<TimeSpan> list, TimeSpan value, int from, int to)
		{
			ValidateIndicesRange(from, to, list.Count);
			var upperBoundFrom = from;
			var upperBoundTo = to;

			// the loop locates the lower bound at the same time restricting the range for upper bound search
			while (from < to)
			{
				var median = from + (to - from) / 2;
				if (list[median] < value)
				{
					from = median + 1;
					upperBoundFrom = from;
				}
				else if (list[median] == value)
				{
					to = median;
					upperBoundFrom = to + 1;
				}
				else
				{
					to = median;
					upperBoundTo = to;
				}
			}
			return TupleStruct.Create(from, UpperBoundCore(list, value, upperBoundFrom, upperBoundTo));
		}
		#endregion

		#region DateTime
		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [0, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [0, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<DateTime> list, DateTime value)
			=> list.EqualRange(value, 0);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [from, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<DateTime> list, DateTime value, int from)
			=> list.EqualRange(value, from, list.Count);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, to - 1] such that list[i] >= value or "to" if no such i exists
		///		j is the smallest index in the range [from, to - 1] such that list[i] > value or "to" if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <param name="to">The upper bound for the index (not included)</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<DateTime> list, DateTime value, int from, int to)
		{
			ValidateIndicesRange(from, to, list.Count);
			var upperBoundFrom = from;
			var upperBoundTo = to;

			// the loop locates the lower bound at the same time restricting the range for upper bound search
			while (from < to)
			{
				var median = from + (to - from) / 2;
				if (list[median] < value)
				{
					from = median + 1;
					upperBoundFrom = from;
				}
				else if (list[median] == value)
				{
					to = median;
					upperBoundFrom = to + 1;
				}
				else
				{
					to = median;
					upperBoundTo = to;
				}
			}
			return TupleStruct.Create(from, UpperBoundCore(list, value, upperBoundFrom, upperBoundTo));
		}
		#endregion

		#region DateTimeOffset
		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [0, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [0, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<DateTimeOffset> list, DateTimeOffset value)
			=> list.EqualRange(value, 0);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, list.Count - 1] such that list[i] >= value or list.Count if no such i exists
		///		j is the smallest index in the range [from, list.Count - 1] such that list[i] > value or list.Count if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<DateTimeOffset> list, DateTimeOffset value, int from)
			=> list.EqualRange(value, from, list.Count);

		/// <summary>
		/// Returns the tuple of [i, j] where
		///		i is the smallest index in the range [from, to - 1] such that list[i] >= value or "to" if no such i exists
		///		j is the smallest index in the range [from, to - 1] such that list[i] > value or "to" if no such j exists
		/// </summary>
		/// <param name="list">The sorted list</param>
		/// <param name="value">The value to compare</param>
		/// <param name="from">The minimum index</param>
		/// <param name="to">The upper bound for the index (not included)</param>
		/// <returns>The tuple of lower bound and upper bound for the value</returns>
		public static TupleStruct<int, int> EqualRange(this IList<DateTimeOffset> list, DateTimeOffset value, int from, int to)
		{
			ValidateIndicesRange(from, to, list.Count);
			var upperBoundFrom = from;
			var upperBoundTo = to;

			// the loop locates the lower bound at the same time restricting the range for upper bound search
			while (from < to)
			{
				var median = from + (to - from) / 2;
				if (list[median] < value)
				{
					from = median + 1;
					upperBoundFrom = from;
				}
				else if (list[median] == value)
				{
					to = median;
					upperBoundFrom = to + 1;
				}
				else
				{
					to = median;
					upperBoundTo = to;
				}
			}
			return TupleStruct.Create(from, UpperBoundCore(list, value, upperBoundFrom, upperBoundTo));
		}
		#endregion
	}
}

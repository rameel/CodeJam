﻿#if !LESSTHAN_NET40
using System;
using System.Linq;
using System.Reflection;

using CodeJam.Targeting;

using JetBrains.Annotations;

namespace CodeJam.Metadata
{
	internal class AttributeReader : IMetadataReader
	{
		[NotNull]
		public T[] GetAttributes<T>([NotNull] Type type, bool inherit = true)
			where T : Attribute
		{
			var attrs = type.GetCustomAttributes(typeof(T), inherit);
			var arr   = new T[attrs.Length];

			for (var i = 0; i < attrs.Length; i++)
				arr[i] = (T)attrs[i];

			return arr;
		}

		[NotNull]
		public T[] GetAttributes<T>([NotNull] MemberInfo memberInfo, bool inherit = true)
			where T : Attribute
		{
			var attrs = memberInfo.GetCustomAttributes(typeof(T), inherit)
#if LESSTHAN_NETSTANDARD20 || LESSTHAN_NETCOREAPP20
				.ToArray()
#endif
				;
			var arr   = new T[attrs.Length];

			for (var i = 0; i < attrs.Length; i++)
				arr[i] = (T)attrs[i];

			return arr;
		}
	}
}
#endif
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apex.Framework.Core.Pagination
{
	[Serializable]
	public sealed class PagedList<T> : List<T>
	{
		public PagedList(IQueryable<T> source, int pageIndex, int pageSize)
		{
			int total = source.Count();
			this.TotalCount = total;
			this.TotalPages = total / pageSize;

			if (total % pageSize > 0)
			{
				TotalPages++;
			}

			PageSize = pageSize;
			PageIndex = pageIndex;
			AddRange(source);
		}

		public PagedList(IList<T> source, int pageIndex, int pageSize)
		{
			TotalCount = source.Count();
			TotalPages = TotalCount / pageSize;

			if (TotalCount % pageSize > 0)
			{
				TotalPages++;
			}

			PageSize = pageSize;
			PageIndex = pageIndex;
			AddRange(source);
		}

		public int PageIndex { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }
		public int TotalPages { get; private set; }

		private void AddRange(IList<T> source)
		{
			int startIndex = PageIndex * PageSize;
			int maxIndex = startIndex + PageSize;
			if (maxIndex > TotalCount)
			{
				maxIndex = TotalCount;
			}

			for (int i = startIndex; i < maxIndex; i++)
			{
				this.Add(source[i]);
			}
		}
	}
}

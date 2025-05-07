using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dauros.StellarisREG.DAL
{
	public static class OrSetExtensions
	{
		/// <summary>
		/// Creates a HashSet<OrSet> with a single OrSet containing the given IEnumerable<string> values
		/// </summary>
		/// <param name="values"></param>
		/// <returns></returns>
		public static HashSet<OrSet> ToOrSet(this IEnumerable<string> values)
		{
			return new HashSet<OrSet> { new OrSet(values) };
		}
	}
}

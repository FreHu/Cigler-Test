using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml.Linq;

namespace Cigler_Telerik.Application.Ares
{
	public class XmlLoader
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="ic"></param>
		/// <returns>The XML document returned by ARES, stripped of namespace prefixes for easier parsing</returns>
		public static XDocument GetAresResponse(int ic)
		{
			try
			{
				var doc = XDocument.Load("http://wwwinfo.mfcr.cz/cgi-bin/ares/darv_std.cgi?ico=" + ic).ToString();
				//remove namespaces
				string regexStart = @"<(are|D|dtt):";
				string regexEnd = @"</(are|D|dtt):";
				doc = Regex.Replace(doc, regexStart, "<");
				doc = Regex.Replace(doc, regexEnd, "</");

				return XDocument.Parse(doc);
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}
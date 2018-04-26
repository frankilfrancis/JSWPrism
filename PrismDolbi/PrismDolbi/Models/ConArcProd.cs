using PrismDolbi.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismDolbi.Models
{
	public class ConArcProd : TableData
	{
		public int INDEX { get; set; }

		public int? SHOW_INDEX { get; set; }

		public string AREA { get; set; }

		public string SUB_AREA { get; set; }

		public string PARAMETER { get; set; }

		public string UNIT { get; set; }

		public string DATE_TIME { get; set; }

		public Double? SHELL_1 { get; set; }

		public Double? SHELL_2 { get; set; }

		public Double? SHELL_3 { get; set; }

		public Double? SHELL_4 { get; set; }

		public Double TOTAL_SHELL { get; set; }

		public string COMMENTS { get; set; }

		public string PRE_DATE { get; set; }

		public Double? PRE_SHEEL_1 { get; set; }

		public Double? PRE_SHEEL_2 { get; set; }

		public Double? PRE_SHEEL_3 { get; set; }

		public Double? PRE_SHEEL_4 { get; set; }

		public Double? PRE_TOTAL_SHEEL { get; set; }

		public Double? Till_SHELL_1 { get; set; }

		public Double? Till_SHELL_2 { get; set; }

		public Double? Till_SHELL_3 { get; set; }

		public Double? Till_SHELL_4 { get; set; }

		public Double? Till_TOTAL_SHELL { get; set; }

		public string COMMENT_1 { get; set; }

		public string COMMENT_2 { get; set; }

		public string COMMENT_3 { get; set; }
	}
}

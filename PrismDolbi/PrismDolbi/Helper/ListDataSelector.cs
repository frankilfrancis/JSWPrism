using PrismDolbi.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrismDolbi.Helper
{
	public class ListDataSelector : DataTemplateSelector
	{
		public DataTemplate ProcessParameter { get; set; }

		public DataTemplate ProcessHeader { get; set; }

		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			//return ((ConArcProd)item).SUB_AREA.ToUpper().Equals("HEADER") ? ProcessHeader : ProcessParameter; 
			return ((ConArcProd)item).INDEX.Equals(0) ? ProcessHeader : ProcessParameter;
		}
	}
}

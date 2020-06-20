using System;
using Xamarin.Forms;
namespace IGTOOLS
{
	public partial class Mass_like
	{
		internal Entry username;
		internal Entry jumlah;
		internal StackLayout result;
		void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Mass_like));
				username = (Entry)this.FindByName("username");
				jumlah = (Entry)this.FindByName("jumlah");
				result = (StackLayout)this.FindByName("result");
		}
	}
}

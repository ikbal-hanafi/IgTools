using System;
using Xamarin.Forms;
namespace IGTOOLS
{
	public partial class Mass_coment
	{
		internal Entry username;
		internal Entry jumlah;
		internal Editor komentar;
		internal StackLayout result;
		void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Mass_coment));
				username = (Entry)this.FindByName("username");
				jumlah = (Entry)this.FindByName("jumlah");
				komentar = (Editor)this.FindByName("komentar");
				result = (StackLayout)this.FindByName("result");
		}
	}
}

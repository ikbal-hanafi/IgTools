using System;
using Xamarin.Forms;
namespace IGTOOLS
{
	public partial class Login
	{
		internal Editor KukiMu;
		void InitializeComponent()
		{
			Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Login));
				KukiMu = (Editor)this.FindByName("KukiMu");
		}
	}
}

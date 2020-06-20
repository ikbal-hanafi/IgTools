using System;
using System.IO;
using Xamarin.Forms;

namespace IGTOOLS
{
	public partial class App_ : Application
	{
		public App_()
		{
			
			InitializeComponent();
			MainPage = new NavigationPage(new Login());
		}
	}
}
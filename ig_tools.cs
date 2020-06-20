using System;
using System.IO;

namespace IGTOOLS
{
	public class ig_tools {
		public static void Main(string[] args){
			
			Ui.RunOnUiThread(() => Ui.LoadApplication(new App_()));
		}
	}
}
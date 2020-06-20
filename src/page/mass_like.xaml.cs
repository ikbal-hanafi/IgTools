using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace IGTOOLS
{
	public partial class Mass_like : ContentPage
	{
		public Mass_like()
		{
			InitializeComponent();
		}
		
		async void GassCok(object sender, EventArgs args){
			Button btn = sender as Button;
			int j;
			try{
				j = int.Parse(jumlah.Text);
			}catch(Exception){
				jumlah.Text = "0";
				j = 0;
			}
			
			string u = (string)username.Text;
			
			if(string.IsNullOrEmpty(u)){
				Toast.MakeText("jangan kasi' kosong :) ", ToastLength.Short).Show();
			
			}else{
				if(j > 500){
					Toast.MakeText("jumlah maxsimum 500", ToastLength.Short).Show();
				}else{
					btn.IsEnabled =false;
					
					JObject data = await Api_.getPosts(u, j);
					foreach(JObject l in data["data"]["user"]["edge_owner_to_timeline_media"]["edges"]){
						string id = (string)l["node"]["id"].ToString();
						JObject rs = await Api_.like(id);
						result.Children.Add(new Label{
							Text = (string)rs.ToString(),
							TextColor = Color.LightGreen
						});
					}
					
					
					
					btn.IsEnabled =true;
				}
			}
		}
	}
}
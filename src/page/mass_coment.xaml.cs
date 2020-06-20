using System;
using System.IO;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace IGTOOLS
{
	public partial class Mass_coment : ContentPage
	{
		public Mass_coment()
		{
			InitializeComponent();
		}
		async void GassCok(object sender, EventArgs args){
			Button btn = sender as Button;
			string u = (string)username.Text;
			int j;
			try{
				j = int.Parse(jumlah.Text);
			}catch(Exception){
				j = 0;
				jumlah.Text="0";
			}
			string k = (string)komentar.Text;
			if(string.IsNullOrEmpty(u)){
				Toast.MakeText("jangan kasi' kosong :)", ToastLength.Short).Show();
			}else{
				if(j > 500){
					Toast.MakeText("maksimum 500 :)").Show();
				}else{
					btn.IsEnabled = false;
					JObject data = await Api_.getPosts(u, j);
					foreach(JObject l in data["data"]["user"]["edge_owner_to_timeline_media"]["edges"]){
						string id = (string)l["node"]["id"].ToString();
						JObject r = await Api_.coment(k, id);
						result.Children.Add(new Label{
							Text = (string)r.ToString(),
							TextColor = Color.LightGreen
						});
					}
					btn.IsEnabled = true;
					
				}
			}
		}
	}
}
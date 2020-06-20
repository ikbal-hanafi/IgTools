using System;
using System.IO;
using Xamarin.Forms;

namespace IGTOOLS
{
	
	public partial class Login : ContentPage
	{
		public Login()
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();
			
		}
		async void BantuangLogin(object sender, EventArgs args){
			await DisplayAlert("bantuang", "Jalangkan http canary (download di PS) , Buka browser chrome dan masuk ke instagram.com jika akun anda sudah loging silahkan logout dan loging kembali kalau tidak pernah loging silahkan loging langsung mengunakan akun yang mau di ambil cookiesnya setelah selesai loging , masuk ke http canary buka menu drawer tekan pada bagian history dan cari list yang bertuliskan method: POST carilah cookies pada bagian headersnya trus copy dan pastekan ke sini dan tekan tombol CHECK untuk men check apa cookies anda valid atau tidak.",  "OK");
		}
	    async void CheckKuki(object sender, EventArgs args) {
			string kuki = (string)KukiMu.Text;
			if(!string.IsNullOrWhiteSpace(kuki)){
				if(await Api_.CheckKuki(kuki)){
					
				   Navigation.PushAsync(new Mater());
				   Navigation.RemovePage(this);
				}
				else Toast.MakeText("cookie kadaluarsa", ToastLength.Short).Show();
			}else Toast.MakeText("Jangan dikasi' kosong :)", ToastLength.Short).Show();
		}
	}
}
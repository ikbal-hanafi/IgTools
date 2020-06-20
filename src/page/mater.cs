using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Xamarin.Forms;

namespace IGTOOLS
{
	public class Template{
		public string Item {get; set;}
	}


    public partial class Mater:MasterDetailPage
    {
           public Mater(){
           	
              	NavigationPage.SetHasNavigationBar(this, false);
				Master = new MasterPage(this);
              	Detail = new NavigationPage(new Mass_coment());
              	
           }
    }
    public class MasterPage:ContentPage {
    	private MasterDetailPage mdpl;
    	
    	public MasterPage(MasterDetailPage mdpl ){
    		
    		
    		this.mdpl = mdpl;
    		
    		StackLayout stck = new StackLayout{
    			Children={
    				new Frame{
    					HeightRequest=200,
    					BackgroundColor=Color.FromRgba(0,0,0,0.1),
    					Content=new StackLayout{
    						Children = {
    							new Image{
		    						Source=ImageSource.FromFile("assets/images/logo.png")
		    					},
		    					new Label{
		    						Text = "by: Muhammad Ikbal",
		    						HorizontalOptions=LayoutOptions.StartAndExpand,
		    						VerticalOptions=LayoutOptions.EndAndExpand,
		    					}
    						}
    					}
    				}
    			}
    			
    		};
    		List<Template> list_menu = new List<Template>(){
    			new Template(){Item = "MASS SPAM COMENT POST"},
    			new Template(){Item = "MASS LIKE POST"},
    			new Template(){Item = "ABOUT"}
    		};
    		
    		ListView lw = new ListView();
    		
    		lw.ItemTemplate = new DataTemplate(typeof(TextCell));
    		lw.ItemTemplate.SetBinding(TextCell.TextProperty,"Item");
    		lw.ItemsSource = list_menu;
    		lw.ItemSelected += (sender, args) => {
    			string item_s_t = ((Template)args.SelectedItem).Item;
    			switch(item_s_t){
    				case "MASS SPAM COMENT POST":
    					mdpl.Detail = new NavigationPage(new Mass_coment());
    					break;
    				case "MASS LIKE POST":
    					mdpl.Detail = new NavigationPage(new Mass_like());
    					break;
    				case "ABOUT":
    					mdpl.Detail = new NavigationPage(new About());
    					break;
    				default:
    					break;
    			}
    		};
    		
    		
    		stck.Children.Add(lw);
    		Content = stck;
    		
    		Title="ok";
    	}
    }
    

}
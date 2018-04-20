using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VRMLColorPicker
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		char decSep;
		public MainWindow()
		{
			InitializeComponent();
			decSep = Convert.ToChar(CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator);
			decSep = ',';
			PastedCodeInVRMLtb.Text = "";
		}

		private void Check_OnClick(object sender, RoutedEventArgs e)
		{
			if (PastedCodeInVRMLtb.Text != "")
			{
				try
				{
					var str = PastedCodeInVRMLtb.Text;
					str = str.Replace(',', decSep);
					str = str.Replace('.', decSep);
					var rgb = str.Split(' ');
					var R = Convert.ToByte(Convert.ToSingle(rgb[0])*255);
					var G = Convert.ToByte(Convert.ToSingle(rgb[1])*255);
					var B = Convert.ToByte(Convert.ToSingle(rgb[2])*255);
					var color = Color.FromRgb(R,G,B);
					ConvertFromVRMLbtn.Background = new SolidColorBrush(color);
					var tstr = "rgb(" + R + "," + G + "," + B + ")";
					ConvertFromVRMLbtn.Content = tstr;
					frame1.Background = new SolidColorBrush(color);
				}
				catch (Exception)
				{
					throw;
				}
			}
		}

		private void PastedCodetb_GotFocus(object sender, RoutedEventArgs e)
		{
			PastedCodeInRGBtb.Text = "";
			PastedCodeInVRMLtb.Text = "";
		}

		private void Get_Color_in_VRML_format_Click(object sender, RoutedEventArgs e)
		{
			if (PastedCodeInRGBtb.Text != "")
			{
				try
				{
					var str = PastedCodeInRGBtb.Text;
					str = str.Replace("rgb(", "");
					str = str.Replace(")", "");
					var rgb = str.Split(',');
					var R = Convert.ToByte(rgb[0]);
					var G = Convert.ToByte(rgb[1]);
					var B = Convert.ToByte(rgb[2]);
					var color = Color.FromRgb(R, G, B);
					ConvertFromRGBbtn.Background = new SolidColorBrush(color);
					frame1.Background = new SolidColorBrush(color);
					 
					var x = Math.Round(Convert.ToSingle(R / 255.0),2).ToString().Replace(',','.');
					var y = Math.Round(Convert.ToSingle(G / 255.0),2).ToString().Replace(',','.');
					var z = Math.Round(Convert.ToSingle(B / 255.0),2).ToString().Replace(',','.');
					
					var tstr = x + " " + y + " " + z;
					ConvertFromRGBbtn.Content = tstr;
				}
				catch (Exception)
				{
					throw;
				}
			}

		}
	}
}

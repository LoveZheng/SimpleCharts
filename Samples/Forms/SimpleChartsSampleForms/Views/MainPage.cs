﻿using System;

using Xamarin.Forms;
using SimpleChartsSampleForms.Views;

namespace SimpleChartsSampleForms
{
	public class MainPage : TabbedPage
	{
		public MainPage()
		{
			var lin = new SimpleCharts.Forms.LineChart();
			Page itemsPage, aboutPage = null;

			switch (Device.RuntimePlatform)
			{
				case Device.iOS:
					itemsPage = new NavigationPage(new GraphsPage())
					{
						Title = "Browse"
					};

					aboutPage = new NavigationPage(new AboutPage())
					{
						Title = "About"
					};
					itemsPage.Icon = "tab_feed.png";
					aboutPage.Icon = "tab_about.png";
					break;
				default:
					itemsPage = new GraphsPage()
					{
						Title = "Browse"
					};

					aboutPage = new AboutPage()
					{
						Title = "About"
					};
					break;
			}

			Children.Add(itemsPage);
			Children.Add(aboutPage);

			Title = Children[0].Title;
		}

		protected override void OnCurrentPageChanged()
		{
			base.OnCurrentPageChanged();
			Title = CurrentPage?.Title ?? string.Empty;
		}
	}
}
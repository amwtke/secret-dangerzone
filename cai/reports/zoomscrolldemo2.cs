using System;
using ChartDirector;

namespace CSharpChartExplorer
{
	public class zoomscrolldemo2 : DemoModule
	{
		//Name of demo module
		public string getName() { return "Zooming and Scrolling (2)"; }

		//Number of charts produced in this demo module
		public int getNoOfCharts() 
		{ 
			return 1;
		}

		//Main code for creating chart.
		public void createChart(WinChartViewer viewer, string img)
		{
			//This demo uses its own form. The viewer on the right pane is not used.
			viewer.Image = null;
			System.Windows.Forms.Form f = new FrmZoomScrollDemo2();
			f.ShowDialog();
			f.Dispose();
		}
	}
}

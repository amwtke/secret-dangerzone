using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class colorbar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Multi-Color Bar Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the bar chart
            double[] data = {85, 156, 179.5, 211, 123};

            // The labels for the bar chart
            string[] labels = {"Mon", "Tue", "Wed", "Thu", "Fri"};

            // The colors for the bar chart
            int[] colors = {0xb8bc9c, 0xa0bdc4, 0x999966, 0x333366, 0xc3c3e6};

            // Create a XYChart object of size 300 x 220 pixels. Use golden
            // background color. Use a 2 pixel 3D border.
            XYChart c = new XYChart(300, 220, Chart.goldColor(), -1, 2);

            // Add a title box using 10 point Arial Bold font. Set the background
            // color to metallic blue (9999FF) Use a 1 pixel 3D border.
            c.addTitle("Daily Network Load", "Arial Bold", 10).setBackground(
                Chart.metalColor(0x9999ff), -1, 1);

            // Set the plotarea at (40, 40) and of 240 x 150 pixels in size
            c.setPlotArea(40, 40, 240, 150);

            // Add a multi-color bar chart layer using the given data and colors. Use
            // a 1 pixel 3D border for the bars.
            c.addBarLayer3(data, colors).setBorderColor(-1, 1);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{xLabel}: {value} GBytes'");
        }
    }
}


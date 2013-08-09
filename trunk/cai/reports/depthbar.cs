using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class depthbar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Depth Bar Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the bar chart
            double[] data0 = {100, 125, 245, 147, 67};
            double[] data1 = {85, 156, 179, 211, 123};
            double[] data2 = {97, 87, 56, 267, 157};

            // The labels for the bar chart
            string[] labels = {"Mon", "Tue", "Wed", "Thu", "Fri"};

            // Create a XYChart object of size 500 x 320 pixels
            XYChart c = new XYChart(500, 320);

            // Set the plotarea at (100, 40) and of size 280 x 240 pixels
            c.setPlotArea(100, 40, 280, 240);

            // Add a legend box at (405, 100)
            c.addLegend(405, 100);

            // Add a title to the chart
            c.addTitle("Weekday Network Load");

            // Add a title to the y axis. Draw the title upright (font angle = 0)
            c.yAxis().setTitle("Average\nWorkload\n(MBytes\nPer Hour)").setFontAngle(
                0);

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            // Add three bar layers, each representing one data set. The bars are
            // drawn in semi-transparent colors.
            c.addBarLayer(data0, unchecked((int)0x808080ff), "Server # 1", 5);
            c.addBarLayer(data1, unchecked((int)0x80ff0000), "Server # 2", 5);
            c.addBarLayer(data2, unchecked((int)0x8000ff00), "Server # 3", 5);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{dataSetName} on {xLabel}: {value} MBytes/hour'");
        }
    }
}


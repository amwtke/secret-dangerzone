using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class stackedbar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Stacked Bar Chart"; }

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

            // Add a legend box at (400, 100)
            c.addLegend(400, 100);

            // Add a title to the chart using 14 points Times Bold Itatic font
            c.addTitle("Weekday Network Load", "Times New Roman Bold Italic", 14);

            // Add a title to the y axis. Draw the title upright (font angle = 0)
            c.yAxis().setTitle("Average\nWorkload\n(MBytes\nPer Hour)").setFontAngle(
                0);

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            // Add a stacked bar layer and set the layer 3D depth to 8 pixels
            BarLayer layer = c.addBarLayer2(Chart.Stack, 8);

            // Add the three data sets to the bar layer
            layer.addDataSet(data0, 0xff8080, "Server # 1");
            layer.addDataSet(data1, 0x80ff80, "Server # 2");
            layer.addDataSet(data2, 0x8080ff, "Server # 3");

            // Enable bar label for the whole bar
            layer.setAggregateLabelStyle();

            // Enable bar label for each segment of the stacked bar
            layer.setDataLabelStyle();

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{dataSetName} on {xLabel}: {value} MBytes/hour'");
        }
    }
}


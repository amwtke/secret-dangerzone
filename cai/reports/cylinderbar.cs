using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class cylinderbar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Cylinder Bar Shape"; }

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

            // Create a XYChart object of size 400 x 240 pixels.
            XYChart c = new XYChart(400, 240);

            // Add a title to the chart using 14 pts Times Bold Italic font
            c.addTitle("Weekly Server Load", "Times New Roman Bold Italic", 14);

            // Set the plotarea at (45, 40) and of 300 x 160 pixels in size. Use
            // alternating light grey (f8f8f8) / white (ffffff) background.
            c.setPlotArea(45, 40, 300, 160, 0xf8f8f8, 0xffffff);

            // Add a multi-color bar chart layer
            BarLayer layer = c.addBarLayer3(data);

            // Set layer to 3D with 10 pixels 3D depth
            layer.set3D(10);

            // Set bar shape to circular (cylinder)
            layer.setBarShape(Chart.CircleShape);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            // Add a title to the y axis
            c.yAxis().setTitle("MBytes");

            // Add a title to the x axis
            c.xAxis().setTitle("Work Week 25");

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{xLabel}: {value} MBytes'");
        }
    }
}


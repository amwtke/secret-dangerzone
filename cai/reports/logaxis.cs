using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class logaxis : DemoModule
    {
        //Name of demo module
        public string getName() { return "Log Scale Axis"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 2; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the chart
            double[] data = {100, 125, 260, 147, 67};
            string[] labels = {"Mon", "Tue", "Wed", "Thu", "Fri"};

            // Create a XYChart object of size 200 x 180 pixels
            XYChart c = new XYChart(200, 180);

            // Set the plot area at (30, 10) and of size 140 x 130 pixels
            c.setPlotArea(30, 10, 140, 130);

            // Ise log scale axis if required
            if (img == "1") {
                c.yAxis().setLogScale3();
            }

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            // Add a color bar layer using the given data. Use a 1 pixel 3D border
            // for the bars.
            c.addBarLayer3(data).setBorderColor(-1, 1);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Mileage on {xLabel}: {value} miles'");
        }
    }
}


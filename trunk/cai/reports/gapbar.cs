using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class gapbar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Bar Gap"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 6; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            double bargap = int.Parse(img) * 0.25 - 0.25;

            // The data for the bar chart
            double[] data = {100, 125, 245, 147, 67};

            // The labels for the bar chart
            string[] labels = {"Mon", "Tue", "Wed", "Thu", "Fri"};

            // Create a XYChart object of size 150 x 150 pixels
            XYChart c = new XYChart(150, 150);

            // Set the plotarea at (27, 20) and of size 120 x 100 pixels
            c.setPlotArea(27, 20, 120, 100);

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            if (bargap >= 0) {
                // Add a title to display to bar gap using 8 pts Arial font
                c.addTitle("      Bar Gap = " + bargap, "Arial", 8);
            } else {
                // Use negative value to mean TouchBar
                c.addTitle("      Bar Gap = TouchBar", "Arial", 8);
                bargap = Chart.TouchBar;
            }

            // Add a bar chart layer using the given data and set the bar gap
            c.addBarLayer(data).setBarGap(bargap);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Production on {xLabel}: {value} kg'");
        }
    }
}


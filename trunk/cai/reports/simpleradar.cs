using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class simpleradar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Simple Radar Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the chart
            double[] data = {90, 60, 65, 75, 40};

            // The labels for the chart
            string[] labels = {"Speed", "Reliability", "Comfort", "Safety",
                "Efficiency"};

            // Create a PolarChart object of size 450 x 350 pixels
            PolarChart c = new PolarChart(450, 350);

            // Set center of plot area at (225, 185) with radius 150 pixels
            c.setPlotArea(225, 185, 150);

            // Add an area layer to the polar chart
            c.addAreaLayer(data, 0x9999ff);

            // Set the labels to the angular axis as spokes
            c.angularAxis().setLabels(labels);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: score = {value}'");
        }
    }
}


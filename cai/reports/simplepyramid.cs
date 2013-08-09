using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class simplepyramid : DemoModule
    {
        //Name of demo module
        public string getName() { return "Simple Pyramid Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pyramid chart
            double[] data = {156, 123, 211, 179};

            // The labels for the pyramid chart
            string[] labels = {"Funds", "Bonds", "Stocks", "Cash"};

            // Create a PyramidChart object of size 360 x 360 pixels
            PyramidChart c = new PyramidChart(360, 360);

            // Set the pyramid center at (180, 180), and width x height to 150 x 180
            // pixels
            c.setPyramidSize(180, 180, 150, 300);

            // Set the pyramid data and labels
            c.setData(data, labels);

            // Add labels at the center of the pyramid layers using Arial Bold font.
            // The labels will have two lines showing the layer name and percentage.
            c.setCenterLabel("{label}\n{percent}%", "Arial Bold");

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: US$ {value}M ({percent}%)'");
        }
    }
}


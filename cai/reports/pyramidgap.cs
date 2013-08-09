using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class pyramidgap : DemoModule
    {
        //Name of demo module
        public string getName() { return "Pyramid Gap"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 6; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pyramid chart
            double[] data = {156, 123, 211, 179};

            // The colors for the pyramid layers
            int[] colors = {0x66aaee, 0xeebb22, 0xcccccc, 0xcc88ff};

            // The layer gap
            double gap = int.Parse(img) * 0.01;

            // Create a PyramidChart object of size 200 x 200 pixels, with white
            // (ffffff) background and grey (888888) border
            PyramidChart c = new PyramidChart(200, 200, 0xffffff, 0x888888);

            // Set the pyramid center at (100, 100), and width x height to 60 x 120
            // pixels
            c.setPyramidSize(100, 100, 60, 120);

            // Set the layer gap
            c.addTitle("Gap = " + gap, "Arial Italic", 15);
            c.setLayerGap(gap);

            // Set the elevation to 15 degrees
            c.setViewAngle(15);

            // Set the pyramid data
            c.setData(data);

            // Set the layer colors to the given colors
            c.setColors2(Chart.DataColor, colors);

            // Output the chart
            viewer.Image = c.makeImage();
        }
    }
}


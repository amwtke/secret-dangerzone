using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class pyramidelevation : DemoModule
    {
        //Name of demo module
        public string getName() { return "Pyramid Elevation"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 7; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pyramid chart
            double[] data = {156, 123, 211, 179};

            // The colors for the pyramid layers
            int[] colors = {0x66aaee, 0xeebb22, 0xcccccc, 0xcc88ff};

            // The elevation angle
            int angle = int.Parse(img) * 15;

            // Create a PyramidChart object of size 200 x 200 pixels, with white
            // (ffffff) background and grey (888888) border
            PyramidChart c = new PyramidChart(200, 200, 0xffffff, 0x888888);

            // Set the pyramid center at (100, 100), and width x height to 60 x 120
            // pixels
            c.setPyramidSize(100, 100, 60, 120);

            // Set the elevation angle
            c.addTitle("Elevation = " + angle, "Arial Italic", 15);
            c.setViewAngle(angle);

            // Set the pyramid data
            c.setData(data);

            // Set the layer colors to the given colors
            c.setColors2(Chart.DataColor, colors);

            // Leave 1% gaps between layers
            c.setLayerGap(0.01);

            // Output the chart
            viewer.Image = c.makeImage();
        }
    }
}


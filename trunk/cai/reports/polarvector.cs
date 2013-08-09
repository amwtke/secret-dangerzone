using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class polarvector : DemoModule
    {
        //Name of demo module
        public string getName() { return "Polar Vector Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // Coordinates of the starting points of the vectors
            double[] radius = {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 10, 10, 10, 10,
                10, 10, 10, 10, 10, 10, 10, 10, 15, 15, 15, 15, 15, 15, 15, 15, 15,
                15, 15, 15, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 25, 25,
                25, 25, 25, 25, 25, 25, 25, 25, 25, 25};
            double[] angle = {0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330,
                0, 30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 0, 30, 60, 90,
                120, 150, 180, 210, 240, 270, 300, 330, 0, 30, 60, 90, 120, 150, 180,
                210, 240, 270, 300, 330, 0, 30, 60, 90, 120, 150, 180, 210, 240, 270,
                300, 330};

            // Magnitude and direction of the vectors
            double[] magnitude = {5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 4, 4, 4, 4, 4,
                4, 4, 4, 4, 4, 4, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 2, 2, 2, 2,
                2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            double[] direction = {60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 0,
                30, 60, 90, 120, 150, 180, 210, 240, 270, 300, 330, 0, 30, 60, 90,
                120, 150, 180, 210, 240, 270, 300, 330, 0, 30, 60, 90, 120, 150, 180,
                210, 240, 270, 300, 330, 0, 30, 60, 90, 120, 150, 180, 210, 240, 270,
                300, 330, 0, 30};

            // Create a PolarChart object of size 460 x 460 pixels
            PolarChart c = new PolarChart(460, 460);

            // Add a title to the chart at the top left corner using 15pts Arial Bold
            // Italic font
            c.addTitle("Polar Vector Chart Demonstration", "Arial Bold Italic", 15);

            // Set center of plot area at (230, 240) with radius 180 pixels
            c.setPlotArea(230, 240, 180);

            // Set the grid style to circular grid
            c.setGridStyle(false);

            // Set angular axis as 0 - 360, with a spoke every 30 units
            c.angularAxis().setLinearScale(0, 360, 30);

            // Add a polar vector layer to the chart with blue (0000ff) vectors
            c.addVectorLayer(radius, angle, magnitude, direction,
                Chart.RadialAxisScale, 0x0000ff);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Vector at ({value}, {angle} deg): Length = {len}, Angle = " +
                "{dir} deg'");
        }
    }
}


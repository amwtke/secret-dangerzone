using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class contour : DemoModule
    {
        //Name of demo module
        public string getName() { return "Contour Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The x and y coordinates of the grid
            double[] dataX = {-10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4,
                5, 6, 7, 8, 9, 10};
            double[] dataY = {-10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4,
                5, 6, 7, 8, 9, 10};

            // The values at the grid points. In this example, we will compute the
            // values using the formula z = x * sin(y) + y * sin(x).
            double[] dataZ = new double[(dataX.Length) * (dataY.Length)];
            for(int yIndex = 0; yIndex < dataY.Length; ++yIndex) {
                double y = dataY[yIndex];
                for(int xIndex = 0; xIndex < dataX.Length; ++xIndex) {
                    double x = dataX[xIndex];
                    dataZ[yIndex * (dataX.Length) + xIndex] = x * Math.Sin(y) + y *
                        Math.Sin(x);
                }
            }

            // Create a XYChart object of size 600 x 500 pixels
            XYChart c = new XYChart(600, 500);

            // Add a title to the chart using 15 points Arial Bold Italic font
            c.addTitle("z = x * sin(y) + y * sin(x)      ", "Arial Bold Italic", 15);

            // Set the plotarea at (75, 40) and of size 400 x 400 pixels. Use
            // semi-transparent black (80000000) dotted lines for both horizontal and
            // vertical grid lines
            c.setPlotArea(75, 40, 400, 400, -1, -1, -1, c.dashLineColor(
                unchecked((int)0x80000000), Chart.DotLine), -1);

            // Set x-axis and y-axis title using 12 points Arial Bold Italic font
            c.xAxis().setTitle("X-Axis Title Place Holder", "Arial Bold Italic", 12);
            c.yAxis().setTitle("Y-Axis Title Place Holder", "Arial Bold Italic", 12);

            // Set x-axis and y-axis labels to use Arial Bold font
            c.xAxis().setLabelStyle("Arial Bold");
            c.yAxis().setLabelStyle("Arial Bold");

            // When auto-scaling, use tick spacing of 40 pixels as a guideline
            c.yAxis().setTickDensity(40);
            c.xAxis().setTickDensity(40);

            // Add a contour layer using the given data
            ContourLayer layer = c.addContourLayer(dataX, dataY, dataZ);

            // Move the grid lines in front of the contour layer
            c.getPlotArea().moveGridBefore(layer);

            // Add a color axis (the legend) in which the top left corner is anchored
            // at (505, 40). Set the length to 400 pixels and the labels on the right
            // side.
            ColorAxis cAxis = layer.setColorAxis(505, 40, Chart.TopLeft, 400,
                Chart.Right);

            // Add a title to the color axis using 12 points Arial Bold Italic font
            cAxis.setTitle("Color Legend Title Place Holder", "Arial Bold Italic", 12
                );

            // Set color axis labels to use Arial Bold font
            cAxis.setLabelStyle("Arial Bold");

            // Output the chart
            viewer.Image = c.makeImage();
        }
    }
}


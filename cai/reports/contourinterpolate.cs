using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class contourinterpolate : DemoModule
    {
        //Name of demo module
        public string getName() { return "Contour Interpolation"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 4; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The x and y coordinates of the grid
            double[] dataX = {-4, -3, -2, -1, 0, 1, 2, 3, 4};
            double[] dataY = {-4, -3, -2, -1, 0, 1, 2, 3, 4};

            // The values at the grid points. In this example, we will compute the
            // values using the formula z = Sin(x * pi / 3) * Sin(y * pi / 3).
            double[] dataZ = new double[(dataX.Length) * (dataY.Length)];
            for(int yIndex = 0; yIndex < dataY.Length; ++yIndex) {
                double y = dataY[yIndex];
                for(int xIndex = 0; xIndex < dataX.Length; ++xIndex) {
                    double x = dataX[xIndex];
                    dataZ[yIndex * (dataX.Length) + xIndex] = Math.Sin(x * 3.1416 / 3
                        ) * Math.Sin(y * 3.1416 / 3);
                }
            }

            // Create a XYChart object of size 360 x 360 pixels
            XYChart c = new XYChart(360, 360);

            // Set the plotarea at (30, 25) and of size 300 x 300 pixels. Use
            // semi-transparent black (c0000000) for both horizontal and vertical
            // grid lines
            c.setPlotArea(30, 25, 300, 300, -1, -1, -1, unchecked((int)0xc0000000),
                -1);

            // Add a contour layer using the given data
            ContourLayer layer = c.addContourLayer(dataX, dataY, dataZ);

            // Set the x-axis and y-axis scale
            c.xAxis().setLinearScale(-4, 4, 1);
            c.yAxis().setLinearScale(-4, 4, 1);

            if (img == "0") {
                // Discrete coloring, spline surface interpolation
                c.addTitle("Spline Surface - Discrete Coloring", "Arial Bold Italic",
                    12);
            } else if (img == "1") {
                // Discrete coloring, linear surface interpolation
                c.addTitle("Linear Surface - Discrete Coloring", "Arial Bold Italic",
                    12);
                layer.setSmoothInterpolation(false);
            } else if (img == "2") {
                // Smooth coloring, spline surface interpolation
                c.addTitle("Spline Surface - Continuous Coloring",
                    "Arial Bold Italic", 12);
                layer.setContourColor(Chart.Transparent);
                layer.colorAxis().setColorGradient(true);
            } else {
                // Discrete coloring, linear surface interpolation
                c.addTitle("Linear Surface - Continuous Coloring",
                    "Arial Bold Italic", 12);
                layer.setSmoothInterpolation(false);
                layer.setContourColor(Chart.Transparent);
                layer.colorAxis().setColorGradient(true);
            }

            // Output the chart
            viewer.Image = c.makeImage();
        }
    }
}


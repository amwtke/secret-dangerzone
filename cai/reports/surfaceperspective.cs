using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class surfaceperspective : DemoModule
    {
        //Name of demo module
        public string getName() { return "Surface Perspective"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 6; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The x and y coordinates of the grid
            double[] dataX = {0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0};
            double[] dataY = {0, 0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0};

            // The values at the grid points. In this example, we will compute the
            // values using the formula z = sin((x - 0.5) * 2 * pi) * sin((y - 0.5) *
            // 2 * pi)
            double[] dataZ = new double[(dataX.Length) * (dataY.Length)];
            for(int yIndex = 0; yIndex < dataY.Length; ++yIndex) {
                double y = (dataY[yIndex] - 0.5) * 2 * 3.1416;
                for(int xIndex = 0; xIndex < dataX.Length; ++xIndex) {
                    double x = (dataX[xIndex] - 0.5) * 2 * 3.1416;
                    dataZ[yIndex * (dataX.Length) + xIndex] = Math.Sin(x) * Math.Sin(
                        y);
                }
            }

            // the perspective level
            int perspective = int.Parse(img) * 12;

            // Create a SurfaceChart object of size 360 x 360 pixels, with white
            // (ffffff) background and grey (888888) border.
            SurfaceChart c = new SurfaceChart(360, 360, 0xffffff, 0x888888);

            // Set the perspective level
            c.setPerspective(perspective);
            c.addTitle("Perspective = " + perspective);

            // Set the center of the plot region at (195, 165), and set width x depth
            // x height to 200 x 200 x 150 pixels
            c.setPlotRegion(195, 165, 200, 200, 150);

            // Set the plot region wall thichness to 5 pixels
            c.setWallThickness(5);

            // Set the elevation and rotation angles to 30 and 30 degrees
            c.setViewAngle(30, 30);

            // Set the data to use to plot the chart
            c.setData(dataX, dataY, dataZ);

            // Spline interpolate data to a 40 x 40 grid for a smooth surface
            c.setInterpolation(40, 40);

            // Use smooth gradient coloring.
            c.colorAxis().setColorGradient();

            // Output the chart
            viewer.Image = c.makeImage();
        }
    }
}


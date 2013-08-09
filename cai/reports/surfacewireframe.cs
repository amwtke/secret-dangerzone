using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class surfacewireframe : DemoModule
    {
        //Name of demo module
        public string getName() { return "Surface Wireframe"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 6; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The x and y coordinates of the grid
            double[] dataX = {-2, -1, 0, 1, 2};
            double[] dataY = {-2, -1, 0, 1, 2};

            // The values at the grid points. In this example, we will compute the
            // values using the formula z = square_root(15 - x * x - y * y).
            double[] dataZ = new double[(dataX.Length) * (dataY.Length)];
            for(int yIndex = 0; yIndex < dataY.Length; ++yIndex) {
                double y = dataY[yIndex];
                for(int xIndex = 0; xIndex < dataX.Length; ++xIndex) {
                    double x = dataX[xIndex];
                    dataZ[yIndex * (dataX.Length) + xIndex] = Math.Sqrt(15 - x * x -
                        y * y);
                }
            }

            // Create a SurfaceChart object of size 380 x 340 pixels, with white
            // (ffffff) background and grey (888888) border.
            SurfaceChart c = new SurfaceChart(380, 340, 0xffffff, 0x888888);

            // Demonstrate various wireframes with and without interpolation
            if (img == "0") {
                // Original data without interpolation
                c.addTitle("5 x 5 Data Points\nStandard Shading", "Arial Bold", 12);
                c.setContourColor(unchecked((int)0x80ffffff));
            } else if (img == "1") {
                // Original data, spline interpolated to 40 x 40 for smoothness
                c.addTitle(
                    "5 x 5 Points - Spline Fitted to 40 x 40\nStandard Shading",
                    "Arial Bold", 12);
                c.setContourColor(unchecked((int)0x80ffffff));
                c.setInterpolation(40, 40);
            } else if (img == "2") {
                // Rectangular wireframe of original data
                c.addTitle("5 x 5 Data Points\nRectangular Wireframe");
                c.setShadingMode(Chart.RectangularFrame);
            } else if (img == "3") {
                // Rectangular wireframe of original data spline interpolated to 40 x
                // 40
                c.addTitle(
                    "5 x 5 Points - Spline Fitted to 40 x 40\nRectangular Wireframe")
                    ;
                c.setShadingMode(Chart.RectangularFrame);
                c.setInterpolation(40, 40);
            } else if (img == "4") {
                // Triangular wireframe of original data
                c.addTitle("5 x 5 Data Points\nTriangular Wireframe");
                c.setShadingMode(Chart.TriangularFrame);
            } else {
                // Triangular wireframe of original data spline interpolated to 40 x
                // 40
                c.addTitle(
                    "5 x 5 Points - Spline Fitted to 40 x 40\nTriangular Wireframe");
                c.setShadingMode(Chart.TriangularFrame);
                c.setInterpolation(40, 40);
            }

            // Set the center of the plot region at (200, 170), and set width x depth
            // x height to 200 x 200 x 150 pixels
            c.setPlotRegion(200, 170, 200, 200, 150);

            // Set the plot region wall thichness to 5 pixels
            c.setWallThickness(5);

            // Set the elevation and rotation angles to 20 and 30 degrees
            c.setViewAngle(20, 30);

            // Set the data to use to plot the chart
            c.setData(dataX, dataY, dataZ);

            // Output the chart
            viewer.Image = c.makeImage();
        }
    }
}


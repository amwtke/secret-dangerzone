using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class background : DemoModule
    {
        //Name of demo module
        public string getName() { return "Background and Wallpaper"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 4; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the chart
            double[] data = {85, 156, 179.5, 211, 123};
            string[] labels = {"Mon", "Tue", "Wed", "Thu", "Fri"};

            // Create a XYChart object of size 270 x 270 pixels
            XYChart c = new XYChart(270, 270);

            // Set the plot area at (40, 32) and of size 200 x 200 pixels
            PlotArea plotarea = c.setPlotArea(40, 32, 200, 200);

            // Set the background style based on the input parameter
            if (img == "0") {
                // Has wallpaper image
                c.setWallpaper("tile.gif");
            } else if (img == "1") {
                // Use a background image as the plot area background
                plotarea.setBackground2("bg.png");
            } else if (img == "2") {
                // Use white (0xffffff) and grey (0xe0e0e0) as two alternate plotarea
                // background colors
                plotarea.setBackground(0xffffff, 0xe0e0e0);
            } else {
                // Use a dark background palette
                c.setColors(Chart.whiteOnBlackPalette);
            }

            // Set the labels on the x axis
            c.xAxis().setLabels(labels);

            // Add a color bar layer using the given data. Use a 1 pixel 3D border
            // for the bars.
            c.addBarLayer3(data).setBorderColor(-1, 1);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Revenue for {xLabel}: US${value}K'");
        }
    }
}


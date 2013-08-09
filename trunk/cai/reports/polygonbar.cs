using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class polygonbar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Polygon Bar Shapes"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the bar chart
            double[] data = {85, 156, 179.5, 211, 123, 176, 195};

            // The labels for the bar chart
            string[] labels = {"Square", "Star(8)", "Polygon(6)", "Cross", "Cross2",
                "Diamond", "Custom"};

            // Create a XYChart object of size 500 x 280 pixels.
            XYChart c = new XYChart(500, 280);

            // Set the plotarea at (50, 40) with alternating light grey (f8f8f8) /
            // white (ffffff) background
            c.setPlotArea(50, 40, 400, 200, 0xf8f8f8, 0xffffff);

            // Add a title to the chart using 14 pts Arial Bold Italic font
            c.addTitle("    Bar Shape Demonstration", "Arial Bold Italic", 14);

            // Add a multi-color bar chart layer
            BarLayer layer = c.addBarLayer3(data);

            // Set layer to 3D with 10 pixels 3D depth
            layer.set3D(10);

            // Set bar shape to circular (cylinder)
            layer.setBarShape(Chart.CircleShape);

            // Set the first bar (index = 0) to square shape
            layer.setBarShape(Chart.SquareShape, 0, 0);

            // Set the second bar to 8-pointed star
            layer.setBarShape(Chart.StarShape(8), 0, 1);

            // Set the third bar to 6-sided polygon
            layer.setBarShape(Chart.PolygonShape(6), 0, 2);

            // Set the next 3 bars to cross shape, X shape and diamond shape
            layer.setBarShape(Chart.CrossShape(), 0, 3);
            layer.setBarShape(Chart.Cross2Shape(), 0, 4);
            layer.setBarShape(Chart.DiamondShape, 0, 5);

            // Set the last bar to a custom shape, specified as an array of (x, y)
            // points in normalized coordinates
            layer.setBarShape2(new int[] {-500, 0, 0, 500, 500, 0, 500, 1000, 0, 500,
                -500, 1000}, 0, 6);

            // Set the labels on the x axis.
            c.xAxis().setLabels(labels);

            // Add a title to the y axis
            c.yAxis().setTitle("Frequency");

            // Add a title to the x axis
            c.xAxis().setTitle("Shapes");

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{xLabel}: {value}'");
        }
    }
}


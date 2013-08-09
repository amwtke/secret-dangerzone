using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class bubble : DemoModule
    {
        //Name of demo module
        public string getName() { return "Bubble Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The XYZ points for the bubble chart
            double[] dataX0 = {150, 300, 1000, 1700};
            double[] dataY0 = {12, 60, 25, 65};
            double[] dataZ0 = {20, 50, 50, 85};

            double[] dataX1 = {500, 1000, 1300};
            double[] dataY1 = {35, 50, 75};
            double[] dataZ1 = {30, 55, 95};

            // Create a XYChart object of size 450 x 420 pixels
            XYChart c = new XYChart(450, 420);

            // Set the plotarea at (55, 65) and of size 350 x 300 pixels, with a
            // light grey border (0xc0c0c0). Turn on both horizontal and vertical
            // grid lines with light grey color (0xc0c0c0)
            c.setPlotArea(55, 65, 350, 300, -1, -1, 0xc0c0c0, 0xc0c0c0, -1);

            // Add a legend box at (50, 30) (top of the chart) with horizontal
            // layout. Use 12 pts Times Bold Italic font. Set the background and
            // border color to Transparent.
            c.addLegend(50, 30, false, "Times New Roman Bold Italic", 12
                ).setBackground(Chart.Transparent);

            // Add a title to the chart using 18 pts Times Bold Itatic font.
            c.addTitle("Product Comparison Chart", "Times New Roman Bold Italic", 18)
                ;

            // Add a title to the y axis using 12 pts Arial Bold Italic font
            c.yAxis().setTitle("Capacity (tons)", "Arial Bold Italic", 12);

            // Add a title to the x axis using 12 pts Arial Bold Italic font
            c.xAxis().setTitle("Range (miles)", "Arial Bold Italic", 12);

            // Set the axes line width to 3 pixels
            c.xAxis().setWidth(3);
            c.yAxis().setWidth(3);

            // Add (dataX0, dataY0) as a scatter layer with semi-transparent red
            // (0x80ff3333) circle symbols, where the circle size is modulated by
            // dataZ0. This creates a bubble effect.
            c.addScatterLayer(dataX0, dataY0, "Technology AAA", Chart.CircleSymbol,
                9, unchecked((int)0x80ff3333), unchecked((int)0x80ff3333)
                ).setSymbolScale(dataZ0);

            // Add (dataX1, dataY1) as a scatter layer with semi-transparent green
            // (0x803333ff) circle symbols, where the circle size is modulated by
            // dataZ1. This creates a bubble effect.
            c.addScatterLayer(dataX1, dataY1, "Technology BBB", Chart.CircleSymbol,
                9, unchecked((int)0x803333ff), unchecked((int)0x803333ff)
                ).setSymbolScale(dataZ1);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='[{dataSetName}] Range = {x} miles, Capacity = {value} " +
                "tons, Length = {z} meters'");
        }
    }
}


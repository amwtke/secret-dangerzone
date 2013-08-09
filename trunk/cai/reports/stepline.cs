using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class stepline : DemoModule
    {
        //Name of demo module
        public string getName() { return "Step Line Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the chart
            double[] dataY0 = {4, 4.5, 5, 5.25, 5.75, 5.25, 5, 4.5, 4, 3, 2.5, 2.5};
            DateTime[] dataX0 = {new DateTime(1997, 1, 1), new DateTime(1998, 6, 25),
                new DateTime(1999, 9, 6), new DateTime(2000, 2, 6), new DateTime(
                2000, 9, 21), new DateTime(2001, 3, 4), new DateTime(2001, 6, 8),
                new DateTime(2002, 2, 4), new DateTime(2002, 5, 19), new DateTime(
                2002, 8, 16), new DateTime(2002, 12, 1), new DateTime(2003, 1, 1)};

            double[] dataY1 = {7, 6.5, 6, 5, 6.5, 7, 6, 5.5, 5, 4, 3.5, 3.5};
            DateTime[] dataX1 = {new DateTime(1997, 1, 1), new DateTime(1997, 7, 1),
                new DateTime(1997, 12, 1), new DateTime(1999, 1, 15), new DateTime(
                1999, 6, 9), new DateTime(2000, 3, 3), new DateTime(2000, 8, 13),
                new DateTime(2001, 5, 5), new DateTime(2001, 9, 16), new DateTime(
                2002, 3, 16), new DateTime(2002, 6, 1), new DateTime(2003, 1, 1)};

            // Create a XYChart object of size 500 x 270 pixels, with a pale blue
            // (e0e0ff) background, black border, 1 pixel 3D border effect and
            // rounded corners
            XYChart c = new XYChart(600, 300, 0xe0e0ff, 0x000000, 1);
            c.setRoundedFrame();

            // Set the plotarea at (55, 60) and of size 520 x 200 pixels, with white
            // (ffffff) background. Set horizontal and vertical grid lines to grey
            // (cccccc).
            c.setPlotArea(50, 60, 525, 200, 0xffffff, -1, -1, 0xcccccc, 0xcccccc);

            // Add a legend box at (55, 32) (top of the chart) with horizontal
            // layout. Use 9 pts Arial Bold font. Set the background and border color
            // to Transparent.
            c.addLegend(55, 32, false, "Arial Bold", 9).setBackground(
                Chart.Transparent);

            // Add a title box to the chart using 15 pts Times Bold Italic font. The
            // text is white (ffffff) on a deep blue (000088) background, with soft
            // lighting effect from the right side.
            c.addTitle("Long Term Interest Rates", "Times New Roman Bold Italic", 15,
                0xffffff).setBackground(0x000088, -1, Chart.softLighting(Chart.Right)
                );

            // Set the y axis label format to display a percentage sign
            c.yAxis().setLabelFormat("{value}%");

            // Add a red (ff0000) step line layer to the chart and set the line width
            // to 2 pixels
            StepLineLayer layer0 = c.addStepLineLayer(dataY0, 0xff0000, "Country AAA"
                );
            layer0.setXData(dataX0);
            layer0.setLineWidth(2);

            // Add a blue (0000ff) step line layer to the chart and set the line
            // width to 2 pixels
            StepLineLayer layer1 = c.addStepLineLayer(dataY1, 0x0000ff, "Country BBB"
                );
            layer1.setXData(dataX1);
            layer1.setLineWidth(2);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{dataSetName} change to {value}% on {x|mmm dd, yyyy}'");
        }
    }
}


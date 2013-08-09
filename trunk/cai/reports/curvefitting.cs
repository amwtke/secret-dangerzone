using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class curvefitting : DemoModule
    {
        //Name of demo module
        public string getName() { return "General Curve Fitting"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // Use random table to generate a random series. The random table is set
            // to 1 col x 51 rows, with 9 as the seed
            RanTable rantable = new RanTable(9, 1, 51);

            // Set the 1st column to start from 100, with changes between rows from
            // -5 to +5
            rantable.setCol(0, 100, -5, 5);

            // Get the 1st column of the random table as the data set
            double[] data = rantable.getCol(0);

            // Create a XYChart object of size 600 x 300 pixels
            XYChart c = new XYChart(600, 300);

            // Set the plotarea at (50, 35) and of size 500 x 240 pixels. Enable both
            // the horizontal and vertical grids by setting their colors to grey
            // (0xc0c0c0)
            c.setPlotArea(50, 35, 500, 240).setGridColor(0xc0c0c0, 0xc0c0c0);

            // Add a title to the chart using 18 point Times Bold Itatic font.
            c.addTitle("LOWESS Generic Curve Fitting Algorithm",
                "Times New Roman Bold Italic", 18);

            // Set the y axis line width to 3 pixels
            c.yAxis().setWidth(3);

            // Add a title to the x axis using 12 pts Arial Bold Italic font
            c.xAxis().setTitle("Server Load (TPS)", "Arial Bold Italic", 12);

            // Set the x axis line width to 3 pixels
            c.xAxis().setWidth(3);

            // Set the x axis scale from 0 - 50, with major tick every 5 units and
            // minor tick every 1 unit
            c.xAxis().setLinearScale(0, 50, 5, 1);

            // Add a blue layer to the chart
            LineLayer layer = c.addLineLayer2();

            // Add a red (0x80ff0000) data set to the chart with square symbols
            layer.addDataSet(data, unchecked((int)0x80ff0000)).setDataSymbol(
                Chart.SquareSymbol);

            // Set the line width to 2 pixels
            layer.setLineWidth(2);

            // Use lowess for curve fitting, and plot the fitted data using a spline
            // layer with line width set to 3 pixels
            c.addSplineLayer(new ArrayMath(data).lowess().result(), 0x0000ff
                ).setLineWidth(3);

            // Set zero affinity to 0 to make sure the line is displayed in the most
            // detail scale
            c.yAxis().setAutoScale(0, 0, 0);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='({x}, {value|2})'");
        }
    }
}


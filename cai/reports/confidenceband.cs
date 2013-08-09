using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class confidenceband : DemoModule
    {
        //Name of demo module
        public string getName() { return "Confidence Band"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The XY data of the first data series
            double[] dataX = {50, 55, 37, 24, 42, 49, 63, 72, 83, 59};
            double[] dataY = {3.6, 2.8, 2.5, 2.3, 3.8, 3.0, 3.8, 5.0, 6.0, 3.3};

            // Create a XYChart object of size 450 x 420 pixels
            XYChart c = new XYChart(450, 420);

            // Set the plotarea at (55, 65) and of size 350 x 300 pixels, with white
            // background and a light grey border (0xc0c0c0). Turn on both horizontal
            // and vertical grid lines with light grey color (0xc0c0c0)
            c.setPlotArea(55, 65, 350, 300, 0xffffff, -1, 0xc0c0c0, 0xc0c0c0, -1);

            // Add a title to the chart using 18 point Times Bold Itatic font.
            c.addTitle("Server Performance", "Times New Roman Bold Italic", 18);

            // Add titles to the axes using 12 pts Arial Bold Italic font
            c.yAxis().setTitle("Response Time (sec)", "Arial Bold Italic", 12);
            c.xAxis().setTitle("Server Load (TPS)", "Arial Bold Italic", 12);

            // Set the axes line width to 3 pixels
            c.yAxis().setWidth(3);
            c.xAxis().setWidth(3);

            // Add a scatter layer using (dataX, dataY)
            ScatterLayer scatterLayer = c.addScatterLayer(dataX, dataY, "",
                Chart.DiamondSymbol, 11, 0x008000);

            // tool tip for scatter layer
            scatterLayer.setHTMLImageMap("", "",
                "title='Response time at {x} TPS: {value} sec'");

            // Add a trend line layer for (dataX, dataY)
            TrendLayer trendLayer = c.addTrendLayer2(dataX, dataY, 0x008000);

            // Set the line width to 3 pixels
            trendLayer.setLineWidth(3);

            // Add a 95% confidence band for the line
            trendLayer.addConfidenceBand(0.95, unchecked((int)0x806666ff));

            // Add a 95% confidence band (prediction band) for the points
            trendLayer.addPredictionBand(0.95, unchecked((int)0x8066ff66));

            // tool tip for trend layer
            trendLayer.setHTMLImageMap("", "",
                "title='Slope = {slope|4} sec/TPS; Intercept = {intercept|4} sec'");

            // Add a legend box at (50, 30) (top of the chart) with horizontal
            // layout. Use 10 pts Arial Bold Italic font. Set the background and
            // border color to Transparent.
            LegendBox legendBox = c.addLegend(50, 30, false, "Arial Bold Italic", 10)
                ;
            legendBox.setBackground(Chart.Transparent);

            // Add entries to the legend box
            legendBox.addKey("95% Line Confidence", unchecked((int)0x806666ff));
            legendBox.addKey("95% Point Confidence", unchecked((int)0x8066ff66));

            // Display the trend line parameters as a text table formatted using CDML
            ChartDirector.TextBox textbox = c.addText(56, 65, String.Format(
                "<*block*>Slope\nIntercept\nCorrelation\nStd Error<*/*>   " +
                "<*block*>{0:0.0000} sec/tps\n{1:0.0000} sec\n{2:0.0000}\n" +
                "{3:0.0000} sec<*/*>", trendLayer.getSlope(),
                trendLayer.getIntercept(), trendLayer.getCorrelation(),
                trendLayer.getStdError()), "Arial Bold", 8);

            // Set the background of the text box to light grey, with a black border,
            // and 1 pixel 3D border
            textbox.setBackground(0xc0c0c0, 0, 1);

            // Output the chart
            viewer.Image = c.makeImage();

            // include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable");
        }
    }
}


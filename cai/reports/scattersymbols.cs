using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class scattersymbols : DemoModule
    {
        //Name of demo module
        public string getName() { return "Custom Scatter Symbols"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The XY points for the scatter chart
            double[] dataX = {200, 400, 300, 250, 500};
            double[] dataY = {40, 100, 50, 150, 250};

            // The custom symbols for the points
            string[] symbols = {"robot1.png", "robot2.png", "robot3.png",
                "robot4.png", "robot5.png"};

            // Create a XYChart object of size 450 x 400 pixels
            XYChart c = new XYChart(450, 400);

            // Set the plotarea at (55, 40) and of size 350 x 300 pixels, with a
            // light grey border (0xc0c0c0). Turn on both horizontal and vertical
            // grid lines with light grey color (0xc0c0c0)
            c.setPlotArea(55, 40, 350, 300, -1, -1, 0xc0c0c0, 0xc0c0c0, -1);

            // Add a title to the chart using 18 pts Times Bold Itatic font.
            c.addTitle("Battle Robots", "Times New Roman Bold Italic", 18);

            // Add a title to the y axis using 12 pts Arial Bold Italic font
            c.yAxis().setTitle("Speed (km/s)", "Arial Bold Italic", 12);

            // Add a title to the y axis using 12 pts Arial Bold Italic font
            c.xAxis().setTitle("Range (km)", "Arial Bold Italic", 12);

            // Set the axes line width to 3 pixels
            c.xAxis().setWidth(3);
            c.yAxis().setWidth(3);

            // Add each point of the data as a separate scatter layer, so that they
            // can have a different symbol
            for(int i = 0; i < dataX.Length; ++i) {
                c.addScatterLayer(new double[] {dataX[i]}, new double[] {dataY[i]}
                    ).getDataSet(0).setDataSymbol2(symbols[i]);
            }

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Range = {x} km, Speed = {value} km/s'");
        }
    }
}


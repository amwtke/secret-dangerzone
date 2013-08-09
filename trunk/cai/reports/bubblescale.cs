using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class bubblescale : DemoModule
    {
        //Name of demo module
        public string getName() { return "Bubble XY Scaling"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The XY points for the bubble chart. The bubble chart has independent
            // bubble size on the X and Y direction.
            double[] dataX0 = {1000, 1500, 1700};
            double[] dataY0 = {25, 20, 65};
            double[] dataZX0 = {500, 200, 600};
            double[] dataZY0 = {15, 30, 20};

            double[] dataX1 = {500, 1000, 1300};
            double[] dataY1 = {35, 50, 75};
            double[] dataZX1 = {800, 300, 500};
            double[] dataZY1 = {8, 27, 25};

            double[] dataX2 = {150, 300};
            double[] dataY2 = {20, 60};
            double[] dataZX2 = {160, 400};
            double[] dataZY2 = {30, 20};

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
            c.addTitle("Plasma Battery Comparison", "Times New Roman Bold Italic", 18
                );

            // Add titles to the axes using 12 pts Arial Bold Italic font
            c.yAxis().setTitle("Operating Current", "Arial Bold Italic", 12);
            c.xAxis().setTitle("Operating Voltage", "Arial Bold Italic", 12);

            // Set the axes line width to 3 pixels
            c.xAxis().setWidth(3);
            c.yAxis().setWidth(3);

            // Add (dataX0, dataY0) as a standard scatter layer, and also as a
            // "bubble" scatter layer, using circles as symbols. The "bubble" scatter
            // layer has symbol size modulated by (dataZX0, dataZY0) using the scale
            // on the x and y axes.
            c.addScatterLayer(dataX0, dataY0, "Vendor A", Chart.CircleSymbol, 9,
                0xff3333, 0xff3333);
            c.addScatterLayer(dataX0, dataY0, "", Chart.CircleSymbol, 9,
                unchecked((int)0x80ff3333), unchecked((int)0x80ff3333)
                ).setSymbolScale(dataZX0, Chart.XAxisScale, dataZY0, Chart.YAxisScale
                );

            // Add (dataX1, dataY1) as a standard scatter layer, and also as a
            // "bubble" scatter layer, using squares as symbols. The "bubble" scatter
            // layer has symbol size modulated by (dataZX1, dataZY1) using the scale
            // on the x and y axes.
            c.addScatterLayer(dataX1, dataY1, "Vendor B", Chart.SquareSymbol, 7,
                0x3333ff, 0x3333ff);
            c.addScatterLayer(dataX1, dataY1, "", Chart.SquareSymbol, 9,
                unchecked((int)0x803333ff), unchecked((int)0x803333ff)
                ).setSymbolScale(dataZX1, Chart.XAxisScale, dataZY1, Chart.YAxisScale
                );

            // Add (dataX2, dataY2) as a standard scatter layer, and also as a
            // "bubble" scatter layer, using diamonds as symbols. The "bubble"
            // scatter layer has symbol size modulated by (dataZX2, dataZY2) using
            // the scale on the x and y axes.
            c.addScatterLayer(dataX2, dataY2, "Vendor C", Chart.DiamondSymbol, 9,
                0x00ff00, 0x00ff00);
            c.addScatterLayer(dataX2, dataY2, "", Chart.DiamondSymbol, 9,
                unchecked((int)0x8033ff33), unchecked((int)0x8033ff33)
                ).setSymbolScale(dataZX2, Chart.XAxisScale, dataZY2, Chart.YAxisScale
                );

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='Voltage = {x} +/- {={zx}/2} V, Current = {value} +/- " +
                "{={zy}/2} A'");
        }
    }
}


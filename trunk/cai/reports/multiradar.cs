using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class multiradar : DemoModule
    {
        //Name of demo module
        public string getName() { return "Multi Radar Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the chart
            double[] data0 = {90, 60, 85, 75, 55};
            double[] data1 = {60, 80, 70, 80, 85};

            // The labels for the chart
            string[] labels = {"Speed", "Reliability", "Comfort", "Safety",
                "Efficiency"};

            // Create a PolarChart object of size 480 x 380 pixels. Set background
            // color to gold, with 1 pixel 3D border effect
            PolarChart c = new PolarChart(480, 380, Chart.goldColor(), 0x000000, 1);

            // Add a title to the chart using 15 pts Times Bold Italic font. The
            // title text is white (ffffff) on a deep blue (000080) background
            c.addTitle("Space Travel Vehicles Compared",
                "Times New Roman Bold Italic", 15, 0xffffff).setBackground(0x000080);

            // Set plot area center at (240, 210), with 150 pixels radius, and a
            // white (ffffff) background.
            c.setPlotArea(240, 210, 150, 0xffffff);

            // Add a legend box at top right corner (470, 35) using 10 pts Arial Bold
            // font. Set the background to silver, with 1 pixel 3D border effect.
            LegendBox b = c.addLegend(470, 35, true, "Arial Bold", 10);
            b.setAlignment(Chart.TopRight);
            b.setBackground(Chart.silverColor(), Chart.Transparent, 1);

            // Add an area layer to the chart using semi-transparent blue
            // (0x806666cc). Add a blue (0x6666cc) line layer using the same data
            // with 3 pixel line width to highlight the border of the area.
            c.addAreaLayer(data0, unchecked((int)0x806666cc), "Model Saturn");
            c.addLineLayer(data0, 0x6666cc).setLineWidth(3);

            // Add an area layer to the chart using semi-transparent red
            // (0x80cc6666). Add a red (0xcc6666) line layer using the same data with
            // 3 pixel line width to highlight the border of the area.
            c.addAreaLayer(data1, unchecked((int)0x80cc6666), "Model Jupiter");
            c.addLineLayer(data1, 0xcc6666).setLineWidth(3);

            // Set the labels to the angular axis as spokes.
            c.angularAxis().setLabels(labels);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='[{dataSetName}] {label}: score = {value}'");
        }
    }
}


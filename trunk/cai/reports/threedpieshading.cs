using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class threedpieshading : DemoModule
    {
        //Name of demo module
        public string getName() { return "3D Pie Shading"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 7; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pie chart
            double[] data = {18, 30, 20, 15};

            // The labels for the pie chart
            string[] labels = {"Labor", "Licenses", "Facilities", "Production"};

            // The colors to use for the sectors
            int[] colors = {0x66aaee, 0xeebb22, 0xbbbbbb, 0x8844ff};

            // Create a PieChart object of size 200 x 200 pixels. Use a vertical
            // gradient color from blue (0000cc) to deep blue (000044) as background.
            // Use rounded corners of 16 pixels radius.
            PieChart c = new PieChart(200, 200);
            c.setBackground(c.linearGradientColor(0, 0, 0, c.getHeight(), 0x0000cc,
                0x000044));
            c.setRoundedFrame(0xffffff, 16);

            // Set the center of the pie at (100, 100) and the radius to 80 pixels
            c.setPieSize(100, 100, 80);

            // Set the pie data
            c.setData(data, labels);

            // Set the sector colors
            c.setColors2(Chart.DataColor, colors);

            // Draw the pie in 3D with a pie thickness of 20 pixels
            c.set3D(20);

            // Demonstrates various shading modes
            if (img == "0") {
                c.addTitle("Default Shading", "bold", 12, 0xffffff);
            } else if (img == "1") {
                c.addTitle("Flat Gradient", "bold", 12, 0xffffff);
                c.setSectorStyle(Chart.FlatShading);
            } else if (img == "2") {
                c.addTitle("Local Gradient", "bold", 12, 0xffffff);
                c.setSectorStyle(Chart.LocalGradientShading);
            } else if (img == "3") {
                c.addTitle("Global Gradient", "bold", 12, 0xffffff);
                c.setSectorStyle(Chart.GlobalGradientShading);
            } else if (img == "4") {
                c.addTitle("Concave Shading", "bold", 12, 0xffffff);
                c.setSectorStyle(Chart.ConcaveShading);
            } else if (img == "5") {
                c.addTitle("Rounded Edge", "bold", 12, 0xffffff);
                c.setSectorStyle(Chart.RoundedEdgeShading);
            } else if (img == "6") {
                c.addTitle("Radial Gradient", "bold", 12, 0xffffff);
                c.setSectorStyle(Chart.RadialShading);
            }

            // Disable the sector labels by setting the color to Transparent
            c.setLabelStyle("", 8, Chart.Transparent);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: US${value}K ({percent}%)'");
        }
    }
}


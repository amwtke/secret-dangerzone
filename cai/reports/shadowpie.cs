using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class shadowpie : DemoModule
    {
        //Name of demo module
        public string getName() { return "3D Shadow Mode"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 4; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // the tilt angle of the pie
            int angle = int.Parse(img) * 90 + 45;

            // The data for the pie chart
            double[] data = {25, 18, 15, 12, 8, 30, 35};

            // The labels for the pie chart
            string[] labels = {"Labor", "Licenses", "Taxes", "Legal", "Insurance",
                "Facilities", "Production"};

            // Create a PieChart object of size 100 x 110 pixels
            PieChart c = new PieChart(100, 110);

            // Set the center of the pie at (50, 55) and the radius to 36 pixels
            c.setPieSize(50, 55, 36);

            // Set the depth, tilt angle and 3D mode of the 3D pie (-1 means auto
            // depth, "true" means the 3D effect is in shadow mode)
            c.set3D(-1, angle, true);

            // Add a title showing the shadow angle
            c.addTitle("Shadow @ " + angle + " deg", "Arial", 8);

            // Set the pie data
            c.setData(data, labels);

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


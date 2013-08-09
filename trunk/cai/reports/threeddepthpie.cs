using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class threeddepthpie : DemoModule
    {
        //Name of demo module
        public string getName() { return "3D Depth"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 5; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // the tilt angle of the pie
            int depth = int.Parse(img) * 5 + 5;

            // The data for the pie chart
            double[] data = {25, 18, 15, 12, 8, 30, 35};

            // The labels for the pie chart
            string[] labels = {"Labor", "Licenses", "Taxes", "Legal", "Insurance",
                "Facilities", "Production"};

            // Create a PieChart object of size 100 x 110 pixels
            PieChart c = new PieChart(100, 110);

            // Set the center of the pie at (50, 55) and the radius to 38 pixels
            c.setPieSize(50, 55, 38);

            // Set the depth of the 3D pie
            c.set3D(depth);

            // Add a title showing the depth
            c.addTitle("Depth = " + depth + " pixels", "Arial", 8);

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


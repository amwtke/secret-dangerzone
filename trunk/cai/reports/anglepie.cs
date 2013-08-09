using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class anglepie : DemoModule
    {
        //Name of demo module
        public string getName() { return "Start Angle and Direction"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 2; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // Determine the starting angle and direction based on input parameter
            int angle = 0;
            bool clockwise = true;
            if (img != "0") {
                angle = 90;
                clockwise = false;
            }

            // The data for the pie chart
            double[] data = {25, 18, 15, 12, 8, 30, 35};

            // The labels for the pie chart
            string[] labels = {"Labor", "Licenses", "Taxes", "Legal", "Insurance",
                "Facilities", "Production"};

            // Create a PieChart object of size 280 x 240 pixels
            PieChart c = new PieChart(280, 240);

            // Set the center of the pie at (140, 130) and the radius to 80 pixels
            c.setPieSize(140, 130, 80);

            // Add a title to the pie to show the start angle and direction
            if (clockwise) {
                c.addTitle("Start Angle = " + angle +
                    " degrees\nDirection = Clockwise");
            } else {
                c.addTitle("Start Angle = " + angle +
                    " degrees\nDirection = AntiClockwise");
            }

            // Set the pie start angle and direction
            c.setStartAngle(angle, clockwise);

            // Draw the pie in 3D
            c.set3D();

            // Set the pie data and the pie labels
            c.setData(data, labels);

            // Explode the 1st sector (index = 0)
            c.setExplode(0);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: US${value}K ({percent}%)'");
        }
    }
}


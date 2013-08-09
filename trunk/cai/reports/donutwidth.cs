using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class donutwidth : DemoModule
    {
        //Name of demo module
        public string getName() { return "Donut Width"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 5; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // Determine the donut inner radius (as percentage of outer radius) based
            // on input parameter
            int donutRadius = int.Parse(img) * 25;

            // The data for the pie chart
            double[] data = {10, 10, 10, 10, 10};

            // The labels for the pie chart
            string[] labels = {"Marble", "Wood", "Granite", "Plastic", "Metal"};

            // Create a PieChart object of size 150 x 120 pixels, with a grey
            // (EEEEEE) background, black border and 1 pixel 3D border effect
            PieChart c = new PieChart(150, 120, 0xeeeeee, 0x000000, 1);

            // Set donut center at (75, 65) and the outer radius to 50 pixels. Inner
            // radius is computed according donutWidth
            c.setDonutSize(75, 60, 50, (int)(50 * donutRadius / 100));

            // Add a title to show the donut width
            c.addTitle("Inner Radius = " + donutRadius + " %", "Arial", 10
                ).setBackground(0xcccccc, 0);

            // Draw the pie in 3D
            c.set3D(12);

            // Set the pie data and the pie labels
            c.setData(data, labels);

            // Disable the sector labels by setting the color to Transparent
            c.setLabelStyle("", 8, Chart.Transparent);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: {value}kg ({percent}%)'");
        }
    }
}


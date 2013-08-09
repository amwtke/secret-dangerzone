using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class texturedonut : DemoModule
    {
        //Name of demo module
        public string getName() { return "Texture Donut Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pie chart
            double[] data = {18, 45, 28};

            // The labels for the pie chart
            string[] labels = {"Marble", "Wood", "Granite"};

            // The icons for the sectors
            string[] texture = {"marble3.png", "wood.png", "rock.png"};

            // Create a PieChart object of size 400 x 330 pixels, with a metallic
            // green (88EE88) background, black border and 1 pixel 3D border effect
            PieChart c = new PieChart(400, 330, Chart.metalColor(0x88ee88), 0x000000,
                1);

            // Set donut center at (200, 160), and outer/inner radii as 120/60 pixels
            c.setDonutSize(200, 160, 120, 60);

            // Add a title box using 15 pts Times Bold Italic font and metallic deep
            // green (008000) background color
            c.addTitle("Material Composition", "Times New Roman Bold Italic", 15
                ).setBackground(Chart.metalColor(0x008000));

            // Set the pie data and the pie labels
            c.setData(data, labels);

            // Set the colors of the sectors to the 3 texture patterns
            c.setColor(Chart.DataColor + 0, c.patternColor2(texture[0]));
            c.setColor(Chart.DataColor + 1, c.patternColor2(texture[1]));
            c.setColor(Chart.DataColor + 2, c.patternColor2(texture[2]));

            // Draw the pie in 3D with a 3D depth of 30 pixels
            c.set3D(30);

            // Use 12 pts Arial Bold Italic as the sector label font
            c.setLabelStyle("Arial Bold Italic", 12);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: {value}kg ({percent}%)'");
        }
    }
}


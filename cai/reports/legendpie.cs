using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class legendpie : DemoModule
    {
        //Name of demo module
        public string getName() { return "Pie Chart with Legend (1)"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pie chart
            double[] data = {25, 18, 15, 12, 8, 30, 35};

            // The labels for the pie chart
            string[] labels = {"Labor", "Licenses", "Taxes", "Legal", "Insurance",
                "Facilities", "Production"};

            // Create a PieChart object of size 450 x 270 pixels
            PieChart c = new PieChart(450, 270);

            // Set the center of the pie at (150, 100) and the radius to 80 pixels
            c.setPieSize(150, 135, 100);

            // add a legend box where the top left corner is at (330, 50)
            c.addLegend(330, 60);

            // modify the sector label format to show percentages only
            c.setLabelFormat("{percent}%");

            // Set the pie data and the pie labels
            c.setData(data, labels);

            // Use rounded edge shading, with a 1 pixel white (FFFFFF) border
            c.setSectorStyle(Chart.RoundedEdgeShading, 0xffffff, 1);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: US${value}K ({percent}%)'");
        }
    }
}


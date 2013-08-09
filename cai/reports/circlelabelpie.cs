using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class circlelabelpie : DemoModule
    {
        //Name of demo module
        public string getName() { return "Circular Label Layout"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 2; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The data for the pie chart
            double[] data = {42, 18, 8};

            // The labels for the pie chart
            string[] labels = {"Agree", "Disagree", "Not Sure"};

            // The colors to use for the sectors
            int[] colors = {0x66ff66, 0xff6666, 0xffff00};

            // Create a PieChart object of size 300 x 300 pixels. Set the background
            // to a gradient color from blue (aaccff) to sky blue (ffffff), with a
            // grey (888888) border. Use rounded corners and soft drop shadow.
            PieChart c = new PieChart(300, 300);
            c.setBackground(c.linearGradientColor(0, 0, 0, c.getHeight() / 2,
                0xaaccff, 0xffffff), 0x888888);
            c.setRoundedFrame();
            c.setDropShadow();

            if (img == "0") {
            //============================================================
            //    Draw a pie chart where the label is on top of the pie
            //============================================================

                // Set the center of the pie at (150, 150) and the radius to 120
                // pixels
                c.setPieSize(150, 150, 120);

                // Set the label position to -40 pixels from the perimeter of the pie
                // (-ve means label is inside the pie)
                c.setLabelPos(-40);

            } else {
            //============================================================
            //    Draw a pie chart where the label is outside the pie
            //============================================================

                // Set the center of the pie at (150, 150) and the radius to 80
                // pixels
                c.setPieSize(150, 150, 80);

                // Set the sector label position to be 20 pixels from the pie. Use a
                // join line to connect the labels to the sectors.
                c.setLabelPos(20, Chart.LineColor);

            }

            // Set the pie data and the pie labels
            c.setData(data, labels);

            // Set the sector colors
            c.setColors2(Chart.DataColor, colors);

            // Use local gradient shading, with a 1 pixel semi-transparent black
            // (bb000000) border
            c.setSectorStyle(Chart.LocalGradientShading, unchecked((int)0xbb000000),
                1);

            // Output the chart
            viewer.Image = c.makeImage();

            //include tool tip for the chart
            viewer.ImageMap = c.getHTMLImageMap("clickable", "",
                "title='{label}: {value} responses ({percent}%)'");
        }
    }
}


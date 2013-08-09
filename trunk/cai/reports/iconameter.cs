using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class iconameter : DemoModule
    {
        //Name of demo module
        public string getName() { return "Icon Angular Meter"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // The value to display on the meter
            double value = 85;

            // Create an AugularMeter object of size 70 x 90 pixels, using black
            // background with a 2 pixel 3D depressed border.
            AngularMeter m = new AngularMeter(70, 90, 0, 0, -2);

            // Use white on black color palette for default text and line colors
            m.setColors(Chart.whiteOnBlackPalette);

            // Set the meter center at (10, 45), with radius 50 pixels, and span from
            // 135 to 45 degress
            m.setMeter(10, 45, 50, 135, 45);

            // Set meter scale from 0 - 100, with the specified labels
            m.setScale2(0, 100, new string[] {"E", " ", " ", " ", "F"});

            // Set the angular arc and major tick width to 2 pixels
            m.setLineWidth(2, 2);

            // Add a red zone at 0 - 15
            m.addZone(0, 15, 0xff3333);

            // Add an icon at (25, 35)
            m.addText(25, 35, "<*img=gas.gif*>");

            // Add a yellow (ffff00) pointer at the specified value
            m.addPointer(value, 0xffff00);

            // Output the chart
            viewer.Image = m.makeImage();
        }
    }
}


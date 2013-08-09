using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class squareameter : DemoModule
    {
        //Name of demo module
        public string getName() { return "Square Angular Meters"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 4; }

        //Main code for creating charts
        public void createChart(WinChartViewer viewer, string img)
        {
            // The value to display on the meter
            double value = 4.75;

            // Create an AugularMeter object of size 110 x 110 pixels, using silver
            // background color with a black 2 pixel 3D depressed border.
            AngularMeter m = new AngularMeter(110, 110, Chart.silverColor(),
                0x000000, -2);

            // Set meter appearance according to a parameter
            if (img == "0") {
                // Set the meter center at bottom left corner (15, 95), with radius
                // 85 pixels. Meter spans from 90 - 0 degrees.
                m.setMeter(15, 95, 85, 90, 0);
                // Add a label to the meter centered at (35, 75)
                m.addText(35, 75, "VDC", "Arial Bold", 12, Chart.TextColor,
                    Chart.Center);
                // Add a text box to show the value at top right corner (103, 7)
                m.addText(103, 7, m.formatValue(value, "2"), "Arial", 8, 0xffffff,
                    Chart.TopRight).setBackground(0, 0, -1);
            } else if (img == "1") {
                // Set the meter center at top left corner (15, 15), with radius 85
                // pixels. Meter spans from 90 - 180 degrees.
                m.setMeter(15, 15, 85, 90, 180);
                // Add a label to the meter centered at (35, 35)
                m.addText(35, 35, "AMP", "Arial Bold", 12, Chart.TextColor,
                    Chart.Center);
                // Add a text box to show the value at bottom right corner (103, 103)
                m.addText(103, 103, m.formatValue(value, "2"), "Arial", 8, 0xffffff,
                    Chart.BottomRight).setBackground(0, 0, -1);
            } else if (img == "2") {
                // Set the meter center at top right corner (15, 95), with radius 85
                // pixels. Meter spans from 270 - 180 degrees.
                m.setMeter(95, 15, 85, 270, 180);
                // Add a label to the meter centered at (75, 35)
                m.addText(75, 35, "KW", "Arial Bold", 12, Chart.TextColor,
                    Chart.Center);
                // Add a text box to show the value at bottom left corner (7, 103)
                m.addText(7, 103, m.formatValue(value, "2"), "Arial", 8, 0xffffff,
                    Chart.BottomLeft).setBackground(0, 0, -1);
            } else {
                // Set the meter center at bottom right corner (95, 95), with radius
                // 85 pixels. Meter spans from 270 - 360 degrees.
                m.setMeter(95, 95, 85, 270, 360);
                // Add a label to the meter centered at (75, 75)
                m.addText(75, 75, "RPM", "Arial Bold", 12, Chart.TextColor,
                    Chart.Center);
                // Add a text box to show the value at top left corner (7, 7)
                m.addText(7, 7, m.formatValue(value, "2"), "Arial", 8, 0xffffff,
                    Chart.TopLeft).setBackground(0, 0, -1);
            }

            // Meter scale is 0 - 10, with a major tick every 2 units, and minor tick
            // every 1 unit
            m.setScale(0, 10, 2, 1);

            // Set 0 - 6 as green (99ff99) zone, 6 - 8 as yellow (ffff00) zone, and 8
            // - 10 as red (ff3333) zone
            m.addZone(0, 6, 0x99ff99, 0x808080);
            m.addZone(6, 8, 0xffff00, 0x808080);
            m.addZone(8, 10, 0xff3333, 0x808080);

            // Add a semi-transparent black (80000000) pointer at the specified value
            m.addPointer(value, unchecked((int)0x80000000));

            // Output the chart
            viewer.Image = m.makeImage();
        }
    }
}


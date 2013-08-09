using System;
using ChartDirector;

namespace CSharpChartExplorer
{
    public class concentric : DemoModule
    {
        //Name of demo module
        public string getName() { return "Concentric Donut Chart"; }

        //Number of charts produced in this demo module
        public int getNoOfCharts() { return 1; }

        //Main code for creating chart.
        //Note: the argument img is unused because this demo only has 1 chart.
        public void createChart(WinChartViewer viewer, string img)
        {
            // Data for outer ring
            double[] data = {88, 124, 96};

            // Data for inner ring
            double[] data2 = {77, 87, 45};

            // Labels for the sectors
            string[] labels = {"Hardware", "Software", "Services"};

            // Colors for the sectors
            int[] colors = {0xff9999, 0x9999ff, 0x66ff66};

            //
            // Create the main chart, which contains the chart title, the outer ring,
            // and the legend box
            //

            // Create a PieChart object of size 450 x 360 pixels, with transparent
            // background
            PieChart c = new PieChart(450, 360);

            // Add a title to the chart with 18pts Times Bold Italic font
            c.addTitle("Concentric Donut Chart", "Times New Roman Bold Italic", 18);

            // Set donut center at (160, 200), and outer/inner radii as 150/100
            // pixels
            c.setDonutSize(160, 200, 150, 100);

            // Add a label at the bottom-right corner of the ring to label the outer
            // ring Use 12pts Arial Bold Italic font in white (ffffff) color, on a
            // green (008800) background, with soft lighting effect and 5 pixels
            // rounded corners
            ChartDirector.TextBox t = c.addText(260, 300, " Year 2006 ",
                "Arial Bold Italic", 12, 0xffffff);
            t.setBackground(0x008800, Chart.Transparent, Chart.softLighting());
            t.setRoundedCorners(5);

            // Set the legend box at (320, 50) with 12 pts Arial Bold Italic font,
            // with no border
            c.addLegend(320, 50, true, "Arial Bold Italic", 13).setBackground(
                Chart.Transparent, Chart.Transparent);

            // Set the pie data and the pie labels
            c.setData(data, labels);

            // Set the pie colors
            c.setColors2(Chart.DataColor, colors);

            // Set pie border color to white (ffffff)
            c.setLineColor(0xffffff);

            // Set pie label to value in $###M format, percentage in (##.#%) format,
            // in two lines.
            c.setLabelFormat("${value}M<*br*>({percent|1}%)");

            // Use 10pts Airal Bold for the sector labels
            c.setLabelStyle("Arial Bold", 10);

            // Set the label position to -25 pixels from the sector (which would be
            // internal to the sector)
            c.setLabelPos(-25);

            //
            // Create the inner ring.
            //

            // Create a PieChart object of size 280 x 320 pixels, with transparent
            // background
            PieChart c2 = new PieChart(280, 320, Chart.Transparent);

            // Set donut center at (110, 110), and outer/inner radii as 100/50 pixels
            c2.setDonutSize(110, 110, 100, 50);

            // Add a label at the center of the ring to label the inner ring. Use
            // 12pts Arial Bold Italic font in white (ffffff) color, on a deep blue
            // (0000cc) background, with soft lighting effect and 5 pixels rounded
            // corners
            ChartDirector.TextBox t2 = c2.addText(110, 110, " Year 2005 ",
                "Arial Bold Italic", 12, 0xffffff, Chart.Center);
            t2.setBackground(0x0000cc, Chart.Transparent, Chart.softLighting());
            t2.setRoundedCorners(5);

            // Set the pie data and the pie labels
            c2.setData(data2, labels);

            // Set the pie colors
            c2.setColors2(Chart.DataColor, colors);

            // Set pie border color to white (ffffff)
            c2.setLineColor(0xffffff);

            // Set pie label to value in $###M format, percentage in (##.#%) format,
            // in two lines.
            c2.setLabelFormat("${value}M<*br*>({percent|1}%)");

            // Use 10pts Airal Bold for the sector labels
            c2.setLabelStyle("Arial Bold", 10);

            // Set the label position to -25 pixels from the sector (which would be
            // internal to the sector)
            c2.setLabelPos(-25);

            // merge the inner ring into the outer ring at (50, 90)
            c.makeChart3().merge(c2.makeChart3(), 50, 90, Chart.TopLeft, 0);

            // Output the chart
            viewer.Image = c.makeImage();

            // include tool tip for the chart
            viewer.ImageMap = c2.getHTMLImageMap("clickable", "",
                "title='{label} revenue for 2005: US${value}M ({percent}%)'", 50, 90)
                 + c.getHTMLImageMap("clickable", "",
                "title='{label} revenue for 2006: US${value}M ({percent}%)'");
        }
    }
}


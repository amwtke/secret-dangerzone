using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;


namespace CSharpChartExplorer
{
	/// <summary>
	/// Application to demonstrate using ChartDirector
	/// </summary>
	public class ChartExplorer : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ToolBar toolBar;
		private System.Windows.Forms.ImageList toolBarImageList;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel statusBarPanel;
		private System.Windows.Forms.TreeView treeView;
		private System.Windows.Forms.ImageList treeViewImageList;
		private System.Windows.Forms.ToolBarButton BackPB;
		private System.Windows.Forms.ToolBarButton ForwardPB;
		private System.Windows.Forms.ToolBarButton PreviousPB;
		private System.Windows.Forms.ToolBarButton NextPB;
		private System.Windows.Forms.ToolBarButton ViewSourcePB;
		private System.Windows.Forms.ToolBarButton HelpPB;
		private System.Windows.Forms.Splitter splitter;
		private System.Windows.Forms.Panel rightPanel;
		private System.Windows.Forms.Label title;
		private System.Windows.Forms.Label line;
		private ChartDirector.WinChartViewer chartViewer1;
		private ChartDirector.WinChartViewer chartViewer2;
		private ChartDirector.WinChartViewer chartViewer3;
		private ChartDirector.WinChartViewer chartViewer4;
		private ChartDirector.WinChartViewer chartViewer5;
		private ChartDirector.WinChartViewer chartViewer6;
		private ChartDirector.WinChartViewer chartViewer7;
		private ChartDirector.WinChartViewer chartViewer8;
		private System.ComponentModel.IContainer components;

		//
		// Array to hold all Windows.ChartViewers in the form to allow processing using loops
		//
		private ChartDirector.WinChartViewer[] chartViewers;
		
		//
		// Data structure to handle the Back / Forward buttons. We support up to
		// 100 histories. We store histories as the nodes begin selected.
		//
		private TreeNode[] history = new TreeNode[100];
		
		// The array index of the currently selected node in the history array.
		private int currentHistoryIndex = -1;

		// The array index of the last valid entry in the history array so that we
		// know if we can use the Forward button.
		private int lastHistoryIndex = -1;


		/// <summary>
		/// The main entry point for the application.
		/// </summary>
        //[STAThread]
        //static void Main() 
        //{
        //    //MessageBox.Show(ChartDirector.Chart.getBootLog());
        //    Application.Run(new ChartExplorer());
        //}

		/// <summary>
		/// ChartExplorer Constructor
		/// </summary>
		public ChartExplorer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// Array to hold all Windows.ChartViewers in the form to allow processing 
			// using loops
			//
			chartViewers = new ChartDirector.WinChartViewer[] 
			{ 
				chartViewer1, chartViewer2, chartViewer3, chartViewer4, 
				chartViewer5, chartViewer6, chartViewer7, chartViewer8
			};

			//
			// Build the tree view on the left to represent available demo modules
			//
			TreeNode pieNode = new TreeNode("Pie Charts");
			treeView.Nodes.Add(pieNode);

			pieNode.Nodes.Add(MakeNode(new simplepie(), 2));
			pieNode.Nodes.Add(MakeNode(new threedpie(), 2));
			pieNode.Nodes.Add(MakeNode(new multidepthpie(), 2));
			pieNode.Nodes.Add(MakeNode(new sidelabelpie(), 2));
			pieNode.Nodes.Add(MakeNode(new circlelabelpie(), 2));
			pieNode.Nodes.Add(MakeNode(new legendpie(), 2));
			pieNode.Nodes.Add(MakeNode(new legendpie2(), 2));
			pieNode.Nodes.Add(MakeNode(new explodedpie(), 2));
			pieNode.Nodes.Add(MakeNode(new iconpie(), 2));
			pieNode.Nodes.Add(MakeNode(new iconpie2(), 2));
			pieNode.Nodes.Add(MakeNode(new multipie(), 2));
			pieNode.Nodes.Add(MakeNode(new donut(), 2));
			pieNode.Nodes.Add(MakeNode(new threeddonut(), 2));
			pieNode.Nodes.Add(MakeNode(new icondonut(), 2));
			pieNode.Nodes.Add(MakeNode(new texturedonut(), 2));
			pieNode.Nodes.Add(MakeNode(new concentric(), 2));
			pieNode.Nodes.Add(MakeNode(new pieshading(), 2));
			pieNode.Nodes.Add(MakeNode(new threedpieshading(), 2));
			pieNode.Nodes.Add(MakeNode(new donutshading(), 2));
			pieNode.Nodes.Add(MakeNode(new threeddonutshading(), 2));
			pieNode.Nodes.Add(MakeNode(new fontpie(), 2));
			pieNode.Nodes.Add(MakeNode(new threedanglepie(), 2));
			pieNode.Nodes.Add(MakeNode(new threeddepthpie(), 2));
			pieNode.Nodes.Add(MakeNode(new shadowpie(), 2));
			pieNode.Nodes.Add(MakeNode(new anglepie(), 2));
			pieNode.Nodes.Add(MakeNode(new donutwidth(), 2));

			TreeNode barNode = new TreeNode("Bar Charts");
			treeView.Nodes.Add(barNode);

			barNode.Nodes.Add(MakeNode(new simplebar(), 3));
			barNode.Nodes.Add(MakeNode(new colorbar(), 3));
			barNode.Nodes.Add(MakeNode(new softlightbar(), 3));
			barNode.Nodes.Add(MakeNode(new glasslightbar(), 3));
			barNode.Nodes.Add(MakeNode(new gradientbar(), 3));
			barNode.Nodes.Add(MakeNode(new cylinderlightbar(), 3));
			barNode.Nodes.Add(MakeNode(new threedbar(), 3));
			barNode.Nodes.Add(MakeNode(new cylinderbar(), 3));
			barNode.Nodes.Add(MakeNode(new polygonbar(), 3));
			barNode.Nodes.Add(MakeNode(new stackedbar(), 3));
			barNode.Nodes.Add(MakeNode(new percentbar(), 3));
			barNode.Nodes.Add(MakeNode(new multibar(), 3));
			barNode.Nodes.Add(MakeNode(new softmultibar(), 3));
			barNode.Nodes.Add(MakeNode(new glassmultibar(), 3));
			barNode.Nodes.Add(MakeNode(new gradientmultibar(), 3));
			barNode.Nodes.Add(MakeNode(new multicylinder(), 3));
			barNode.Nodes.Add(MakeNode(new multishapebar(), 3));
			barNode.Nodes.Add(MakeNode(new overlapbar(), 3));
			barNode.Nodes.Add(MakeNode(new multistackbar(), 3));
			barNode.Nodes.Add(MakeNode(new depthbar(), 3));
			barNode.Nodes.Add(MakeNode(new posnegbar(), 3));
			barNode.Nodes.Add(MakeNode(new hbar(), 3));
			barNode.Nodes.Add(MakeNode(new dualhbar(), 3));
			barNode.Nodes.Add(MakeNode(new markbar(), 3));
			barNode.Nodes.Add(MakeNode(new pareto(), 3));
			barNode.Nodes.Add(MakeNode(new varwidthbar(), 3));
			barNode.Nodes.Add(MakeNode(new gapbar(), 3));

			TreeNode lineNode = new TreeNode("Line Charts");
			treeView.Nodes.Add(lineNode);

			lineNode.Nodes.Add(MakeNode(new simpleline(), 4));
			lineNode.Nodes.Add(MakeNode(new compactline(), 4));
			lineNode.Nodes.Add(MakeNode(new threedline(), 4));
			lineNode.Nodes.Add(MakeNode(new multiline(), 4));
			lineNode.Nodes.Add(MakeNode(new symbolline(), 4));
			lineNode.Nodes.Add(MakeNode(new symbolline2(), 4));
			lineNode.Nodes.Add(MakeNode(new missingpoints(), 4));
			lineNode.Nodes.Add(MakeNode(new unevenpoints(), 4));
			lineNode.Nodes.Add(MakeNode(new splineline(), 4));
			lineNode.Nodes.Add(MakeNode(new stepline(), 4));
			lineNode.Nodes.Add(MakeNode(new linefill(), 4));
			lineNode.Nodes.Add(MakeNode(new linecompare(), 4));
			lineNode.Nodes.Add(MakeNode(new errline(), 4));
			lineNode.Nodes.Add(MakeNode(new multisymbolline(), 4));
			lineNode.Nodes.Add(MakeNode(new binaryseries(), 4));
			lineNode.Nodes.Add(MakeNode(new customsymbolline(), 4));
			lineNode.Nodes.Add(MakeNode(new rotatedline(), 4));
			lineNode.Nodes.Add(MakeNode(new xyline(), 4));
			
			TreeNode trendNode = new TreeNode("Trending and Curve Fitting");
			treeView.Nodes.Add(trendNode);

			trendNode.Nodes.Add(MakeNode(new trendline(), 5));
			trendNode.Nodes.Add(MakeNode(new scattertrend(), 5));
			trendNode.Nodes.Add(MakeNode(new confidenceband(), 5));
			trendNode.Nodes.Add(MakeNode(new paramcurve(), 5));
			trendNode.Nodes.Add(MakeNode(new curvefitting(), 5));
			
			TreeNode scatterNode = new TreeNode("Scatter/Bubble/Vector Charts");
			treeView.Nodes.Add(scatterNode);

			scatterNode.Nodes.Add(MakeNode(new scatter(), 6));
			scatterNode.Nodes.Add(MakeNode(new builtinsymbols(), 6));
			scatterNode.Nodes.Add(MakeNode(new scattersymbols(), 6));
			scatterNode.Nodes.Add(MakeNode(new scatterlabels(), 6));
			scatterNode.Nodes.Add(MakeNode(new bubble(), 6));
			scatterNode.Nodes.Add(MakeNode(new threedbubble(), 6));
			scatterNode.Nodes.Add(MakeNode(new threedbubble2(), 6));
			scatterNode.Nodes.Add(MakeNode(new threedbubble3(), 6));
			scatterNode.Nodes.Add(MakeNode(new bubblescale(), 6));
			scatterNode.Nodes.Add(MakeNode(new vector(), 6));

			TreeNode areaNode = new TreeNode("Area Charts");
			treeView.Nodes.Add(areaNode);

			areaNode.Nodes.Add(MakeNode(new simplearea(), 7));
			areaNode.Nodes.Add(MakeNode(new enhancedarea(), 7));
			areaNode.Nodes.Add(MakeNode(new threedarea(), 7));
			areaNode.Nodes.Add(MakeNode(new patternarea(), 7));
			areaNode.Nodes.Add(MakeNode(new stackedarea(), 7));
			areaNode.Nodes.Add(MakeNode(new threedstackarea(), 7));
			areaNode.Nodes.Add(MakeNode(new percentarea(), 7));
			areaNode.Nodes.Add(MakeNode(new deptharea(), 7));
			areaNode.Nodes.Add(MakeNode(new rotatedarea(), 7));

			TreeNode boxNode = new TreeNode("Floating Box/Waterfall Charts");
			treeView.Nodes.Add(boxNode);

			boxNode.Nodes.Add(MakeNode(new boxwhisker(), 8));
			boxNode.Nodes.Add(MakeNode(new boxwhisker2(), 8));
			boxNode.Nodes.Add(MakeNode(new floatingbox(), 8));
			boxNode.Nodes.Add(MakeNode(new waterfall(), 8));
			boxNode.Nodes.Add(MakeNode(new posnegwaterfall(), 8));

			TreeNode ganttNode = new TreeNode("Gantt Charts");
			treeView.Nodes.Add(ganttNode);

			ganttNode.Nodes.Add(MakeNode(new gantt(), 9));
			ganttNode.Nodes.Add(MakeNode(new colorgantt(), 9));
			ganttNode.Nodes.Add(MakeNode(new layergantt(), 9));

			TreeNode contourNode = new TreeNode("Contour Charts/Heat Maps");
			treeView.Nodes.Add(contourNode);
			
			contourNode.Nodes.Add(MakeNode(new contour(), 10));
			contourNode.Nodes.Add(MakeNode(new smoothcontour(), 10));
			contourNode.Nodes.Add(MakeNode(new scattercontour(), 10));
			contourNode.Nodes.Add(MakeNode(new contourinterpolate(), 10));

			TreeNode financeNode = new TreeNode("Finance Charts");
			treeView.Nodes.Add(financeNode);

			financeNode.Nodes.Add(MakeNode(new hloc(), 11));
			financeNode.Nodes.Add(MakeNode(new candlestick(), 11));
			financeNode.Nodes.Add(MakeNode(new finance(), 11));
			financeNode.Nodes.Add(MakeNode(new finance2(), 11));
			financeNode.Nodes.Add(MakeNode(new financedemo(), 11));
			
			TreeNode xyMiscNode = new TreeNode("Other XY Chart Features");
			treeView.Nodes.Add(xyMiscNode);

			xyMiscNode.Nodes.Add(MakeNode(new markzone(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new markzone2(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new yzonecolor(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new xzonecolor(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new dualyaxis(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new dualxaxis(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new multiaxes(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new fourq(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new datatable(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new datatable2(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new fontxy(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new background(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new logaxis(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new axisscale(), 12));
			xyMiscNode.Nodes.Add(MakeNode(new ticks(), 12));

			TreeNode surfaceNode = new TreeNode("Surface Charts");
			treeView.Nodes.Add(surfaceNode);

			surfaceNode.Nodes.Add(MakeNode(new surface(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surface2(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surface3(), 13));
			surfaceNode.Nodes.Add(MakeNode(new scattersurface(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surfaceaxis(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surfacelighting(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surfaceshading(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surfacewireframe(), 13));
			surfaceNode.Nodes.Add(MakeNode(new surfaceperspective(), 13));

			TreeNode polarNode = new TreeNode("Polar Charts");
			treeView.Nodes.Add(polarNode);

			polarNode.Nodes.Add(MakeNode(new simpleradar(), 14));
			polarNode.Nodes.Add(MakeNode(new multiradar(), 14));
			polarNode.Nodes.Add(MakeNode(new stackradar(), 14));
			polarNode.Nodes.Add(MakeNode(new polarline(), 14));
			polarNode.Nodes.Add(MakeNode(new polararea(), 14));
			polarNode.Nodes.Add(MakeNode(new polarspline(), 14));
			polarNode.Nodes.Add(MakeNode(new polarscatter(), 14));
			polarNode.Nodes.Add(MakeNode(new polarbubble(), 14));
			polarNode.Nodes.Add(MakeNode(new polarvector(), 14));
			polarNode.Nodes.Add(MakeNode(new rose(), 14));
			polarNode.Nodes.Add(MakeNode(new stackrose(), 14));
			polarNode.Nodes.Add(MakeNode(new polarzones(), 14));
			polarNode.Nodes.Add(MakeNode(new polarzones2(), 14));
											
			TreeNode pyramidNode = new TreeNode("Pyramids/Cones/Funnels");
			treeView.Nodes.Add(pyramidNode);
			
			pyramidNode.Nodes.Add(MakeNode(new simplepyramid(), 15));
			pyramidNode.Nodes.Add(MakeNode(new threedpyramid(), 15));
			pyramidNode.Nodes.Add(MakeNode(new rotatedpyramid(), 15));
			pyramidNode.Nodes.Add(MakeNode(new cone(), 15));
			pyramidNode.Nodes.Add(MakeNode(new funnel(), 15));
			pyramidNode.Nodes.Add(MakeNode(new pyramidelevation(), 15));
			pyramidNode.Nodes.Add(MakeNode(new pyramidrotation(), 15));
			pyramidNode.Nodes.Add(MakeNode(new pyramidgap(), 15));
										   
			TreeNode meterNode = new TreeNode("Meters/Dials/Guages");
			treeView.Nodes.Add(meterNode);

			meterNode.Nodes.Add(MakeNode(new semicirclemeter(), 16));
			meterNode.Nodes.Add(MakeNode(new roundmeter(), 16));
			meterNode.Nodes.Add(MakeNode(new wideameter(), 16));
			meterNode.Nodes.Add(MakeNode(new squareameter(), 16));
			meterNode.Nodes.Add(MakeNode(new multiameter(), 16));
			meterNode.Nodes.Add(MakeNode(new iconameter(), 16));
			meterNode.Nodes.Add(MakeNode(new hlinearmeter(), 16));
			meterNode.Nodes.Add(MakeNode(new vlinearmeter(), 16));
			meterNode.Nodes.Add(MakeNode(new multihmeter(), 16));
			meterNode.Nodes.Add(MakeNode(new multivmeter(), 16));
			meterNode.Nodes.Add(MakeNode(new linearzonemeter(), 16));

			TreeNode activeNode = new TreeNode("Zooming and Scrolling");
			treeView.Nodes.Add(activeNode);

			activeNode.Nodes.Add(MakeNode(new zoomscrolldemo(), 17));
			activeNode.Nodes.Add(MakeNode(new zoomscrolldemo2(), 17));

			TreeNode realTimeNode = new TreeNode("Realtime Charts");
			treeView.Nodes.Add(realTimeNode);

			realTimeNode.Nodes.Add(MakeNode(new realtimedemo(), 18));

			treeView.SelectedNode = getNextChartNode(treeView.Nodes[0]);
		}

		/// <summary>
		/// Help method to add a demo module to the tree
		/// </summary>
		private TreeNode MakeNode(DemoModule module, int icon)
		{
			TreeNode node = new TreeNode(module.getName(), icon, icon);
			node.Tag = module;	// The demo module is attached to the node as the Tag property.
			return node;
		}
		
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			//
			// Standard code generated by Visual Studio.NET
			//
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChartExplorer));
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.statusBarPanel = new System.Windows.Forms.StatusBarPanel();
            this.toolBar = new System.Windows.Forms.ToolBar();
            this.BackPB = new System.Windows.Forms.ToolBarButton();
            this.ForwardPB = new System.Windows.Forms.ToolBarButton();
            this.PreviousPB = new System.Windows.Forms.ToolBarButton();
            this.NextPB = new System.Windows.Forms.ToolBarButton();
            this.ViewSourcePB = new System.Windows.Forms.ToolBarButton();
            this.HelpPB = new System.Windows.Forms.ToolBarButton();
            this.toolBarImageList = new System.Windows.Forms.ImageList(this.components);
            this.treeView = new System.Windows.Forms.TreeView();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.splitter = new System.Windows.Forms.Splitter();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.chartViewer8 = new ChartDirector.WinChartViewer();
            this.chartViewer7 = new ChartDirector.WinChartViewer();
            this.chartViewer6 = new ChartDirector.WinChartViewer();
            this.chartViewer5 = new ChartDirector.WinChartViewer();
            this.chartViewer4 = new ChartDirector.WinChartViewer();
            this.chartViewer3 = new ChartDirector.WinChartViewer();
            this.chartViewer2 = new ChartDirector.WinChartViewer();
            this.line = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.chartViewer1 = new ChartDirector.WinChartViewer();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel)).BeginInit();
            this.rightPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusBar
            // 
            this.statusBar.Location = new System.Drawing.Point(0, 483);
            this.statusBar.Name = "statusBar";
            this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel});
            this.statusBar.ShowPanels = true;
            this.statusBar.Size = new System.Drawing.Size(842, 23);
            this.statusBar.TabIndex = 3;
            this.statusBar.Text = "statusBar";
            // 
            // statusBarPanel
            // 
            this.statusBarPanel.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel.Name = "statusBarPanel";
            this.statusBarPanel.Text = " Please select chart to view";
            this.statusBarPanel.Width = 825;
            // 
            // toolBar
            // 
            this.toolBar.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.BackPB,
            this.ForwardPB,
            this.PreviousPB,
            this.NextPB,
            this.ViewSourcePB,
            this.HelpPB});
            this.toolBar.ButtonSize = new System.Drawing.Size(60, 50);
            this.toolBar.Divider = false;
            this.toolBar.DropDownArrows = true;
            this.toolBar.ImageList = this.toolBarImageList;
            this.toolBar.Location = new System.Drawing.Point(0, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.ShowToolTips = true;
            this.toolBar.Size = new System.Drawing.Size(842, 44);
            this.toolBar.TabIndex = 4;
            this.toolBar.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);
            // 
            // BackPB
            // 
            this.BackPB.Enabled = false;
            this.BackPB.ImageIndex = 0;
            this.BackPB.Name = "BackPB";
            this.BackPB.Text = "Back";
            // 
            // ForwardPB
            // 
            this.ForwardPB.Enabled = false;
            this.ForwardPB.ImageIndex = 1;
            this.ForwardPB.Name = "ForwardPB";
            this.ForwardPB.Text = "Forward";
            // 
            // PreviousPB
            // 
            this.PreviousPB.ImageIndex = 2;
            this.PreviousPB.Name = "PreviousPB";
            this.PreviousPB.Text = "Previous";
            // 
            // NextPB
            // 
            this.NextPB.ImageIndex = 3;
            this.NextPB.Name = "NextPB";
            this.NextPB.Text = "Next";
            // 
            // ViewSourcePB
            // 
            this.ViewSourcePB.ImageIndex = 4;
            this.ViewSourcePB.Name = "ViewSourcePB";
            this.ViewSourcePB.Text = "View Code";
            // 
            // HelpPB
            // 
            this.HelpPB.ImageIndex = 5;
            this.HelpPB.Name = "HelpPB";
            this.HelpPB.Text = "View Doc";
            // 
            // toolBarImageList
            // 
            this.toolBarImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("toolBarImageList.ImageStream")));
            this.toolBarImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.toolBarImageList.Images.SetKeyName(0, "");
            this.toolBarImageList.Images.SetKeyName(1, "");
            this.toolBarImageList.Images.SetKeyName(2, "");
            this.toolBarImageList.Images.SetKeyName(3, "");
            this.toolBarImageList.Images.SetKeyName(4, "");
            this.toolBarImageList.Images.SetKeyName(5, "");
            // 
            // treeView
            // 
            this.treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView.HotTracking = true;
            this.treeView.ImageIndex = 0;
            this.treeView.ImageList = this.treeViewImageList;
            this.treeView.ItemHeight = 16;
            this.treeView.Location = new System.Drawing.Point(0, 44);
            this.treeView.Name = "treeView";
            this.treeView.SelectedImageIndex = 0;
            this.treeView.Size = new System.Drawing.Size(252, 439);
            this.treeView.TabIndex = 5;
            this.treeView.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeCollapse);
            this.treeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView_BeforeExpand);
            this.treeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_AfterSelect);
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.treeViewImageList.Images.SetKeyName(0, "");
            this.treeViewImageList.Images.SetKeyName(1, "");
            this.treeViewImageList.Images.SetKeyName(2, "");
            this.treeViewImageList.Images.SetKeyName(3, "");
            this.treeViewImageList.Images.SetKeyName(4, "");
            this.treeViewImageList.Images.SetKeyName(5, "");
            this.treeViewImageList.Images.SetKeyName(6, "");
            this.treeViewImageList.Images.SetKeyName(7, "");
            this.treeViewImageList.Images.SetKeyName(8, "");
            this.treeViewImageList.Images.SetKeyName(9, "");
            this.treeViewImageList.Images.SetKeyName(10, "");
            this.treeViewImageList.Images.SetKeyName(11, "");
            this.treeViewImageList.Images.SetKeyName(12, "");
            this.treeViewImageList.Images.SetKeyName(13, "");
            this.treeViewImageList.Images.SetKeyName(14, "");
            this.treeViewImageList.Images.SetKeyName(15, "");
            this.treeViewImageList.Images.SetKeyName(16, "");
            this.treeViewImageList.Images.SetKeyName(17, "");
            this.treeViewImageList.Images.SetKeyName(18, "");
            // 
            // splitter
            // 
            this.splitter.Location = new System.Drawing.Point(252, 44);
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(4, 439);
            this.splitter.TabIndex = 6;
            this.splitter.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.AutoScroll = true;
            this.rightPanel.BackColor = System.Drawing.SystemColors.Window;
            this.rightPanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.rightPanel.Controls.Add(this.chartViewer8);
            this.rightPanel.Controls.Add(this.chartViewer7);
            this.rightPanel.Controls.Add(this.chartViewer6);
            this.rightPanel.Controls.Add(this.chartViewer5);
            this.rightPanel.Controls.Add(this.chartViewer4);
            this.rightPanel.Controls.Add(this.chartViewer3);
            this.rightPanel.Controls.Add(this.chartViewer2);
            this.rightPanel.Controls.Add(this.line);
            this.rightPanel.Controls.Add(this.title);
            this.rightPanel.Controls.Add(this.chartViewer1);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(256, 44);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(586, 439);
            this.rightPanel.TabIndex = 7;
            this.rightPanel.Layout += new System.Windows.Forms.LayoutEventHandler(this.rightPanel_Layout);
            // 
            // chartViewer8
            // 
            this.chartViewer8.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer8.Location = new System.Drawing.Point(442, 155);
            this.chartViewer8.Name = "chartViewer8";
            this.chartViewer8.Size = new System.Drawing.Size(134, 106);
            this.chartViewer8.TabIndex = 9;
            this.chartViewer8.TabStop = false;
            this.chartViewer8.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // chartViewer7
            // 
            this.chartViewer7.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer7.Location = new System.Drawing.Point(298, 155);
            this.chartViewer7.Name = "chartViewer7";
            this.chartViewer7.Size = new System.Drawing.Size(134, 106);
            this.chartViewer7.TabIndex = 8;
            this.chartViewer7.TabStop = false;
            this.chartViewer7.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // chartViewer6
            // 
            this.chartViewer6.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer6.Location = new System.Drawing.Point(154, 155);
            this.chartViewer6.Name = "chartViewer6";
            this.chartViewer6.Size = new System.Drawing.Size(134, 106);
            this.chartViewer6.TabIndex = 7;
            this.chartViewer6.TabStop = false;
            this.chartViewer6.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // chartViewer5
            // 
            this.chartViewer5.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer5.Location = new System.Drawing.Point(7, 155);
            this.chartViewer5.Name = "chartViewer5";
            this.chartViewer5.Size = new System.Drawing.Size(135, 106);
            this.chartViewer5.TabIndex = 6;
            this.chartViewer5.TabStop = false;
            this.chartViewer5.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // chartViewer4
            // 
            this.chartViewer4.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer4.Location = new System.Drawing.Point(442, 41);
            this.chartViewer4.Name = "chartViewer4";
            this.chartViewer4.Size = new System.Drawing.Size(134, 105);
            this.chartViewer4.TabIndex = 5;
            this.chartViewer4.TabStop = false;
            this.chartViewer4.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // chartViewer3
            // 
            this.chartViewer3.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer3.Location = new System.Drawing.Point(298, 41);
            this.chartViewer3.Name = "chartViewer3";
            this.chartViewer3.Size = new System.Drawing.Size(134, 105);
            this.chartViewer3.TabIndex = 4;
            this.chartViewer3.TabStop = false;
            this.chartViewer3.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // chartViewer2
            // 
            this.chartViewer2.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer2.Location = new System.Drawing.Point(154, 41);
            this.chartViewer2.Name = "chartViewer2";
            this.chartViewer2.Size = new System.Drawing.Size(134, 105);
            this.chartViewer2.TabIndex = 3;
            this.chartViewer2.TabStop = false;
            this.chartViewer2.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // line
            // 
            this.line.BackColor = System.Drawing.Color.DarkBlue;
            this.line.Dock = System.Windows.Forms.DockStyle.Top;
            this.line.Location = new System.Drawing.Point(0, 29);
            this.line.Name = "line";
            this.line.Size = new System.Drawing.Size(582, 3);
            this.line.TabIndex = 2;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Dock = System.Windows.Forms.DockStyle.Top;
            this.title.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(494, 29);
            this.title.TabIndex = 1;
            this.title.Text = "Up to 8 charts in each demo module";
            // 
            // chartViewer1
            // 
            this.chartViewer1.HotSpotCursor = System.Windows.Forms.Cursors.Hand;
            this.chartViewer1.Location = new System.Drawing.Point(10, 41);
            this.chartViewer1.Name = "chartViewer1";
            this.chartViewer1.Size = new System.Drawing.Size(134, 105);
            this.chartViewer1.TabIndex = 0;
            this.chartViewer1.TabStop = false;
            this.chartViewer1.ClickHotSpot += new ChartDirector.WinHotSpotEventHandler(this.chartViewer_ClickHotSpot);
            // 
            // ChartExplorer
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(842, 506);
            this.Controls.Add(this.rightPanel);
            this.Controls.Add(this.splitter);
            this.Controls.Add(this.treeView);
            this.Controls.Add(this.toolBar);
            this.Controls.Add(this.statusBar);
            this.Name = "ChartExplorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChartDirector Sample Charts";
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.rightPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartViewer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// Handler for the TreeView BeforeExpand event
		/// </summary>
		private void treeView_BeforeExpand(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			// Change the node to use the open folder icon when the node expands
			e.Node.SelectedImageIndex = e.Node.ImageIndex = 1;
		}

		/// <summary>
		/// Handler for the TreeView BeforeCollapse event
		/// </summary>
		private void treeView_BeforeCollapse(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			// Change the node to use the clode folder icon when the node collapse
			e.Node.SelectedImageIndex = e.Node.ImageIndex = 0;
		}

		/// <summary>
		/// Handler for the TreeView AfterSelect event
		/// </summary>
		private void treeView_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			// Check if a demo module node is selected. Demo module is attached to the node
			// as the Tag property
			DemoModule demo = (DemoModule)e.Node.Tag;
			if (demo != null)
			{
				// Display the title
				title.Text = demo.getName();

				// Clear all ChartViewers
				for (int i = 0; i < chartViewers.Length; ++i)
					chartViewers[i].Visible = false;

				// Each demo module can display a number of charts
				int noOfCharts = demo.getNoOfCharts();
				for (int i = 0; i < noOfCharts; ++i)
				{
					demo.createChart(chartViewers[i], "" + i);
					chartViewers[i].Visible = true;
				}
						
				// Now perform flow layout of the charts (viewers) 
				layoutCharts();

				// Add current node to the history array to support Back/Forward browsing
				addHistory(e.Node);
			}

			// Update the state of the buttons, status bar, etc.
			updateControls();
		}

		/// <summary>
		/// Helper method to perform a flow layout (left to right, top to bottom) of
		/// the chart.
		/// </summary>
		private void layoutCharts()
		{
			// Margin between the charts
			int margin = 5;

			// The first chart is always at the position as seen on the visual designer
			ChartDirector.WinChartViewer viewer =  chartViewers[0];
			viewer.Top = line.Bottom + margin;

			// The next chart is at the left of the first chart
			int currentX = viewer.Left + viewer.Width + margin;
			int currentY = viewer.Top;

			// The line height of a line of charts is that of the tallest chart in the line
			int lineHeight = viewer.Height;
			
			// Now layout subsequent charts (other than the first chart)
			for (int i = 1; i < chartViewers.Length; ++i)
			{
				viewer = chartViewers[i];
				
				// Layout only visible charts
				if (!viewer.Visible)
					continue;

				// Check for enough space on the left before it hits the panel border
				if (currentX + viewer.Width > rightPanel.Width)
				{
					// Not enough space, so move to the next line

					// Start of line is to align with the left of the first chart
					currentX = chartViewers[0].Left;

					// Adjust vertical by lineHeight plus a margin
					currentY += lineHeight + margin;

					// Reset the lineHeight
					lineHeight = 0;
				}
				
				// Put the chart at the current position
				viewer.Left = currentX;
				viewer.Top = currentY;

				// Advance the current position to the left prepare for the next chart
				currentX += viewer.Width + margin;

				// Update the lineHeight to reflect the tallest chart so far encountered
				// in the same line
				if (lineHeight < viewer.Height)
					lineHeight = viewer.Height;
			}
		}

		/// <summary>
		/// Add a selected node to the history array
		/// </summary>
		private void addHistory(TreeNode node)
		{
			// Don't add if selected node is current node to avoid duplication.
			if ((currentHistoryIndex >= 0) && (node == history[currentHistoryIndex]))
				return;

			// Check if the history array is full
			if (currentHistoryIndex + 1 >= history.Length)
			{
				// History array is full. Remove oldest 25% from the history array.
				// We add 1 to make sure at least 1 item is removed.
				int itemsToDiscard = history.Length / 4 + 1;

				// Remove the oldest items by shifting the array. 
				for (int i = itemsToDiscard; i < history.Length; ++i)
					history[i - itemsToDiscard] = history[i];
				
				// Adjust index because array is shifted.
				currentHistoryIndex = history.Length - itemsToDiscard;
			}
			
			// Add node to history array
			history[++currentHistoryIndex] = node;

			// After adding a new node, the forward button is always disabled. (This
			// is consistent with normal browser behaviour.) That means the last 
			// history node is always assumed to be the current node. 
			lastHistoryIndex = currentHistoryIndex;
		}

		/// <summary>
		/// Handler for the ToolBar ButtonClick event
		/// </summary>
		private void toolBar_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			//
			// Execute handler depending on which button is pressed
			//
			if (e.Button == BackPB)
				backHistory();
			else if (e.Button == ForwardPB)
				forwardHistory();
			else if (e.Button == NextPB)
				nextNode();
			else if (e.Button == PreviousPB)
				prevNode();
			else if (e.Button == ViewSourcePB)
				viewSource();
			else if (e.Button == HelpPB)
				help();
		}
		
		/// <summary>
		/// Handler for the Back button
		/// </summary>
		private void backHistory()
		{
			// Select the previous node in the history array
			if (currentHistoryIndex > 0)
				treeView.SelectedNode = history[--currentHistoryIndex];
		}

		/// <summary>
		/// Handler for the Forward button
		/// </summary>
		private void forwardHistory()
		{
			// Select the next node in the history array
			if (lastHistoryIndex > currentHistoryIndex)
				treeView.SelectedNode = history[++currentHistoryIndex];
		}

		/// <summary>
		/// Handler for the Next button
		/// </summary>
		private void nextNode()
		{
			// Getnext chart node of the current selected node by going down the tree
			TreeNode node = getNextChartNode(treeView.SelectedNode);
			
			// Display the node if available
			if (node != null)
				treeView.SelectedNode = node;
		}
		
		/// <summary>
		/// Helper method to go to the next chart node down the tree
		/// </summary>
		private TreeNode getNextChartNode(TreeNode node)
		{
			// Get the next node of by going down the tree
			node = getNextNode(node);
			
			// Skip nodes that are not associated with charts (e.g the folder nodes)
			while ((node != null) && (node.Tag == null))
				node = getNextNode(node);

			return node;
		}
			
		/// <summary>
		/// Helper method to go to the next node down the tree
		/// </summary>
		private TreeNode getNextNode(TreeNode node)
		{
			if (node == null)
				return null;
			
			// If the current node is a folder, the next node is the first child.
			if (node.FirstNode != null)
				return node.FirstNode;
			
			while (node != null)
			{
				// If there is a next sibling node, it is the next node.
				if (node.NextNode != null)
					return node.NextNode;

				// If there is no sibling node, the next node is the next sibling 
				// of the parent node. So we go back to the parent and loop again.
				node = node.Parent;
			}

			// No next node - must be already the last node.
            return null;
		}

		/// <summary>
		/// Handler for the Previous button
		/// </summary>
		private void prevNode()
		{
			// Get previous chart node of the current selected node by going up the tree
			TreeNode node = getPrevChartNode(treeView.SelectedNode);

			// Display the node if available
			if (node != null)
				treeView.SelectedNode = node;
		}
		
		/// <summary>
		/// Helper method to go to the previous chart node down the tree
		/// </summary>
		private TreeNode getPrevChartNode(TreeNode node)
		{
			// Get the prev node of by going up the tree
			node = getPrevNode(node);
			
			// Skip nodes that are not associated with charts (e.g the folder nodes)
			while ((node != null) && (node.Tag == null))
				node = getPrevNode(node);

			return node;
		}
		
		/// <summary>
		/// Helper method to go to the previous node up the tree
		/// </summary>
		private TreeNode getPrevNode(TreeNode node)
		{
			if (node == null)
				return null;
			
			// If there is no previous sibling node, the previous node must be its
			// parent. 
			if (node.PrevNode == null)
				return node.Parent;
		
			// If there is a previous sibling node, the previous node is the last
			// child of the previous sibling (if it has any child at all).
			node = node.PrevNode;
			while (node.LastNode != null)
				node = node.LastNode;

			return node;
		}

		/// <summary>
		/// Handler for the View Source button
		/// </summary>
		private void viewSource()
		{
			// Get the path name of the help file
			string helpFilePath = getHelpPath();
			if ((helpFilePath != null) && (currentHistoryIndex >= 0))
			{
                DemoModule m = (DemoModule)(history[currentHistoryIndex].Tag);
				Help.ShowHelp(this, helpFilePath, HelpNavigator.Topic, m.GetType().Name + ".htm");
			}
		}

		/// <summary>
		/// Handler for the View Doc button
		/// </summary>
		private void help()
		{
			// Get the path name of the help file
			string helpFilePath = getHelpPath();
			if (helpFilePath != null)
				Help.ShowHelp(this, helpFilePath);
		}

		/// <summary>
		/// Helper method to get the path name of the help file
		/// </summary>
		private string getHelpPath()
		{
			string helpfile = "netchartdir.chm";

			// To allow this program to run more robustly, we search for various
			// place for the help file.
			string [] placeToSearch = new string[] 
			{
				"",					// search the current directory
				"../../../doc/",	// the install directory of the help file relative 
									// to the "bin" subdirectory of the VS.NET project
									// when installed by the ChartDirector installer.
				"../",				// the project directory of VS.NET (relative to "bin")
				"../../"			// the solution directory of VS.NET (relative to "bin")
			};

			// Return the first directory that contains the help file
			for (int i = 0; i < placeToSearch.Length; ++i)
			{
				if (System.IO.File.Exists(placeToSearch[i] + helpfile))
					return placeToSearch[i] + helpfile;
			}

			// Help file not found ???
			MessageBox.Show("Cannot locate help file " + helpfile + ".", "Help Error",
				MessageBoxButtons.OK, MessageBoxIcon.Error);

			return null;
		}

		/// <summary>
		/// Helper method to update the various controls
		/// </summary>
		private void updateControls()
		{
			//
			// Enable the various buttons there is really something they can do.
			//
			BackPB.Enabled = (currentHistoryIndex > 0);
			ForwardPB.Enabled = (lastHistoryIndex > currentHistoryIndex);
			NextPB.Enabled = (getNextChartNode(treeView.SelectedNode) != null);
			PreviousPB.Enabled = (getPrevChartNode(treeView.SelectedNode) != null);

			// The status bar always reflects the selected demo module
			if ((null != treeView.SelectedNode) && (null != treeView.SelectedNode.Tag))
			{
				DemoModule m = (DemoModule)treeView.SelectedNode.Tag;
				statusBarPanel.Text = " Module " + m.GetType().Name + ": " + m.getName();
			}
			else
				statusBarPanel.Text = "";
		}

		/// <summary>
		/// Handler for the panel layout event
		/// </summary>
		private void rightPanel_Layout(object sender, System.Windows.Forms.LayoutEventArgs e)
		{
			// Perform flow layout of the charts 
			if (chartViewers != null)
				layoutCharts();
		}

		/// <summary>
		/// Handler for the ClickHotSpot event, which occurs when the mouse clicks on 
		/// a hot spot on the chart
		/// </summary>
		private void chartViewer_ClickHotSpot(object sender, ChartDirector.WinHotSpotEventArgs e)
		{
			// In this demo, just list out the information provided by ChartDirector about hot spot
			new ParamViewer().Display(sender, e);
		}
	}
}

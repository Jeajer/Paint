namespace Paint
{
    partial class GraphicsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GraphicsForm));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ribbonTab1 = new System.Windows.Forms.RibbonTab();
            this.drawPanel = new System.Windows.Forms.RibbonPanel();
            this.zoomPanel = new System.Windows.Forms.RibbonPanel();
            this.modifyTab = new System.Windows.Forms.RibbonTab();
            this.editPanel = new System.Windows.Forms.RibbonPanel();
            this.popup = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cancelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.coordinate = new System.Windows.Forms.ToolStripStatusLabel();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.vScrollBar = new System.Windows.Forms.VScrollBar();
            this.drawing = new System.Windows.Forms.PictureBox();
            this.pointBtn = new System.Windows.Forms.RibbonButton();
            this.lineBtn = new System.Windows.Forms.RibbonButton();
            this.circleBtn = new System.Windows.Forms.RibbonButton();
            this.circleBtn21 = new System.Windows.Forms.RibbonButton();
            this.circleBtn23 = new System.Windows.Forms.RibbonButton();
            this.circleBtn22 = new System.Windows.Forms.RibbonButton();
            this.circleBtn24 = new System.Windows.Forms.RibbonButton();
            this.ellipseBtn = new System.Windows.Forms.RibbonButton();
            this.ellipseBtn31 = new System.Windows.Forms.RibbonButton();
            this.ellipseBtn32 = new System.Windows.Forms.RibbonButton();
            this.arcBtn = new System.Windows.Forms.RibbonButton();
            this.arcBtn11 = new System.Windows.Forms.RibbonButton();
            this.arcBtn12 = new System.Windows.Forms.RibbonButton();
            this.arcBtn13 = new System.Windows.Forms.RibbonButton();
            this.arcBtn14 = new System.Windows.Forms.RibbonButton();
            this.arcBtn15 = new System.Windows.Forms.RibbonButton();
            this.arcBtn16 = new System.Windows.Forms.RibbonButton();
            this.arcBtn17 = new System.Windows.Forms.RibbonButton();
            this.polylineBtn = new System.Windows.Forms.RibbonButton();
            this.rectangleBtn = new System.Windows.Forms.RibbonButton();
            this.polygonBtn = new System.Windows.Forms.RibbonButton();
            this.zoomInBtn = new System.Windows.Forms.RibbonButton();
            this.zoomoutBtn = new System.Windows.Forms.RibbonButton();
            this.zoomWinBtn = new System.Windows.Forms.RibbonButton();
            this.copyBtn = new System.Windows.Forms.RibbonButton();
            this.moveBtn = new System.Windows.Forms.RibbonButton();
            this.rotateBtn = new System.Windows.Forms.RibbonButton();
            this.mirrorBtn = new System.Windows.Forms.RibbonButton();
            this.popup.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.CaptionBarVisible = false;
            this.ribbon1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 447);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ribbon1.Size = new System.Drawing.Size(1091, 175);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ribbonTab1);
            this.ribbon1.Tabs.Add(this.modifyTab);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue_2010;
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Panels.Add(this.drawPanel);
            this.ribbonTab1.Panels.Add(this.zoomPanel);
            this.ribbonTab1.Text = "Drawing";
            // 
            // drawPanel
            // 
            this.drawPanel.ButtonMoreEnabled = false;
            this.drawPanel.ButtonMoreVisible = false;
            this.drawPanel.Items.Add(this.pointBtn);
            this.drawPanel.Items.Add(this.lineBtn);
            this.drawPanel.Items.Add(this.circleBtn);
            this.drawPanel.Items.Add(this.ellipseBtn);
            this.drawPanel.Items.Add(this.arcBtn);
            this.drawPanel.Items.Add(this.polylineBtn);
            this.drawPanel.Items.Add(this.rectangleBtn);
            this.drawPanel.Items.Add(this.polygonBtn);
            this.drawPanel.Name = "drawPanel";
            this.drawPanel.Text = "";
            // 
            // zoomPanel
            // 
            this.zoomPanel.ButtonMoreVisible = false;
            this.zoomPanel.Items.Add(this.zoomInBtn);
            this.zoomPanel.Items.Add(this.zoomoutBtn);
            this.zoomPanel.Items.Add(this.zoomWinBtn);
            this.zoomPanel.Name = "zoomPanel";
            this.zoomPanel.Text = "";
            // 
            // modifyTab
            // 
            this.modifyTab.Name = "modifyTab";
            this.modifyTab.Panels.Add(this.editPanel);
            this.modifyTab.Text = "Modify";
            // 
            // editPanel
            // 
            this.editPanel.ButtonMoreVisible = false;
            this.editPanel.Items.Add(this.copyBtn);
            this.editPanel.Items.Add(this.moveBtn);
            this.editPanel.Items.Add(this.rotateBtn);
            this.editPanel.Items.Add(this.mirrorBtn);
            this.editPanel.Name = "editPanel";
            this.editPanel.Text = "";
            // 
            // popup
            // 
            this.popup.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popup.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.popup.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cancelToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.popup.Name = "popup";
            this.popup.Size = new System.Drawing.Size(136, 60);
            // 
            // cancelToolStripMenuItem
            // 
            this.cancelToolStripMenuItem.Name = "cancelToolStripMenuItem";
            this.cancelToolStripMenuItem.Size = new System.Drawing.Size(135, 28);
            this.cancelToolStripMenuItem.Text = "Cancel";
            this.cancelToolStripMenuItem.Click += new System.EventHandler(this.cancelToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(135, 28);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeBoundary_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordinate});
            this.statusStrip.Location = new System.Drawing.Point(0, 551);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1091, 30);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // coordinate
            // 
            this.coordinate.Name = "coordinate";
            this.coordinate.Size = new System.Drawing.Size(165, 24);
            this.coordinate.Text = "0.000, 0.000, 0.000";
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(0, 527);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(1091, 21);
            this.hScrollBar.TabIndex = 4;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // vScrollBar
            // 
            this.vScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vScrollBar.Location = new System.Drawing.Point(1070, 178);
            this.vScrollBar.Name = "vScrollBar";
            this.vScrollBar.Size = new System.Drawing.Size(21, 346);
            this.vScrollBar.TabIndex = 5;
            this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
            // 
            // drawing
            // 
            this.drawing.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawing.ContextMenuStrip = this.popup;
            this.drawing.Location = new System.Drawing.Point(0, 178);
            this.drawing.Name = "drawing";
            this.drawing.Size = new System.Drawing.Size(1067, 346);
            this.drawing.TabIndex = 1;
            this.drawing.TabStop = false;
            this.drawing.Paint += new System.Windows.Forms.PaintEventHandler(this.drawing_Paint);
            this.drawing.MouseDown += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseDown);
            this.drawing.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseMove);
            this.drawing.MouseUp += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseUp);
            this.drawing.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.drawing_MouseWheel);
            // 
            // pointBtn
            // 
            this.pointBtn.Image = global::Paint.Properties.Resources.point_icon;
            this.pointBtn.LargeImage = global::Paint.Properties.Resources.point_icon;
            this.pointBtn.Name = "pointBtn";
            this.pointBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("pointBtn.SmallImage")));
            this.pointBtn.Text = "Point";
            this.pointBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // lineBtn
            // 
            this.lineBtn.Image = global::Paint.Properties.Resources.line_icon;
            this.lineBtn.LargeImage = global::Paint.Properties.Resources.line_icon;
            this.lineBtn.Name = "lineBtn";
            this.lineBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("lineBtn.SmallImage")));
            this.lineBtn.Text = "Line";
            this.lineBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // circleBtn
            // 
            this.circleBtn.DropDownItems.Add(this.circleBtn21);
            this.circleBtn.DropDownItems.Add(this.circleBtn23);
            this.circleBtn.DropDownItems.Add(this.circleBtn22);
            this.circleBtn.DropDownItems.Add(this.circleBtn24);
            this.circleBtn.Image = global::Paint.Properties.Resources.circle_icon;
            this.circleBtn.LargeImage = global::Paint.Properties.Resources.circle_icon;
            this.circleBtn.Name = "circleBtn";
            this.circleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn.SmallImage")));
            this.circleBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.circleBtn.Text = "Circle";
            // 
            // circleBtn21
            // 
            this.circleBtn21.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.circleBtn21.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn21.Image")));
            this.circleBtn21.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.LargeImage")));
            this.circleBtn21.Name = "circleBtn21";
            this.circleBtn21.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn21.SmallImage")));
            this.circleBtn21.Text = "Center, Radius";
            this.circleBtn21.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // circleBtn23
            // 
            this.circleBtn23.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.circleBtn23.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn23.Image")));
            this.circleBtn23.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn23.LargeImage")));
            this.circleBtn23.Name = "circleBtn23";
            this.circleBtn23.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn23.SmallImage")));
            this.circleBtn23.Text = "Center, Diameter";
            this.circleBtn23.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // circleBtn22
            // 
            this.circleBtn22.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.circleBtn22.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn22.Image")));
            this.circleBtn22.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn22.LargeImage")));
            this.circleBtn22.Name = "circleBtn22";
            this.circleBtn22.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn22.SmallImage")));
            this.circleBtn22.Text = "3-Points";
            this.circleBtn22.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // circleBtn24
            // 
            this.circleBtn24.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.circleBtn24.Image = ((System.Drawing.Image)(resources.GetObject("circleBtn24.Image")));
            this.circleBtn24.LargeImage = ((System.Drawing.Image)(resources.GetObject("circleBtn24.LargeImage")));
            this.circleBtn24.Name = "circleBtn24";
            this.circleBtn24.SmallImage = ((System.Drawing.Image)(resources.GetObject("circleBtn24.SmallImage")));
            this.circleBtn24.Text = "2-Points";
            this.circleBtn24.Click += new System.EventHandler(this.CircleBtn_Click);
            // 
            // ellipseBtn
            // 
            this.ellipseBtn.DropDownItems.Add(this.ellipseBtn31);
            this.ellipseBtn.DropDownItems.Add(this.ellipseBtn32);
            this.ellipseBtn.Image = global::Paint.Properties.Resources.ellipse_icon;
            this.ellipseBtn.LargeImage = global::Paint.Properties.Resources.ellipse_icon;
            this.ellipseBtn.Name = "ellipseBtn";
            this.ellipseBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn.SmallImage")));
            this.ellipseBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.ellipseBtn.Text = "Ellipse";
            // 
            // ellipseBtn31
            // 
            this.ellipseBtn31.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ellipseBtn31.Image = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.Image")));
            this.ellipseBtn31.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.LargeImage")));
            this.ellipseBtn31.Name = "ellipseBtn31";
            this.ellipseBtn31.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn31.SmallImage")));
            this.ellipseBtn31.Text = "Full ellipse";
            this.ellipseBtn31.Click += new System.EventHandler(this.EllipseBtn_Click);
            // 
            // ellipseBtn32
            // 
            this.ellipseBtn32.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ellipseBtn32.Image = ((System.Drawing.Image)(resources.GetObject("ellipseBtn32.Image")));
            this.ellipseBtn32.LargeImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn32.LargeImage")));
            this.ellipseBtn32.Name = "ellipseBtn32";
            this.ellipseBtn32.SmallImage = ((System.Drawing.Image)(resources.GetObject("ellipseBtn32.SmallImage")));
            this.ellipseBtn32.Text = "Elliptical arc";
            this.ellipseBtn32.Click += new System.EventHandler(this.EllipseBtn_Click);
            // 
            // arcBtn
            // 
            this.arcBtn.DropDownItems.Add(this.arcBtn11);
            this.arcBtn.DropDownItems.Add(this.arcBtn12);
            this.arcBtn.DropDownItems.Add(this.arcBtn13);
            this.arcBtn.DropDownItems.Add(this.arcBtn14);
            this.arcBtn.DropDownItems.Add(this.arcBtn15);
            this.arcBtn.DropDownItems.Add(this.arcBtn16);
            this.arcBtn.DropDownItems.Add(this.arcBtn17);
            this.arcBtn.Image = global::Paint.Properties.Resources.arc_icon;
            this.arcBtn.LargeImage = global::Paint.Properties.Resources.arc_icon;
            this.arcBtn.Name = "arcBtn";
            this.arcBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn.SmallImage")));
            this.arcBtn.Style = System.Windows.Forms.RibbonButtonStyle.DropDown;
            this.arcBtn.Text = "Arc";
            // 
            // arcBtn11
            // 
            this.arcBtn11.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn11.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn11.Image")));
            this.arcBtn11.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn11.LargeImage")));
            this.arcBtn11.Name = "arcBtn11";
            this.arcBtn11.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn11.SmallImage")));
            this.arcBtn11.Text = "3-Point";
            this.arcBtn11.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBtn12
            // 
            this.arcBtn12.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn12.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn12.Image")));
            this.arcBtn12.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn12.LargeImage")));
            this.arcBtn12.Name = "arcBtn12";
            this.arcBtn12.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn12.SmallImage")));
            this.arcBtn12.Text = "Start, Center, End";
            this.arcBtn12.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBtn13
            // 
            this.arcBtn13.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn13.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn13.Image")));
            this.arcBtn13.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn13.LargeImage")));
            this.arcBtn13.Name = "arcBtn13";
            this.arcBtn13.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn13.SmallImage")));
            this.arcBtn13.Text = "Center, Start, End";
            this.arcBtn13.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBtn14
            // 
            this.arcBtn14.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn14.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn14.Image")));
            this.arcBtn14.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn14.LargeImage")));
            this.arcBtn14.Name = "arcBtn14";
            this.arcBtn14.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn14.SmallImage")));
            this.arcBtn14.Text = "Center, Start, Angle";
            this.arcBtn14.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBtn15
            // 
            this.arcBtn15.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn15.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn15.Image")));
            this.arcBtn15.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn15.LargeImage")));
            this.arcBtn15.Name = "arcBtn15";
            this.arcBtn15.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn15.SmallImage")));
            this.arcBtn15.Text = "Center, Start, Length";
            this.arcBtn15.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBtn16
            // 
            this.arcBtn16.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn16.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn16.Image")));
            this.arcBtn16.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn16.LargeImage")));
            this.arcBtn16.Name = "arcBtn16";
            this.arcBtn16.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn16.SmallImage")));
            this.arcBtn16.Text = "Start, End, Angle";
            this.arcBtn16.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // arcBtn17
            // 
            this.arcBtn17.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.arcBtn17.Image = ((System.Drawing.Image)(resources.GetObject("arcBtn17.Image")));
            this.arcBtn17.LargeImage = ((System.Drawing.Image)(resources.GetObject("arcBtn17.LargeImage")));
            this.arcBtn17.Name = "arcBtn17";
            this.arcBtn17.SmallImage = ((System.Drawing.Image)(resources.GetObject("arcBtn17.SmallImage")));
            this.arcBtn17.Text = "Start, Center, Length";
            this.arcBtn17.Click += new System.EventHandler(this.ArcBtn_Click);
            // 
            // polylineBtn
            // 
            this.polylineBtn.Image = global::Paint.Properties.Resources.polyline_icon;
            this.polylineBtn.LargeImage = global::Paint.Properties.Resources.polyline_icon;
            this.polylineBtn.Name = "polylineBtn";
            this.polylineBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("polylineBtn.SmallImage")));
            this.polylineBtn.Text = "Polyline";
            this.polylineBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // rectangleBtn
            // 
            this.rectangleBtn.Image = global::Paint.Properties.Resources.rectangle_icon1;
            this.rectangleBtn.LargeImage = global::Paint.Properties.Resources.rectangle_icon1;
            this.rectangleBtn.Name = "rectangleBtn";
            this.rectangleBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("rectangleBtn.SmallImage")));
            this.rectangleBtn.Text = "Rectangle";
            this.rectangleBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // polygonBtn
            // 
            this.polygonBtn.Image = global::Paint.Properties.Resources.polygon_icon;
            this.polygonBtn.LargeImage = global::Paint.Properties.Resources.polygon_icon;
            this.polygonBtn.Name = "polygonBtn";
            this.polygonBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("polygonBtn.SmallImage")));
            this.polygonBtn.Text = "Polygon";
            this.polygonBtn.Click += new System.EventHandler(this.DrawBtn_Click);
            // 
            // zoomInBtn
            // 
            this.zoomInBtn.Image = global::Paint.Properties.Resources.zoom_in;
            this.zoomInBtn.LargeImage = global::Paint.Properties.Resources.zoom_in;
            this.zoomInBtn.Name = "zoomInBtn";
            this.zoomInBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomInBtn.SmallImage")));
            this.zoomInBtn.Text = "Zoom in";
            this.zoomInBtn.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.zoomInBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
            // 
            // zoomoutBtn
            // 
            this.zoomoutBtn.Image = global::Paint.Properties.Resources.zoom_out;
            this.zoomoutBtn.LargeImage = global::Paint.Properties.Resources.zoom_out;
            this.zoomoutBtn.Name = "zoomoutBtn";
            this.zoomoutBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomoutBtn.SmallImage")));
            this.zoomoutBtn.Text = "Zoom out";
            this.zoomoutBtn.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.zoomoutBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
            // 
            // zoomWinBtn
            // 
            this.zoomWinBtn.Image = global::Paint.Properties.Resources.zoom_win;
            this.zoomWinBtn.LargeImage = global::Paint.Properties.Resources.zoom_win;
            this.zoomWinBtn.Name = "zoomWinBtn";
            this.zoomWinBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("zoomWinBtn.SmallImage")));
            this.zoomWinBtn.Text = "Zoom win";
            this.zoomWinBtn.TextAlignment = System.Windows.Forms.RibbonItem.RibbonItemTextAlignment.Center;
            this.zoomWinBtn.Click += new System.EventHandler(this.ZoomBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Image = global::Paint.Properties.Resources.copy_img;
            this.copyBtn.LargeImage = global::Paint.Properties.Resources.copy_img;
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("copyBtn.SmallImage")));
            this.copyBtn.Text = "Copy";
            this.copyBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // moveBtn
            // 
            this.moveBtn.Image = global::Paint.Properties.Resources.move_img;
            this.moveBtn.LargeImage = global::Paint.Properties.Resources.move_img;
            this.moveBtn.Name = "moveBtn";
            this.moveBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("moveBtn.SmallImage")));
            this.moveBtn.Text = "Move";
            this.moveBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // rotateBtn
            // 
            this.rotateBtn.Image = global::Paint.Properties.Resources.rotate;
            this.rotateBtn.LargeImage = global::Paint.Properties.Resources.rotate;
            this.rotateBtn.Name = "rotateBtn";
            this.rotateBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("rotateBtn.SmallImage")));
            this.rotateBtn.Text = "Rotate";
            this.rotateBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // mirrorBtn
            // 
            this.mirrorBtn.Image = global::Paint.Properties.Resources.mirror;
            this.mirrorBtn.LargeImage = global::Paint.Properties.Resources.mirror;
            this.mirrorBtn.Name = "mirrorBtn";
            this.mirrorBtn.SmallImage = ((System.Drawing.Image)(resources.GetObject("mirrorBtn.SmallImage")));
            this.mirrorBtn.Text = "Mirror";
            this.mirrorBtn.Click += new System.EventHandler(this.ModifyBtn_Click);
            // 
            // GraphicsForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1091, 581);
            this.Controls.Add(this.vScrollBar);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.drawing);
            this.Controls.Add(this.ribbon1);
            this.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "GraphicsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Graphics";
            this.popup.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drawing)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab ribbonTab1;
        private System.Windows.Forms.RibbonPanel drawPanel;
        private System.Windows.Forms.RibbonButton pointBtn;
        private System.Windows.Forms.RibbonButton lineBtn;
        private System.Windows.Forms.RibbonButton circleBtn;
        private System.Windows.Forms.RibbonButton ellipseBtn;
        private System.Windows.Forms.RibbonButton arcBtn;
        private System.Windows.Forms.RibbonButton polygonBtn;
        private System.Windows.Forms.RibbonButton polylineBtn;
        private System.Windows.Forms.RibbonButton rectangleBtn;
        private System.Windows.Forms.RibbonButton circleBtn21;
        private System.Windows.Forms.RibbonButton circleBtn22;
        private System.Windows.Forms.PictureBox drawing;
        private System.Windows.Forms.ContextMenuStrip popup;
        private System.Windows.Forms.ToolStripMenuItem cancelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel coordinate;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.VScrollBar vScrollBar;
        private System.Windows.Forms.RibbonButton arcBtn11;
        private System.Windows.Forms.RibbonButton arcBtn12;
        private System.Windows.Forms.RibbonButton arcBtn13;
        private System.Windows.Forms.RibbonButton arcBtn14;
        private System.Windows.Forms.RibbonButton arcBtn15;
        private System.Windows.Forms.RibbonButton arcBtn16;
        private System.Windows.Forms.RibbonButton arcBtn17;
        private System.Windows.Forms.RibbonButton circleBtn23;
        private System.Windows.Forms.RibbonButton circleBtn24;
        private System.Windows.Forms.RibbonButton ellipseBtn31;
        private System.Windows.Forms.RibbonButton ellipseBtn32;
        private System.Windows.Forms.RibbonPanel zoomPanel;
        private System.Windows.Forms.RibbonButton zoomInBtn;
        private System.Windows.Forms.RibbonButton zoomoutBtn;
        private System.Windows.Forms.RibbonButton zoomWinBtn;
        private System.Windows.Forms.RibbonTab modifyTab;
        private System.Windows.Forms.RibbonPanel editPanel;
        private System.Windows.Forms.RibbonButton copyBtn;
        private System.Windows.Forms.RibbonButton moveBtn;
        private System.Windows.Forms.RibbonButton rotateBtn;
        private System.Windows.Forms.RibbonButton mirrorBtn;
    }
}


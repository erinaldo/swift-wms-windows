<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmShelfSpots
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bodegas", 2, 2)
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmShelfSpots))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PanelControl1 = New DevExpress.XtraEditors.PanelControl()
        Me.SplitContainerControl1 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.SplitContainerControl3 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.PropertyGrid2 = New System.Windows.Forms.PropertyGrid()
        Me.SplitContainerControl2 = New DevExpress.XtraEditors.SplitContainerControl()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuItem_CopyPartition = New System.Windows.Forms.ToolStripMenuItem()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn_Wh = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Line = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Aisle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Column = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Location = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Module = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Allow_Fast_Picking = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn_Is_Waste = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.NewToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.SaveToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.CutToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.PrintToolStripButton = New System.Windows.Forms.ToolStripButton()
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.Panel1.SuspendLayout()
        CType(Me.PanelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelControl1.SuspendLayout()
        CType(Me.SplitContainerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl1.SuspendLayout()
        CType(Me.SplitContainerControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl3.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.SplitContainerControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainerControl2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.PanelControl1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1111, 507)
        Me.Panel1.TabIndex = 0
        '
        'PanelControl1
        '
        Me.PanelControl1.Controls.Add(Me.SplitContainerControl1)
        Me.PanelControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelControl1.Location = New System.Drawing.Point(0, 0)
        Me.PanelControl1.Name = "PanelControl1"
        Me.PanelControl1.Size = New System.Drawing.Size(1111, 507)
        Me.PanelControl1.TabIndex = 0
        '
        'SplitContainerControl1
        '
        Me.SplitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl1.Location = New System.Drawing.Point(2, 2)
        Me.SplitContainerControl1.Name = "SplitContainerControl1"
        Me.SplitContainerControl1.Panel1.Controls.Add(Me.SplitContainerControl3)
        Me.SplitContainerControl1.Panel1.Text = "Panel1"
        Me.SplitContainerControl1.Panel2.Controls.Add(Me.SplitContainerControl2)
        Me.SplitContainerControl1.Panel2.Text = "Panel2"
        Me.SplitContainerControl1.Size = New System.Drawing.Size(1107, 503)
        Me.SplitContainerControl1.SplitterPosition = 344
        Me.SplitContainerControl1.TabIndex = 0
        Me.SplitContainerControl1.Text = "SplitContainerControl1"
        '
        'SplitContainerControl3
        '
        Me.SplitContainerControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl3.Horizontal = False
        Me.SplitContainerControl3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl3.Name = "SplitContainerControl3"
        Me.SplitContainerControl3.Panel1.Controls.Add(Me.TreeView1)
        Me.SplitContainerControl3.Panel1.Text = "Panel1"
        Me.SplitContainerControl3.Panel2.Controls.Add(Me.ToolStrip2)
        Me.SplitContainerControl3.Panel2.Controls.Add(Me.PropertyGrid2)
        Me.SplitContainerControl3.Panel2.Text = "Panel2"
        Me.SplitContainerControl3.Size = New System.Drawing.Size(344, 503)
        Me.SplitContainerControl3.SplitterPosition = 211
        Me.SplitContainerControl3.TabIndex = 0
        Me.SplitContainerControl3.Text = "SplitContainerControl3"
        '
        'TreeView1
        '
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 0)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.ImageIndex = 2
        TreeNode1.Name = "Node0"
        TreeNode1.SelectedImageIndex = 2
        TreeNode1.Text = "Bodegas"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode1})
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.Size = New System.Drawing.Size(344, 211)
        Me.TreeView1.TabIndex = 1
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "ID_WINDOW_ARRANGE_ALL_SMALL.png")
        Me.ImageList1.Images.SetKeyName(1, "ID_WINDOW_SPLIT_SMALL.png")
        Me.ImageList1.Images.SetKeyName(2, "BlockArrows15_Small.png")
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripSeparator2, Me.ToolStripButton4, Me.ToolStripSeparator3})
        Me.ToolStrip2.Location = New System.Drawing.Point(59, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(116, 25)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "&New"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "&Save"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton3.Text = "C&ut"
        Me.ToolStripButton3.ToolTipText = "Cancel"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton4.Text = "&Print"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'PropertyGrid2
        '
        Me.PropertyGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PropertyGrid2.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PropertyGrid2.Name = "PropertyGrid2"
        Me.PropertyGrid2.Size = New System.Drawing.Size(344, 282)
        Me.PropertyGrid2.TabIndex = 6
        '
        'SplitContainerControl2
        '
        Me.SplitContainerControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.SplitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainerControl2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainerControl2.Name = "SplitContainerControl2"
        Me.SplitContainerControl2.Panel1.Controls.Add(Me.GridControl1)
        Me.SplitContainerControl2.Panel1.Text = "Panel1"
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.ToolStrip1)
        Me.SplitContainerControl2.Panel2.Controls.Add(Me.PropertyGrid1)
        Me.SplitContainerControl2.Panel2.Text = "Panel2"
        Me.SplitContainerControl2.Size = New System.Drawing.Size(753, 503)
        Me.SplitContainerControl2.SplitterPosition = 449
        Me.SplitContainerControl2.TabIndex = 0
        Me.SplitContainerControl2.Text = "SplitContainerControl2"
        '
        'GridControl1
        '
        Me.GridControl1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.GridControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridControl1.Location = New System.Drawing.Point(0, 0)
        Me.GridControl1.MainView = Me.GridView1
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(449, 499)
        Me.GridControl1.TabIndex = 0
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem_CopyPartition})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(187, 26)
        '
        'ToolStripMenuItem_CopyPartition
        '
        Me.ToolStripMenuItem_CopyPartition.Image = Global.WMSOnePlan_Client.My.Resources.Resources.ChangeListLevel_Small
        Me.ToolStripMenuItem_CopyPartition.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ToolStripMenuItem_CopyPartition.Name = "ToolStripMenuItem_CopyPartition"
        Me.ToolStripMenuItem_CopyPartition.Size = New System.Drawing.Size(186, 22)
        Me.ToolStripMenuItem_CopyPartition.Text = "Copiar en Particiones"
        '
        'GridView1
        '
        Me.GridView1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn_Wh, Me.GridColumn_Line, Me.GridColumn_Aisle, Me.GridColumn_Column, Me.GridColumn_Location, Me.GridColumn_Module, Me.GridColumn_Allow_Fast_Picking, Me.GridColumn_Is_Waste})
        Me.GridView1.FixedLineWidth = 1
        Me.GridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
        Me.GridView1.GridControl = Me.GridControl1
        Me.GridView1.GroupCount = 1
        Me.GridView1.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "LOCATION_SPOT", Nothing, "")})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.SortInfo.AddRange(New DevExpress.XtraGrid.Columns.GridColumnSortInfo() {New DevExpress.XtraGrid.Columns.GridColumnSortInfo(Me.GridColumn_Module, DevExpress.Data.ColumnSortOrder.Ascending)})
        Me.GridView1.ViewCaption = "Ubicaciones"
        '
        'GridColumn_Wh
        '
        Me.GridColumn_Wh.Caption = "Bodega"
        Me.GridColumn_Wh.FieldName = "WAREHOUSE_PARENT"
        Me.GridColumn_Wh.Name = "GridColumn_Wh"
        Me.GridColumn_Wh.OptionsColumn.AllowEdit = False
        Me.GridColumn_Wh.OptionsColumn.FixedWidth = True
        Me.GridColumn_Wh.OptionsColumn.ReadOnly = True
        Me.GridColumn_Wh.Visible = True
        Me.GridColumn_Wh.VisibleIndex = 0
        Me.GridColumn_Wh.Width = 94
        '
        'GridColumn_Line
        '
        Me.GridColumn_Line.Caption = "Linea"
        Me.GridColumn_Line.FieldName = "SPOT_LINE"
        Me.GridColumn_Line.Name = "GridColumn_Line"
        Me.GridColumn_Line.OptionsColumn.AllowEdit = False
        Me.GridColumn_Line.OptionsColumn.AllowFocus = False
        Me.GridColumn_Line.OptionsColumn.ReadOnly = True
        Me.GridColumn_Line.Visible = True
        Me.GridColumn_Line.VisibleIndex = 1
        '
        'GridColumn_Aisle
        '
        Me.GridColumn_Aisle.Caption = "Rack"
        Me.GridColumn_Aisle.FieldName = "SPOT_AISLE"
        Me.GridColumn_Aisle.Name = "GridColumn_Aisle"
        Me.GridColumn_Aisle.OptionsColumn.AllowEdit = False
        Me.GridColumn_Aisle.OptionsColumn.AllowFocus = False
        Me.GridColumn_Aisle.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Aisle.OptionsColumn.AllowMerge = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn_Aisle.Visible = True
        Me.GridColumn_Aisle.VisibleIndex = 2
        '
        'GridColumn_Column
        '
        Me.GridColumn_Column.Caption = "Columna"
        Me.GridColumn_Column.FieldName = "SPOT_COLUMN"
        Me.GridColumn_Column.Name = "GridColumn_Column"
        Me.GridColumn_Column.OptionsColumn.AllowEdit = False
        Me.GridColumn_Column.OptionsColumn.AllowFocus = False
        Me.GridColumn_Column.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.[True]
        Me.GridColumn_Column.Visible = True
        Me.GridColumn_Column.VisibleIndex = 3
        '
        'GridColumn_Location
        '
        Me.GridColumn_Location.Caption = "Ubicacion"
        Me.GridColumn_Location.FieldName = "LOCATION_SPOT"
        Me.GridColumn_Location.Name = "GridColumn_Location"
        Me.GridColumn_Location.OptionsColumn.AllowEdit = False
        Me.GridColumn_Location.OptionsColumn.ReadOnly = True
        Me.GridColumn_Location.Visible = True
        Me.GridColumn_Location.VisibleIndex = 4
        '
        'GridColumn_Module
        '
        Me.GridColumn_Module.Caption = "Modulo"
        Me.GridColumn_Module.FieldName = "MODULE_PARENT"
        Me.GridColumn_Module.Name = "GridColumn_Module"
        Me.GridColumn_Module.OptionsColumn.AllowEdit = False
        Me.GridColumn_Module.OptionsColumn.ReadOnly = True
        Me.GridColumn_Module.Visible = True
        Me.GridColumn_Module.VisibleIndex = 1
        '
        'GridColumn_Allow_Fast_Picking
        '
        Me.GridColumn_Allow_Fast_Picking.Caption = "Permite Picking Rápido"
        Me.GridColumn_Allow_Fast_Picking.FieldName = "ALLOW_COLUMN_FAST_PICKING"
        Me.GridColumn_Allow_Fast_Picking.Name = "GridColumn_Allow_Fast_Picking"
        Me.GridColumn_Allow_Fast_Picking.OptionsColumn.AllowEdit = False
        Me.GridColumn_Allow_Fast_Picking.OptionsColumn.ReadOnly = True
        '
        'GridColumn_Is_Waste
        '
        Me.GridColumn_Is_Waste.Caption = "Ubicación Desperdicio"
        Me.GridColumn_Is_Waste.FieldName = "IS_COLUMN_WASTE"
        Me.GridColumn_Is_Waste.Name = "GridColumn_Is_Waste"
        Me.GridColumn_Is_Waste.OptionsColumn.AllowEdit = False
        Me.GridColumn_Is_Waste.OptionsColumn.ReadOnly = True
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripButton, Me.SaveToolStripButton, Me.CutToolStripButton, Me.toolStripSeparator, Me.PrintToolStripButton, Me.toolStripSeparator1})
        Me.ToolStrip1.Location = New System.Drawing.Point(59, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.Size = New System.Drawing.Size(116, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'NewToolStripButton
        '
        Me.NewToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.NewToolStripButton.Image = CType(resources.GetObject("NewToolStripButton.Image"), System.Drawing.Image)
        Me.NewToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.NewToolStripButton.Name = "NewToolStripButton"
        Me.NewToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.NewToolStripButton.Text = "&New"
        '
        'SaveToolStripButton
        '
        Me.SaveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SaveToolStripButton.Image = CType(resources.GetObject("SaveToolStripButton.Image"), System.Drawing.Image)
        Me.SaveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SaveToolStripButton.Name = "SaveToolStripButton"
        Me.SaveToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.SaveToolStripButton.Text = "&Save"
        '
        'CutToolStripButton
        '
        Me.CutToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.CutToolStripButton.Image = Global.WMSOnePlan_Client.My.Resources.Resources.Symbols_Delete_icon
        Me.CutToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.CutToolStripButton.Name = "CutToolStripButton"
        Me.CutToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.CutToolStripButton.Text = "C&ut"
        Me.CutToolStripButton.ToolTipText = "Cancel"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'PrintToolStripButton
        '
        Me.PrintToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.PrintToolStripButton.Image = CType(resources.GetObject("PrintToolStripButton.Image"), System.Drawing.Image)
        Me.PrintToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.PrintToolStripButton.Name = "PrintToolStripButton"
        Me.PrintToolStripButton.Size = New System.Drawing.Size(23, 22)
        Me.PrintToolStripButton.Text = "&Print"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertyGrid1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 0)
        Me.PropertyGrid1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.Size = New System.Drawing.Size(290, 499)
        Me.PropertyGrid1.TabIndex = 4
        '
        'frmShelfSpots
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1111, 507)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmShelfSpots"
        Me.Text = "Catalogos: Ubicaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(false)
        CType(Me.PanelControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.PanelControl1.ResumeLayout(false)
        CType(Me.SplitContainerControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl1.ResumeLayout(false)
        CType(Me.SplitContainerControl3,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl3.ResumeLayout(false)
        Me.ToolStrip2.ResumeLayout(false)
        Me.ToolStrip2.PerformLayout
        CType(Me.SplitContainerControl2,System.ComponentModel.ISupportInitialize).EndInit
        Me.SplitContainerControl2.ResumeLayout(false)
        CType(Me.GridControl1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ContextMenuStrip1.ResumeLayout(false)
        CType(Me.GridView1,System.ComponentModel.ISupportInitialize).EndInit
        Me.ToolStrip1.ResumeLayout(false)
        Me.ToolStrip1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents PanelControl1 As DevExpress.XtraEditors.PanelControl
    Friend WithEvents SplitContainerControl1 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents SplitContainerControl2 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn_Wh As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Location As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents NewToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents SaveToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents CutToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PrintToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents SplitContainerControl3 As DevExpress.XtraEditors.SplitContainerControl
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ToolStrip2 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents PropertyGrid2 As System.Windows.Forms.PropertyGrid
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents GridColumn_Aisle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Column As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ToolStripMenuItem_CopyPartition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GridColumn_Line As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Module As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Allow_Fast_Picking As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn_Is_Waste As DevExpress.XtraGrid.Columns.GridColumn
End Class

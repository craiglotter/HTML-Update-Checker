Public Class HTML_Update_Checker
    Inherits System.Windows.Forms.Form



    Dim WithEvents ThreadSnapshot1 As ThreadSnapshot


    ' Dataset used for DataGrid1
    Private myDataSet As DataSet
    Private Max_Threads As Integer
    Private Current_Threads As Integer
    Private Job_Queue As Queue
    Public Delegate Sub FHandler()

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        ThreadSnapshot1 = New ThreadSnapshot()
        AddHandler ThreadSnapshot1.AnEvent, AddressOf DecreaseCurrentThreads
    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents txtSource As System.Windows.Forms.RichTextBox


    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid




    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Proxy As System.Windows.Forms.ComboBox
    Friend WithEvents Proxy_Check As System.Windows.Forms.CheckBox
    Friend WithEvents Proxy_Groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Check_Source_Button As System.Windows.Forms.Button
    Friend WithEvents Add_URL_Button As System.Windows.Forms.Button
    Friend WithEvents Check_List_Button As System.Windows.Forms.Button
    Friend WithEvents Remove_URL_Button As System.Windows.Forms.Button
    Friend WithEvents Check_URL_Button As System.Windows.Forms.Button
    Friend WithEvents Open_Browser_Button As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lbMaxThreads As System.Windows.Forms.Label
    Friend WithEvents lbCurrentThreads As System.Windows.Forms.Label
    Friend WithEvents lbQueued As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents StatusBar1 As System.Windows.Forms.Label
    Friend WithEvents StatusBar2 As System.Windows.Forms.Label



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(HTML_Update_Checker))
        Me.Check_Source_Button = New System.Windows.Forms.Button
        Me.txtURL = New System.Windows.Forms.TextBox
        Me.txtSource = New System.Windows.Forms.RichTextBox
        Me.DataGrid1 = New System.Windows.Forms.DataGrid
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle
        Me.Add_URL_Button = New System.Windows.Forms.Button
        Me.Proxy = New System.Windows.Forms.ComboBox
        Me.Proxy_Check = New System.Windows.Forms.CheckBox
        Me.Proxy_Groupbox = New System.Windows.Forms.GroupBox
        Me.Check_List_Button = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Remove_URL_Button = New System.Windows.Forms.Button
        Me.Check_URL_Button = New System.Windows.Forms.Button
        Me.Open_Browser_Button = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.StatusBar1 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.StatusBar2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.lbMaxThreads = New System.Windows.Forms.Label
        Me.lbCurrentThreads = New System.Windows.Forms.Label
        Me.lbQueued = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Proxy_Groupbox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Check_Source_Button
        '
        Me.Check_Source_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Check_Source_Button.ForeColor = System.Drawing.Color.White
        Me.Check_Source_Button.Location = New System.Drawing.Point(600, 344)
        Me.Check_Source_Button.Name = "Check_Source_Button"
        Me.Check_Source_Button.Size = New System.Drawing.Size(88, 24)
        Me.Check_Source_Button.TabIndex = 1
        Me.Check_Source_Button.Text = "Check Source"
        '
        'txtURL
        '
        Me.txtURL.BackColor = System.Drawing.Color.White
        Me.txtURL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtURL.ForeColor = System.Drawing.Color.Black
        Me.txtURL.Location = New System.Drawing.Point(24, 16)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(416, 20)
        Me.txtURL.TabIndex = 2
        Me.txtURL.Text = ""
        '
        'txtSource
        '
        Me.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtSource.Location = New System.Drawing.Point(40, 360)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(536, 160)
        Me.txtSource.TabIndex = 4
        Me.txtSource.Text = ""
        '
        'DataGrid1
        '
        Me.DataGrid1.AllowNavigation = False
        Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
        Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Black
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.ForeColor = System.Drawing.Color.Black
        Me.DataGrid1.GridLineColor = System.Drawing.Color.White
        Me.DataGrid1.HeaderBackColor = System.Drawing.Color.LightGray
        Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
        Me.DataGrid1.Location = New System.Drawing.Point(40, 64)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.LightGray
        Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DataGrid1.ParentRowsVisible = False
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.SelectionBackColor = System.Drawing.Color.LightGray
        Me.DataGrid1.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGrid1.Size = New System.Drawing.Size(776, 248)
        Me.DataGrid1.TabIndex = 8
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridLineColor = System.Drawing.SystemColors.Window
        Me.DataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGridTableStyle1.HeaderBackColor = System.Drawing.Color.LightGray
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        Me.DataGridTableStyle1.SelectionBackColor = System.Drawing.Color.LightGray
        Me.DataGridTableStyle1.SelectionForeColor = System.Drawing.Color.Black
        '
        'Add_URL_Button
        '
        Me.Add_URL_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Add_URL_Button.ForeColor = System.Drawing.Color.White
        Me.Add_URL_Button.Location = New System.Drawing.Point(448, 16)
        Me.Add_URL_Button.Name = "Add_URL_Button"
        Me.Add_URL_Button.Size = New System.Drawing.Size(80, 20)
        Me.Add_URL_Button.TabIndex = 9
        Me.Add_URL_Button.Text = "Add URL"
        Me.ToolTip1.SetToolTip(Me.Add_URL_Button, "Adds the entered URL into the list")
        '
        'Proxy
        '
        Me.Proxy.Location = New System.Drawing.Point(16, 24)
        Me.Proxy.Name = "Proxy"
        Me.Proxy.Size = New System.Drawing.Size(208, 21)
        Me.Proxy.TabIndex = 11
        '
        'Proxy_Check
        '
        Me.Proxy_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Proxy_Check.Location = New System.Drawing.Point(16, 48)
        Me.Proxy_Check.Name = "Proxy_Check"
        Me.Proxy_Check.Size = New System.Drawing.Size(136, 24)
        Me.Proxy_Check.TabIndex = 12
        Me.Proxy_Check.Text = "Use Proxy Connection"
        '
        'Proxy_Groupbox
        '
        Me.Proxy_Groupbox.Controls.Add(Me.Proxy)
        Me.Proxy_Groupbox.Controls.Add(Me.Proxy_Check)
        Me.Proxy_Groupbox.ForeColor = System.Drawing.Color.White
        Me.Proxy_Groupbox.Location = New System.Drawing.Point(600, 384)
        Me.Proxy_Groupbox.Name = "Proxy_Groupbox"
        Me.Proxy_Groupbox.Size = New System.Drawing.Size(240, 80)
        Me.Proxy_Groupbox.TabIndex = 13
        Me.Proxy_Groupbox.TabStop = False
        Me.Proxy_Groupbox.Text = "Connection"
        '
        'Check_List_Button
        '
        Me.Check_List_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Check_List_Button.ForeColor = System.Drawing.Color.White
        Me.Check_List_Button.Location = New System.Drawing.Point(696, 344)
        Me.Check_List_Button.Name = "Check_List_Button"
        Me.Check_List_Button.Size = New System.Drawing.Size(136, 24)
        Me.Check_List_Button.TabIndex = 14
        Me.Check_List_Button.Text = "Check List for Updates"
        '
        'GroupBox1
        '
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(24, 40)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(808, 288)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "URLs"
        '
        'GroupBox2
        '
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(24, 336)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(568, 200)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Page Source"
        '
        'Remove_URL_Button
        '
        Me.Remove_URL_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Remove_URL_Button.ForeColor = System.Drawing.Color.White
        Me.Remove_URL_Button.Location = New System.Drawing.Point(536, 16)
        Me.Remove_URL_Button.Name = "Remove_URL_Button"
        Me.Remove_URL_Button.Size = New System.Drawing.Size(88, 20)
        Me.Remove_URL_Button.TabIndex = 17
        Me.Remove_URL_Button.Text = "Remove URL"
        Me.ToolTip1.SetToolTip(Me.Remove_URL_Button, "Removes the selected URL from the list")
        '
        'Check_URL_Button
        '
        Me.Check_URL_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Check_URL_Button.ForeColor = System.Drawing.Color.White
        Me.Check_URL_Button.Location = New System.Drawing.Point(632, 16)
        Me.Check_URL_Button.Name = "Check_URL_Button"
        Me.Check_URL_Button.Size = New System.Drawing.Size(112, 20)
        Me.Check_URL_Button.TabIndex = 18
        Me.Check_URL_Button.Text = "Check for Update"
        Me.ToolTip1.SetToolTip(Me.Check_URL_Button, "Checks selected page for updates")
        '
        'Open_Browser_Button
        '
        Me.Open_Browser_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Open_Browser_Button.ForeColor = System.Drawing.Color.White
        Me.Open_Browser_Button.Location = New System.Drawing.Point(752, 16)
        Me.Open_Browser_Button.Name = "Open_Browser_Button"
        Me.Open_Browser_Button.Size = New System.Drawing.Size(75, 20)
        Me.Open_Browser_Button.TabIndex = 19
        Me.Open_Browser_Button.Text = "Browse"
        Me.ToolTip1.SetToolTip(Me.Open_Browser_Button, "Open selected page in default browser")
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.StatusBar1)
        Me.Panel1.Location = New System.Drawing.Point(8, 536)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(552, 32)
        Me.Panel1.TabIndex = 20
        '
        'StatusBar1
        '
        Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusBar1.Location = New System.Drawing.Point(0, 0)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(552, 32)
        Me.StatusBar1.TabIndex = 27
        Me.StatusBar1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.StatusBar2)
        Me.Panel2.Location = New System.Drawing.Point(560, 536)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(288, 32)
        Me.Panel2.TabIndex = 21
        '
        'StatusBar2
        '
        Me.StatusBar2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StatusBar2.Location = New System.Drawing.Point(0, 0)
        Me.StatusBar2.Name = "StatusBar2"
        Me.StatusBar2.Size = New System.Drawing.Size(288, 32)
        Me.StatusBar2.TabIndex = 0
        Me.StatusBar2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(832, 48)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(8, 8)
        Me.Button1.TabIndex = 22
        Me.ToolTip1.SetToolTip(Me.Button1, "Clear all Status Entries")
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'lbMaxThreads
        '
        Me.lbMaxThreads.Location = New System.Drawing.Point(784, 480)
        Me.lbMaxThreads.Name = "lbMaxThreads"
        Me.lbMaxThreads.Size = New System.Drawing.Size(56, 23)
        Me.lbMaxThreads.TabIndex = 24
        Me.lbMaxThreads.Text = "Threads"
        Me.lbMaxThreads.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbCurrentThreads
        '
        Me.lbCurrentThreads.Location = New System.Drawing.Point(744, 480)
        Me.lbCurrentThreads.Name = "lbCurrentThreads"
        Me.lbCurrentThreads.Size = New System.Drawing.Size(40, 23)
        Me.lbCurrentThreads.TabIndex = 25
        Me.lbCurrentThreads.Text = "/"
        Me.lbCurrentThreads.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lbQueued
        '
        Me.lbQueued.Location = New System.Drawing.Point(744, 504)
        Me.lbQueued.Name = "lbQueued"
        Me.lbQueued.Size = New System.Drawing.Size(80, 23)
        Me.lbQueued.TabIndex = 26
        Me.lbQueued.Text = "Queued"
        Me.lbQueued.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'HTML_Update_Checker
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.Crimson
        Me.ClientSize = New System.Drawing.Size(856, 566)
        Me.Controls.Add(Me.lbQueued)
        Me.Controls.Add(Me.lbCurrentThreads)
        Me.Controls.Add(Me.lbMaxThreads)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Open_Browser_Button)
        Me.Controls.Add(Me.Check_URL_Button)
        Me.Controls.Add(Me.Remove_URL_Button)
        Me.Controls.Add(Me.Check_List_Button)
        Me.Controls.Add(Me.Proxy_Groupbox)
        Me.Controls.Add(Me.Add_URL_Button)
        Me.Controls.Add(Me.DataGrid1)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.txtURL)
        Me.Controls.Add(Me.Check_Source_Button)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(864, 600)
        Me.MinimumSize = New System.Drawing.Size(864, 600)
        Me.Name = "HTML_Update_Checker"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "HTML Update Checker 20050531.9"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Proxy_Groupbox.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    
  

    Private Sub Add_URL_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Add_URL_Button.Click
        Add_URL()
    End Sub


  


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_List_Button.Click
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow

        'Dim urladdthread As System.Threading.Thread
        For Each myDataRow In myDataTable.Rows

            '   Dim ThreadSnapshot1 As New ThreadSnapshot()
            '  Dim Thread As New System.Threading.Thread _
            '                (AddressOf ThreadSnapshot1.CompareSnapshot)
            ' ThreadSnapshot1.DataTable1 = myDataSet.Tables.Item(0)
            'ThreadSnapshot1.id = myDataRow("ID")
            'ThreadSnapshot1.url = myDataRow("URL")
            'ThreadSnapshot1.ProxyCheck = Proxy_Check.Checked
            'ThreadSnapshot1.ProxyText = Proxy.Text
            'Thread.Start()
            Dim Job_Item As Queue_Item = New Queue_Item(2, myDataRow("URL"))
            Job_Queue.Enqueue(Job_Item)
            lbQueued.Text = Job_Queue.Count & " Queued"
        Next

        ' DataGrid1.Update()
        'MsgBox("Function ended")
    End Sub





    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_URL_Button.Click
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow
        Dim keys(0) As Object
        ' keys(0) = id
        keys(0) = txtURL.Text
        myDataRow = myDataTable.Rows.Find(keys)
        Dim ThreadSnapshot1 As New ThreadSnapshot()
        Dim Thread As New System.Threading.Thread _
                         (AddressOf ThreadSnapshot1.CompareSnapshot)

        ThreadSnapshot1.DataTable1 = myDataSet.Tables.Item(0)
        ThreadSnapshot1.id = myDataRow("ID")
        ThreadSnapshot1.url = myDataRow("URL")
        ThreadSnapshot1.ProxyCheck = Proxy_Check.Checked
        ThreadSnapshot1.ProxyText = Proxy.Text
        Thread.Start()
        'DataGrid1.Update()


    End Sub

    Private Sub DataGrid1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseUp
        Dim pt = New Point(e.X, e.Y)
        Dim hit As DataGrid.HitTestInfo = DataGrid1.HitTest(pt)

        If hit.Type = DataGrid.HitTestType.Cell Then
            DataGrid1.CurrentCell = New DataGridCell(hit.Row, hit.Column)
            DataGrid1.Select(hit.Row)
        End If

    End Sub



    '*****************************************************************************************************************
    '*****************************************************************************************************************
    '*****************************************************************************************************************
    '*****************************************************************************************************************




    ' ***********************************************************************************
    ' Form Load and Close Events
    ' ***********************************************************************************




    ' Function handling form load
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' sets up the datatable used in the datagrid

        MakeDataTables()

        StatusBar2.Text = ""

        ' attempt to open the configuration file
        Try
            Dim filereader1 As System.IO.StreamReader = New System.IO.StreamReader("config.ini", System.Text.Encoding.ASCII, False, 512)
            Proxy.Text = filereader1.ReadLine
            Proxy_Check.Checked = filereader1.ReadLine
            Max_Threads = Val(filereader1.ReadLine)
            filereader1.Close()
            StatusBar1.Text = "Configuration file loaded successfully"

        Catch err As System.IO.FileNotFoundException
            MsgBox("Could not load configuration file, config.ini")
            StatusBar1.Text = "Configuration file failed toload"
        End Try

        ' attempt to open the URL list file
        Try
            myDataSet.ReadXml("urllist.xml")
            StatusBar1.Text = "URL list loaded successfully"

        Catch er As System.IO.FileNotFoundException
            StatusBar1.Text = "URL list failed to load"
        End Try
        Job_Queue = New Queue()
        Current_Threads = 0
        ' Run this procedure in an appropriate event.
        ' Set to 1 second.
        lbCurrentThreads.Text = "0/"
        lbMaxThreads.Text = Max_Threads & " Threads"
        lbQueued.Text = "0 Queued"
        Timer1.Interval = 1000
        ' Enable timer.
        Timer1.Enabled = True
        '        Button1.Text = "Enabled"

        ' MsgBox(Max_Threads & "   " & Current_Threads)
        txtURL.Select()
    End Sub

    Private Sub Timer1_Tick(ByVal Sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        'Current_Threads = ThreadSnapshot1.Current_Threads
        'txtSource.Text = txtSource.Text & "Current Threads: " & Current_Threads & vbCrLf
   


        ' Set the caption to the current time.
        If Current_Threads <= Max_Threads Then
            'txtSource.Text = txtSource.Text & "Queued Jobs: " & Job_Queue.Count & vbCrLf
            If Job_Queue.Count > 0 Then

                Dim Job_Item As Queue_Item

                Job_Item = Job_Queue.Dequeue
                lbQueued.Text = Job_Queue.Count & " Queued"
                If Job_Item.task = 2 Then
                    'Dim ThreadSnapshot1 As New ThreadSnapshot()
                    Dim myDataRow As DataRow
                    Dim keys(0) As Object
                    ' keys(0) = id
                    keys(0) = Job_Item.URL
                    myDataRow = myDataSet.Tables.Item(0).Rows.Find(keys)
                    ThreadSnapshot1.DataTable1 = myDataSet.Tables.Item(0)
                    ThreadSnapshot1.id = myDataRow("ID")
                    ThreadSnapshot1.url = myDataRow("URL")
                    ThreadSnapshot1.ProxyCheck = Proxy_Check.Checked
                    ThreadSnapshot1.ProxyText = Proxy.Text
                    Current_Threads = Current_Threads + 1
                    If Current_Threads = 0 Then
                        lbCurrentThreads.Text = (Current_Threads) & "/"
                    Else
                        lbCurrentThreads.Text = (Current_Threads - 1) & "/"
                    End If
                    ThreadSnapshot1.StartThreads(2)
                End If
            End If
        End If


    End Sub



    ' Function handling form close
    Private Sub Form1_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed

        ' attempt to write URL list to file
        Try
            myDataSet.WriteXml("urllist.xml", XmlWriteMode.IgnoreSchema)
            Dim filetoaccess = New System.IO.FileStream("config.ini", IO.FileMode.OpenOrCreate)
            Dim filewriter = New System.IO.StreamWriter(filetoaccess, System.Text.Encoding.ASCII)
            filewriter.writeline(Proxy.Text)
            filewriter.writeline(Proxy_Check.Checked)
            filewriter.writeline(Max_Threads)
            filewriter.close()
            filetoaccess.close()

        Catch err As System.Exception
            MsgBox("Could not write to XML file, urllist.xml (" & err.Message & ") " & err.GetType.ToString)
        End Try

        ' removes temporary file used in comparing snapshots
        'Dim filetomanip As System.IO.File
        'If filetomanip.Exists("temp.txt") Then
        'filetomanip.Delete("temp.txt")
        'End If
        Timer1.Enabled = False

    End Sub




    ' ***********************************************************************************
    ' Event Handlers
    ' ***********************************************************************************




    ' Handles clicking on the datagrid - i.e. selecting a row
    Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.EventArgs) Handles DataGrid1.CurrentCellChanged

        Try
            ' Set the txtURL textbox to reflect the selected row's URL value. This is important
            ' as all functions work off the txtURL vaule
            txtURL.Text = DataGrid1.Item(DataGrid1.CurrentRowIndex, 1)
            StatusBar2.Text = txtURL.Text
            StatusBar1.Text = ""
        Catch err As Exception
            MsgBox(err.Message)
        End Try

    End Sub




    ' Handles the launching of an Internet Browser
    Private Sub Open_Browser_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Open_Browser_Button.Click

        ' Launch internet browser in a new process to view an URL
        Try
            Process.Start(txtURL.Text)
            StatusBar1.Text = "Browser launched successfully"
            StatusBar2.Text = txtURL.Text
        Catch err As System.ComponentModel.Win32Exception
            MsgBox("Failed to open this location", MsgBoxStyle.Exclamation, "Error Encountered")
            StatusBar1.Text = "Browser failed to launch"
            StatusBar2.Text = txtURL.Text
        End Try

    End Sub



    ' Handles the deletion of a URL from the list
    Private Sub Remove_URL_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Remove_URL_Button.Click
        Dim o As Object
        For Each o In GetSelectedRows(DataGrid1)
            Delete_URL(Val(o.ToString()))
        Next o
        Dim s As String = "Selected rows:"
    End Sub




    ' Handles the viewing of a URL's source code
    Private Sub Check_Source_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check_Source_Button.Click

        ' Get the URL
        Dim sServer As String
        sServer = Trim(txtURL.Text)
        Dim errorhandled As Boolean = False
        Try

            ' Check that the URL is not an empty string
            If sServer = "" Then
                MsgBox("There is no URL present in the URL textbox", MsgBoxStyle.Exclamation, "Error Encountered")
                Exit Sub
            End If

            StatusBar1.Text = "Connecting to Host"
            StatusBar2.Text = sServer

            ' Send HTTP request
            Dim HttpWReq As System.Net.HttpWebRequest = _
               CType(System.Net.WebRequest.Create(sServer), System.Net.HttpWebRequest)

            ' Use Proxy if necessary
            If Proxy_Check.Checked = True Then
                Dim proxyObject As New System.Net.WebProxy(Proxy.Text, True)
                HttpWReq.Proxy = proxyObject
            End If

            ' Get Response from Host
            Dim HttpWResp As System.Net.HttpWebResponse = _
               CType(HttpWReq.GetResponse(), System.Net.HttpWebResponse)

            StatusBar1.Text = "Connected to Host"
            StatusBar2.Text = sServer

            ' Set the txtSource text field equal to the response received from the Host
            Dim streamer As System.IO.StreamReader = New System.IO.StreamReader(HttpWResp.GetResponseStream, System.Text.Encoding.ASCII, False, 512)
            txtSource.Text = streamer.ReadToEnd()

            StatusBar1.Text = "Page Source loaded"
            StatusBar2.Text = sServer

            ' Close the connection objects
            HttpWResp.Close()
            streamer.Close()

        Catch errr As System.Net.WebException
            If errorhandled = False Then
                errorhandled = True
                MsgBox(errr.Message, MsgBoxStyle.Exclamation, "Error Encountered")
                StatusBar1.Text = "Failed to connect to Host"
                StatusBar2.Text = sServer
            End If
        Catch err As System.Exception
            If errorhandled = False Then
                errorhandled = True
                MsgBox(err.Message, MsgBoxStyle.Exclamation, "Error Encountered")
                StatusBar1.Text = "Failed to load URL source"
                StatusBar2.Text = sServer
            End If
        End Try

    End Sub




    ' ***********************************************************************************
    ' Code Sub Procedures
    ' ***********************************************************************************




    ' Create datatable to be bound to form' s datagrid
    Private Sub MakeDataTables()

        ' set up datatable
        MakeParentTable()

        ' bind the datatable to the datagrid
        BindToDataGrid()

    End Sub




    ' Set up the datatable
    Private Sub MakeParentTable()

        ' Create a new DataTable.
        Dim myDataTable As DataTable = New DataTable("URL_Status")

        ' Declare variables for DataColumn and DataRow objects.
        Dim myDataColumn As DataColumn
        Dim myDataRow As DataRow

        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn
        myDataColumn.DataType = System.Type.GetType("System.Int32")
        myDataColumn.ColumnName = "ID"
        myDataColumn.ReadOnly = True
        myDataColumn.Unique = True
        myDataColumn.AutoIncrement = True
        myDataColumn.AutoIncrementSeed = 1
        myDataColumn.AutoIncrementStep = 1
        myDataTable.Columns.Add(myDataColumn)

        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "URL"
        myDataColumn.ReadOnly = True
        myDataColumn.Unique = False
        myDataTable.Columns.Add(myDataColumn)

        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "Snapshot1"
        myDataColumn.ReadOnly = False
        myDataColumn.Unique = False
        myDataTable.Columns.Add(myDataColumn)

        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "Snapshot2"
        myDataColumn.ReadOnly = False
        myDataColumn.Unique = False
        myDataTable.Columns.Add(myDataColumn)

        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "Status"
        myDataColumn.ReadOnly = False
        myDataColumn.Unique = False
        myDataTable.Columns.Add(myDataColumn)

        ' Make the URL column the primary key column.
        Dim PrimaryKeyColumns(0) As DataColumn
        PrimaryKeyColumns(0) = myDataTable.Columns("URL")
        myDataTable.PrimaryKey = PrimaryKeyColumns

        ' Map the DataGridTableStyle to the datatable
        DataGridTableStyle1.MappingName = myDataTable.TableName

        ' Instantiate the DataSet variable and add the table to it
        myDataSet = New DataSet
        myDataSet.Tables.Add(myDataTable)

    End Sub




    ' Bind the dataset to the datagrid
    Private Sub BindToDataGrid()

        ' Instruct the DataGrid to bind to the DataSet
        DataGrid1.SetDataBinding(myDataSet, "URL_Status")
        SetGridColumnProperties()

    End Sub




    ' Set the preferred widths for the individual columns
    Public Sub SetGridColumnProperties()

        Dim myDataGridColumnStyle As DataGridColumnStyle
        Dim myGridColumnStylesCollection As GridColumnStylesCollection

        ' Retrieve the GridColumnStyle from the datagrid
        myGridColumnStylesCollection = DataGrid1.TableStyles(0).GridColumnStyles

        ' Set the columns' required width
        myDataGridColumnStyle = myGridColumnStylesCollection.Item(0)
        myDataGridColumnStyle.Width = 30

        myDataGridColumnStyle = myGridColumnStylesCollection.Item(1)
        myDataGridColumnStyle.Width = 332

        myDataGridColumnStyle = myGridColumnStylesCollection.Item(2)
        myDataGridColumnStyle.Width = 130

        myDataGridColumnStyle = myGridColumnStylesCollection.Item(3)
        myDataGridColumnStyle.Width = 130

        myDataGridColumnStyle = myGridColumnStylesCollection.Item(4)
        myDataGridColumnStyle.Width = 115

    End Sub




    ' Code to remove a URL from the datagrid
    Private Sub Delete_URL(ByVal URL As Integer)

        ' Removes URL from the "URL_Status" table in the dataset
        Dim errorhandled As Boolean = False
        Try
            Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
            Dim myDataRow As DataRow

            myDataRow = myDataTable.Rows(URL)

            'Locates row in datagrid using URL as key
            Dim keys(0) As Object
            keys(0) = myDataRow.Item(1).ToString()

            myDataRow = myDataTable.Rows.Find(keys)

            Dim filename As String
            filename = myDataRow("ID") & ".txt"

            ' Removes the row from the dataset

            myDataTable.Rows.Remove(myDataRow)

            ' Removes the file based on the row's ID value
            Dim filetomanip = New System.IO.FileInfo(filename)
            If filetomanip.Exists = True Then
                filetomanip.Delete()
            Else
                Throw New System.IO.FileNotFoundException
            End If

            StatusBar1.Text = "URL removed"
            StatusBar2.Text = txtURL.Text
        
        Catch e As System.IO.FileNotFoundException
            If errorhandled = False Then
                errorhandled = True
                MsgBox("Error in removing snapshot file. However, URL will be removed from the list anyway.", MsgBoxStyle.Exclamation, "Error Encountered")
                StatusBar1.Text = "Failed to Delete URL file"
                StatusBar2.Text = txtURL.Text
            End If
        Catch err As System.Data.DataException
            If errorhandled = False Then
                errorhandled = True
                MsgBox("Error in removing URL.", MsgBoxStyle.Exclamation, "Error Encountered")
                StatusBar1.Text = "Failed to Delete URL"
                StatusBar2.Text = txtURL.Text
            End If
        Catch errr As SystemException
            If errorhandled = False Then
                errorhandled = True
                MsgBox("No Such URL exists in the table", MsgBoxStyle.Exclamation, "Error Encountered")
                StatusBar1.Text = "Failed to Delete URL"
                StatusBar2.Text = txtURL.Text
            End If
        End Try

    End Sub




    ' Retrieves URL source and writes it to file
    Protected Function TakeSnapshot(ByVal url As String, ByVal id As Integer, ByVal snapshot As Integer) As Boolean

        ' Find the row in the datagrid for which the snapshot is to be taken
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow

        ' Use URL as primary key
        Dim keys(0) As Object
        keys(0) = url
        myDataRow = myDataTable.Rows.Find(keys)

        TakeSnapshot = True

        ' Set up HTTP connection
        Dim sServer As String
        sServer = Trim(url)

        ' Check that the URL is not an empty string
        If sServer = "" Then
            MsgBox("There is no URL present in the URL textbox", MsgBoxStyle.Exclamation, "Error Encountered")
            TakeSnapshot = False
            Exit Function
        End If

        StatusBar1.Text = "Connecting to Host"
        StatusBar2.Text = sServer

        Dim errorhandled As Boolean = False

        Try
            ' Send HTTP request
            Dim HttpWReq As System.Net.HttpWebRequest = _
                      CType(System.Net.WebRequest.Create(sServer), System.Net.HttpWebRequest)

            ' Use proxy if necessary
            If Proxy_Check.Checked = True Then
                Dim proxyObject As New System.Net.WebProxy(Proxy.Text, True)
                HttpWReq.Proxy = proxyObject
            End If

            ' Get Response
            Dim HttpWResp As System.Net.HttpWebResponse = _
               CType(HttpWReq.GetResponse(), System.Net.HttpWebResponse)

            StatusBar1.Text = "Connected"
            StatusBar2.Text = sServer

            ' Create text file
            Dim streamer As System.IO.StreamReader = New System.IO.StreamReader(HttpWResp.GetResponseStream, System.Text.Encoding.ASCII, False, 512)
            Dim filetoaccess As System.IO.FileStream

            ' Filename depends on type of snapshot. 0 indicates snapshot to be taken and placed in saved file,
            ' 1 indicates snapshot to be saved in temporary file
            If snapshot = 0 Or snapshot = 2 Then
                filetoaccess = New System.IO.FileStream(id.ToString & ".txt", IO.FileMode.Create)
            End If
            If snapshot = 1 Then
                filetoaccess = New System.IO.FileStream("temp" & id.ToString & ".txt", IO.FileMode.Create)
            End If

            ' Write to filestream
            Dim filewriter = New System.IO.StreamWriter(filetoaccess, System.Text.Encoding.ASCII)

            StatusBar1.Text = "Creating File"
            StatusBar2.Text = sServer

            While streamer.Peek() <> -1
                filewriter.writeline(streamer.ReadLine())
            End While

            ' close file objects
            streamer.Close()
            filewriter.close()
            filetoaccess.Close()

            'close connection objects
            HttpWResp.Close()


            ' Edit the rows textual content
            myDataRow.BeginEdit()

            If snapshot = 0 Or snapshot = 2 Then
                myDataRow("Snapshot1") = Now()
            End If

            If snapshot = 1 Then
                myDataRow("Snapshot2") = Now()
            End If

            myDataRow("Status") = "File Created"
            StatusBar1.Text = "File Created"
            StatusBar2.Text = sServer

            myDataRow.EndEdit()

            If snapshot = 0 Then
                StatusBar1.Text = "URL added"
                StatusBar2.Text = sServer
            End If

            Dim filetomanip As System.IO.File
            If filetomanip.Exists("temp" & id.ToString & ".txt") Then
                filetomanip.Delete("temp" & id.ToString & ".txt")
            End If

        Catch errr As System.Net.WebException
            If errorhandled = False Then
                errorhandled = True
                'MsgBox(errr.Message, MsgBoxStyle.Exclamation, "Error Encountered")
                If snapshot = 0 Then
                    myDataRow.BeginEdit()
                    myDataRow.Delete()
                    myDataRow.EndEdit()
                End If
                StatusBar1.Text = "Failed to add URL"
                StatusBar2.Text = sServer
                TakeSnapshot = False
            End If

        Catch er As System.Exception
            If errorhandled = False Then
                errorhandled = True
                'MsgBox(er.Message, MsgBoxStyle.Exclamation, "Error Encountered")
                If snapshot = 0 Then
                    myDataRow.BeginEdit()
                    myDataRow.Delete()
                    myDataRow.EndEdit()
                End If
                StatusBar1.Text = "Failed to add URL"
                StatusBar2.Text = sServer
                TakeSnapshot = False
            End If
        End Try

    End Function




    ' Compares a new snapshot with stored snapshot
    '  Protected Function CompareSnapshot(ByVal url As String, ByVal id As Integer)

    '     Dim result As Boolean = TakeSnapshot(url, id, 1)

    '    If result = True Then
    '       Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
    '      Dim myDataRow As DataRow
    '     Dim keys(0) As Object

    '    keys(0) = url

    '   myDataRow = myDataTable.Rows.Find(keys)

    '  Dim filereader1 As System.IO.StreamReader = New System.IO.StreamReader("temp.txt", System.Text.Encoding.ASCII, False, 512)
    ' Dim filereader2 As System.IO.StreamReader = New System.IO.StreamReader(id.ToString & ".txt", System.Text.Encoding.ASCII, False, 512)
    'Dim flagged As Boolean = False
    'While filereader1.Peek() <> -1
    '   If Not String.Compare(filereader1.ReadLine, filereader2.ReadLine) = 0 Then

    '      filereader1.Close()
    '     filereader2.Close()
    '    TakeSnapshot(url, id, 2)

    '   myDataRow.BeginEdit()
    '  myDataRow("Status") = "Update Detected"
    ' myDataRow.EndEdit()

    'flagged = True
    'Exit While
    'End If

    '            End While
    '           If flagged = False Then
    '              filereader1.Close()
    '             filereader2.Close()
    '            myDataRow.BeginEdit()
    '           myDataRow("Status") = "Page unchanged"
    '          myDataRow.EndEdit()
    '     End If
    '        Else
    '           Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
    '          Dim myDataRow As DataRow
    '         Dim keys(0) As Object
    ' 'keys(0) = id
    '        keys(0) = url

    '       myDataRow = myDataTable.Rows.Find(keys)


    '     myDataRow.BeginEdit()
    '    myDataRow("Status") = "Error Encountered"
    '   myDataRow.EndEdit()
    'End If

    '    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow

        Dim counter As Integer
        For counter = 0 To myDataTable.Rows.Count - 1
            myDataRow = myDataTable.Rows(counter)
            myDataRow.BeginEdit()
            myDataRow("Status") = ""
            myDataRow.EndEdit()
        Next
    End Sub

    Private Sub Add_URL()
        If Not txtURL.Text = "" Then
            Dim errorhandled As Boolean = False
            Try
                Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
                Dim myDataRow As DataRow

                myDataRow = myDataTable.NewRow()
                myDataRow("URL") = txtURL.Text
                myDataRow("Snapshot1") = ""
                myDataRow("Snapshot2") = ""
                myDataRow("Status") = "Taking Snapshot"
                StatusBar1.Text = "Taking Snapshot"
                StatusBar2.Text = txtURL.Text
                myDataTable.Rows.Add(myDataRow)
                myDataRow = myDataTable.Rows.Item(myDataTable.Rows.Count - 1)
                TakeSnapshot(txtURL.Text, myDataRow.Item(0), 0)
                myDataRow("Status") = "Checked"
            Catch err As System.Data.ConstraintException
                If errorhandled = False Then
                    errorhandled = True
                    MsgBox("The URL you are trying to add already exists in the list", MsgBoxStyle.Exclamation, "Error Encountered")
                    StatusBar1.Text = "Failed to add URL"
                    StatusBar2.Text = txtURL.Text
                End If
            Catch e As System.Exception
                If errorhandled = False Then
                    errorhandled = True
                    MsgBox("Failed to add the URL", MsgBoxStyle.Exclamation, "Error Encountered")
                    StatusBar1.Text = "Failed to add URL"
                    StatusBar2.Text = txtURL.Text
                End If
            End Try
        End If
    End Sub

    '------------------------------------------
    Public Function GetSelectedRows(ByVal dg As DataGrid) As System.Collections.ArrayList

        Dim al As New ArrayList



        Dim cm As CurrencyManager = Me.BindingContext(dg.DataSource, dg.DataMember)

        Dim dv As DataView = CType(cm.List, DataView)



        Dim i As Integer

        For i = 0 To dv.Count - 1

            If dg.IsSelected(i) Then

                al.Add(i)

            End If
        Next

        Return al

    End Function 'GetSelectedRows 



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim s As String = "Selected rows:"

        Dim o As Object

        For Each o In GetSelectedRows(DataGrid1)

            s += " " + o.ToString()

        Next o

        MessageBox.Show(s)
    End Sub

    Public Sub DecreaseCurrentThreads()
        Current_Threads = Current_Threads - 1
        If Current_Threads = 0 Then
            lbCurrentThreads.Text = (Current_Threads) & "/"
        Else
            lbCurrentThreads.Text = (Current_Threads - 1) & "/"
        End If
    End Sub


End Class


Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents cmdView As System.Windows.Forms.Button
    Friend WithEvents txtURL As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.RichTextBox
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar


    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    



    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Proxy As System.Windows.Forms.ComboBox
    Friend WithEvents Proxy_Check As System.Windows.Forms.CheckBox
    Friend WithEvents Proxy_Groupbox As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button



    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cmdView = New System.Windows.Forms.Button()
        Me.txtURL = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.RichTextBox()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Proxy = New System.Windows.Forms.ComboBox()
        Me.Proxy_Check = New System.Windows.Forms.CheckBox()
        Me.Proxy_Groupbox = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Proxy_Groupbox.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdView
        '
        Me.cmdView.Location = New System.Drawing.Point(272, 8)
        Me.cmdView.Name = "cmdView"
        Me.cmdView.TabIndex = 1
        Me.cmdView.Text = "Button1"
        '
        'txtURL
        '
        Me.txtURL.Location = New System.Drawing.Point(24, 8)
        Me.txtURL.Name = "txtURL"
        Me.txtURL.Size = New System.Drawing.Size(216, 20)
        Me.txtURL.TabIndex = 2
        Me.txtURL.Text = "http://www.commerce.uct.ac.za"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Label1"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(8, 288)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(256, 72)
        Me.txtSource.TabIndex = 4
        Me.txtSource.Text = "RichTextBox1"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 487)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(856, 22)
        Me.StatusBar1.TabIndex = 5
        Me.StatusBar1.Text = "StatusBar1"
        '
        'DataGrid1
        '
        Me.DataGrid1.BackgroundColor = System.Drawing.SystemColors.Desktop
        Me.DataGrid1.CaptionVisible = False
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.GridLineColor = System.Drawing.SystemColors.Window
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 64)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.ParentRowsVisible = False
        Me.DataGrid1.ReadOnly = True
        Me.DataGrid1.RowHeadersVisible = False
        Me.DataGrid1.Size = New System.Drawing.Size(776, 208)
        Me.DataGrid1.TabIndex = 8
        Me.DataGrid1.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.DataGrid1
        Me.DataGridTableStyle1.GridLineColor = System.Drawing.SystemColors.Window
        Me.DataGridTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(48, 368)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(168, 368)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "Button2"
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
        Me.Proxy_Check.Location = New System.Drawing.Point(16, 48)
        Me.Proxy_Check.Name = "Proxy_Check"
        Me.Proxy_Check.Size = New System.Drawing.Size(136, 24)
        Me.Proxy_Check.TabIndex = 12
        Me.Proxy_Check.Text = "Use Proxy Connection"
        '
        'Proxy_Groupbox
        '
        Me.Proxy_Groupbox.Controls.AddRange(New System.Windows.Forms.Control() {Me.Proxy, Me.Proxy_Check})
        Me.Proxy_Groupbox.Location = New System.Drawing.Point(16, 400)
        Me.Proxy_Groupbox.Name = "Proxy_Groupbox"
        Me.Proxy_Groupbox.Size = New System.Drawing.Size(240, 80)
        Me.Proxy_Groupbox.TabIndex = 13
        Me.Proxy_Groupbox.TabStop = False
        Me.Proxy_Groupbox.Text = "Connection"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(560, 392)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "Button3"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(856, 509)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button3, Me.Proxy_Groupbox, Me.Button2, Me.Button1, Me.DataGrid1, Me.StatusBar1, Me.txtSource, Me.Label1, Me.txtURL, Me.cmdView})
        Me.Name = "Form1"
        Me.Text = "9"
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Proxy_Groupbox.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Dim sBuffer As String

    Private myDataSet As DataSet

    Private Overloads Sub cmdView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdView.Click
        On Error GoTo ErrHandler
        Dim sServer As String
        Dim nPort As Long
        Dim sPage As String

        nPort = 80
        sServer = Trim(txtURL.Text)
        'If InStr(sServer, "://") > 0 Then sServer = Mid(sServer, InStr(sServer, "://") + 3)
        'If InStr(sServer, "/") > 0 Then
        'sPage = Mid(sServer, InStr(sServer, "/") + 1)
        'sServer = Microsoft.VisualBasic.Left(sServer, InStr(sServer, "/") - 1)
        'End If
        'If InStr(sServer, ":") > 0 Then
        'nPort = Mid(sServer, InStr(sServer, ":") + 1)
        'sServer = Microsoft.VisualBasic.Left(sServer, InStr(sServer, ":") - 1)
        'End If
        MsgBox(sServer)
        If sServer = "" Then Exit Sub

        Dim HttpWReq As System.Net.HttpWebRequest = _
           CType(System.Net.WebRequest.Create(sServer), System.Net.HttpWebRequest)

        If Proxy_Check.Checked = True Then
            Dim proxyObject As New System.Net.WebProxy(Proxy.Text, True)
            HttpWReq.Proxy = proxyObject
        End If

        Dim HttpWResp As System.Net.HttpWebResponse = _
           CType(HttpWReq.GetResponse(), System.Net.HttpWebResponse)
        Dim streamer As System.IO.StreamReader = New System.IO.StreamReader(HttpWResp.GetResponseStream, System.Text.Encoding.ASCII, False, 512)
        txtSource.Text = streamer.ReadToEnd()

        ' Insert code that uses the response object.
        HttpWResp.Close()
        streamer.Close()

        'Dim wsTCP as New  System.Net.HttpWebRequest(
        'wsTCP.Address = sServer
        'wsTCP = CreateObject("oswinsck.TCP")
        'If wsTCP.Connect(sServer, nPort) = 0 Then
        'wsTCP.SendData("GET /" & sPage & " HTTP/1.0" & vbCrLf & vbCrLf)
        'txtSource = wsTCP.GetData
        'wsTCP.Disconnect()
        'End If
        'Exit Sub

ErrHandler:
        MsgBox(Err.Number & ": " & Err.Description)
    End Sub

    
    ' Put the next line into the Declarations section.


    Private Sub MakeDataTables()
        ' Run all of the functions. 
        MakeParentTable()
        'MakeChildTable()
        'MakeDataRelation()
        BindToDataGrid()
    End Sub

    Private Sub MakeParentTable()
        ' Create a new DataTable.
        Dim myDataTable As DataTable = New DataTable("URL_Status")
        ' Declare variables for DataColumn and DataRow objects.
        Dim myDataColumn As DataColumn
        Dim myDataRow As DataRow



        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.Int32")
        myDataColumn.ColumnName = "ID"
        myDataColumn.ReadOnly = True
        myDataColumn.Unique = True
        myDataColumn.AutoIncrement = True
        myDataColumn.AutoIncrementSeed = 1
        myDataColumn.AutoIncrementStep = 1


        ' Add the Column to the DataColumnCollection.
        myDataTable.Columns.Add(myDataColumn)

        ' Create new DataColumn, set DataType, ColumnName and add to DataTable.    
        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "URL"
        myDataColumn.ReadOnly = True
        myDataColumn.Unique = False
        ' Add the Column to the DataColumnCollection.
        myDataTable.Columns.Add(myDataColumn)

        ' Create second column.
        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "Snapshot1"
        myDataColumn.ReadOnly = False
        myDataColumn.Unique = False
        ' Add the column to the table.
        myDataTable.Columns.Add(myDataColumn)

        ' Create second column.
        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "Snapshot2"
        myDataColumn.ReadOnly = False
        myDataColumn.Unique = False
        ' Add the column to the table.
        myDataTable.Columns.Add(myDataColumn)

        ' Create second column.
        myDataColumn = New DataColumn()
        myDataColumn.DataType = System.Type.GetType("System.String")
        myDataColumn.ColumnName = "Status"
        myDataColumn.ReadOnly = False
        myDataColumn.Unique = False
        ' Add the column to the table.
        myDataTable.Columns.Add(myDataColumn)

        ' Make the ID column the primary key column.

        Dim PrimaryKeyColumns(0) As DataColumn

        'PrimaryKeyColumns(0) = myDataTable.Columns("ID")
        PrimaryKeyColumns(0) = myDataTable.Columns("URL")
        myDataTable.PrimaryKey = PrimaryKeyColumns



        DataGridTableStyle1.MappingName = myDataTable.TableName
      







        ' Instantiate the DataSet variable.
        myDataSet = New DataSet()
        ' Add the new DataTable to the DataSet.
        myDataSet.Tables.Add(myDataTable)

        ' Create three new DataRow objects and add them to the DataTable
        ' Dim i As Integer
        'For i = 0 To 2
        'myDataRow = myDataTable.NewRow()
        'myDataRow("URL") = i
        'myDataRow("Snapshot1") = Now()
        'myDataRow("Snapshot2") = Now()
        'myDataRow("Status") = ""
        'myDataTable.Rows.Add(myDataRow)
        'Next i
    End Sub

    'Private Sub MakeChildTable()
        ' Create a new DataTable.
    'Dim myDataTable As DataTable = New DataTable("childTable")
    'Dim myDataColumn As DataColumn
    'Dim myDataRow As DataRow

        ' Create first column and add to the DataTable.
        'myDataColumn = New DataColumn()
        'myDataColumn.DataType = System.Type.GetType("System.Int32")
        'myDataColumn.ColumnName = "ChildID"
        'myDataColumn.AutoIncrement = True
        'myDataColumn.Caption = "ID"
        'myDataColumn.ReadOnly = True
        'myDataColumn.Unique = True
        ' Add the column to the DataColumnCollection.
        'myDataTable.Columns.Add(myDataColumn)

        ' Create second column.
        'myDataColumn = New DataColumn()
        'myDataColumn.DataType = System.Type.GetType("System.String")
        'myDataColumn.ColumnName = "ChildItem"
        'myDataColumn.AutoIncrement = False
        'myDataColumn.Caption = "ChildItem"
        'myDataColumn.ReadOnly = False
        'myDataColumn.Unique = False
        'myDataTable.Columns.Add(myDataColumn)

        ' Create third column.
        'myDataColumn = New DataColumn()
        'myDataColumn.DataType = System.Type.GetType("System.Int32")
        'myDataColumn.ColumnName = "ParentID"
        'myDataColumn.AutoIncrement = False
        'myDataColumn.Caption = "ParentID"
        'myDataColumn.ReadOnly = False
        'myDataColumn.Unique = False
        'myDataTable.Columns.Add(myDataColumn)

        'myDataSet.Tables.Add(myDataTable)
        ' Create three sets of DataRow objects, five rows each, and add to DataTable.
        'Dim i As Integer
        'For i = 0 To 4
        'myDataRow = myDataTable.NewRow()
        'myDataRow("childID") = i
        'myDataRow("ChildItem") = "Item " + i.ToString()
        'myDataRow("ParentID") = 0
        'myDataTable.Rows.Add(myDataRow)
        'Next i
        'For i = 0 To 4
        'myDataRow = myDataTable.NewRow()
        'myDataRow("childID") = i + 5
        'myDataRow("ChildItem") = "Item " + i.ToString()
        'myDataRow("ParentID") = 1
        'myDataTable.Rows.Add(myDataRow)
        'Next i
        'For i = 0 To 4
        '  myDataRow = myDataTable.NewRow()
        '   myDataRow("childID") = i + 10
        '    myDataRow("ChildItem") = "Item " + i.ToString()
        '     myDataRow("ParentID") = 2
        '      myDataTable.Rows.Add(myDataRow)
        '   Next i
        'End Sub

        ' Private Sub MakeDataRelation()
        ' DataRelation requires two DataColumn (parent and child) and a name.
        '    Dim myDataRelation As DataRelation
        '   Dim parentColumn As DataColumn
        '  Dim childColumn As DataColumn
        ' parentColumn = myDataSet.Tables("ParentTable").Columns("id")
        'childColumn = myDataSet.Tables("ChildTable").Columns("ParentID")
        'myDataRelation = New DataRelation("parent2Child", parentColumn, childColumn)
        'myDataSet.Tables("ChildTable").ParentRelations.Add(myDataRelation)
        'End Sub

    Private Sub BindToDataGrid()
        ' Instruct the DataGrid to bind to the DataSet, with the 
        ' ParentTable as the topmost DataTable.


        DataGrid1.SetDataBinding(myDataSet, "URL_Status")
        GetGridColumnProperties()
        'DataGrid1.AllowNavigation = False
        'DataGridTableStyle1.GridColumnStyles(0).Width = 20


        'Dim colstyle As DataGridTableStyle

        'colstyle.MappingName = "URL"
        'DataGridTableStyle1.GridColumnStyles.Add(colstyle)

    End Sub
    Public Sub GetGridColumnProperties()

        Dim myDataGridColumnStyle As DataGridColumnStyle
        Dim myGridColumnStylesCollection As _
        GridColumnStylesCollection
        myGridColumnStylesCollection = _
        dataGrid1.TableStyles(0).GridColumnStyles
        myDataGridColumnStyle = myGridColumnStylesCollection.Item(0)
        myDataGridColumnStyle.Width = 30


        myDataGridColumnStyle = myGridColumnStylesCollection.Item(1)
        myDataGridColumnStyle.Width = 332


        myDataGridColumnStyle = myGridColumnStylesCollection.Item(2)
        myDataGridColumnStyle.Width = 130


        myDataGridColumnStyle = myGridColumnStylesCollection.Item(3)
        myDataGridColumnStyle.Width = 130


        myDataGridColumnStyle = myGridColumnStylesCollection.Item(3)
        myDataGridColumnStyle.Width = 170

        'msgbox(myDataGridColumnStyle.NullText)
        'MsgBox(myDataGridColumnStyle.ToString())
        'Next
    End Sub


    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        MakeDataTables()
        Try
            myDataSet.ReadXml("urllist.xml")
        Catch err As System.Exception
            MsgBox("Could not load XML file, urllist.xml (" & err.Message & ")")
        End Try
        'Dim contextmenu1 As ContextMenu
        'contextmenu1.MenuItems.Add("Take New Snapshot")
        'DataGrid1.ContextMenu = contextmenu1
    End Sub

    Private Sub Form1_Closed(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        Try
            myDataSet.WriteXml("urllist.xml", XmlWriteMode.IgnoreSchema)
        Catch err As System.Exception
            MsgBox("Could not write to XML file, urllist.xml (" & err.Message & ")")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Dim filetoaccess = New System.IO.FileStream("urllist.txt", IO.FileMode.OpenOrCreate)
        'Dim filewriter = New System.IO.StreamWriter(filetoaccess, System.Text.Encoding.ASCII)
        'Dim runner = New Integer()
        'MsgBox(DataGrid1.DataMember.ToString())
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow
        myDataRow = myDataTable.NewRow()
        myDataRow("URL") = txtURL.Text
        myDataRow("Snapshot1") = Now()
        myDataRow("Snapshot2") = Now()
        myDataRow("Status") = "Checked"
        Try
            myDataTable.Rows.Add(myDataRow)

            myDataRow = myDataTable.Rows.Item(myDataTable.Rows.Count - 1)

            TakeSnapshot(txtURL.Text, myDataRow.Item(0))

        Catch err As System.Data.ConstraintException
            MsgBox("The URL you are trying to add already exists in the list.")
        End Try

        ' Declare variables for DataColumn and DataRow objects.
        'Dim myDataColumn As DataColumn

        'MsgBox(myDataTable.TableName)
        'MsgBox(myDataTable.Rows.Count())
        'For runner = 0 To myDataTable.Rows.Count - 1

        '   filewriter.write(myDataTable.Rows.Item(0).Item(1))
        'Next
        'DataGrid1.Select(runner)
        'Dim xmlreader As New System.Xml.Reader()

        'filewriter.close()
        'filetoaccess.close()
    End Sub

    Protected Function TakeSnapshot(ByVal url As String, ByVal id As Integer)
        Dim sServer As String
        Dim nPort As Long
        Dim sPage As String

        nPort = 80
        sServer = Trim(url)

        MsgBox(sServer)
        If sServer = "" Then Exit Function
        Dim HttpWReq As System.Net.HttpWebRequest = _
                  CType(System.Net.WebRequest.Create(sServer), System.Net.HttpWebRequest)

        If Proxy_Check.Checked = True Then
            Dim proxyObject As New System.Net.WebProxy(Proxy.Text, True)
            HttpWReq.Proxy = proxyObject
        End If

        Dim HttpWResp As System.Net.HttpWebResponse = _
           CType(HttpWReq.GetResponse(), System.Net.HttpWebResponse)



        Dim streamer As System.IO.StreamReader = New System.IO.StreamReader(HttpWResp.GetResponseStream, System.Text.Encoding.ASCII, False, 512)
        'txtSource.Text = streamer.ReadToEnd()
        '*************************************************
        Dim filetoaccess = New System.IO.FileStream(id.ToString & ".txt", IO.FileMode.OpenOrCreate)
        Dim filewriter = New System.IO.StreamWriter(filetoaccess, System.Text.Encoding.ASCII)






        '**********************************************


        While streamer.Peek() <> -1
            filewriter.writeline(streamer.ReadLine())
        End While
        ' Insert code that uses the response object.
        HttpWResp.Close()
        streamer.Close()
        filewriter.close()
        filetoaccess.close()
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow

        Dim keys(0) As Object
        'keys(0) = id
        keys(0) = url

        myDataRow = myDataTable.Rows.Find(keys)
        myDataRow.BeginEdit()
        myDataRow("Snapshot1") = Now()
        myDataRow.EndEdit()


        MsgBox("done")
    End Function

    Protected Function CompareSnapshot(ByVal url As String, ByVal id As Integer)
        Dim sServer As String
        Dim nPort As Long
        Dim sPage As String

        nPort = 80
        sServer = Trim(url)

        MsgBox(sServer)
        If sServer = "" Then Exit Function

        Dim HttpWReq As System.Net.HttpWebRequest = _
                CType(System.Net.WebRequest.Create(sServer), System.Net.HttpWebRequest)

        If Proxy_Check.Checked = True Then
            Dim proxyObject As New System.Net.WebProxy(Proxy.Text, True)
            HttpWReq.Proxy = proxyObject
        End If

        Dim HttpWResp As System.Net.HttpWebResponse = _
           CType(HttpWReq.GetResponse(), System.Net.HttpWebResponse)

        Dim streamer As System.IO.StreamReader = New System.IO.StreamReader(HttpWResp.GetResponseStream, System.Text.Encoding.ASCII, False, 512)
        'txtSource.Text = streamer.ReadToEnd()
        '*************************************************
        Dim filetoaccess = New System.IO.FileStream("temp.txt", IO.FileMode.OpenOrCreate)
        Dim filewriter = New System.IO.StreamWriter(filetoaccess, System.Text.Encoding.ASCII)


        '**********************************************


        While streamer.Peek() <> -1
            filewriter.writeline(streamer.ReadLine())
        End While
        ' Insert code that uses the response object.
        HttpWResp.Close()
        streamer.Close()
        filewriter.close()
        filetoaccess.close()
        Dim filereader1 As System.IO.StreamReader = New System.IO.StreamReader("temp.txt", System.Text.Encoding.ASCII, False, 512)
        Dim filereader2 As System.IO.StreamReader = New System.IO.StreamReader(id.ToString & ".txt", System.Text.Encoding.ASCII, False, 512)
        Dim flagged As Boolean = False
        While filereader1.Peek() <> -1
            If Not String.Compare(filereader1.ReadLine, filereader2.ReadLine) = 0 Then
                MsgBox("Files are different " & id)
                filereader1.Close()
                filereader2.Close()
                TakeSnapshot(url, id)
                MsgBox("New Snapshot Taken")
                flagged = True
                Exit While
            End If

        End While
        If flagged = False Then
            filereader1.Close()
            filereader2.Close()
        End If
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow
        Dim keys(0) As Object
        'keys(0) = id
        keys(0) = url

        myDataRow = myDataTable.Rows.Find(keys)
        myDataRow.BeginEdit()
        myDataRow("Snapshot2") = myDataRow("Snapshot1")
        myDataRow.EndEdit()




        ' MsgBox("done")
    End Function


    Private Sub a(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.ContextMenuChanged
        MsgBox("hello")
    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim myDataTable As DataTable = myDataSet.Tables.Item(0)
        Dim myDataRow As DataRow


        For Each myDataRow In myDataTable.Rows
            ' myDataRow = myDataTable.Rows.Find(keys)
            'myDataRow.BeginEdit()
            MsgBox(myDataRow("URL") & "  " & myDataRow("ID"))
            CompareSnapshot(myDataRow("URL"), myDataRow("ID"))
            'MsgBox(myDataRow("URL"))
            'myDataRow.EndEdit()
        Next

    End Sub
End Class

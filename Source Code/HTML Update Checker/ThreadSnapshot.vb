Public Class ThreadSnapshot
    Inherits System.ComponentModel.Component
    Public DataTable1 As DataTable
    Public url As String
    Public id As Integer
    Public ProxyCheck As Boolean
    Public ProxyText As String

    Public Event AnEvent()


#Region " Component Designer generated code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        'Current_Threads = 0
    End Sub

    'Component overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    ' Compares a new snapshot with stored snapshot


    Public Sub StartThreads(ByVal job_number As Integer)
        ' Determines which thread to start based on the value it receives.
        'Select Case job_number
        'Case 2
        Dim Thread As New System.Threading.Thread(AddressOf CompareSnapshot)
        Thread.Start()
        'End Select

    End Sub



    Public Sub CompareSnapshot()
        Dim myDataTable As DataTable = DataTable1
        Dim myurl As String = url
        Dim myid As Integer = id
        Dim myProxyCheck As Boolean = ProxyCheck
        Dim myProxyText As String = ProxyText

        Dim result As Boolean = TakeSnapshot(1, myDataTable, myurl, myid, myProxyCheck, myProxyText)

        If result = True Then
            'Dim myDataTable As DataTable = DataTable1
            Dim myDataRow As DataRow
            Dim keys(0) As Object

            keys(0) = myurl

            myDataRow = myDataTable.Rows.Find(keys)

            Dim filereader1 As System.IO.StreamReader = New System.IO.StreamReader("temp" & myid.ToString & ".txt", System.Text.Encoding.ASCII, False, 512)
            Dim filereader2 As System.IO.StreamReader = New System.IO.StreamReader(myid.ToString & ".txt", System.Text.Encoding.ASCII, False, 512)
            Dim flagged As Boolean = False
            While filereader1.Peek() <> -1
                If Not String.Compare(filereader1.ReadLine, filereader2.ReadLine) = 0 Then

                    filereader1.Close()
                    filereader2.Close()
                    TakeSnapshot(2, myDataTable, myurl, myid, myProxyCheck, myProxyText)

                    myDataRow.BeginEdit()
                    myDataRow("Status") = "Update Detected"
                    myDataRow.EndEdit()

                    flagged = True
                    Exit While
                End If

            End While
            If flagged = False Then
                filereader1.Close()
                filereader2.Close()
                myDataRow.BeginEdit()
                myDataRow("Status") = "Page unchanged"
                myDataRow.EndEdit()
            End If
        Else
            Dim myDataRow As DataRow
            Dim keys(0) As Object
            ' keys(0) = id
            keys(0) = myurl

            myDataRow = myDataTable.Rows.Find(keys)


            myDataRow.BeginEdit()
            myDataRow("Status") = "Error Encountered"
            myDataRow.EndEdit()
        End If

        Dim filetomanip As System.IO.File
        If filetomanip.Exists("temp" & myid.ToString & ".txt") Then
            filetomanip.Delete("temp" & myid.ToString & ".txt")
        End If

        'Current_Threads = Current_Threads - 1
        RaiseEvent AnEvent()
    End Sub

    ' Retrieves URL source and writes it to file
    Protected Function TakeSnapshot(ByVal snapshot As Integer, ByVal myDataTable As DataTable, ByVal url As String, ByVal id As Integer, ByVal ProxyCheck As Boolean, ByVal ProxyText As String) As Boolean

        ' Find the row in the datagrid for which the snapshot is to be taken
        ' Dim myDataTable As DataTable = DataTable1
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

        'StatusBar1.Text = "Connecting to Host"
        'StatusBar2.Text = sServer

        Dim errorhandled As Boolean = False

        Try
            ' Send HTTP request
            Dim HttpWReq As System.Net.HttpWebRequest = _
                      CType(System.Net.WebRequest.Create(sServer), System.Net.HttpWebRequest)

            ' Use proxy if necessary
            If ProxyCheck = True Then
                Dim proxyObject As New System.Net.WebProxy(ProxyText, True)
                HttpWReq.Proxy = proxyObject
            End If

            ' Get Response
            Dim HttpWResp As System.Net.HttpWebResponse = _
               CType(HttpWReq.GetResponse(), System.Net.HttpWebResponse)

            ' StatusBar1.Text = "Connected"
            'StatusBar2.Text = sServer

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

            'StatusBar1.Text = "Creating File"
            'StatusBar2.Text = sServer

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
            'StatusBar1.Text = "File Created"
            'StatusBar2.Text = sServer

            myDataRow.EndEdit()

            If snapshot = 0 Then
                'StatusBar1.Text = "URL added"
                'StatusBar2.Text = sServer
            End If

        Catch errr As System.Net.WebException
            If errorhandled = False Then
                errorhandled = True
                MsgBox(errr.Message, MsgBoxStyle.Exclamation, "Error Encountered")
                If snapshot = 0 Then
                    myDataRow.BeginEdit()
                    myDataRow.Delete()
                    myDataRow.EndEdit()
                End If
                ' StatusBar1.Text = "Failed to add URL"
                'StatusBar2.Text = sServer
                TakeSnapshot = False
            End If

        Catch er As System.Exception
            If errorhandled = False Then
                errorhandled = True
                MsgBox(er.Message, MsgBoxStyle.Exclamation, "Error Encountered")
                If snapshot = 0 Then
                    myDataRow.BeginEdit()
                    myDataRow.Delete()
                    myDataRow.EndEdit()
                End If
                'StatusBar1.Text = "Failed to add URL"
                ' StatusBar2.Text = sServer
                TakeSnapshot = False
            End If
        End Try

    End Function



End Class

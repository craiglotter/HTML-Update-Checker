Public Class Queue_Item
    'Tasks:
    '1 - Take Snapshot
    '2 - Compare Snapshot
    '3 - Check Source
    Public task As Integer
    Public URL As String

    Public Sub New(ByVal intask As Integer, ByVal inurl As String)
        MyBase.New()
        task = intask
        URL = inurl
    End Sub

End Class

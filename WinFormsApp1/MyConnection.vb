Public Class MyConnection
    Public con As New ADODB.Connection

    Public Sub NewConnection()
        On Error GoTo aaa

        con = New ADODB.Connection
            con.CommandTimeout = 0
            con.ConnectionTimeout = 0
            con.Open("Driver={MySQL ODBC 8.0 Unicode Driver};Server=103.195.140.222;Database=ogmesco2_kop;User=kop;Password=premp@ss&*^#!@;Option=18475;Port = 3306;Max Pool Size=200;Connect Timeout=0;POOLING=true;max_connections=1000;Packet Size=32000;max_allowed_packet=2G;")
aaa:
        MessageBox.Show(Err.Description.ToString())


    End Sub


End Class

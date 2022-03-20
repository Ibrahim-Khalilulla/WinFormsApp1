Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Xml

Public Class Form1
    Dim rst As New ADODB.Recordset
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sData() As String
        ' Dim arrName As New List(Of String)()
        Dim sFile As String
        sFile = TextBox2.Text
        Dim sw As New StreamWriter(TextBox3.Text)
        Using sr As New StreamReader(sFile)
            While Not sr.EndOfStream
                sData = sr.ReadLine().Split(",")

                'arrName.Add(sData(0).Trim())
                'ListBox1.Items.Add(sData(0).Trim())
                Dim mob As String
                mob = "0" & sData(0).Trim()

                'Dim hc As HttpClient
                'hc = New HttpClient
                'Try
                '    Dim rm As HttpResponseMessage
                '    rm = Await hc.GetAsync("https://api.mobireach.com.bd/SendTextMessage?Username=rajasthan&Password=Windows@1122&From=RAJASTHAN&To=" & mob & "&Message=" & TextBox1.Text)
                '    If rm.IsSuccessStatusCode Then
                '        Dim res As Boolean
                '        res = Await rm.Content.ReadAsStringAsync
                '        If res Then
                '            MessageBox.Show(res.ToString())
                '        End If
                '    End If
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message.ToString)
                'End Try


                'Dim wc As WebClient
                'wc = New WebClient
                'Try
                '    Dim res As Boolean
                '    res = wc.DownloadString("https://api.mobireach.com.bd/SendTextMessage?Username=rajasthan&Password=Windows@1122&From=RAJASTHAN&To=" & mob & "&Message=" & TextBox1.Text)
                '    If res Then
                '        MessageBox.Show("OK")
                '    End If
                'Catch ex As Exception
                '    MessageBox.Show(ex.Message.ToString)
                'End Try
                Dim xmlDoc As New XmlDocument
                Dim nsMgr As XmlNamespaceManager


                Dim hwrequest As Net.HttpWebRequest = Net.HttpWebRequest.Create("https://api.mobireach.com.bd/SendTextMessage?Username=rajasthan&Password=Myr@j@sthan321&From=RAJASTHAN&To=" & mob & "&Message=" & TextBox1.Text)
                'hwrequest.CookieContainer = cookies
                hwrequest.Accept = "*/*"
                'hwrequest.AllowAutoRedirect = False
                'hwrequest.UserAgent = "http_requester/0.1"
                'hwrequest.Timeout = 60000
                hwrequest.Method = "GET"
                Dim hwresponse As Net.HttpWebResponse = hwrequest.GetResponse()
                If hwresponse.StatusCode = Net.HttpStatusCode.OK Then
                    Dim responseStream As IO.StreamReader =
         New IO.StreamReader(hwresponse.GetResponseStream())
                    'MessageBox.Show(responseStream.ReadToEnd())
                    xmlDoc.LoadXml(responseStream.ReadToEnd().ToString)
                    nsMgr = New XmlNamespaceManager(xmlDoc.NameTable)
                    Dim selectedNode = xmlDoc.SelectSingleNode("ArrayOfServiceClass/ServiceClass/StatusText", nsMgr)
                    If selectedNode.InnerText = "success" Then
                        sw.WriteLine(mob)
                    End If
                End If



            End While
        End Using

        sw.Close()
        MessageBox.Show("sesh")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        MessageBox.Show(TextBox1.Text)

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim a As New MyConnection()
        a.NewConnection()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim sw As New StreamWriter(TextBox3.Text)
        sw.WriteLine("hello")
        sw.WriteLine("world")

        'File.AppendText(sw, TextBox1.Text)
        sw.Close()
        MessageBox.Show("ok")
    End Sub
End Class

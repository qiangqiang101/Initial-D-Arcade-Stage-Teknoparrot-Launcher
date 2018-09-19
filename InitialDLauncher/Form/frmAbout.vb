Public Class frmAbout

    Dim htmlstring As String = "
<!DOCTYPE html>
<html>
<head>
<style>
body {
    background-color: #323232;
}
</style>
</head>
<body>
<div style=""font-family:'Segoe UI'; font-size:small;"" ><center><font color=""white"">
<h3>DEVELOPED BY</h3>
I'm Not MentaL

<h3>THIRD PARTY</h3>
This application uses some parts which provided by third party.<br /><br />

Build with Microsoft Visual Studio 2015<br />
The PHP Group<br />
Winform DropShadow © 陈杨文<br />
PlayFile © Blake Pell<br />
PHP/SQL Leaderboard © Alex Rose<br />
ExtendedWebClient © ChrisD<br />
GameSpot Theme © w3layouts<br />
Translucent Control using GDI+ © a_pess<br />
SplitButton Control © bergerkiller<br />
Net Seal Theme © aeonhack<br />
simple plugin mechanism © chriga<br />
GifImage © Jeremy Thompson<br />
CheckJapaneseCharacterWidth © Gekka<br />
CRCDotNet © Gediminas Masaitis<br />

<h3>LOCALIZATION CONTRIBUTORS</h3>
English - I'm Not MentaL & Kurisuchan<br />
繁體中文 - 奥巴鸡<br />
简体中文 - 奥巴鸡<br />
日本語 - 雪熊霸<br />
한국어 - Mellanitomo Gen<br />
Bahasa Malaysia - Kurisuchan<br />
Deutsche - Soul<br />
Español - Gixer & Batlez<br />
Français (Outdated) - nucleaireland<br />

<h3>COMMUNITY CONTRIBUTORS</h3>
BearBo Ultra/ComputerNoob - Player Name, Legend Chapter & Chapter Level Offset<br />
Lemon The Kid - Avatar Offset, Avatar Preview Pictures for InitialD 6, MyFrame Preview Pictures ofr InitialD 8, Car Color, Car Engine/Rollbar Parts, Car Fullspec, Car Number Plate, 
Aura, Avatar Names & etc<br />
AkiiHoshi - Avatar Preview Pictures for InitialD 7<br />
Nezarn - Avatar Preview Pictures for InitialD 8<br />
oPTToXenMe - Level Offset<br />
Gammaガァマ - Car Name Offset<br />
DSThanatos - Time Attack ID6 Offset<br />
Turtle - Mileage Offset<br />
AsukaXVB - InitialD 8 Offsets<br />
TheKrzysiek - InitialD 8 Aura & Custom Tachometers<br />
小默 - InitialD 8 Title Effects & InitialD 8 Title<br />
I'm Not MentaL - Gender Offset, Time Attack ID7 Offset & Time Attack ID8 Offset<br />

<h3>THANKS TO</h3>
(alphabetically)<br />
Adrian Bloeß, Alexander Pfitzner (GTAInside), Angela Ziegler, Black Tree Gaming Limited, BYEONGHEOL LEE, Christine Guillory, Christopher Stewart (DoctorGTA), Chris Wong, 
Daniel López Sánchez, Daniel Ly, Daniel Van der Meer, David Womacks, Насыров Адель, HCT Tuning, Heng Zhang, James, John Yang, Juiced Box Computers, Kira Manell, 
Kito Zhayne Bordeos, Kyousuke Nanikawa, Marcelle Waul, Matthew Adair, Michael J Bradley (Digitalclips), Muhammad Alfa Alghifari, Patrick Hu, Paul Cybulska, Tan Hock, 
Thomas Tunac-De Leon, Timo Düsterhöft, Timur Nurtayev, William Argoud, Yongli Chang, Zhenjie Zou, Zigeng Ma, 辰斐 丁, דור צרפתי
<br />

<h3>SPECIAL THANKS TO</h3>
Reaver, Keb, Avail, NTAuthority<br />

<h3>HUGE THANKS TO</h3>
SEGA<br />
</font></center></div>
</body>
</html>"

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Translate()
        wbAbout.WB.DocumentText = htmlstring

        For Each item In frmLauncher.plugins
            lvPlugins.AddItem(item.Name, item.Version, item.Author, "")
        Next

        wbAbout.WB.IsWebBrowserContextMenuEnabled = False
    End Sub

    Private Sub llblWebsite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblWebsite.LinkClicked
        Process.Start("https://www.imnotmental.com")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Translate()
        Try
            Dim langFile As String = String.Format("{0}\Languages\{1}.ini", My.Application.Info.DirectoryPath, My.Settings.Language)
            lblVersion.Text = String.Format(ReadCfgValue("VersionBuild", langFile), FileVersionInfo.GetVersionInfo(Application.ExecutablePath).FileVersion, frmLauncher.buildDate)
            lblTitle.Text = ReadCfgValue("LauncherTitle", langFile)
            Me.Text = ReadCfgValue("AboutMeText", langFile)
            NsTheme1.Text = Me.Text
            NsGroupBox1.Title = ReadCfgValue("Plugins", langFile)
            btnDonate.Text = ReadCfgValue("Donate", langFile)
            lvPlugins.Columns(0).Text = ReadCfgValue("PluginName", langFile)
            lvPlugins.Columns(1).Text = ReadCfgValue("VersionText", langFile)
            lvPlugins.Columns(2).Text = ReadCfgValue("Author", langFile)
        Catch ex As Exception
            NSMessageBox.ShowOk(ex.Message, MessageBoxIcon.Error, "Error")
            Logger.Log(ex.Message & ex.StackTrace)
        End Try
    End Sub

    Private Sub btnDonate_Click(sender As Object, e As EventArgs) Handles btnDonate.Click
        Process.Start("https://www.paypal.me/IMNOTMENTAL")
    End Sub

    Private Sub frmAbout_LocationChanged(sender As Object, e As EventArgs) Handles MyBase.LocationChanged
        If Me.Location.Y <= -1 Then
            Me.Location = New Point(Me.Location.X, 0)
        End If
    End Sub

    Private Sub frmAbout_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        frmLauncher.Enabled = True
    End Sub
End Class
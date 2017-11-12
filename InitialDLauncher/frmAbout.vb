Public Class frmAbout

    Dim htmlstring As String = "<center><h2>Developed by</h2>
I'm Not MentaL

<h2>Third Party</h2>
This application uses some parts which provided by third party.<br /><br />

Build with Microsoft Visual Studio 2015, <br />
The PHP Group, <br />
Winform DropShadow © 陈杨文, <br />
PlayFile © Blake Pell, <br />
PHP/SQL Leaderboard © Alex Rose<br />
ExtendedWebClient © ChrisD<br />

<h2>Localization contributors</h2>
English - I'm Not MentaL<br />
中文 - I'm Not MentaL<br />
French - nucleaireland<br />

<h2>Skill contributors</h2>
BearBo Ultra/ComputerNoob - Player Name, Legend Chapter & Chapter Level Offset,<br />
Lemon The Kid - Avatar Offset & Avatar Preview Pictures,<br />
oPTToXenMe - Level Offset,<br />
Gammaガァマ - Car Name Offset,<br />
DSThanatos - Time Attack ID6 Offset,<br />
I'm Not MentaL - Gender Offset, Time Attack ID7 Offset<br />

<h2>Thanks to</h2>
(alphabetically)<br />
Adrian Bloeß, Alexander Pfitzner (GTAInside), Black Tree Gaming Limited (Nexus Mods), Christine Guillory, Christopher Stewart (DoctorGTA), Daniel López Sánchez, Daniel Van der Meer, David Womacks, Насыров Адель, HCT Tuning, Heng Zhang, Juiced Box Computers, Kenny, Kira Manell, Map1e, Marcelle Waul, Matthew Adair, Michael J Bradley (Digitalclips), obataku7, Paul Cybulska, Rob Campbell, Tan Hock, Timo Düsterhöft, William Argoud, Zhenjie Zou, Zigeng Ma, 辰斐 丁, דור צרפתי
<br />
<h2>Special Thanks to</h2>
Reaver, Keb, Avail, NTAuthority<br />

<h2>Huge Thanks to</h2>
SEGA</center>"

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblVersion.Text = String.Format("Version: {0} Build: {1}", My.Application.Info.Version, frmLauncher.buildDate)
        wbAbout.DocumentText = htmlstring
    End Sub

    Private Sub llblWebsite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llblWebsite.LinkClicked
        Process.Start("https://www.imnotmental.com")
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
#Region "#usings"
Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.Utils
#End Region ' #usings

Namespace TabStop_EachNCharacters
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			richEditControl1.CreateNewDocument()
			richEditControl1.Views.DraftView.AllowDisplayLineNumbers = True
			richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft

		End Sub

		Private Sub barButtonItem1_ItemClick(ByVal sender As Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles barButtonItem1.ItemClick
'			#Region "#measuresinglelinestring"
			Dim document As Document = richEditControl1.Document
			Dim tabSize As SizeF = richEditControl1.MeasureSingleLineString(New String(" "c, 4), _
 document.DefaultCharacterProperties)
			Dim tabs As TabInfoCollection = document.Paragraphs(0).BeginUpdateTabs(True)
			Try
				For i As Integer = 1 To 30
					Dim tab As New DevExpress.XtraRichEdit.API.Native.TabInfo()
					tab.Position = i * tabSize.Width
					tabs.Add(tab)
				Next i
			Finally
				document.Paragraphs(0).EndUpdateTabs(tabs)
			End Try
'			#End Region ' #measuresinglelinestring
		End Sub

		Private Sub richEditControl1_InitializeDocument(ByVal sender As Object, ByVal e As EventArgs) Handles richEditControl1.InitializeDocument
			Dim document As Document = richEditControl1.Document
			document.BeginUpdate()
			Try
				document.DefaultCharacterProperties.FontName = "Courier New"
				document.DefaultCharacterProperties.FontSize = 10
				document.Sections(0).Page.Width = Units.InchesToDocumentsF(100)
				document.Sections(0).LineNumbering.CountBy = 1
				document.Sections(0).LineNumbering.RestartType = LineNumberingRestart.Continuous
			Finally
				document.EndUpdate()
			End Try
		End Sub

	End Class
End Namespace
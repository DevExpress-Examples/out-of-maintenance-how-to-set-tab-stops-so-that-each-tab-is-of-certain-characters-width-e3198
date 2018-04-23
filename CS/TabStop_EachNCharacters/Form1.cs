using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
#region #usings
using DevExpress.XtraRichEdit.API.Native;
using DevExpress.XtraRichEdit.Utils;
#endregion #usings

namespace TabStop_EachNCharacters
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            richEditControl1.CreateNewDocument();
            richEditControl1.Views.DraftView.AllowDisplayLineNumbers = true;
            richEditControl1.ActiveViewType = DevExpress.XtraRichEdit.RichEditViewType.Draft;

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            #region #measuresinglelinestring
            Document document = richEditControl1.Document;
            SizeF tabSize = richEditControl1.MeasureSingleLineString(new String(' ', 4), document.DefaultCharacterProperties);
            TabInfoCollection tabs = document.Paragraphs[0].BeginUpdateTabs(true);
            try {
                for (int i = 1; i <= 30; i++) {
                    DevExpress.XtraRichEdit.API.Native.TabInfo tab = new DevExpress.XtraRichEdit.API.Native.TabInfo();
                    tab.Position = i * tabSize.Width;
                    tabs.Add(tab);
                }
            }
            finally {
                document.Paragraphs[0].EndUpdateTabs(tabs);
            }
            #endregion #measuresinglelinestring
        }

        private void richEditControl1_InitializeDocument(object sender, EventArgs e)
        {
            Document document = richEditControl1.Document;
            document.BeginUpdate();
            try {
                document.DefaultCharacterProperties.FontName = "Courier New";
                document.DefaultCharacterProperties.FontSize = 10;
                document.Sections[0].Page.Width = Units.InchesToDocumentsF(100);
                document.Sections[0].LineNumbering.CountBy = 1;
                document.Sections[0].LineNumbering.RestartType = LineNumberingRestart.Continuous;
            }
            finally {
                document.EndUpdate();
            }
        }

    }
}
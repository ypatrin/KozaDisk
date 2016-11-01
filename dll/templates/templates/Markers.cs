using DevExpress.XtraRichEdit.API.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms; //for debug only

namespace templates
{
    class Markers
    {
        public string processMarkers(string html, string markerName, string markerType)
        {
            if (markerType == "text")
            {
                html = html.Replace("$$" + markerName + "$$", "<input type='text' name='" + markerName + "' id='" + markerName + "'>");
            }

            return html;
        }

        public Document replaceInDocument(Document document, string from, string to)
        {
            document.BeginUpdate();
            try
            {
                DocumentRange[] ranges = document.FindAll("$$" + from + "$$", SearchOptions.None);

                foreach (DocumentRange range in ranges)
                {
                    document.Replace(range, to);
                }
            }
            finally
            {
                document.EndUpdate();
            }
            return document;
        }
    }
}

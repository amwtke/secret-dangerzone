using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Net;

using System.Threading;

using System.IO;





namespace HtmlHelper
{

    internal class WebReqState
    {

        public byte[] Buffer;

        public MemoryStream ms;

        public const int BufferSize = 1024;

        public Stream OrginalStream;

        public HttpWebResponse WebResponse;



        public WebReqState()
        {

            Buffer = new byte[1024];

            ms = new MemoryStream();

        }

    }

    public delegate void ReadDataComplectedEventHandler(byte[] data);



    public class HtmlFromWebReq
    {
        private Uri url;
        public event ReadDataComplectedEventHandler OnReadDataComplected;
        public HtmlFromWebReq(string absoluteUrl,ReadDataComplectedEventHandler hendler)
        {
            if (hendler != null)
            {
                OnReadDataComplected += hendler;
            }
            url = new Uri(absoluteUrl);

        }

        protected void readDataCallback(IAsyncResult ar)
        {
            WebReqState rs = ar.AsyncState as WebReqState;

            int read = rs.OrginalStream.EndRead(ar);

            if (read > 0)
            {
                rs.ms.Write(rs.Buffer, 0, read);

                rs.OrginalStream.BeginRead(rs.Buffer, 0, WebReqState.BufferSize,

                    new AsyncCallback(readDataCallback), rs);
            }
            else
            {
                rs.OrginalStream.Close();

                rs.WebResponse.Close();

                if (OnReadDataComplected != null)
                {

                    OnReadDataComplected(rs.ms.ToArray());

                }

            }



        }



        protected void responseCallback(IAsyncResult ar)
        {

            HttpWebRequest req = ar.AsyncState as HttpWebRequest;

            if (req == null)

                return;

            HttpWebResponse response =

                req.EndGetResponse(ar) as HttpWebResponse;

            if (response.StatusCode != HttpStatusCode.OK)
            {

                response.Close();

                return;

            }

            WebReqState st = new WebReqState();

            st.WebResponse = response;

            Stream repsonseStream = response.GetResponseStream();

            st.OrginalStream = repsonseStream;

            repsonseStream.BeginRead(st.Buffer, 0,

                WebReqState.BufferSize,

                new AsyncCallback(readDataCallback), st);

        }

        public void BeginCreateHtml()
        {

            HttpWebRequest req =

                HttpWebRequest.Create(url.AbsoluteUri) as HttpWebRequest;

            req.BeginGetResponse(new AsyncCallback(responseCallback), req);

        }



    }

}
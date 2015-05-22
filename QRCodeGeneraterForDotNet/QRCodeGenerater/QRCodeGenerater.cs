﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Windows.UI.Xaml.Media.Imaging;

namespace QRCodeGenerater
{
    // ------------------------------------------------------------------------------
    //  <autogenerated>
    //      This code was generated by a tool.
    //      Mono Runtime Version: 4.0.30319.17020
    // 
    //      Changes to this file may cause incorrect behavior and will be lost if 
    //      the code is regenerated.
    //  </autogenerated>
    // ------------------------------------------------------------------------------
    using System;
    using System.Net.Http;

    namespace QRCodeGeneraterForDotNet
    {
        public class QRCodeGenerater
        {

            public WriteableBitmap GenerateQRCode(string source, short width, short height)
            {
                string URL = makeURL(source, width, height);

            }

            protected writeableBitmap getImageFromURL(string url)
            {
                HttpClient client = new HttpClient();
                var response = client.GetAsync(url);

                if (!response.Result.IsSuccessStatusCode)
                {
                    throw new Exception("画像の取得に失敗しました");
                }


            }

            protected string makeURL(string source, short width, short height)
            {
                string result = "http://chart.googleapis.com/chart?cht=qr";

                result += "&" + "chl=" + source;
                result += "&" + "chs=" + width + "x" + height;
                return result;

            }
        }
    }


}

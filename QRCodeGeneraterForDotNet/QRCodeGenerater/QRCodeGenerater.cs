using System;
using Windows.UI.Xaml.Media.Imaging;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace QRCodeGenerater
{
    //    Copyright [yyyy] [name of copyright owner]

    //Licensed under the Apache License, Version 2.0 (the "License");
    // you may not use this file except in compliance with the License.
    // You may obtain a copy of the License at

    //     http://www.apache.org/licenses/LICENSE-2.0

    // Unless required by applicable law or agreed to in writing, software
    // distributed under the License is distributed on an "AS IS" BASIS,
    // WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
    // See the License for the specific language governing permissions and
    // limitations under the License.

    using System;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;

    namespace QRCodeGeneraterForDotNet
    {
        public class QRCodeGenerater
        {
            public int Width { get; set; } = 256;
            public int Height { get; set; } = 256;

            public async Task<WriteableBitmap> GenerateQRCode(string source)
            {
                string URL = makeURL(source);

                var bitmap = await getImageFromURL(URL);
                return bitmap ?? new WriteableBitmap(Width, Height);
            }

            protected async Task<WriteableBitmap> getImageFromURL(string url)
            {
                HttpClient client = new HttpClient();
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("画像の取得に失敗しました");
                }

                byte[] resultByte = await response.Content.ReadAsByteArrayAsync();


                var bitmap = new WriteableBitmap(Width, Height);

                using (var pixelStream = bitmap.PixelBuffer.AsStream())
                {
                    pixelStream.Seek(0, SeekOrigin.Begin);
                    pixelStream.Write(resultByte, 0, resultByte.Length);
                }

                return bitmap;

            }

            protected string makeURL(string source)
            {
                string result = "http://chart.googleapis.com/chart?cht=qr";

                result += "&" + "chl=" + source;
                result += "&" + "chs=" + Width + "x" + Height;
                return result;

            }
        }
    }


}

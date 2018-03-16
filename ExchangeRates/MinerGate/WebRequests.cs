﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using MirzaCryptoHelpers.Common;
using MirzaCryptoHelpers.Extensions;
using MirzaCryptoHelpers.SymmetricCryptos;
using Newtonsoft.Json.Linq;

namespace ExchangeRates.MinerGate
{
    public class WebRequests
    {
        public WebRequests()
        {
            /**/
        }

        public JObject GetObject(string token, string baseUrl, string endPoint)
        {
            return JObject.Parse(Get(baseUrl, endPoint, token));
        }

        public JArray GetArray(string token, string baseUrl, string endPoint)
        {
            return JArray.Parse(Get(baseUrl, endPoint, token));
        }

        public string GetString(string token, string baseUrl, string endPoint)
        {
            return Get(baseUrl, endPoint, token);
        }

        private static string Get(string baseUrl, string endPoint, string token)
        {
            var request = (HttpWebRequest)WebRequest.Create(baseUrl + endPoint);
            request.ContentType = "application/json";

            if (!string.IsNullOrEmpty(token))
                request.Headers.Add("token", token);

            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }

        public JObject Login(int? totp)
        {
            var request = (HttpWebRequest) WebRequest.Create("https://minergate.com/api/2.2" + "/auth/login");

            request.Method = "POST";
            request.ContentType = "application/json";
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36";
            request.Referer = "https://minergate.com/login";
            request.Accept = "*/*";
            request.Host = "minergate.com";

            request.Headers.Add("Origin", "https://minergate.com");

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                dynamic jsonObject = new JObject();

                jsonObject.email = Statics.YourEmailAddress;
                /*
                string input = Statics.YourPassword;
                string password = "P@s$w0rD~!";
                byte[] cipherInBytes = new AESCrypto().Encrypt(
                    BitHelpers.ConvertStringToBytes(input), password
                );  //byte[16] { 6, 186, 118, 13, 202, 18, 116, 245, 127, 199, 186, 125, 9, 117, 187, 9 }
                string cipherInBase64 = BitHelpers.ConvertToBase64String(cipherInBytes); //Brp2DcoSdPV/x7p9CXW7CQ==

                string plain = BitHelpers.ConvertBytesToString(
                    new AESCrypto().Decrypt(
                        BitHelpers.ConvertFromBase64String(cipherInBase64), password
                    )
                ); //Hello World!
                */
                var hashPassword = BCrypt.Net.BCrypt.HashPassword(Statics.YourPassword);//minergate encrypt salt
                jsonObject.password = hashPassword;
                //hashPassword;//, "$2a$10$OOv2wLxbNjUxVcc1sjysau");//minergate encrypt salt
                jsonObject.recaptcha = "03AMPJSYWOWPdMqxbFD8yWUHyspcbA3GFO7mtLPLcTbzzZoCQutHlcPvXhCQn_vgeyPU9GX0hKFg7N-zVvup70mATISQTL0Gp8NYaux0mMnfDPfGX7pA1dZvP-wpf-FWsmOIHTi8QusVyk_9q8qNj0Ge0GaeGk7ohA-C6uGGeR34-aY4DYc3pplmywnQ3VC3IAZ6e4zLdfkJuqD_gKMQR1VnZHAIoLujcccCL9EJHqzzPV9lju7ILDi5OScX5uKdYFYs_5yIZDe7gGdHGU2ybu_VivQu0K5936AroM_VPacT2_M7mAahWH7R2fua2NigsbmcBbWRCiTEVB2OdMmUMiJOSI0w9RTCS2udnhpVMVGkwmLyUxJqw404SisLKmI780E2G9fLwMjU4AmuPXRz407LRfQYdGKHVCEYWwWezjiM4Dzwm36Crq_sk";
                //jsonObject.totp = totp;

                streamWriter.Write(jsonObject.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                return JObject.Parse(streamReader.ReadToEnd());
            }
        }
    }
}

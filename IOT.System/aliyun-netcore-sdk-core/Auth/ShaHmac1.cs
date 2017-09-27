/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
using System;
using System.Security.Cryptography;
using System.Text;

namespace Aliyun.Acs.Core.Auth
{
    public class ShaHmac1 : ISigner
    {

        public override string SignerName
        {
            get
            {
                return "HMAC-SHA1";
            }
        }

        public override string SignerVersion
        {
            get
            {
                return "1.0";
            }
        }

        //public override String SignString(String source, String accessSecret)
        //{
        //    using (var algorithm = KeyedHashAlgorithm.Create("HMACSHA1"))
        //    {
        //        algorithm.Key = Encoding.UTF8.GetBytes(accessSecret.ToCharArray());
        //        return Convert.ToBase64String(algorithm.ComputeHash(Encoding.UTF8.GetBytes(source.ToCharArray())));
        //    }
        //}

        public override String SignString(string source, string accessSecret)
        {
            HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(accessSecret));
            hmac.Initialize();

            byte[] buffer = Encoding.UTF8.GetBytes(source);
            if (true)
            {
                byte[] ret = hmac.ComputeHash(buffer);
                return Convert.ToBase64String(ret);
            }
            else
            {
                string res = BitConverter.ToString(hmac.ComputeHash(buffer)).Replace("-", "").ToLower();
                return Convert.ToBase64String(Encoding.UTF8.GetBytes(res));
            }
        }
    }
}

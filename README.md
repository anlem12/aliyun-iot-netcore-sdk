# aliyun-iot-netcore-sdk
阿里云IOT 服务器端 SDK ，使用旧版本(V20160530)改写  ，.NETCore

用法：


		/// <summary>
        /// 发送消息到设备
        /// </summary>
        /// <param name="device_productKey">产品Key</param>
        /// <param name="device_topic">设备topic</param>
        /// <param name="msgContent">消息内容</param>
        public static bool Pub(long device_productKey,string device_topic,string msgContent)
        {
            IClientProfile clientProfile = DefaultProfile.GetProfile("cn-shanghai", "accessKeyId", "secret");
            DefaultAcsClient client = new DefaultAcsClient(clientProfile);
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(msgContent);
                string strContent = Convert.ToBase64String(bytes);

                PubRequest pub = new PubRequest();
                pub.ProductKey = device_productKey;
                pub.MessageContent = strContent;
                pub.TopicFullName = device_topic;
                pub.Qos = 1;
                PubResponse resp = client.GetAcsResponse(pub);
                return true;
            }
            catch (Exception err)
            {
                Console.Write(err.Message);
                return false;
            }
        }

        /// <summary>
        /// 创建设备
        /// </summary>
        /// <param name="productKey">设备所属的产品Key</param>
        /// <param name="deviceName">设备名称(支持英文字母、数字和特殊字符-_@.:，长度限制4~32)</param>
        public static RegistDeviceResponse Create(string productKey, string deviceName)
        {
            IClientProfile clientProfile = DefaultProfile.GetProfile("cn-shanghai", "accessKeyId", "secret");
            DefaultAcsClient client = new DefaultAcsClient(clientProfile);

            try
            {
                RegistDeviceRequest request = new RegistDeviceRequest();
                request.ProductKey = productKey;
                request.DeviceName = deviceName;//
                RegistDeviceResponse resp = client.GetAcsResponse(request);
                if (resp.Success == null || !resp.Success.Value)
                {
                    return null;
                }
           
                return resp;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

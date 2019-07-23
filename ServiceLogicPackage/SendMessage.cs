using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Text;


namespace chat2._0.ServiceLogicPackage
{
    class SendMessage
    {
        //用户注册
        public bool RegUser(string name,string password,string email,Image photo)
        {
            //data[0]:用户名  data[1]:已加密的密码
            List<string> data = new List<string>();
            data.Add(name);

            //==============调用系统自带MD5函数进行加密====================
            byte[] result = Encoding.Default.GetBytes(password);    //textBox2为输入的密码
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            string swstr= BitConverter.ToString(output).Replace("-", "");  //输出加密文本赋给data[1]
            data.Add(swstr);

            data.Add(email);

            //byte[] 转换为string
            byte[] by = GetPictureData(photo);
            string photostr = Convert.ToBase64String(by);
            data.Add(photostr);

            //注册账号时发送的消息
            if (!dataProcessing.sendData(4, data))
            {
                return false;
            }
            return true;
        }

        //名字查重
        public bool Namerechecking(string name)
        {
            List<string> data = new List<string>();
            data.Add(name);
            if (!dataProcessing.sendData(5, data))
            {
                return false;
            }
            string[] receiveData = dataProcessing.receiveData();
            if (receiveData[1] == "SAMENAME")
            {
                return false;
            }
            else
            {
                dataProcessing.beginWork("login");
                return true;
            } 
        }


        #region  图片转化为字节
        //参数是图片路径，返回Byte[]类型
        public byte[] GetPictureData(string imagepath)
        {
            FileStream file = new FileStream(imagepath, FileMode.Open);
            byte[] by = new byte[file.Length];
            file.Read(by, 0, by.Length);
            file.Close();
            return by;
        }
        //参数是Image，返回Byte[]类型
        public byte[] GetPictureData(Image imgPhoto)
        {
            //将Image转换成流数据，并保存为byte[]
            MemoryStream mstream = new MemoryStream();
            imgPhoto.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new Byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length);
            mstream.Close();
            return byData;
        }
        #endregion
    }
}

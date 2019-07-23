using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace chat2._0.ServiceLogicPackage
{
    public class FromValidation
    {
        public string val_name(string name)
        {
            SendMessage sendMessage = new SendMessage();//消息发送
            string str = "pass";
            Regex regExp = new Regex("[ \\[ \\] \\^ \\-_*×――(^)$%~!@#$…&%￥—+=<>《》!！??？:：•`·、。，；,.;\"‘’“”-]");
            if (name.Equals("")) return "*用户名为空";
            if (regExp.IsMatch(name)) return "*含有非法字符";
            if (name.Length > 15) return "*字符长度不能大于15";
            if (name.Length <= 4) return "*字符长度不能小于4";
            if (!sendMessage.Namerechecking(name)) return "*该账号名已注册";
            return str;
        }

        public string val_password(string pass,string repass)
        {
            string str = "pass";
            if (pass.Equals("")) return "*密码不能为空";
            if (pass.Length > 15) return "*密码长度不能大于15位";
            if (pass.Length <= 5) return "*密码长度不能小于6位";
            if (!pass.Equals(repass)) return "*两次密码输入不一致";
            return str;
        }

        public string val_mail(string mail)
        {
            string str = "pass";
            Regex regExp = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");
            if (!regExp.IsMatch(mail)) return "*邮箱格式错误";
            return str;
        }
    }
}

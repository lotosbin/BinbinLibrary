using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace RenrenRESTful
{
    public class GalaxyRenrenRESTfulClient : RESTClient
    {

        public List<string> Friends_Get()
        {
            //        Required	Name	Type	Description
            //required	api_key	string	申请应用时分配的api_key，调用接口时候代表应用的唯一身份。
            //method	string	friends.get
            //call_id	float	当前调用请求队列号，建议使用当前系统时间的毫秒值。
            //sig	string	它是由当前请求参数和secretKey的一个MD5值, 有关签名如何认证的文档，请查看校内REST如何认证你的应用，
            //v	string	API的版本号，请设置成1.0
            //session_key	string	登录用户的session key. 用于验证是否为当前用户发出的请求，如果出现Session Key过期的情况请参考关于session_key过期
            //optional	format	string	Response的格式,XML或者JSON，缺省值为XML。
            //page	int	分页，默认为0
            //count	int	返回每页个数，默认为500
            var responseText = base.GetResponseText();
            new DataContractJsonSerializer();
        }
    }
}

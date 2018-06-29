<%@ WebHandler Language="C#" Class="OverallData2018" %>

using System;
using System.Web;
using System.Net;
using System.Data;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Data.SqlClient;

public class OverallData2018 : IHttpHandler
{

  public void ProcessRequest(HttpContext context)
  {
    context.Response.ContentType = "text/plain";
    SQLHelper.SQLHelper dataAccess = new SQLHelper.SQLHelper();
    //获取传递过来的参数
    string RequestType = "";
    if (context.Request.QueryString["t"] != null)
    {
      RequestType = context.Request.QueryString["t"].ToString();
    }

    if (RequestType == "send")
    {
      string str_pagename = context.Request["pagename"].ToString();
      string str_clientname = context.Request["clientname"].ToString();
      string str_cellphone = context.Request["cellphone"].ToString();
      string str_age = context.Request["age"].ToString();
      string str_ip = "";
      if (context.Request.ServerVariables["HTTP_VIA"] != null)
      {
        str_ip = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
      }
      else
      {
        str_ip = context.Request.ServerVariables["REMOTE_ADDR"].ToString();
      }

      try
      {
        string str_title = "【" + str_pagename + "】" + str_clientname;
        string strSql = string.Format(@"
            DECLARE @ID INT
            SET @ID = (SELECT MAX(WorkID)+1 FROM [PE_Work])

            INSERT INTO
            [PE_Work]
            ([WorkID],[WorkName],[WorkCategoryID],[UserName],[IP],[InputTime],[FormID],[FormTable],[FlowID],[Status]) 
            VALUES 
            (@ID,'{0}',5,'admin','{1}',GETDATE(),103,'PE_U_OverallData','',0)

            INSERT INTO 
            [PE_U_OverallData] 
             ([ID],[pagename],[clientname],[cellphone],[age],[ip]) 
            VALUES
            (@ID,'{0}','{1}','{2}','{3}','{4}',GETDATE())", str_title, str_clientname, str_cellphone, str_age,
          str_ip);
        dataAccess.ExecSqlwithoutReturn(strSql);


        if (str_cellphone.Length == 11 || str_cellphone.Length == 12)
        {
          string strSmsContent = "【" + str_pagename + "】" + str_clientname + ",请及时处理。 " + DateTime.Now.Month.ToString() + "月" +
                                 DateTime.Now.Day.ToString() + "日" + DateTime.Now.Hour.ToString() + ":" +
                                 DateTime.Now.Minute.ToString();
          //hySendSms.SendByUtnet("18284501179", strSmsContent);
          try
          {
            string strData = "【少儿-" + str_pagename + "】" + str_clientname;
            if (str_cellphone != "")
            {
              strData += " 手机：" + str_cellphone;
            }

            string strUrl = "https://www.huaying.info/Wechat/QyWeixin/getPeixunPinggu.html";
            strData = "cc=20b89792-75bd-bfba-055f-57a0e9975015&cell=" + str_cellphone + "&clientinfo=" + strData;
            Request_WebClient(strUrl, strData, Encoding.UTF8);
          }
          catch (Exception ex)
          {
          }

          context.Response.Write("你的信息已提交，我们将尽快与你联系");
        }
      }
      catch (Exception er)
      {
        context.Response.Write("数据提交失败！" + er);
      }

    }
    else
    {
      context.Response.Write("数据不完整！");
    }

  }

  public bool IsReusable
  {
    get { return false; }
  }

  //发送消息到服务器

  /// <summary>
  /// 通过WebClient类Post数据到远程地址，需要Basic认证；
  /// 调用端自己处理异常
  /// </summary>
  /// <param name="uri"></param>
  /// <param name="paramStr">name=张三&age=20</param>
  /// <param name="encoding">请先确认目标网页的编码方式</param>
  /// <param name="username"></param>
  /// <param name="password"></param>
  /// <returns></returns>
  public static string Request_WebClient(string uri, string paramStr, Encoding encoding)
  {
    if (encoding == null)
      encoding = Encoding.UTF8;

    string result = string.Empty;

    WebClient wc = new WebClient();

    // 采取POST方式必须加的Header
    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

    byte[] postData = encoding.GetBytes(paramStr);

    byte[] responseData = wc.UploadData(uri, "POST", postData); // 得到返回字符流
    return encoding.GetString(responseData); // 解码                  
  }

}
/*************************************
 *创建人：王文兵
 *创建日期：2007-3-29
 *功能描述：提供向页面输出客户端代码实现特殊功能的方法
 *****************************/
using System;
using System.Web;
using System.Web.UI.HtmlControls ;
using System.Text;
using System.Web.UI;

namespace JScriptTools
{
	/// <summary>
	/// 提供向页面输出客户端代码实现特殊功能的方法
	/// </summary>
	/// <remarks>
	/// </remarks>

	public class JScript
	{

		/// <summary>
		/// 构造函数
		/// </summary>
		public JScript()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 弹出提示窗口点击确定
		/// <summary>
		/// 弹出提示窗口并转向指定页面
		/// </summary>
		/// <param name="message"></param>
		public static void AlertAndHistory(string message)
		{
			string js = "<SCRIPT language=JavaScript>alert('{0}')</SCRIPT>";
			HttpContext.Current.Response.Write(string.Format(js,message ));
		}
		#endregion
		
		#region 弹出提示窗口并转向指定页面
		/// <summary>
		/// 弹出提示窗口并转向指定页面
		/// </summary>
		/// <param name="message"></param>
		/// <param name="toURL"></param>
		public static void AlertAndRedirect(string message,string toURL)
		{
			string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
			HttpContext.Current.Response.Write(string.Format(js,message ,toURL));
		}
		#endregion

        #region 弹出提示窗口确定后关闭本窗口
        /// <summary>
		/// 弹出提示窗口确定后关闭本窗口
		/// </summary>
		/// <param name="message"></param>
		/// <param name="toURL"></param>
		public static void AlertAndClose(string message)
		{
			string js = "<SCRIPT language=JavaScript>alert('{0}');window.opener=null;window.close();</SCRIPT>";
			HttpContext.Current.Response.Write(string.Format(js,message ));
		}
		#endregion

		#region 弹出JavaScript小窗口
		/// <summary>
		/// 弹出JavaScript小窗口
		/// </summary>
		/// <param name="js">窗口信息</param>
		public static void Alert(string message)
		{
			//message = StringUtil.DeleteUnVisibleChar(message);
			string js=@"<Script language='JavaScript' defer>
                    alert('"+ message +"');</Script>";
			HttpContext.Current.Response.Write(js);
		}
		public static void Alert(object message)
		{
			string js=@"<Script language='JavaScript' defer>
                    alert('{0}');  
                  </Script>";
			HttpContext.Current.Response.Write(string.Format(js,message.ToString()));
		}
		#endregion

		#region 控件点击 消息确认提示框
		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="Control">空件ID</param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}
		#endregion

		#region 回到历史页面
		/// <summary>
		/// 回到历史页面
		/// </summary>
		/// <param name="value">-1/1</param>
		public static void GoHistory(int value)
		{
			string js=@"<Script language='JavaScript'>javascript:history.go("+value+")</SCRIPT>";
			HttpContext.Current.Response.Write(js);
		}

		#endregion

		#region 关闭当前窗口
		/// <summary>
		/// 关闭当前窗口
		/// </summary>
		/// <param name="IsRefresh">是否刷新父窗口</param>
		public static void CloseWindow(bool IsRefresh)
		{
			string js=@"<Script language='JavaScript'>";
			if(IsRefresh)
			{
				js+=@"        window.opener.location=window.opener.location;";
			}
			js+=@"        window.opener=null;window.close();  
                  </Script>";
			HttpContext.Current.Response.Write(js);     
			//HttpContext.Current.Response.End();  
		}
		#endregion

		#region 刷新打开窗口
		/// <summary>
		/// 刷新打开窗口
		/// </summary>
		public static void RefreshOpener()
		{
			string js=@"<Script language='JavaScript'>
                    window.location=window.location;
                  </Script>";
			HttpContext.Current.Response.Write(js);     
		}
		#endregion


		#region 刷新父窗口
		

		/// <summary>
		/// 刷新父窗口
		/// </summary>
		public static void RefreshParent()
		{
			string js=@"<Script language='JavaScript'>
                    parent.location.reload();
                  </Script>";
			HttpContext.Current.Response.Write(js);     
		}

		/// <summary>
		/// 刷新父窗口
		/// </summary>
		/// 

		#endregion

		#region 刷新指定框架
/// <summary>
/// 刷新指定框架
/// </summary>
/// <param name="url"></param>
		public static void RefreshParentB(string Fram)
		{
			string js=@"<script  language='javascript'>window.parent.frames['"+Fram+@"'].location.reload();</script>";
			HttpContext.Current.Response.Write(js);     
		}

		public static void RefreshParent(string url)
		{
			string js=@"<Script language='JavaScript'>
                    opener.location="+url+@";
                  </Script>";
			HttpContext.Current.Response.Write(js);     
		}

		#endregion

		#region 格式化为JS可解释的字符串
		/// <summary>
		/// 格式化为JS可解释的字符串
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string JSStringFormat(string s)
		{
			return s.Replace("\r","\\r").Replace("\n","\\n").Replace("'","\\'").Replace("\"","\\\"");
		}

		#endregion

		#region 打开指定窗口
		/// <summary>
		///  打开窗口(去掉IE菜单)
		/// </summary>
		/// <param name="url"></param>
		public static void OpenWebForm(string url)
		{
			
			
			string js=@"<Script language='JavaScript'>
			//window.open('"+url+@"');
			window.open('"+url+@"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
			</Script>";
			                
			HttpContext.Current.Response.Write(js);     
		}
		#endregion

		#region 打开新窗口
		/// <summary>
		/// 打开新窗口
		/// </summary>
		/// <param name="url"></param>
		public static void OpenWindow(string url)
		{
			string js=@"<Script language='JavaScript'>
                     window.open('"+url+@"')
                  </Script>";
			HttpContext.Current.Response.Write(js);     
		}
		#endregion

		#region 打开模态窗口，并可指定长宽
		public static void OpenModalForm(string url,int width,int height,string Ourl)
		{
			string js=@"<Script language='JavaScript'>
                     window.showModalDialog('"+url+@"',window,'dialogWidth:"+width+@"px;dialogHeight:"+height+@"px;center:yes;help:no;resizable:no;status:no');
                     window.location='"+Ourl+@"';
                  </Script>";
			HttpContext.Current.Response.Write(js);
		}
		#endregion

		#region 打开一个去掉IE菜单的窗口
		public static void OpenWebForm(string url,string formName)
		{
			/*…………………………………………………………………………………………*/
			/*修改人员:		sxs						*/
			/*修改时间:	2003-4-9	*/
			/*修改目的:	新开页面去掉ie的菜单。。。						*/
			/*注释内容:								*/
			/*开始*/
			string js=@"<Script language='JavaScript'>
			//window.open('"+url+@"','"+formName+@"');
			window.open('"+url+@"','"+formName+@"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
			</Script>";
			/*结束*/
			/*…………………………………………………………………………………………*/

			HttpContext.Current.Response.Write(js);     
		}

		#endregion


        #region 打开WEB窗口
        /// <summary>		
		/// 函数名:OpenWebForm	
		/// 功能描述:打开WEB窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="url">WEB窗口</param>
		/// <param name="isFullScreen">是否全屏幕</param>
		public static void OpenWebForm(string url,bool isFullScreen)
		{			
			string js=@"<Script language='JavaScript'>";
			if(isFullScreen)
			{
				js+="var iWidth = 0;";
				js+="var iHeight = 0;";
				js+="iWidth=window.screen.availWidth-10;";
				js+="iHeight=window.screen.availHeight-50;";
				js+="var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
				js+="window.open('"+url+@"','',szFeatures);";
			}
			else
			{
				js+="window.open('"+url+@"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";
			}
			js+="</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion


        #region 转向Url制定的页面
        /// <summary>
		/// 转向Url制定的页面
		/// </summary>
		/// <param name="url"></param>
		public static void JavaScriptLocationHref(string url)
		{
			string js=@"<Script language='JavaScript'>
                    window.location.replace('{0}');
                  </Script>";
			js=string.Format(js,url);
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 指定的框架页面转换
        /// <summary>
		/// 指定的框架页面转换
		/// </summary>
		/// <param name="FrameName"></param>
		/// <param name="url"></param>
		public static void JavaScriptFrameHref(string FrameName,string url)
		{
			string js=@"<Script language='JavaScript'>
					
                    @obj.location.replace(""{0}"");
                  </Script>";
			js = js.Replace("@obj",FrameName );
			js=string.Format(js,url);
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 重置页面
        /// <summary>
		///重置页面
		/// </summary>
		public static void JavaScriptResetPage(string strRows)
		{
			string js=@"<Script language='JavaScript'>
                    window.parent.CenterFrame.rows='"+strRows+"';</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion
        #region 客户端方法设置Cookie
        /// <summary>
		/// 函数名:JavaScriptSetCookie
		/// 功能描述:客户端方法设置Cookie
		/// 作者:
		/// 日期：
		/// 版本：
		/// </summary>
		/// <param name="strName">Cookie名</param>
		/// <param name="strValue">Cookie值</param>
		public static void JavaScriptSetCookie(string strName,string strValue)
		{
			string js=@"<script language=Javascript>
			var the_cookie = '"+strName+"="+strValue+@"'
			var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';
			//document.cookie = the_cookie;//写入Cookie<BR>} <BR>
			document.cookie = the_cookie + '; expires='+dateexpire;			
			</script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 返回父窗口
        /// <summary>		
		/// 函数名:GotoParentWindow	
		/// 功能描述:返回父窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="parentWindowUrl">父窗口</param>		
		public static void GotoParentWindow(string parentWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    this.parent.location.replace('"+parentWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换父窗口
        /// <summary>		
		/// 函数名:ReplaceParentWindow	
		/// 功能描述:替换父窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="parentWindowUrl">父窗口</param>
		/// <param name="caption">窗口提示</param>
		/// <param name="future">窗口特征参数</param>
		public static void ReplaceParentWindow(string parentWindowUrl,string caption,string future)
		{	
			string js="";
			if(future!=null&&future.Trim()!="")
			{
				js=@"<script language=javascript>this.parent.location.replace('"+parentWindowUrl+"','"+caption+"','"+future+"');</script>";
			}
			else
			{
				js=@"<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;
							var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('"+parentWindowUrl+"','"+caption+"',szFeatures);</script>";
			}

			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换当前窗体的打开窗口
        /// <summary>		
		/// 函数名:ReplaceOpenerWindow	
		/// 功能描述:替换当前窗体的打开窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="openerWindowUrl">当前窗体的打开窗口</param>		
		public static void ReplaceOpenerWindow(string openerWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.location.replace('"+openerWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换当前窗体的打开窗口的父窗口
        /// <summary>		
		/// 函数名:ReplaceOpenerParentWindow	
		/// 功能描述:替换当前窗体的打开窗口的父窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="openerWindowUrl">当前窗体的打开窗口的父窗口</param>		
		public static void ReplaceOpenerParentFrame(string frameName,string frameWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.parent." + frameName + ".location.replace('"+frameWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 替换当前窗体的打开窗口的父窗口
        /// <summary>		
		/// 函数名:ReplaceOpenerParentWindow	
		/// 功能描述:替换当前窗体的打开窗口的父窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="openerWindowUrl">当前窗体的打开窗口的父窗口</param>		
		public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.parent.location.replace('"+openerParentWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 关闭窗口
        /// <summary>		
		/// 函数名:CloseParentWindow	
		/// 功能描述:关闭窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期:
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		public static void CloseParentWindow()
		{			
			string js=@"<Script language='JavaScript'>
                    window.parent.close();  
                  </Script>";
			HttpContext.Current.Response.Write(js);
        }
        
        public static void CloseOpenerWindow()
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.close();  
                  </Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region 返回打开模式窗口的脚本
        /// <summary>
		/// 函数名:ShowModalDialogJavascript	
		/// 功能描述:返回打开模式窗口的脚本	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="webFormUrl"></param>
		/// <returns></returns>
		public static string ShowModalDialogJavascript(string webFormUrl)
		{
			string js=@"<script language=javascript>
							var iWidth = 0 ;
							var iHeight = 0 ;
							iWidth=window.screen.availWidth-10;
							iHeight=window.screen.availHeight-50;
							var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';
							showModalDialog('"+webFormUrl+"','',szFeatures);</script>";
			return js;
		}

		public static string ShowModalDialogJavascript(string webFormUrl,string features)
		{
			string js=@"<script language=javascript>							
							showModalDialog('"+webFormUrl+"','','"+features+"');</script>";
			return js;
        }
        #endregion

        #region 打开模式窗口
        /// <summary>
		/// 函数名:ShowModalDialogWindow	
		/// 功能描述:打开模式窗口	
		/// 处理流程:
		/// 算法描述:
		/// 作 者: 
		/// 日 期: 
		/// 修 改:
		/// 日 期:
		/// 版 本:
		/// </summary>
		/// <param name="webFormUrl"></param>
		/// <returns></returns>
		public static void ShowModalDialogWindow(string webFormUrl)
		{
			string js=ShowModalDialogJavascript(webFormUrl);
			HttpContext.Current.Response.Write(js);
		}

		public static void ShowModalDialogWindow(string webFormUrl,string features)
		{
			string js=ShowModalDialogJavascript(webFormUrl,features);
			HttpContext.Current.Response.Write(js);
		}
		public static void ShowModalDialogWindow(string webFormUrl,int width,int height,int top,int left)
		{
			string features = "dialogWidth:"+width.ToString() + "px"
				+";dialogHeight:" + height.ToString() + "px" 
				+";dialogLeft:" + left.ToString() + "px"
				+";dialogTop:" + top.ToString() + "px"
				+";center:yes;help=no;resizable:no;status:no;scroll=no";
			ShowModalDialogWindow(webFormUrl,features);			
		}

		public static void SetHtmlElementValue(string formName,string elementName,string elementValue)
		{			
			string js=@"<Script language='JavaScript'>if(document."+formName+"." + elementName +"!=null){document."+formName+"." + elementName +".value ="+ elementValue +";}</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion
        /// <summary>
		/// 指定控件获得焦点
		/// </summary>
		/// <param name="str_Ctl_Name">str_Ctl_Name是要获得焦点的控件的ID</param>
		/// <param name="page"></param>
        //public static void FocusNow(string str_Ctl_Name,Page page)
        //{
        //    page.RegisterStartupScript("","<script>document.forms(0)."+str_Ctl_Name+".focus(); document.forms(0)."+str_Ctl_Name+".select();</script>"); 
        //}


        #region 弹出信息窗体
        /// <summary>
		/// 1.静态方法,弹出信息窗体
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="description">信息内容</param>
		/// <example>
		/// JSUnit.Alert(this,"NiHao!");
		/// </example>
		public static void Alert(System.Web.UI.Page page,string description)
		{
			if(description!=null)
			{
				String scriptString = "<script language=JavaScript> ";
				scriptString += "alert('"+description+"');";
				scriptString += "</script>";

				if(!page.IsClientScriptBlockRegistered("clientScript"))
					page.RegisterClientScriptBlock("clientScript", scriptString);
			}
			else
			{
				Alert(page,"描述信息为空！");
			}
        }
        #endregion

        #region 关闭一个网页的父窗口，例如一个frame关闭其父窗口。
        /// <summary>
		///2 静态方法,关闭一个网页的父窗口，例如一个frame关闭其父窗口。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <example>
		/// JSUnit.CloseParent(this);
		/// </example>
		public static void CloseParent(System.Web.UI.Page page)
		{
			String scriptString = "<script language=JavaScript> ";
			scriptString += "window.parent.close();";
			scriptString += "</script>";

			if(!page.IsClientScriptBlockRegistered("clientScript"))
				page.RegisterClientScriptBlock("clientScript", scriptString);
        }
        #endregion 

        #region 关闭一个模态网页窗口并刷新父窗口
        /// <summary>
		///3 静态方法,关闭一个模态网页窗口并刷新父窗口
		/// 前提条件是必须调用此类中的OpenModalDialog方法
		/// 在该方法中自动生成刷新方法才能实现父页面刷新。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <example>
		/// JSUnit.CloseModalDialog(this);
		/// </example>
		public static void CloseModalDialog(System.Web.UI.Page page)
		{

			String scriptString = "<script language=JavaScript> ";
			scriptString += "var sData = dialogArguments;";
			scriptString += "sData.Refresh();";
			scriptString += "window.close();";
			scriptString += "</script>";

			if(!page.IsClientScriptBlockRegistered("clientScript"))
				page.RegisterClientScriptBlock("clientScript", scriptString);
        }
        #endregion

        #region 关闭一个网页窗口
        /// <summary>
		///3 静态方法,关闭一个网页窗口。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <example>
		/// JSUnit.CloseWindow(this);
		/// </example>
		public static void CloseWindow(System.Web.UI.Page page)
		{
			String scriptString = "<script language=JavaScript> ";
			scriptString += "window.close();";
			scriptString += "</script>";

			if(!page.IsClientScriptBlockRegistered("clientScript"))
				page.RegisterClientScriptBlock("clientScript", scriptString);
        }
        #endregion

        /// <summary>
		///5 静态方法,执行客户端一小块脚本语言,
		///利用page的RegisterClientScriptBlock方法在客户端注册一段脚本,
		///参数script无需包括html标记<script>、</script>。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="script">javascript脚本</param>
		/// <example>
		/// JSUnit.ExecuteBlock(this,"alert("Hello");");
		/// </example>
		public static void ExecuteBlock(System.Web.UI.Page page,string script)
		{
			if(script!=null)
			{
				String scriptString = "<script language=JavaScript> ";
				scriptString += script;
				scriptString += "</script>";

				if(!page.IsClientScriptBlockRegistered("clientScript"))
					page.RegisterClientScriptBlock("clientScript", scriptString);
			}
			else
			{
				Alert(page,"JavaScript脚本不能为空！");
			}
		}

		/// <summary>
		///6 静态方法,执行客户端一小块脚本语言,
		///利用page的RegisterStartupScript方法在客户端注册一段脚本，
		///参数script无需包括html标记<script>、</script>。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="script">JavaScript脚本</param>
		public static void ExecuteStartup(System.Web.UI.Page page,string script)
		{
			if(script!=null)
			{
				String scriptString = "<script language=JavaScript> ";
				scriptString += script;
				scriptString += "</script>";

				if(!page.IsStartupScriptRegistered("ExecuteStartup"))
					page.RegisterStartupScript("ExecuteStartup", scriptString);
			}
			else
			{
				Alert(page,"JavaScript脚本不能为空！");
			}
		}

		/// <summary>
		///8	静态方法,打开一个网页对话框，并生成刷新页面方法。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="URL">页面名称</param>
		/// <param name="Width">宽度</param>
		/// <param name="Height">高度</param>
		/// <example>
		/// JSUnit.OpenModalDialog(page,"weihu.aspx",700,350); 
		/// </example>
		public static void OpenModalDialog(System.Web.UI.Page page,string URL, int Width, int Height)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"页面宽度和高度不能为零！");
					return;
				}
				string scriptString ="<script language='javascript'>";
				scriptString += "function Refresh()";
				scriptString += "{";
				scriptString += "	window.location.href= window.location.href;";
				scriptString += "}";
				scriptString += "window.showModalDialog('"+URL+"',window,'dialogHeight:" + Height +"px;dialogWidth:" +Width +"px;center:Yes;help:No;scroll:No;resizable:No;status:No;')";
				scriptString += "</script>";

				if(!page.IsStartupScriptRegistered("Startup"))
					page.RegisterStartupScript("Startup", scriptString);
			}
			else
			{
				Alert(page,"页面地址不能为空！");
			}
		}


		/// <summary>
		///14 静态方法,打开一个无模式网页对话框。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="URL">页面名称</param>
		/// <param name="Width">宽度</param>
		/// <param name="Height">高度</param>
		/// <example>
		/// JSUnit.OpenDialog(page,"weihu.aspx",700,350); 
		/// </example>
		public static void OpenDialog(System.Web.UI.Page page,string URL, int Width, int Height)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"页面宽度和高度不能为零！");
					return;
				}
				string str ="<script language='javascript'>"
					+"window.open('"+URL+"','','location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width="+Width+",height="+Height+"')"
					+"</script>";

				if(!page.IsClientScriptBlockRegistered("clientScript"))
					page.RegisterClientScriptBlock("clientScript", str);
			}
			else
			{
				Alert(page,"页面地址不能为空！");
			}
		}

		/// <summary>
		///11 静态方法,打开一个IE窗口(无标题栏、工具栏、地址栏等)。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="URL">页面名称</param>
		/// <param name="Width">宽度</param>
		/// <param name="Height">高度</param>
		/// <param name="Left">左边距</param>
		/// <param name="Top">上边距</param>
		/// <example>
		/// JSUnit.OpenIEWindow(page,"weihu.aspx",700,350,10,20);
		/// </example>
		public static void OpenIEWindow(System.Web.UI.Page page,string URL, int Width, int Height,int Left,int Top)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"页面宽度和高度不能为零！");
					return;
				}
				string str ="<script language='javascript'>"
					+"window.open('"+URL+"','','location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width="+Width+",height="+Height+",left="+Left+",top="+Top+"');"
					+"</script>";

				if(!page.IsClientScriptBlockRegistered("clientScript"))
					page.RegisterClientScriptBlock("clientScript", str);
			}
			else
			{
				Alert(page,"页面地址不能为空！");
			}
		}

		/// <summary>
		///12 静态方法,打开一个IE窗口(无标题栏、工具栏、地址栏等)
		///在屏幕的最右边，上下满屏，宽度由参数指定。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="URL">页面名称</param>
		/// <param name="Width">宽度</param>
		/// <example>
		/// JSUnit.OpenIEWindowRight(page,"weihu.aspx",700);
		/// </example>
		public static void OpenIEWindowRight(System.Web.UI.Page page,string URL, int Width)
		{
			if(URL!=null)
			{
				if (Width==0 )
				{
					Alert(page,"页面宽度和高度不能为零！");
					return;
				}
				string str ="<script language='javascript'>"
					+"newwindow=window.open('"+URL+"','','location=no,status=no,menubar=no,scrollbars=yes,resizable=no,width="+Width+",height=document.height');"
					+"newwindow.moveTo(screen.width-"+Width+",0);newwindow.resizeTo("+Width+",screen.height);"
					+"</script>";

				if(!page.IsClientScriptBlockRegistered("clientScript"))
					page.RegisterClientScriptBlock("clientScript", str);
			}
			else
			{
				Alert(page,"页面地址不能为空！");
			}
		}

		/// <summary>
		///13	静态方法,打开一个IE窗口(无标题栏、工具栏、地址栏等)，在屏幕的最右边，上下位置在中间。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="URL">页面名称</param>
		/// <param name="Width">宽度</param>
		/// <param name="Height">高度</param>
		/// <example>
		/// JSUnit.OpenIEWindowRight(page,"weihu.aspx",700,350);
		/// </example>
		public static void OpenIEWindowRight(System.Web.UI.Page page,string URL, int Width, int Height)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"页面宽度和高度不能为零！");
					return;
				}
				string str ="<script language='javascript'>"
					+"newwindow=window.open('"+URL+"','','location=no,status=no,menubar=no,scrollbars=no,resizable=no,width="+Width+",height="+Height+"');"
					+"newwindow.moveTo(screen.width-"+Width+",(screen.height-"+Height+")/2);"
					+"</script>";

				if(!page.IsClientScriptBlockRegistered("clientScript"))
					page.RegisterClientScriptBlock("clientScript", str);
			}
			else
			{
				Alert(page,"页面地址不能为空！");
			}
		}

	

		/// <summary>
		/// 15 静态方法,在客户端注册一块脚本语言,
		/// 在Page对象的form runat= server元素的结束标记之前发出该脚本。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="script">JavaScript脚本</param>
		/// <example>
		/// JSUnit.RegisterStartupScript(this,"alert("Hello!")");
		/// </example>
		public static void RegisterStartupScript(System.Web.UI.Page page,string script)
		{
			if(script!=null)
			{
				
				string scriptString ="<script language='javascript'>"
					+script
					+"</script>";

				if(!page.IsStartupScriptRegistered("RegisterStartupScript"))
					page.RegisterStartupScript("RegisterStartupScript", scriptString);
			}
			else
			{
				Alert(page,"JavaScript脚本不能为空！");
			}
		}

       // public static bool DeleteConfirm

		/// <summary>
		///16 静态方法,在客户端注册一块脚本语言,
		///在Page对象的form runat= server元素的开始标记之后立即发出该脚本。
		/// </summary>
		/// <param name="page">页面对象</param>
		/// <param name="script">JavaScript脚本</param>
		/// <example>
		/// JSUnit.RegisterClientScriptBlock(this,"alert("Hello!")");
		/// </example>
		public static void RegisterClientScriptBlock(System.Web.UI.Page page,string script)
		{
			if(script!=null)
			{
				string str ="<script language='javascript'>"
					+script
					+"</script>";

				if(!page.IsClientScriptBlockRegistered("RegisterClientScriptBlock"))
					page.RegisterClientScriptBlock("RegisterClientScriptBlock", str);
			}
			else
			{
				Alert(page,"JavaScript脚本不能为空！");
			}
		}


		/// <summary>
		/// 显示消息提示对话框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{
			page.RegisterStartupScript("message","<script language='javascript' defer>alert('"+msg.ToString()+"');</script>");
		}

		/// <summary>
		/// 控件点击 消息确认提示框
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		public static void  ShowConfirmm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// 显示消息提示对话框，并进行页面跳转
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="msg">提示信息</param>
		/// <param name="url">跳转的目标URL</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{
			StringBuilder Builder=new StringBuilder();
			Builder.Append("<script language='javascript' defer>");
			Builder.AppendFormat("alert('{0}');",msg);
			Builder.AppendFormat("top.location.href='{0}'",url);
			Builder.Append("</script>");
			page.RegisterStartupScript("message",Builder.ToString());

		}
		/// <summary>
		/// 输出自定义脚本信息
		/// </summary>
		/// <param name="page">当前页面指针，一般为this</param>
		/// <param name="script">输出脚本</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
			page.RegisterStartupScript("message","<script language='javascript' defer>"+script+"</script>");
		}

		/// <summary>
		/// Name:Redirect (跳转到指定页,用于处理数据后返加信息结果)
		/// Author:Bifek
		/// Date:2006/10/30
		/// </summary>
		/// <param name="url">显示出错页还是成功页  1表示成功页 2表示出错页</param>
		/// <param name="messages"></param>
		/// <param name="history"></param>
		/// <param name="breaker">刷次框架名</param>
		/// <param name="url">返回页面路径</param>
		public static void Redirect(int url,string messages,string urll,string breaker)
		{
			if (url==1)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('../../Success.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+"&url="+urll+"&breaker="+breaker+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			else if(url==2)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('../../Error.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+"&url="+urll+"&breaker="+breaker+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			
		}

		public static void Redirect(int url,string messages,string urll,string breaker,string path)
		{
			if (url==1)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"Success.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+"&url="+urll+"&breaker="+breaker+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			else if(url==2)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"error.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+" &url="+urll+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			
		}

		
		public static void Redirect2(int url,string messages,string urll,string path)
		{
			if (url==1)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"Success.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+"&url="+urll+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			else if(url==2)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"error.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+" &url="+urll+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			
		}

		public static void Redirect2(int url,string messages,int go,string path)
		{
			if (url==1)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"Success.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+"&go="+go+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			else if(url==2)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"error.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+" &go="+go+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			
		}

		/// <summary>
		/// 返回时关闭弹出的窗口
		/// </summary>
		/// <param name="url"></param>
		/// <param name="messages"></param>
		/// <param name="go"></param>
		/// <param name="path"></param>
		public static void Redirect(int url,string messages,string path,bool a)
		{
			if (url==1)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"Success.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+"&a="+a+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			else if(url==2)
			{
				StringBuilder Builder=new StringBuilder();
				Builder.Append("<script language='javascript'>");
				Builder.Append("window.location.replace('"+path+"error.aspx?ex="+System.Web.HttpContext.Current.Server.UrlEncode(messages)+" &a="+a+"')");
				Builder.Append("</script>");
				HttpContext.Current.Response.Write(Builder.ToString());
			}
			
		}
	}

}

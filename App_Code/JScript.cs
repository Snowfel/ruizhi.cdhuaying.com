/*************************************
 *�����ˣ����ı�
 *�������ڣ�2007-3-29
 *�����������ṩ��ҳ������ͻ��˴���ʵ�����⹦�ܵķ���
 *****************************/
using System;
using System.Web;
using System.Web.UI.HtmlControls ;
using System.Text;
using System.Web.UI;

namespace JScriptTools
{
	/// <summary>
	/// �ṩ��ҳ������ͻ��˴���ʵ�����⹦�ܵķ���
	/// </summary>
	/// <remarks>
	/// </remarks>

	public class JScript
	{

		/// <summary>
		/// ���캯��
		/// </summary>
		public JScript()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#region ������ʾ���ڵ��ȷ��
		/// <summary>
		/// ������ʾ���ڲ�ת��ָ��ҳ��
		/// </summary>
		/// <param name="message"></param>
		public static void AlertAndHistory(string message)
		{
			string js = "<SCRIPT language=JavaScript>alert('{0}')</SCRIPT>";
			HttpContext.Current.Response.Write(string.Format(js,message ));
		}
		#endregion
		
		#region ������ʾ���ڲ�ת��ָ��ҳ��
		/// <summary>
		/// ������ʾ���ڲ�ת��ָ��ҳ��
		/// </summary>
		/// <param name="message"></param>
		/// <param name="toURL"></param>
		public static void AlertAndRedirect(string message,string toURL)
		{
			string js = "<script language=javascript>alert('{0}');window.location.replace('{1}')</script>";
			HttpContext.Current.Response.Write(string.Format(js,message ,toURL));
		}
		#endregion

        #region ������ʾ����ȷ����رձ�����
        /// <summary>
		/// ������ʾ����ȷ����رձ�����
		/// </summary>
		/// <param name="message"></param>
		/// <param name="toURL"></param>
		public static void AlertAndClose(string message)
		{
			string js = "<SCRIPT language=JavaScript>alert('{0}');window.opener=null;window.close();</SCRIPT>";
			HttpContext.Current.Response.Write(string.Format(js,message ));
		}
		#endregion

		#region ����JavaScriptС����
		/// <summary>
		/// ����JavaScriptС����
		/// </summary>
		/// <param name="js">������Ϣ</param>
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

		#region �ؼ���� ��Ϣȷ����ʾ��
		/// <summary>
		/// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="Control">�ռ�ID</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}
		#endregion

		#region �ص���ʷҳ��
		/// <summary>
		/// �ص���ʷҳ��
		/// </summary>
		/// <param name="value">-1/1</param>
		public static void GoHistory(int value)
		{
			string js=@"<Script language='JavaScript'>javascript:history.go("+value+")</SCRIPT>";
			HttpContext.Current.Response.Write(js);
		}

		#endregion

		#region �رյ�ǰ����
		/// <summary>
		/// �رյ�ǰ����
		/// </summary>
		/// <param name="IsRefresh">�Ƿ�ˢ�¸�����</param>
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

		#region ˢ�´򿪴���
		/// <summary>
		/// ˢ�´򿪴���
		/// </summary>
		public static void RefreshOpener()
		{
			string js=@"<Script language='JavaScript'>
                    window.location=window.location;
                  </Script>";
			HttpContext.Current.Response.Write(js);     
		}
		#endregion


		#region ˢ�¸�����
		

		/// <summary>
		/// ˢ�¸�����
		/// </summary>
		public static void RefreshParent()
		{
			string js=@"<Script language='JavaScript'>
                    parent.location.reload();
                  </Script>";
			HttpContext.Current.Response.Write(js);     
		}

		/// <summary>
		/// ˢ�¸�����
		/// </summary>
		/// 

		#endregion

		#region ˢ��ָ�����
/// <summary>
/// ˢ��ָ�����
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

		#region ��ʽ��ΪJS�ɽ��͵��ַ���
		/// <summary>
		/// ��ʽ��ΪJS�ɽ��͵��ַ���
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string JSStringFormat(string s)
		{
			return s.Replace("\r","\\r").Replace("\n","\\n").Replace("'","\\'").Replace("\"","\\\"");
		}

		#endregion

		#region ��ָ������
		/// <summary>
		///  �򿪴���(ȥ��IE�˵�)
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

		#region ���´���
		/// <summary>
		/// ���´���
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

		#region ��ģ̬���ڣ�����ָ������
		public static void OpenModalForm(string url,int width,int height,string Ourl)
		{
			string js=@"<Script language='JavaScript'>
                     window.showModalDialog('"+url+@"',window,'dialogWidth:"+width+@"px;dialogHeight:"+height+@"px;center:yes;help:no;resizable:no;status:no');
                     window.location='"+Ourl+@"';
                  </Script>";
			HttpContext.Current.Response.Write(js);
		}
		#endregion

		#region ��һ��ȥ��IE�˵��Ĵ���
		public static void OpenWebForm(string url,string formName)
		{
			/*��������������������������������������������������������������������*/
			/*�޸���Ա:		sxs						*/
			/*�޸�ʱ��:	2003-4-9	*/
			/*�޸�Ŀ��:	�¿�ҳ��ȥ��ie�Ĳ˵�������						*/
			/*ע������:								*/
			/*��ʼ*/
			string js=@"<Script language='JavaScript'>
			//window.open('"+url+@"','"+formName+@"');
			window.open('"+url+@"','"+formName+@"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');
			</Script>";
			/*����*/
			/*��������������������������������������������������������������������*/

			HttpContext.Current.Response.Write(js);     
		}

		#endregion


        #region ��WEB����
        /// <summary>		
		/// ������:OpenWebForm	
		/// ��������:��WEB����	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// </summary>
		/// <param name="url">WEB����</param>
		/// <param name="isFullScreen">�Ƿ�ȫ��Ļ</param>
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


        #region ת��Url�ƶ���ҳ��
        /// <summary>
		/// ת��Url�ƶ���ҳ��
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

        #region ָ���Ŀ��ҳ��ת��
        /// <summary>
		/// ָ���Ŀ��ҳ��ת��
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

        #region ����ҳ��
        /// <summary>
		///����ҳ��
		/// </summary>
		public static void JavaScriptResetPage(string strRows)
		{
			string js=@"<Script language='JavaScript'>
                    window.parent.CenterFrame.rows='"+strRows+"';</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion
        #region �ͻ��˷�������Cookie
        /// <summary>
		/// ������:JavaScriptSetCookie
		/// ��������:�ͻ��˷�������Cookie
		/// ����:
		/// ���ڣ�
		/// �汾��
		/// </summary>
		/// <param name="strName">Cookie��</param>
		/// <param name="strValue">Cookieֵ</param>
		public static void JavaScriptSetCookie(string strName,string strValue)
		{
			string js=@"<script language=Javascript>
			var the_cookie = '"+strName+"="+strValue+@"'
			var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';
			//document.cookie = the_cookie;//д��Cookie<BR>} <BR>
			document.cookie = the_cookie + '; expires='+dateexpire;			
			</script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region ���ظ�����
        /// <summary>		
		/// ������:GotoParentWindow	
		/// ��������:���ظ�����	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// </summary>
		/// <param name="parentWindowUrl">������</param>		
		public static void GotoParentWindow(string parentWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    this.parent.location.replace('"+parentWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region �滻������
        /// <summary>		
		/// ������:ReplaceParentWindow	
		/// ��������:�滻������	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// </summary>
		/// <param name="parentWindowUrl">������</param>
		/// <param name="caption">������ʾ</param>
		/// <param name="future">������������</param>
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

        #region �滻��ǰ����Ĵ򿪴���
        /// <summary>		
		/// ������:ReplaceOpenerWindow	
		/// ��������:�滻��ǰ����Ĵ򿪴���	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// </summary>
		/// <param name="openerWindowUrl">��ǰ����Ĵ򿪴���</param>		
		public static void ReplaceOpenerWindow(string openerWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.location.replace('"+openerWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region �滻��ǰ����Ĵ򿪴��ڵĸ�����
        /// <summary>		
		/// ������:ReplaceOpenerParentWindow	
		/// ��������:�滻��ǰ����Ĵ򿪴��ڵĸ�����	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// </summary>
		/// <param name="openerWindowUrl">��ǰ����Ĵ򿪴��ڵĸ�����</param>		
		public static void ReplaceOpenerParentFrame(string frameName,string frameWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.parent." + frameName + ".location.replace('"+frameWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region �滻��ǰ����Ĵ򿪴��ڵĸ�����
        /// <summary>		
		/// ������:ReplaceOpenerParentWindow	
		/// ��������:�滻��ǰ����Ĵ򿪴��ڵĸ�����	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// </summary>
		/// <param name="openerWindowUrl">��ǰ����Ĵ򿪴��ڵĸ�����</param>		
		public static void ReplaceOpenerParentWindow(string openerParentWindowUrl)
		{			
			string js=@"<Script language='JavaScript'>
                    window.opener.parent.location.replace('"+openerParentWindowUrl+"');</Script>";
			HttpContext.Current.Response.Write(js);
        }
        #endregion

        #region �رմ���
        /// <summary>		
		/// ������:CloseParentWindow	
		/// ��������:�رմ���	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
		/// �� ��:
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

        #region ���ش�ģʽ���ڵĽű�
        /// <summary>
		/// ������:ShowModalDialogJavascript	
		/// ��������:���ش�ģʽ���ڵĽű�	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
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

        #region ��ģʽ����
        /// <summary>
		/// ������:ShowModalDialogWindow	
		/// ��������:��ģʽ����	
		/// ��������:
		/// �㷨����:
		/// �� ��: 
		/// �� ��: 
		/// �� ��:
		/// �� ��:
		/// �� ��:
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
		/// ָ���ؼ���ý���
		/// </summary>
		/// <param name="str_Ctl_Name">str_Ctl_Name��Ҫ��ý���Ŀؼ���ID</param>
		/// <param name="page"></param>
        //public static void FocusNow(string str_Ctl_Name,Page page)
        //{
        //    page.RegisterStartupScript("","<script>document.forms(0)."+str_Ctl_Name+".focus(); document.forms(0)."+str_Ctl_Name+".select();</script>"); 
        //}


        #region ������Ϣ����
        /// <summary>
		/// 1.��̬����,������Ϣ����
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="description">��Ϣ����</param>
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
				Alert(page,"������ϢΪ�գ�");
			}
        }
        #endregion

        #region �ر�һ����ҳ�ĸ����ڣ�����һ��frame�ر��丸���ڡ�
        /// <summary>
		///2 ��̬����,�ر�һ����ҳ�ĸ����ڣ�����һ��frame�ر��丸���ڡ�
		/// </summary>
		/// <param name="page">ҳ�����</param>
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

        #region �ر�һ��ģ̬��ҳ���ڲ�ˢ�¸�����
        /// <summary>
		///3 ��̬����,�ر�һ��ģ̬��ҳ���ڲ�ˢ�¸�����
		/// ǰ�������Ǳ�����ô����е�OpenModalDialog����
		/// �ڸ÷������Զ�����ˢ�·�������ʵ�ָ�ҳ��ˢ�¡�
		/// </summary>
		/// <param name="page">ҳ�����</param>
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

        #region �ر�һ����ҳ����
        /// <summary>
		///3 ��̬����,�ر�һ����ҳ���ڡ�
		/// </summary>
		/// <param name="page">ҳ�����</param>
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
		///5 ��̬����,ִ�пͻ���һС��ű�����,
		///����page��RegisterClientScriptBlock�����ڿͻ���ע��һ�νű�,
		///����script�������html���<script>��</script>��
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="script">javascript�ű�</param>
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
				Alert(page,"JavaScript�ű�����Ϊ�գ�");
			}
		}

		/// <summary>
		///6 ��̬����,ִ�пͻ���һС��ű�����,
		///����page��RegisterStartupScript�����ڿͻ���ע��һ�νű���
		///����script�������html���<script>��</script>��
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="script">JavaScript�ű�</param>
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
				Alert(page,"JavaScript�ű�����Ϊ�գ�");
			}
		}

		/// <summary>
		///8	��̬����,��һ����ҳ�Ի��򣬲�����ˢ��ҳ�淽����
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="URL">ҳ������</param>
		/// <param name="Width">���</param>
		/// <param name="Height">�߶�</param>
		/// <example>
		/// JSUnit.OpenModalDialog(page,"weihu.aspx",700,350); 
		/// </example>
		public static void OpenModalDialog(System.Web.UI.Page page,string URL, int Width, int Height)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"ҳ���Ⱥ͸߶Ȳ���Ϊ�㣡");
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
				Alert(page,"ҳ���ַ����Ϊ�գ�");
			}
		}


		/// <summary>
		///14 ��̬����,��һ����ģʽ��ҳ�Ի���
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="URL">ҳ������</param>
		/// <param name="Width">���</param>
		/// <param name="Height">�߶�</param>
		/// <example>
		/// JSUnit.OpenDialog(page,"weihu.aspx",700,350); 
		/// </example>
		public static void OpenDialog(System.Web.UI.Page page,string URL, int Width, int Height)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"ҳ���Ⱥ͸߶Ȳ���Ϊ�㣡");
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
				Alert(page,"ҳ���ַ����Ϊ�գ�");
			}
		}

		/// <summary>
		///11 ��̬����,��һ��IE����(�ޱ�����������������ַ����)��
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="URL">ҳ������</param>
		/// <param name="Width">���</param>
		/// <param name="Height">�߶�</param>
		/// <param name="Left">��߾�</param>
		/// <param name="Top">�ϱ߾�</param>
		/// <example>
		/// JSUnit.OpenIEWindow(page,"weihu.aspx",700,350,10,20);
		/// </example>
		public static void OpenIEWindow(System.Web.UI.Page page,string URL, int Width, int Height,int Left,int Top)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"ҳ���Ⱥ͸߶Ȳ���Ϊ�㣡");
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
				Alert(page,"ҳ���ַ����Ϊ�գ�");
			}
		}

		/// <summary>
		///12 ��̬����,��һ��IE����(�ޱ�����������������ַ����)
		///����Ļ�����ұߣ���������������ɲ���ָ����
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="URL">ҳ������</param>
		/// <param name="Width">���</param>
		/// <example>
		/// JSUnit.OpenIEWindowRight(page,"weihu.aspx",700);
		/// </example>
		public static void OpenIEWindowRight(System.Web.UI.Page page,string URL, int Width)
		{
			if(URL!=null)
			{
				if (Width==0 )
				{
					Alert(page,"ҳ���Ⱥ͸߶Ȳ���Ϊ�㣡");
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
				Alert(page,"ҳ���ַ����Ϊ�գ�");
			}
		}

		/// <summary>
		///13	��̬����,��һ��IE����(�ޱ�����������������ַ����)������Ļ�����ұߣ�����λ�����м䡣
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="URL">ҳ������</param>
		/// <param name="Width">���</param>
		/// <param name="Height">�߶�</param>
		/// <example>
		/// JSUnit.OpenIEWindowRight(page,"weihu.aspx",700,350);
		/// </example>
		public static void OpenIEWindowRight(System.Web.UI.Page page,string URL, int Width, int Height)
		{
			if(URL!=null)
			{
				if (Width==0 || Height==0)
				{
					Alert(page,"ҳ���Ⱥ͸߶Ȳ���Ϊ�㣡");
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
				Alert(page,"ҳ���ַ����Ϊ�գ�");
			}
		}

	

		/// <summary>
		/// 15 ��̬����,�ڿͻ���ע��һ��ű�����,
		/// ��Page�����form runat= serverԪ�صĽ������֮ǰ�����ýű���
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="script">JavaScript�ű�</param>
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
				Alert(page,"JavaScript�ű�����Ϊ�գ�");
			}
		}

       // public static bool DeleteConfirm

		/// <summary>
		///16 ��̬����,�ڿͻ���ע��һ��ű�����,
		///��Page�����form runat= serverԪ�صĿ�ʼ���֮�����������ýű���
		/// </summary>
		/// <param name="page">ҳ�����</param>
		/// <param name="script">JavaScript�ű�</param>
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
				Alert(page,"JavaScript�ű�����Ϊ�գ�");
			}
		}


		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի���
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{
			page.RegisterStartupScript("message","<script language='javascript' defer>alert('"+msg.ToString()+"');</script>");
		}

		/// <summary>
		/// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  ShowConfirmm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		/// <param name="url">��ת��Ŀ��URL</param>
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
		/// ����Զ���ű���Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="script">����ű�</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
			page.RegisterStartupScript("message","<script language='javascript' defer>"+script+"</script>");
		}

		/// <summary>
		/// Name:Redirect (��ת��ָ��ҳ,���ڴ������ݺ󷵼���Ϣ���)
		/// Author:Bifek
		/// Date:2006/10/30
		/// </summary>
		/// <param name="url">��ʾ����ҳ���ǳɹ�ҳ  1��ʾ�ɹ�ҳ 2��ʾ����ҳ</param>
		/// <param name="messages"></param>
		/// <param name="history"></param>
		/// <param name="breaker">ˢ�ο����</param>
		/// <param name="url">����ҳ��·��</param>
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
		/// ����ʱ�رյ����Ĵ���
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

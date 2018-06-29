using System;
using System.Data;
using System.Data.SqlClient;

namespace SQLHelper
{
	/// <summary>
	/// 自定义Exception
	/// </summary>
	public class SystemException:Exception
	{
		/// <summary>
		/// 包含系统Excepton
		/// </summary>
		public SystemException(string source,string message,Exception inner):base(message,inner)
		{
			base.Source=source;
		}

		/// <summary>
		/// 不包含系统Excepton
		/// </summary>			
		public SystemException(string source,string message):base(message)
		{
			base.Source=source;
		}
	}

	/// <summary>
	/// 处理网页中的HTML代码，并消除危险字符
	/// </summary>
	public class SystemHTML
	{
		private static string HTMLEncode(string fString)
		{
			if(fString!=string.Empty)
			{
				///替换尖括号
				fString.Replace("<","&lt;");
				fString.Replace(">","&rt;");
				///替换引号
				fString.Replace(((char)34).ToString(), "&quot;");
				fString.Replace(((char)39).ToString(), "&#39;");
				///替换空格
				fString.Replace(((char)13).ToString(), "");
				///替换换行符
				fString.Replace(((char)10).ToString(), "<BR> ");
			}
			return(fString);
		}
	}

	/// <summary>
	/// SystemTools 的摘要说明。
	/// </summary>
	public class SystemTools
	{		
		/// <summary>
		/// 将DataReader转为DataTable
		/// </summary>
		/// <param name="DataReader">DataReader</param>
		public static DataTable ConvertDataReaderToDataTable(SqlDataReader dataReader)
		{
			///定义DataTable
			DataTable datatable = new DataTable();					
			
			try
			{	///动态添加表的数据列
				for(int i = 0; i < dataReader.FieldCount; i++)
				{
					DataColumn myDataColumn = new DataColumn();
					myDataColumn.DataType = dataReader.GetFieldType(i);
					myDataColumn.ColumnName = dataReader.GetName(i);
					datatable.Columns.Add(myDataColumn);
				}	
			
				///添加表的数据
				while (dataReader.Read())
				{
					DataRow myDataRow = datatable.NewRow();
					for (int i = 0; i < dataReader.FieldCount; i++)
					{
						myDataRow[i] = dataReader[i].ToString();
					}
					datatable.Rows.Add(myDataRow);
					myDataRow = null;
				}              
				///关闭数据读取器
				dataReader.Close();
				return datatable;
			}
			catch(Exception ex)
			{				
				///抛出类型转换错误
				SystemError.CreateErrorLog(ex.Message);
				throw new Exception(ex.Message,ex);				
			}			
		}
        /// <summary>
        /// 判断一个字符串是否为数字
        /// </summary>
        /// <param name="strNumeric">输入的字符串</param>
        /// <returns></returns>
        public static bool IsNumeric(string strNumeric)
        {
            if (string.IsNullOrEmpty(strNumeric))
            {
                return false;
            }
            string strTemp = "";
            for (int i = 0; i < strNumeric.Length; i++)
            {
                strTemp = strNumeric.Substring(i, 1);
                if (strTemp.CompareTo("9")>0 || strTemp.CompareTo("0")<0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

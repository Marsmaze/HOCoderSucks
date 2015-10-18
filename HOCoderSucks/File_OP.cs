using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOCoderSucks
{
    class File_OP
    {
        public static bool WriteLog(string sAMAccountName,string displayName,string Password,int Result)
        {
            try
            {
                    StreamWriter sw = File.AppendText("域帐号创建结果.txt");
                    sw.WriteLine(displayName + "," + sAMAccountName + ","+Password+"," + Result);
                    sw.Flush();
                    sw.Close();
                    return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n写入日志操作出错。\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public static bool CHNtoPiyin(string displayName,string FamilyName,string GivenName)
        {
            try
            {
                StreamWriter sw = File.AppendText("汉字转拼音结果.txt");
                sw.WriteLine(displayName + "," + FamilyName + "," + GivenName);
                sw.Flush();
                sw.Dispose();
                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n拼音因转换时写入日志出错。\n\n" + ex.Message.ToString());
                return false;
            }
        }
    }
}

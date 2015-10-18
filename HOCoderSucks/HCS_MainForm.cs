using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.DirectoryServices;
using Microsoft.International.Converters.PinYinConverter;

namespace HOCoderSucks
{
    public partial class HCS_MainForm : Form
    {
        public HCS_MainForm()
        {
            InitializeComponent();
        }

        public string DG_SelectedAccount = "";

        /// <summary>
        /// 查询按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Search_Click(object sender, EventArgs e)
        {
            try
            {
                //DirectoryEntry de = AD_OP.GetDirectoryEntryByName(TB_Search.Text,TB_SAMAccount.Text.ToString(),TB_Password.Text.ToString());
                //textBox1.Text = "";
                //if(de!=null)
                //{
                    //foreach (PropertyValueCollection i in de.Properties)
                    //{
                    //    //MessageBox.Show(i.PropertyName.ToString());
                    //    textBox1.AppendText(i.PropertyName.ToString() + "=" + i.Value.ToString() + "\n");
                    //}           
         
                    //foreach (SearchResult j in AD_OP.GetDirectoryEntriesByName(TB_Search.Text))
                    //{
                    //    DirectoryEntry de2 = new DirectoryEntry(j.Path);
                    //    textBox1.AppendText(AD_OP.GetProperty(de2, "displayName") + " ");
                    //    textBox1.AppendText(AD_OP.GetProperty(de2, "sAMAccountName") + " ");
                    //    textBox1.AppendText(AD_OP.GetProperty(de2, "wWWHomePage") + " ");
                    //    textBox1.AppendText(AD_OP.GetProperty(de2, "pager") + "\n");
                    //}
                    //TB_displayName.Text = AD_OP.GetProperty(de, "displayName");
                    //TB_sAMAccount.Text = AD_OP.GetProperty(de, "sAMAccountName");
                    //TB_EmployeeID.Text = AD_OP.GetProperty(de, "wWWHomePage");
                    //TB_SocialID.Text = AD_OP.GetProperty(de, "pager");
                    //TB_lastLogonTimestamp.Text = DateTime.FromFileTime(AD_OP.GetLastTimestamp(TB_displayName.Text)).ToShortDateString();
                    //TB_IsAccountDisabled.Text = AD_OP.IsAccountDisabled(de).ToString();
                    //TB_IsAccountLockout.Text = AD_OP.IsAccountLockOut(de).ToString();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// 在查询文本框按回车以后的动作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果按下回车键
            if (e.KeyChar == (char)13)
            {
                try
                {
                    AD_OP.ADPath = TB_LDAP.Text;

                    if (AD_OP.IsLoginCheck(TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) != "OK")
                    {
                        MessageBox.Show(AD_OP.IsLoginCheck(TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()));
                    }
                    else if (AD_OP.IsLoginCheck(TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == "OK")
                    {
                        DirectoryEntry de = AD_OP.GetDirectoryEntryByName(TB_Search.Text, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString());
                        //初始化dataGrid的列数和行数。
                        DG_Result.ColumnCount = 6;
                        DG_Result.RowCount = 1;

                        //初始化DataGrid列标题的内容。
                        DG_Result.Columns[0].HeaderText = AD_OP._displayName[0];
                        DG_Result.Columns[1].HeaderText = AD_OP._sAMAccountName[0];
                        DG_Result.Columns[2].HeaderText = AD_OP._wWWHomePage[0];
                        DG_Result.Columns[3].HeaderText = AD_OP._pager[0];
                        DG_Result.Columns[4].HeaderText = AD_OP._mail[0];
                        DG_Result.Columns[5].HeaderText = "上次登录日期";
                        //
                        for (int i = 0; i < DG_Result.ColumnCount; i++)
                        {
                            DG_Result.Columns[i].Width = (DG_Result.Width - DG_Result.RowHeadersWidth) / DG_Result.ColumnCount;
                        }

                        //结果集非空。
                        if (de != null)
                        {
                            //根据搜索框TB_Search的内容来填充DataGrid。
                            foreach (SearchResult j in AD_OP.GetDirectoryEntriesByName(TB_Search.Text, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()))
                            {
                                DirectoryEntry de2 = new DirectoryEntry(j.Path);
                                //向DataGrid内加入一行数据。
                                DG_Result.Rows.Add(
                                    AD_OP.GetProperty(de2, AD_OP._displayName[1]),
                                    AD_OP.GetProperty(de2, AD_OP._sAMAccountName[1]),
                                    AD_OP.GetProperty(de2, AD_OP._wWWHomePage[1]),
                                    AD_OP.GetProperty(de2, AD_OP._pager[1]),
                                    AD_OP.GetProperty(de2, AD_OP._mail[1]),
                                    DateTime.FromFileTime(
                                        AD_OP.GetLastTimestamp(AD_OP.GetProperty(de2, AD_OP._displayName[1]), TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString())).ToShortDateString()
                                    );
                                Application.DoEvents();
                            }

                            //判断帐号是否禁用
                            if (AD_OP.IsAccountDisabled(de) == true)
                            {
                                LB_IsAccountDisabled_R.ForeColor = System.Drawing.Color.FromName("White");
                                LB_IsAccountDisabled_R.BackColor = System.Drawing.Color.FromName("Red");
                            }
                            else
                            {
                                LB_IsAccountDisabled_R.ForeColor = System.Drawing.Color.FromName("White");
                                LB_IsAccountDisabled_R.BackColor = System.Drawing.Color.FromName("Green");
                            }
                            //判断帐号是否被锁定
                            if (AD_OP.IsAccountLockOut(de) == true)
                            {
                                LB_IsAccountLockout_R.ForeColor = System.Drawing.Color.FromName("White");
                                LB_IsAccountLockout_R.BackColor = System.Drawing.Color.FromName("Red");
                            }
                            else
                            {
                                LB_IsAccountLockout_R.ForeColor = System.Drawing.Color.FromName("White");
                                LB_IsAccountLockout_R.BackColor = System.Drawing.Color.FromName("Green");
                            }
                            LB_IsAccountLockout_R.BackColor = System.Drawing.Color.FromName("Green");
                        }
                    }
                    DG_Result.Focus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n" + ex.Message);
                }
            }
            else
                return;
        }

        /// <summary>
        /// 双击DataGrid单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Result_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                MessageBox.Show("Hahaha");
  
            }
        }

        /// <summary>
        /// 双击行的头部RowHeader
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_RH_DoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            
        }
    
        /// <summary>
        /// DataGrid单元格内容改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //RowHeader的RowIndex==-1，所以需要排除掉。
            if (e.RowIndex != -1)
            {
                DG_Result.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = System.Drawing.Color.FromName("Chocolate");
                DG_SelectedAccount = DG_Result.Rows[e.RowIndex].Cells[1].Value.ToString();

            }
        }

        /// <summary>
        /// 单击DataGrid单元格显示的内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Result_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DirectoryEntry de = AD_OP.GetDirectoryEntryByName(TB_Search.Text);
            
            
        }

        /// <summary>
        /// 单击DataGrid单元格
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DG_Result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //不是按的ColumnHeader且不是按DataGrid最后一个空行的情况
                if (e.RowIndex >= 0 && e.RowIndex != DG_Result.Rows.Count-1)
                {
                    //根据DataGrid显示的帐号来得到一个DirectoryEntry
                    DirectoryEntry de = AD_OP.GetDirectoryEntryByAccount(DG_Result.Rows[e.RowIndex].Cells[1].Value.ToString(), TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString());
                    
                    TB_RstAccount.Text = AD_OP.GetProperty(de,AD_OP._sAMAccountName[1]);
                    TB_RstPwd.Text = AD_OP.RandomPWD(8);
                    //判断帐号是否禁用
                    if (de == null)
                    {
                        //de如果是空，则将Lable背景和前景设置为白色。
                        LB_IsAccountDisabled_R.ForeColor = System.Drawing.Color.FromName("White");
                        LB_IsAccountDisabled_R.BackColor = System.Drawing.Color.FromName("White");
                    }
                    //如果禁用，则将Lable前景设置为白色背景设置为红色。
                    else if (de != null && AD_OP.IsAccountDisabled(de) == true)
                    {
                        LB_IsAccountDisabled_R.ForeColor = System.Drawing.Color.FromName("White");
                        LB_IsAccountDisabled_R.BackColor = System.Drawing.Color.FromName("Red");
                    }
                    else
                    {
                        LB_IsAccountDisabled_R.ForeColor = System.Drawing.Color.FromName("White");
                        LB_IsAccountDisabled_R.BackColor = System.Drawing.Color.FromName("Green");
                    }
                    //判断帐号是否被锁定
                    if(de == null)
                    {
                        //de如果是空，则将Lable背景和前景设置为白色。
                        LB_IsAccountLockout_R.ForeColor = System.Drawing.Color.FromName("White");
                        LB_IsAccountLockout_R.BackColor = System.Drawing.Color.FromName("White");
                    }
                    //如果锁定，则将Lable前景设置为白色背景设置为红色。
                    else if (de != null && AD_OP.IsAccountLockOut(de) == true)
                    {
                        LB_IsAccountLockout_R.ForeColor = System.Drawing.Color.FromName("White");
                        LB_IsAccountLockout_R.BackColor = System.Drawing.Color.FromName("Red");
                    }
                    else
                    {
                        LB_IsAccountLockout_R.ForeColor = System.Drawing.Color.FromName("White");
                        LB_IsAccountLockout_R.BackColor = System.Drawing.Color.FromName("Green");
                    }
                    de.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
 
        /// <summary>
        /// 按下更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Update_Click(object sender, EventArgs e)
        {
            try
            {
                if (DG_Result.SelectedCells.Count == 1)
                {
                    //
                    DirectoryEntry de = AD_OP.GetDirectoryEntryByAccount(DG_SelectedAccount, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString());
                    //修改显示名属性值，并写回DC。
                    AD_OP.SetProperty(de,
                        AD_OP._displayName[1],
                        DG_Result.SelectedCells[0].Value.ToString());
                    de.CommitChanges();
                    DG_SelectedAccount = "";
                    de.Close();
                }
                else if (DG_Result.SelectedCells.Count < 1)
                {
                    MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n现在还没有格子。");
                }
                else
                {
                    MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n格子选多了。");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n"+ex.Message);
            }

        }

        /// <summary>
        /// 焦点进入密码框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_PasswordEnter(object sender, EventArgs e)
        {
            TB_Password.SelectAll();
        }

        /// <summary>
        /// 在密码框内点鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_PasswordClick(object sender, MouseEventArgs e)
        {
            TB_Password.SelectAll();
        }

        /// <summary>
        /// 焦点进入帐号框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_SAMAccountEnter(object sender, EventArgs e)
        {
            TB_SAMAccount.SelectAll();
        }

        /// <summary>
        /// 帐号框内点鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_SAMAccountClick(object sender, MouseEventArgs e)
        {
            TB_SAMAccount.SelectAll();
        }

        /// <summary>
        /// 焦点进入查询框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_SearchEnter(object sender, EventArgs e)
        {
            TB_Search.SelectAll();
        }

        /// <summary>
        /// 查询框内点鼠标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_SearchClick(object sender, MouseEventArgs e)
        {
            TB_Search.SelectAll();
        }

        /// <summary>
        /// 单击重置密码按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_RstPwd_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryEntry de = AD_OP.GetDirectoryEntryByAccount(TB_RstAccount.Text.ToString(), 
                    TB_SAMAccount.Text.ToString(), 
                    TB_Password.Text.ToString());
                //重置密码。
                de.Invoke("SetPassword", new object[] {TB_RstPwd.Text.ToString()});
                //解锁帐号。
                de.Properties["LockOutTime"].Value = 0;
                //向域写入修改。
                de.CommitChanges();
                de.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n重置密码时出错\n\n" + ex.Message.ToString());
            }
        }
        
        
        
        /// <summary>
        /// 单击帐号导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_Import_Click(object sender, EventArgs e)
        {
            try
            {
                int AccountCreationResult;//帐号创建返回结果0正常，1帐号存在，-1帐号创建异常
                string Password;
                AD_OP.ADPath = TB_LDAP.Text;
                AD_OP.DomainName = TB_UPN.Text;

                //检测登录框帐号密码是否正确
                if (AD_OP.IsLoginCheck(TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == "OK")
                {
                    BT_Import.Enabled = false;//禁用导入按钮
                    TB_Import.Enabled = false;//禁用导入文本框，防止导入时误操作
                    
                    File_OP.WriteLog("",DateTime.Now.ToString(),"",20120605);//写入帐号导入时间
                    
                    string strLineData;
                    StringReader sr = new StringReader(TB_Import.Text.Trim());
                    strLineData = sr.ReadLine();

                    while (!String.IsNullOrEmpty(strLineData))//如果读入字符串不为空
                    {
                        //将当前行字符串以英文半角逗号分隔开，并存入数组strLineArr
                        string[] strLineArr = strLineData.Split(',');

                        string Account = strLineArr[1] + strLineArr[2];//帐号由姓和名组合而成
                        //保证有7个帐号信息不能少(姓名，姓（拼音），名（拼音），部门，员工编号，身份证号，公司),并且帐号不存在。
                        if (strLineArr.Length == 7 && AD_OP.IsAccExist(Account, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == 0) 
                        {
                            //Password = "Password123";
                            Password = AD_OP.RandomPWD(8);//8位随机密码
                            AccountCreationResult= AD_OP.CreateAccount(
                                    strLineArr[0],//姓名
                                    Account,//帐号
                                    Password,//密码,随机生成
                                    strLineArr[3],//部门
                                    strLineArr[4],//员工编号
                                    strLineArr[5],//身份证号
                                    Account + "@juneyaoair.com",//邮箱,和帐号相同
                                    strLineArr[6],//公司
                                    TB_SAMAccount.Text.ToString(),//登录帐号用户名
                                    TB_Password.Text.ToString()//登录帐号密码
                                    );

                            PB_Import.Value++;
                            Application.DoEvents();//在进度条累加的过程中，防止窗体假死。暂时不知道为什么，网上查到的。
                            //continue;
                        }
                        //保证有7个帐号信息不能少(姓名，姓（拼音），名（拼音），部门，员工编号，身份证号，公司),并且帐号已经存在。
                        else if (strLineArr.Length == 7 && AD_OP.IsAccExist(Account, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == 1)
                        {
                            DirectoryEntry de = AD_OP.GetDirectoryEntryByAccount(Account, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString());

                            //需要创建的同名帐号身份证号和之前存在的不同&&需要创建的同名帐号员工编号和之前存在的不同
                            if (AD_OP.GetProperty(de, AD_OP._pager[1]) != strLineArr[5]
                                && AD_OP.GetProperty(de, AD_OP._wWWHomePage[1]) != strLineArr[4]
                                )
                            {
                                //Password = "Password123";
                                Password = AD_OP.RandomPWD(8);//8位随机密码
                                Account = strLineArr[1][0].ToString() + strLineArr[2];//姓简拼，名全拼。
                                AccountCreationResult = AD_OP.CreateAccount(
                                strLineArr[0],//姓名
                                Account,//帐号号
                                Password,//密码,随机生成
                                strLineArr[3],//部门
                                strLineArr[4],//员工编
                                strLineArr[5],//身份证号
                                Account + "@juneyaoair.com",//邮箱和帐号相同
                                strLineArr[6],//公司
                                TB_SAMAccount.Text.ToString(),//登录帐号用户名
                                TB_Password.Text.ToString()//登录帐号密码
                                );
                                PB_Import.Value++;
                                Application.DoEvents();//在进度条累加的过程中，防止窗体假死。暂时不知道为什么，网上查到的。
                            }
                            else
                            {
                                File_OP.WriteLog(Account, strLineArr[0], "帐号已存在", 1);
                                PB_Import.Value++;
                                Application.DoEvents();//在进度条累加的过程中，防止窗体假死。暂时不知道为什么，网上查到的。
                            }

                            de.Dispose();
                            de.Close();
                        }
                        //继续读下一行
                        strLineData = sr.ReadLine();
                        
                        //进度条百分比显示，"*1.0"是为了将整型转换成浮点数。
                        LB_Processing.Text = (PB_Import.Value*1.0 / PB_Import.Maximum).ToString("P0");
                    }
                    
                    CB_Unlock.Checked = false;//不勾选解锁复选框
                    TB_Import.Enabled = true;//启用导入文本框
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n导入用户时出错。\n\n" + ex.Message.ToString());
            }
        }

        /// <summary>
        /// 单击汉字转换拼音按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_ChnConvert_Click(object sender, EventArgs e)
        {
            string strLineData;
            StringReader sr = new StringReader(TB_Import.Text.Trim());
            strLineData = sr.ReadLine();
            while (!String.IsNullOrEmpty(strLineData))
            {
                string[] strLineArr = strLineData.Split(',');//将当前行字符串以英文半角逗号分隔开，并存入数组strLineArr
                //写入日志
                File_OP.CHNtoPiyin(      
                    strLineArr[0],//汉字姓名
                    Pinyin.GetPinyin(strLineArr[0][0].ToString()).ToLower(),//姓氏转成拼音
                    Pinyin.GetPinyin(strLineArr[0].Substring(1,strLineArr[0].Length-1)).ToLower()//名转成拼音
                    );
                strLineData = sr.ReadLine();//读取下一行
            }
        }

        /// <summary>
        /// 账号导入文本框内容变更时触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_Import_TextChanged(object sender, EventArgs e)
        {
            LB_Total.Text = TB_Import.Lines.Length.ToString();
            PB_Import.Maximum = TB_Import.Lines.Length;
            PB_Import.Minimum = 0;
            PB_Import.Value = 0;
        }

        /// <summary>
        /// 解锁导入按钮复选框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_Unlock_CheckStateChanged(object sender, EventArgs e)
        {
            if (CB_Unlock.Checked == true)
            {
                BT_Import.Enabled = true;
                BT_EFB_Import.Enabled = true;
                TB_Import.Enabled = true;//让导入帐号文本框可编辑
                LB_Processing.Text = "0%";
                PB_Import.Value = 0;
            }
            else
            {
                BT_Import.Enabled = false;
                BT_EFB_Import.Enabled = false;
                TB_Import.Enabled = true;//让导入帐号文本框可编辑
            }
        }

        /// <summary>
        /// 主窗体加载时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HCS_MainForm_Load(object sender, EventArgs e)
        {
            LB_Processing.Text = "0%";
            TB_UPN.Text = "@juneyaoair.com";
            PB_Import.Value = 0;
            BT_Import.Enabled = false;
            TB_LDAP.Enabled = false;
            LB_LDAP_Example.Text = "示例：LDAP://juneyaoair.com/cn=users,dc=juneyaoair,dc=com";
            TB_LDAP.Text = "LDAP://192.168.254.212/ou=dkh,dc=marsmaze,dc=org";
            TB_UPN.Enabled = false;
            BT_Import.Enabled = false;
            BT_EFB_Import.Enabled = false;
        }

        /// <summary>
        /// 解锁LDAP复选框选中状态改变时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_LDAP_CheckStateChanged(object sender, EventArgs e)
        {
            if (CB_LDAP.Checked == true)
            {
                TB_LDAP.Enabled = true;
            }
            else
            {
                TB_LDAP.Enabled = false;
                //复选框没有被选中时，将LDAP路径写成测试环境
                TB_LDAP.Text = "LDAP://192.168.254.212/ou=dkh,dc=marsmaze,dc=org";
            }
        }

        /// <summary>
        /// UPN后缀复选框状态改变
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CB_UPN_CheckStateChanged(object sender, EventArgs e)
        {
            if (CB_UPN.Checked == true)
            {
                TB_UPN.Enabled = true;
            }
            else
            {
                TB_UPN.Enabled = false;
            }
        }

        /// <summary>
        /// 双击示例标签
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LB_LDAP_Example_DoubleClick(object sender, EventArgs e)
        {
            if (TB_LDAP.Enabled == true)
            {
                TB_LDAP.Text = "LDAP://juneyaoair.com/cn=users,dc=juneyaoair,dc=com";
            }
        }

        /// <summary>
        /// 单击EFB账号导入按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BT_EFB_Import_Click(object sender, EventArgs e)
        {
            try
            {
                int AccountCreationResult;//帐号创建返回结果0正常，1帐号存在，-1帐号创建异常
                string Password;
                AD_OP.ADPath = TB_LDAP.Text;
                AD_OP.DomainName = TB_UPN.Text;

                //检测登录框帐号密码是否正确
                if (AD_OP.IsLoginCheck(TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == "OK")
                {
                    BT_EFB_Import.Enabled = false;//禁用导入按钮
                    TB_Import.Enabled = false;//禁用导入文本框，防止导入时误操作

                    File_OP.WriteLog("", DateTime.Now.ToString(), "", 20120605);//写入帐号导入时间

                    string strLineData;
                    StringReader sr = new StringReader(TB_Import.Text.Trim());
                    strLineData = sr.ReadLine();

                    while (!String.IsNullOrEmpty(strLineData))//如果读入字符串不为空
                    {
                        //将当前行字符串以英文半角逗号分隔开，并存入数组strLineArr
                        string[] strLineArr = strLineData.Split(',');

                        string Account = strLineArr[1];//MAC地址就是账号 
                        //保证有3个帐号信息不能少(姓名，MAC地址，公司),并且帐号不存在。
                        if (strLineArr.Length == 3 && AD_OP.IsAccExist(Account, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == 0)
                        {
                            Password = strLineArr[1];//MAC地址就是密码
                            AccountCreationResult = AD_OP.CreateAccount(
                                    strLineArr[0],//姓名（显示名）
                                    Account.ToLower(),//帐号,小写。
                                    Password.ToLower(),//密码,MAC地址，小写。
                                    " ",//部门
                                    " ",//员工编号
                                    " ",//身份证号
                                    " ",//邮箱,和帐号相同
                                    strLineArr[2],//公司
                                    TB_SAMAccount.Text.ToString(),//登录帐号用户名
                                    TB_Password.Text.ToString()//登录帐号密码
                                    );

                            PB_Import.Value++;
                            Application.DoEvents();//在进度条累加的过程中，防止窗体假死。暂时不知道为什么，网上查到的。
                            
                        }
                        //保证有3个帐号信息不能少(姓名，MAC地址，公司),并且帐号已经存在。
                        //保证有3个帐号信息不能少(姓名，MAC地址，公司),并且帐号已经存在。
                        //保证有3个帐号信息不能少(姓名，MAC地址，公司),并且帐号已经存在。
                        //保证有3个帐号信息不能少(姓名，MAC地址，公司),并且帐号已经存在。
                        else if (strLineArr.Length == 3 && AD_OP.IsAccExist(Account, TB_SAMAccount.Text.ToString(), TB_Password.Text.ToString()) == 1)
                        {
                                File_OP.WriteLog(Account, strLineArr[0], "帐号已存在", 1);
                                PB_Import.Value++;
                                Application.DoEvents();//在进度条累加的过程中，防止窗体假死。暂时不知道为什么，网上查到的。
                        }
                        //继续读下一行
                        strLineData = sr.ReadLine();

                        //进度条百分比显示，"*1.0"是为了将整型转换成浮点数。
                        LB_Processing.Text = (PB_Import.Value * 1.0 / PB_Import.Maximum).ToString("P0");
                    }

                    CB_Unlock.Checked = false;//不勾选解锁复选框
                    TB_Import.Enabled = true;//启用导入文本框
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n导入用户时出错。\n\n" + ex.Message.ToString());
            }
        }

    }
}

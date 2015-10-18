using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using System.DirectoryServices;
using System.Windows.Forms;

namespace HOCoderSucks
{
    class AD_OP
    {
        #region 公有变量
        ///<summary>
        /// 域名
        ///</summary>
        public static string DomainName = "@juneyaoair.com";  //实际
        //private static string DomainName = "marsmaze.org";    //测试用

        /// <summary>
        /// LDAP绑定路径
        /// </summary>
        public static string ADPath = "LDAP://192.168.254.212/ou=dkh,dc=marsmaze,dc=org";     //测试用

        #endregion

        #region 私有变量
        /// <summary>
        /// homeMTA
        /// </summary>
        //private static string homeMTA = ""; //请填写自己的环境变量
        /// <summary>
        /// homeMDB
        /// </summary>
        //private static string homeMDB = ""; //请填写自己的环境变量
        /// <summary>
        /// msExchHomeServerName
        /// </summary>
        //private static string msExchHomeServerName = ""; //请填写自己的环境变量

        
        /// <summary>
        /// LDAP 地址
        /// </summary>
        //private static string LDAPDomain = "DC=marsmaze,DC=org";    //测试用
        
        
        //private static string sPrincpleNameTail = "@marsmaze.org";  //测试用
        /// <summary>
        /// 登录帐号
        /// </summary>
        //private static string ADUser = @"marsmaze\adgetinfo";
        //private static string ADUser = @"adgetinfo@marsmaze.org";
        /// <summary>
        /// 登录密码
        /// </summary>
        //private static string ADPassword = "";   //测试用

        ///<summary>
        ///
        ///</summary>
        #endregion


        #region 枚举常量
        /// <summary>
        /// 用户登录验证结果
        /// </summary>
        public enum LoginResult
        {
            /// 
            /// 正常登录
            /// 
            LOGIN_USER_OK = 0,
            /// 
            /// 用户不存在
            /// 
            LOGIN_USER_DOESNT_EXIST,
            /// 
            /// 用户帐号被禁用
            /// 
            LOGIN_USER_ACCOUNT_INACTIVE,
            /// 
            /// 用户密码不正确
            /// 
            LOGIN_USER_PASSWORD_INCORRECT
        }

        /// <summary>
        /// 用户属性定义标志
        /// </summary>
        public enum ADS_USER_FLAG_ENUM
        {
            /// 
            /// 登录脚本标志。如果通过 ADSI LDAP 进行读或写操作时，
            /// 该标志失效。如果通过 ADSI WINNT，该标志为只读。
            /// 
            ADS_UF_SCRIPT = 0X0001,
            /// 
            /// 用户帐号禁用标志
            /// 
            ADS_UF_ACCOUNTDISABLE = 0X0002,
            /// 
            /// 主文件夹标志
            /// 
            ADS_UF_HOMEDIR_REQUIRED = 0X0008,
            /// 
            /// 过期标志
            /// 
            ADS_UF_LOCKOUT = 0X0010,
            /// 
            /// 用户密码不是必须的
            /// 
            ADS_UF_PASSWD_NOTREQD = 0X0020,
            /// 
            /// 密码不能更改标志
            /// 
            ADS_UF_PASSWD_CANT_CHANGE = 0X0040,
            /// 
            /// 使用可逆的加密保存密码
            /// 
            ADS_UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED = 0X0080,
            /// 
            /// 本地帐号标志
            /// 
            ADS_UF_TEMP_DUPLICATE_ACCOUNT = 0X0100,
            /// 
            /// 普通用户的默认帐号类型
            /// 
            ADS_UF_NORMAL_ACCOUNT = 0X0200,
            /// 
            /// 跨域的信任帐号标志
            /// 
            ADS_UF_INTERDOMAIN_TRUST_ACCOUNT = 0X0800,
            /// 
            /// 工作站信任帐号标志
            /// 
            ADS_UF_WORKSTATION_TRUST_ACCOUNT = 0x1000,
            /// 
            /// 服务器信任帐号标志
            /// 
            ADS_UF_SERVER_TRUST_ACCOUNT = 0X2000,
            /// 
            /// 密码永不过期标志
            /// 
            ADS_UF_DONT_EXPIRE_PASSWD = 0X10000,
            /// 
            /// MNS 帐号标志
            /// 
            ADS_UF_MNS_LOGON_ACCOUNT = 0X20000,
            /// 
            /// 交互式登录必须使用智能卡
            /// 
            ADS_UF_SMARTCARD_REQUIRED = 0X40000,
            /// 
            /// 当设置该标志时，服务帐号（用户或计算机帐号）将通过 Kerberos 委托信任
            /// 
            ADS_UF_TRUSTED_FOR_DELEGATION = 0X80000,
            /// 
            /// 当设置该标志时，即使服务帐号是通过 Kerberos 委托信任的，敏感帐号不能被委托
            /// 
            ADS_UF_NOT_DELEGATED = 0X100000,
            /// 
            /// 此帐号需要 DES 加密类型
            /// 
            ADS_UF_USE_DES_KEY_ONLY = 0X200000,
            /// 
            /// 不要进行 Kerberos 预身份验证
            /// 
            ADS_UF_DONT_REQUIRE_PREAUTH = 0X4000000,
            /// 
            /// 用户密码过期标志
            /// 
            ADS_UF_PASSWORD_EXPIRED = 0X800000,
            /// 
            /// 用户帐号可委托标志
            /// 
            ADS_UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION = 0X1000000

        }

        #endregion

        #region 公有常量
        /// <summary>
        /// 域帐户显示名数组。索引0为属性对应的中文，索引1为属性值。
        /// </summary>
        public static readonly string[] _displayName = { "姓名","displayName" };
        /// <summary>
        /// 域帐户帐号数组。索引0为属性对应的中文，索引1为属性值。
        /// </summary>
        public static readonly string[] _sAMAccountName = { "域帐号", "sAMAccountName"};
        /// <summary>
        /// 域帐户员工编号数组。索引0为属性对应的中文，索引1为属性值。
        /// </summary>
        public static readonly string[] _wWWHomePage = { "员工编号", "wWWHomePage"};
        /// <summary>
        /// 域帐户身份证号数组。索引0为属性对应的中文，索引1为属性值。
        /// </summary>
        public static readonly string[] _pager = {"身份证号","pager"};
        /// <summary>
        /// 域帐户邮箱数组。索引0为属性对应的中文，索引1为属性值。
        /// </summary>
        public static readonly string[] _mail = {"邮箱","mail" };

        public static readonly string[] _pwd = {"密码","pwd"};
        #endregion

        #region GetDirectoryObject
        /// <summary>
        ///获得DirectoryEntry对象实例,登陆AD
        /// </summary>
        //private static DirectoryEntry GetDirectoryObject()
        //{
        //    DirectoryEntry entry = new DirectoryEntry(ADPath, ADUser, ADPassword, AuthenticationTypes.Secure);
        //    return entry;
        //}

        /// <summary>
        /// 根据输入的帐号密码获得DirectoryEntry对象实例,登陆AD
        /// </summary>
        /// <param name="User">域帐户名</param>
        /// <param name="Password">密码</param>
        /// <returns>返回DirectoryEntry</returns>
        public static DirectoryEntry GetDirectoryObject(string User,string Password)
        {
            DirectoryEntry entry = new DirectoryEntry(ADPath, User, Password, AuthenticationTypes.Secure);
            return entry;
        }

        #endregion

        #region GetDirectoryEntry
        /// <summary>
        /// 根据用户displayName或sAMAccount或pager取得用户的 对象
        /// </summary>
        /// <param name="displayName">displayName或sAMAccount或pager字段内容，支持*号</param>
        /// <returns>如果找到该用户，则返回用户的 对象；否则返回 null</returns>
        public static DirectoryEntry GetDirectoryEntryByName(string displayName,string User,string Password)
        {
            try
            {
                DirectoryEntry de = GetDirectoryObject(User,Password);
                DirectorySearcher deSearch = new DirectorySearcher(de);
                deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(|(displayName=" + displayName + ")(sAMAccountName=" + displayName + ")(pager="+displayName+")))";
                deSearch.SearchScope = SearchScope.Subtree;
                SearchResult result = deSearch.FindOne();
                de = new DirectoryEntry(result.Path);
                return de;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 获取重名用户的SearchResultCollection
        /// </summary>
        /// <param name="displayName">显示名</param>
        /// <returns>有结果返回一个SearchResultCollection，没有结果返回null</returns>
        public static SearchResultCollection GetDirectoryEntriesByName(string displayName, string User, string Password)
        {

            try
            {
                DirectoryEntry de = GetDirectoryObject(User,Password);
                DirectorySearcher deSearch = new DirectorySearcher(de);
                deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(|(displayName=" + displayName + ")(sAMAccountName=" + displayName + ")(pager=" + displayName + ")))";
                deSearch.SearchScope = SearchScope.Subtree;
                SearchResultCollection result = deSearch.FindAll();
                return result;
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// 根据用户帐号称取得用户的对象
        /// </summary>
        /// <param name="sAMAccountName">用户名字</param>
        /// <returns>如果找到该用户，则返回用户的 对象；否则返回 null</returns>
        public static DirectoryEntry GetDirectoryEntryByAccount(string sAMAccountName, string User, string Password)
        {
            try
            {
                DirectoryEntry de = GetDirectoryObject(User,Password);
                DirectorySearcher deSearch = new DirectorySearcher(de);
                deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(sAMAccountName=" + sAMAccountName + "))";
                deSearch.SearchScope = SearchScope.Subtree;
                //返回找到的第一项。sAMAccountName是唯一的，所以只可能有一个记录
                SearchResult result = deSearch.FindOne();
                de = new DirectoryEntry(result.Path, User, Password);
                return de;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 根据用户的名字取得上次登录的时间戳
        /// </summary>
        /// <param name="displayName">用户名字</param>
        /// <returns>如果有最后登录时间戳，则返回时间戳；否则返回0</returns>
        public static long GetLastTimestamp(string displayName, string User, string Password)
        {

            try
            {
                DirectoryEntry de = GetDirectoryObject(User,Password);
                DirectorySearcher deSearch = new DirectorySearcher(de);
                deSearch.Filter = "(&(&(objectCategory=person)(objectClass=user))(|(displayName=" + displayName + ")(sAMAccountName=" + displayName + ")(pager=" + displayName + ")))";
                deSearch.SearchScope = SearchScope.Subtree;
                long Mystamp;
                SearchResult result = deSearch.FindOne();
                Mystamp = (long)result.Properties["lastLogonTimestamp"][0];
                return Mystamp;
            }
            catch
            {
                return 0;
            }

        }

        #endregion

        #region IsLoginCheck
        /// <summary>
        /// 检查是否登录正常。
        /// </summary>
        /// <returns></returns>
        public static string IsLoginCheck(string User,string Password)
        {
            try
            {
                //如果密码正确，有返回值，就可以将字符串ToUpper,否则抛错。
                AD_OP.GetDirectoryObject(User, Password).Name.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return "OK";
        }
        #endregion

        #region GetProperty
        /// <summary>
        /// 获得指定 指定属性名对应的值 
        /// </summary>
        /// <param name="de">DirectoryEntry对象，如为用户则为用户的对象，部门则为部门的对象</param>
        /// <param name="propertyName">属性名称</param>
        /// <returns>属性值</returns>
        public static string GetProperty(DirectoryEntry de, string propertyName)
        {
            if (de.Properties.Contains(propertyName))
            {
                return de.Properties[propertyName][0].ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// 查询指定用户是否是锁定状态
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static bool IsAccountLockOut(DirectoryEntry de)
        {
            //& 按位与运算符，二进制下全1出1，所以在使用8421码的userAccountControl字段中，只有在值包含0x00000010时才会出1，即锁定。
            return Convert.ToBoolean((int)de.Properties["userAccountControl"].Value & 0x00000010);
        }

        /// <summary>
        /// 查询指定用户是否是禁用状态
        /// </summary>
        /// <param name="de"></param>
        /// <returns></returns>
        public static bool IsAccountDisabled(DirectoryEntry de)
        {
                //& 按位与运算符，二进制下全1出1，所以在使用8421码的userAccountControl字段中，只有在值包含0x00000002时才会出1，即禁用。
                return Convert.ToBoolean((int)de.Properties["userAccountControl"].Value & 0x00000002);
        }

        public static string HeadertoProperty(string ColumnIndex)
        {
            if (ColumnIndex == "0")
            {
                return _displayName[0];
            }
            else if (ColumnIndex == "1")
            {
                return _sAMAccountName[0];
            }
            else if (ColumnIndex == "2")
            {
                return _wWWHomePage[0];
            }
            else if (ColumnIndex == "3")
            {
                return _pager[0];
            }
            else
            {
                return null;
            }
        }

        #endregion

        #region SetProperty
        /// <summary>
        /// 设置指定 的属性值
        /// </summary>
        /// <param name="de"></param>
        /// <param name="propertyName">属性名称</param>
        /// <param name="propertyValue">属性值</param>
        public static void SetProperty(DirectoryEntry de, string propertyName, string propertyValue)
        {
            if (propertyValue != string.Empty || propertyValue != "" || propertyValue != null)
            {
                if (de.Properties.Contains(propertyName))
                {
                    de.Properties[propertyName][0] = propertyValue;
                    //Commit修改的值
                    //de.CommitChanges();
                }
                else
                {
                    de.Properties[propertyName].Add(propertyValue);
                    //Commit修改的值
                    //de.CommitChanges();
                }
            }
        }

        #endregion


        #region SetRandomPassword
        /// <summary>
        /// 生成随机密码。
        /// </summary>
        /// <param name="PWDlen">密码长度</param>
        /// <returns></returns>
        public static string RandomPWD(int PWDlen)
        {
            Random R = new Random();
            string PWDSeed = "23456789abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ";
            string RstPwd = PWDSeed[R.Next(32,PWDSeed.Length-1)].ToString();//保证密码首位大写。
            while (RstPwd.Length < PWDlen)
            {
                //第四位必须是数字，为了保证密码里面至少有一个数字
                if(RstPwd.Length==3)
                {
                    RstPwd += PWDSeed[R.Next(0, 7)];
                }
                //地7位必须是小写字母，为了保证密码里面至少有一位小写字母
                else if (RstPwd.Length == 6)
                {
                    RstPwd += PWDSeed[R.Next(8, 31)];
                }
                else
                {
                    RstPwd += PWDSeed[R.Next(0, PWDSeed.Length - 1)];
                }
            }
            return RstPwd.ToString();
        }
        #endregion

        #region AccountOP
        /// <summary>
        /// 检测帐户是否已存在。
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static int IsAccExist(string sAMAccountName,string User,string Password)
        {
            try
            {
                //返回null表示没有找到用户。
                if (AD_OP.GetDirectoryEntryByAccount(sAMAccountName,User,Password) != null)
                {
                    //1表示帐户存在
                    return 1;
                }
                else
                {
                    //0表示帐户不存在
                    return 0;
                }
            }
            catch (Exception ex)
            {    
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n判断用户是否存在时出错。\n\n" + ex.Message.ToString());
                //-1表示异常
                return -1;
            }
        }
        
        /// <summary>
        /// 创建用户
        /// </summary>
        /// <param name="displayName"></param>
        /// <param name="sAMAccountName"></param>
        /// <param name="Password"></param>
        /// <param name="Department"></param>
        /// <param name="EmployeeID"></param>
        /// <param name="SocialID"></param>
        /// <param name="Mail"></param>
        /// <param name="LoginUser"></param>
        /// <param name="LoginPassword"></param>
        /// <returns></returns>
        public static int CreateAccount(
            string displayName,//姓名
            string sAMAccountName,//帐号
            string Password,//密码
            string Department,//部门
            string EmployeeID,//员工编号
            string SocialID,//身份证号
            string Mail,//邮箱
            string company,//公司
            string LoginUser,//登录帐号
            string LoginPassword//登录密码
            )
        {
            try
            {
                //如果帐户不存在。
                if (IsAccExist(sAMAccountName, LoginUser, LoginPassword) == 0)
                {
                    DirectoryEntry user = null;
                    DirectoryEntry de = GetDirectoryObject(LoginUser, LoginPassword);
                    user = de.Children.Add("CN=" + sAMAccountName, "user");
                    user.Properties["userPrincipalName"].Value = sAMAccountName + DomainName;
                    user.Properties["sAMAccountName"].Add(sAMAccountName);
                    user.Properties["displayName"].Add(displayName);
                    user.Properties["department"].Add(Department);
                    user.Properties["wWWHomePage"].Add(EmployeeID);
                    user.Properties["pager"].Add(SocialID);
                    user.Properties["mail"].Add(Mail);
                    user.Properties["company"].Add(company);

                    user.CommitChanges();
                    user.Invoke("SetPassword", new object[] { Password });

                    //启用帐号。
                    user.Properties["userAccountControl"].Value = //0x200; //ADS_UF_NORMAL_ACCOUNT
                         ADS_USER_FLAG_ENUM.ADS_UF_NORMAL_ACCOUNT | ADS_USER_FLAG_ENUM.ADS_UF_DONT_EXPIRE_PASSWD;
                    user.CommitChanges();
                    
                    user.Dispose();
                    user.Close();
                    de.Dispose();
                    de.Close();

                    //写入日志
                    File_OP.WriteLog(sAMAccountName, displayName, Password, 0);
                    return 0;
                }
                //帐号存在。
                else if (IsAccExist(sAMAccountName, LoginUser, LoginPassword) == 1)
                {
                    File_OP.WriteLog(sAMAccountName, displayName, "缩写后帐号已存在", 1);
                    return 1;
                }
                //异常。
                else
                {
                    File_OP.WriteLog(sAMAccountName, displayName, "创建帐号异常", -1);
                    return -1;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("(╯‵□′)╯︵┻━┻\n\n创建用户操作时出错。\n\n" + ex.Message.ToString());
                File_OP.WriteLog(sAMAccountName, displayName, "创建帐号异常", -1);
                return -1;
            }
        }


        #endregion
    }
}
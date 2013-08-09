using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Linq;
using Microsoft.Win32;

namespace cai
{
    public delegate void ProcessControl(System.Windows.Forms.Control c);

    public class CommonHelper
    {
        public enum OfficeVersion
        {
            Office2003 = 3,
            Office2007 = 7,
            OfficeUnknown = -1//未知office
        }

        /// <summary>
        /// 获取一个样本空间中所有相同的集合
        /// </summary>
        /// <typeparam name="T">类型(重写了Equals方法)</typeparam>
        /// <param name="space">样本</param>
        /// <returns></returns>
        public static Dictionary<int, List<IDataType>> GetSameRecord(IDataType[] space, ICaiCompare compare)
        {
            //1 取和数合集的倒排表
            //2 插入的同时遍历表中的集合
            //3 找出同样的记录 入返回集合

            Dictionary<int, List<IDataType>> reviseTable = new Dictionary<int, List<IDataType>>();
            Dictionary<int, List<IDataType>> retDic = new Dictionary<int, List<IDataType>>();
            if (space.Length > 0)
            {
                foreach (IDataType t in space)
                {
                    if (reviseTable.ContainsKey(t.GetGetSumNo()))
                    {
                        foreach (IDataType inner in reviseTable[t.GetGetSumNo()])
                        {
                            if (compare.Compare(t, inner))
                            {
                                if (!retDic.ContainsKey(t.GetGetSumNo()))
                                    retDic[t.GetGetSumNo()] = new List<IDataType>();
                                retDic[t.GetGetSumNo()].Add(t);
                                if (!retDic[t.GetGetSumNo()].Contains(inner))
                                {
                                    retDic[t.GetGetSumNo()].Add(inner);

                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        reviseTable.Add(t.GetGetSumNo(), new List<IDataType>());
                    }

                    if (!reviseTable[t.GetGetSumNo()].Contains(t))
                        reviseTable[t.GetGetSumNo()].Add(t);
                }
            }
            return retDic;
        }
        public static string GetAssemblyPath()
        {
            string _CodeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
            _CodeBase = _CodeBase.Substring(8, _CodeBase.Length - 8);    // 8是 file:// 的长度
            string[] arrSection = _CodeBase.Split(new char[] { '/' });

            string _FolderPath = "";
            for (int i = 0; i < arrSection.Length - 1; i++)
            {
                _FolderPath += arrSection[i] + "/";
            }
            return _FolderPath;
        }

       


        public static void DeleteFolder(string path)
        {
            if (System.IO.Directory.Exists(path))
            {
                System.IO.Directory.Delete(path, true);
            }
        }

        public static void OpenInExplorer(string path)
        {
            if (!string.IsNullOrEmpty(path))
                System.Diagnostics.Process.Start(path);
        }
        /// <summary>
        /// 获取客户端Office版本
        /// </summary>
        /// <returns></returns>
        public static OfficeVersion GetOfficeVersion()
        {
            Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine;
            RegistryKey keyOffice03 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\11.0\\Word\\InstallRoot\\");
            RegistryKey keyOffice07 = rk.OpenSubKey(@"SOFTWARE\\Microsoft\\Office\\12.0\\Word\\InstallRoot\\");
            if (keyOffice07 != null)
            {
                string strFile07 = keyOffice07.GetValue("Path").ToString();
                if (File.Exists(Path.Combine(strFile07, "Excel.exe")))
                {
                    return OfficeVersion.Office2007;
                }
            }
            if (keyOffice03 != null)
            {
                string strFile03 = keyOffice03.GetValue("Path").ToString();
                if (File.Exists(Path.Combine(strFile03, "Excel.exe")))
                {
                    return OfficeVersion.Office2003;
                }
            }
            return OfficeVersion.OfficeUnknown;
        }

        #region Reflect
        //深度复制对象
        public static void CopyObject<T>(T original, T updated)
        {
            PropertyInfo[] ps = typeof(T).GetProperties();
            for (int j = 0; j < ps.Length - 1; j++)
            {
                ps[j].SetValue(original, ps[j].GetValue(updated, null), null);
            }
        }

        /// <summary>
        ///为类设置其Property的值
        /// </summary>
        /// <param name="o">对象实例</param>
        /// <param name="propertyName">Property名称</param>
        /// <param name="value">值</param>
        public static void SetPropertyValueByPropertyName(object o, string propertyName, object value)
        {
            PropertyInfo[] ps = o.GetType().GetProperties();
            foreach (PropertyInfo p in ps)
            {
                if (p.Name == propertyName)
                {
                    p.SetValue(o, value, null);
                }
            }
        }

        /// <summary>
        /// 为类设置字段的值
        /// </summary>
        /// <param name="o">类实例</param>
        /// <param name="fieldName">字段名</param>
        /// <returns></returns>
        public static object GetFieldValueByFieldName(object o, string fieldName)
        {
            FieldInfo f = o.GetType().GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            return f.GetValue(o);
        }

        //public static void CreateObject<T>(string filePath)
        //{
        //    foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
        //    {
        //        if (t.IsClass && t.GetInterface("IFunctionConponent", true) != null)
        //        {
        //            IFunctionConponent temp = (IFunctionConponent)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
        //            if (temp is IFunctionConponent)
        //                Add(temp);
        //        }

        //    }
        //}

        /// <summary>
        /// 加载DLL，并从中获取T类型的实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="path"></param>
        /// <param name="vt"></param>
        /// <returns></returns>
        public static T Get<T>(string path, string vt)
        {
            System.Reflection.Assembly ass = System.Reflection.Assembly.LoadFile(path);
            //string vt = "Laptop.Order.PDF.WABPdfProvider2";
            T r = default(T);
            Type tt = ass.GetType(vt);
            ConstructorInfo ci = tt.GetConstructor(System.Type.EmptyTypes);
            r = (T)ci.Invoke(null);
            return r;
        }

        /// <summary>
        /// 本地获取类型实例。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="vt">全名--Laptop.Order.PDF.WABPdfProvider2</param>
        /// <returns></returns>
        public static T Get<T>(string vt)
        {
            T r = default(T);
            Type tt = System.Reflection.Assembly.GetExecutingAssembly().GetType(vt);
            ConstructorInfo ci = tt.GetConstructor(System.Type.EmptyTypes);
            r = (T)ci.Invoke(null);
            return r;
        }

        /// <summary>
        /// 获取基类的类名的实例集合
        /// </summary>
        /// <typeparam name="T">返回实例的类型</typeparam>
        /// <param name="BaseTypeName">基类类名如Form</param>
        /// <returns></returns>
        public static T[] GenTypesObjectFromAssembly<T>(string BaseTypeName)
        {
            List<T> list = new List<T>();
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsClass && t.BaseType.Name == BaseTypeName)
                {
                    T temp = (T)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
                    if (temp != null)
                        list.Add(temp);
                }
            }
            return list.ToArray();
        }

        /// <summary>
        /// 获取接口的实例集合。
        /// </summary>
        /// <typeparam name="T">返回实例类型</typeparam>
        /// <param name="interFaceName">接口名</param>
        /// <returns></returns>
        public static T[] GetInterfaceObjectFromAssembly<T>(string interFaceName)
        {
            List<T> list = new List<T>();

            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.IsClass && t.GetInterface(interFaceName, true) != null)
                {
                    T temp = (T)t.InvokeMember(string.Empty, BindingFlags.CreateInstance, null, null, null);
                    if (temp != null)
                        list.Add(temp);
                }
            }
            return list.ToArray();
        }
        #endregion



     

        public static void GetYapsFromRootDirectory(List<string> YapList, string rootDirectory)
        {
            if (!string.IsNullOrEmpty(rootDirectory))
            {
                if (System.IO.Directory.Exists(rootDirectory))
                {
                    List<string> temp = GetYapsFromDirectory(rootDirectory);
                    if (temp != null && temp.Count > 0)
                        YapList.AddRange(temp);
                }
                string[] _subDirectorys = System.IO.Directory.GetDirectories(rootDirectory);
                if (_subDirectorys != null && _subDirectorys.Length > 0)
                {
                    foreach (string subDire in _subDirectorys)
                    {
                        GetYapsFromRootDirectory(YapList, subDire);
                    }
                }
            }
        }

        public static List<string> GetYapsFromDirectory(string directory)
        {
            if (!string.IsNullOrEmpty(directory))
            {
                if (System.IO.Directory.Exists(directory))
                {
                    string[] fileNames = System.IO.Directory.GetFiles(directory);
                    if (fileNames != null && fileNames.Length > 0)
                    {
                        List<string> retList = new List<string>();
                        foreach (string filePath in fileNames)
                        {
                            if (System.IO.Path.GetExtension(filePath).Trim().ToLower().Equals(".yap"))
                            {
                                retList.Add(filePath);
                            }
                        }
                        return retList;
                    }
                }
            }
            return null;
        }

        [DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(
        ref   int dwFlag,
        int dwReserved
        );
        public static bool IsInterNetConnected()
        {
            System.Int32 dwFlag = new int();
            return InternetGetConnectedState(ref   dwFlag, 0);
            //MessageBox.Show("未连网!");   
            //else   
            //if((dwFlag   &   INTERNET_CONNECTION_MODEM)!=0)   
            //MessageBox.Show("采用调治解调器上网。");   
            //else   
            //if((dwFlag   &   INTERNET_CONNECTION_LAN)!=0)   
            //MessageBox.Show("采用网卡上网。");   
        }
    }
}

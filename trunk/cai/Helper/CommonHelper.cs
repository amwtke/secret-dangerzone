using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using System.Reflection;
using System.Runtime.Remoting.Messaging;

namespace cai
{
    public enum ContainType
    {
        EndsWithCaseSensitive,
        EndsWith,
        Greater,
        Like,
        Not,
        Or,
        Smaller,
        StartsWithCaseSensitive,
        StartsWith,
        Identity,

    }
    public enum JoinType
    {
        And,
        Or
    }
    class CommonHelper
    {

        public static void ProcessText(string filename,IProcessText processor)
        {
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            try
            {
                sr.BaseStream.Seek(0, SeekOrigin.Begin);//从开始读取
                string str = sr.ReadLine();
                while (str != null)
                {
                    str = sr.ReadLine();
                    processor.datahandler(str);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sr.Close();
                fs.Close();
            }
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

        #region DB4O
        public static IConstraint ConstrainByType(IQuery query, Type t)
        {
            if (query != null)
                return query.Constrain(t);
            else
                throw new Exception("Query is null in ConstrainByType!");
        }

        public static IQuery Descend(IQuery query, string fieldName)
        {
            if (query != null)
            {
                return query.Descend(fieldName);
            }
            return null;
        }
        public static IConstraint Contain(IQuery query, string containString)
        {
            if (query != null)
            {
                return query.Constrain(containString).Contains();
            }
            throw new Exception("Query is null in Contain!");
        }

        public static IObjectSet GetResultLike(IQuery q, Type T, string filedName, string sreachWord)
        {
            CommonHelper.ConstrainByType(q, T);
            IQuery temp = CommonHelper.Descend(q, filedName);
            IConstraint _iconstrain = CommonHelper.Contain(temp, sreachWord);

            return q.Execute();
        }

        public static IQuery GetQuery(IObjectContainer db, Type T, string fieldName, string keyWord)
        {
            IQuery q = db.Query();
            q.Constrain(T);
            IQuery temp = q.Descend(fieldName);
            temp.Constrain(keyWord).Like();
            return q;
        }

        public static IConstraint GetConstrain(IObjectContainer db, Type T, string fieldName, string keyWord)
        {
            IQuery q = db.Query();
            q.Constrain(T);
            return q.Descend(fieldName).Constrain(keyWord).Like();
        }

        /// <summary>
        /// 初始化DB引擎
        /// </summary>
        /// <param name="fileName">默认在应用程序启动目录,只用写文件名</param>
        /// <returns></returns>
        public static IObjectContainer InitDB4O(string fileName,Type t)
        {
            IObjectContainer _db;
            try
            {
                IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                string YapFileName = System.IO.Path.Combine(CommonHelper.GetAssemblyPath() , fileName);
                config.Common.ObjectClass(t).CascadeOnUpdate(true);
                _db = Db4oEmbedded.OpenFile(config, YapFileName);
            }
            catch (Exception ex)
            { 
                throw ex; 
            }
            return _db;
        }

        public static void DeleteDBFile(string fileName)
        {
            string YapFileName = System.IO.Path.Combine(CommonHelper.GetAssemblyPath() , fileName);
            File.Delete(YapFileName);
        }

        public static bool SaveToDB(IObjectContainer db, object o)
        {
            try
            {
                if (db != null)
                {
                    db.Store(o);
                    db.Commit();
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static object GetQueryByExample(IObjectContainer db,object o)
        {
            if (o != null)
            {
                try
                {
                    return db.QueryByExample(o);
                }
                catch (System.Exception ex)
                {
                	throw ex;
                }
            }
            return null;
        }

        public static bool DeleteFromDB<T>(IObjectContainer db, object o)
        {
            try
            {
                object temp;
                IObjectSet result = db.QueryByExample(o);
                temp = (T)result[0];
                if (temp != null)
                {
                    db.Delete(temp);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool UpdateFromDB<T>(IObjectContainer db, object originalObject,object updatedObject)
        {
            try
            {
                object temp;
                IObjectSet result = db.QueryByExample(originalObject);
                temp = (T)result[0];
                CopyObject<T>((T)temp, (T)updatedObject);
                if (temp != null)
                {
                    db.Store(temp);
                    db.Commit();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IConstraint GetConstraintByType(IQuery query,string key,ContainType type)
        {
            if (type == ContainType.EndsWith) { return query.Constrain(key).EndsWith(false); }
            if (type == ContainType.EndsWithCaseSensitive) { return query.Constrain(key).EndsWith(true); }
            if (type == ContainType.StartsWith) { return query.Constrain(key).StartsWith(false); }
            if (type == ContainType.EndsWithCaseSensitive) { return query.Constrain(key).EndsWith(true); }
            if (type == ContainType.Like) { return query.Constrain(key).Like(); }
            if (type == ContainType.Greater) { return query.Constrain(key).Greater(); }
            if (type == ContainType.Smaller) { return query.Constrain(key).Smaller(); }
            if (type == ContainType.Identity) { return query.Constrain(key).Identity(); }
            throw new NotSupportedException();
        }
        public static IConstraint GetJointByType(IConstraint own, IConstraint with, JoinType type)
        {
            if (type == JoinType.And)
                return own.And(with);
            if (type == JoinType.Or)
                return own.Or(with);
            throw new NotSupportedException();
        }
        /// <summary>
        /// 查询函数(AND)与操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="paras">为两个参数一组，第一个为字段名，第二个为搜索Key值</param>
        /// <returns></returns>
        public static T[] Find<T>(IObjectContainer db,JoinType joinType,ContainType constrainType,params Dictionary<string, string>[] paras)
        {
            //IQuery q = db.Query();
            //q.Constrain(T);
            try
            {
                IQuery retQuery = db.Query();
                retQuery.Constrain(typeof(T));
                if (paras.Length > 0)
                {
                    foreach (Dictionary<string, string> dic in paras)
                    {
                        foreach (KeyValuePair<string, string> pair in dic)
                        {
                            IQuery temp = retQuery.Descend(pair.Key);

                            IConstraint constrain = GetConstraintByType(temp,pair.Value,constrainType);
                            GetJointByType(retQuery.Constraints(), constrain, joinType);
                        }
                    }
                }
                retQuery.SortBy(new DoubleBallCompareImp());
                IObjectSet result = retQuery.Execute();
                T[] retArray = new T[result.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    retArray[i] = (T)result[i];
                }
                return retArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static T[] Find<T>(IObjectContainer db, string fileName)
        {
            //IQuery q = db.Query();
            //q.Constrain(T);
            try
            {
                IQuery retQuery = db.Query();
                retQuery.Constrain(typeof(T));
                retQuery.Descend(fileName);
                retQuery.SortBy(new DoubleBallCompareImp());
                IObjectSet result = retQuery.Execute();
                T[] retArray = new T[result.Count];
                for (int i = 0; i < result.Count; i++)
                {
                    retArray[i] = (T)result[i];
                }
                return retArray;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Reflect
        //复制对象
        public static void CopyObject<T>(T original, T updated)
        {
            PropertyInfo[] ps = typeof(T).GetProperties();
            for (int j = 0; j < ps.Length - 1; j++)
            {
                ps[j].SetValue(original, ps[j].GetValue(updated,null), null);
            }
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
        /// 
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
        #endregion

        #region Business
        /// <summary>
        /// 获取一个样本空间中所有相同的集合
        /// </summary>
        /// <typeparam name="T">类型(重写了Equals方法)</typeparam>
        /// <param name="space">样本</param>
        /// <returns></returns>
        public static Dictionary<int, List<IDataType>> GetSameRecord(IDataType[] space,ICaiCompare compare)
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
                            if (compare.Compare(t,inner))
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
        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using Db4objects.Db4o.Query;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Windows.Forms;

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
        Equal
    }
    public enum JoinType
    {
        And,
        Or
    }
    class DBHelper
    {
        static log4net.ILog LOGGER = null;
        static DBHelper()
        {
            if (LOGGER == null)
            {
                LOGGER = log4net.LogManager.GetLogger(typeof(DBHelper));
            }
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
            DBHelper.ConstrainByType(q, T);
            IQuery temp = DBHelper.Descend(q, filedName);
            IConstraint _iconstrain = DBHelper.Contain(temp, sreachWord);

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


        static Dictionary<string, IObjectContainer> _dicIobject = new Dictionary<string, IObjectContainer>();
        /// <summary>
        /// 对于打了DB4OClassAttribute标签的对象Only。不适用与Tree对象。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static IObjectContainer InitDB4O(Type t)
        {
            IObjectContainer _db = null;
            DB4OClassAttribute[] atts = GetDB4OClassAttribute(t);
            if (atts != null && atts.Length > 0)
            {
                try
                {
                    IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                    string YapFileName = System.IO.Path.Combine(CommonHelper.GetAssemblyPath(), atts[0].DBName);
                    if (_dicIobject.ContainsKey(YapFileName))
                    {
                        return _dicIobject[YapFileName];
                    }
                    config.Common.ObjectClass(t).CascadeOnActivate(true);
                    config.Common.ObjectClass(t).CascadeOnDelete(true);
                    config.Common.ObjectClass(t).CascadeOnUpdate(true);
                    config.Common.ActivationDepth = 20;
                    _db = Db4oEmbedded.OpenFile(config, YapFileName);
                    _dicIobject[YapFileName] = _db;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return _db;
            }

            return _db;
        }

        /// <summary>
        /// 初始化DB引擎
        /// </summary>
        /// <param name="fileName">默认在应用程序启动目录,只用写文件名</param>
        /// <returns></returns>
        public static IObjectContainer InitDB4O(string fileName, Type t)
        {
            IObjectContainer _db;
            try
            {
                IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
                string YapFileName = System.IO.Path.Combine(CommonHelper.GetAssemblyPath(), fileName);
                config.Common.ObjectClass(t).CascadeOnActivate(true);
                config.Common.ObjectClass(t).CascadeOnDelete(true);
                config.Common.ObjectClass(t).CascadeOnUpdate(true);
                config.Common.ActivationDepth = 20;
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
            string YapFileName = System.IO.Path.Combine(CommonHelper.GetAssemblyPath(), fileName);
            File.Delete(YapFileName);
        }

        /// <summary>
        /// 如果Unique为True，则会按照对象的Key来获取约束
        /// </summary>
        /// <param name="db"></param>
        /// <param name="o"></param>
        /// <param name="Unique"></param>
        /// <returns></returns>
        public static bool SaveToDB(IObjectContainer db, object o, bool Unique)
        {
            try
            {
                if (db != null)
                {
                    if (!Unique)
                    {
                        db.Store(o);
                        db.Commit();
                        return true;
                    }
                    else
                    {
                        if (!IsDuplicatedByKey(db, o))
                        {
                            db.Store(o);
                            db.Commit();
                            return true;
                        }
                        return false;
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 判断是否有重复Key的Object
        /// </summary>
        /// <param name="db"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        static bool IsDuplicatedByKey(IObjectContainer db, object o)
        {
            if (IsKeysHaveValue(o.GetType(), o))
            {
                KeyAttribute[] keyAtts = GetKeyAttribute(o.GetType()).ToArray();
                Dictionary<string, string> searchDic = new Dictionary<string, string>();
                if (keyAtts != null && keyAtts.Length > 0)
                {
                    foreach (KeyAttribute k in keyAtts)
                    {
                        searchDic.Add(k.KeyName, CommonHelper.GetFieldValueByFieldName(o, k.KeyName).ToString());
                    }
                }

                IObjectSet _olds = DBHelper.Find(db, o.GetType(), JoinType.And, ContainType.Equal, searchDic);
                if (_olds.Count > 0) return true;
                return false;
            }
            else
            {
                LOGGER.Error("请对key属性标记字段赋值！");
                return false;
            }
        }

        /// <summary>
        /// 返回查询字典！
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetKeySeachDictionary(object o)
        {
            if (IsKeysHaveValue(o.GetType(), o))
            {
                KeyAttribute[] keyAtts = GetKeyAttribute(o.GetType()).ToArray();
                Dictionary<string, string> searchDic = new Dictionary<string, string>();
                if (keyAtts != null && keyAtts.Length > 0)
                {
                    foreach (KeyAttribute k in keyAtts)
                    {
                        searchDic.Add(k.KeyName, CommonHelper.GetFieldValueByFieldName(o, k.KeyName).ToString());
                    }
                }
                return searchDic;
            }
            return null;
        }
        /// <summary>
        /// 按照key值删除库中重复的对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="o"></param>
        static void RemoveDuplicateByKey(IObjectContainer db, object o)
        {
            if (IsKeysHaveValue(o.GetType(), o))
            {
                KeyAttribute[] keyAtts = GetKeyAttribute(o.GetType()).ToArray();
                Dictionary<string, string> searchDic = new Dictionary<string, string>();
                if (keyAtts != null && keyAtts.Length > 0)
                {
                    foreach (KeyAttribute k in keyAtts)
                    {
                        searchDic.Add(k.KeyName, CommonHelper.GetFieldValueByFieldName(o, k.KeyName).ToString());
                    }
                }

                IObjectSet _olds = DBHelper.Find(db, o.GetType(), JoinType.And, ContainType.Equal, searchDic);

                while (_olds.HasNext())
                {
                    db.Delete(_olds.Next());
                }
            }
            else
                LOGGER.Error("请对key属性标记字段赋值！删除失败！");
        }

        /// <summary>
        /// 清楚Key值相等的对象
        /// </summary>
        /// <param name="db"></param>
        /// <param name="o"></param>
        public static void DeleteFromDB(IObjectContainer db, object o)
        {
            try
            {
                RemoveDuplicateByKey(db, o);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update by Key。如果查出记录则更新，如果没有则不更新。
        /// </summary>
        /// <param name="db"></param>
        /// <param name="udpateObject"></param>
        public static void UpdateFromDB(IObjectContainer db, object udpateObject)
        {
            try
            {
                if (IsDuplicatedByKey(db, udpateObject))
                {
                    RemoveDuplicateByKey(db, udpateObject);
                    db.Store(udpateObject);
                    db.Commit();
                }
                else
                    throw new Exception("没找到Key值对应的对象！无法更新！");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IConstraint GetConstraintByType2(IQuery query, object key, ContainType type)
        {
            if (type == ContainType.EndsWith) { return query.Constrain(key).EndsWith(false); }
            if (type == ContainType.EndsWithCaseSensitive) { return query.Constrain(key).EndsWith(true); }
            if (type == ContainType.StartsWith) { return query.Constrain(key).StartsWith(false); }
            if (type == ContainType.EndsWithCaseSensitive) { return query.Constrain(key).EndsWith(true); }
            if (type == ContainType.Like) { return query.Constrain(key).Like(); }
            if (type == ContainType.Greater) { return query.Constrain(key).Greater(); }
            if (type == ContainType.Smaller) { return query.Constrain(key).Smaller(); }
            if (type == ContainType.Identity) { return query.Constrain(key).Identity(); }
            if (type == ContainType.Equal) { return query.Constrain(key).Equal(); }
            throw new NotSupportedException();
        }

        public static IConstraint GetConstraintByType(IQuery query, string key, ContainType type)
        {
            if (type == ContainType.EndsWith) { return query.Constrain(key).EndsWith(false); }
            if (type == ContainType.EndsWithCaseSensitive) { return query.Constrain(key).EndsWith(true); }
            if (type == ContainType.StartsWith) { return query.Constrain(key).StartsWith(false); }
            if (type == ContainType.EndsWithCaseSensitive) { return query.Constrain(key).EndsWith(true); }
            if (type == ContainType.Like) { return query.Constrain(key).Like(); }
            if (type == ContainType.Greater) { return query.Constrain(key).Greater(); }
            if (type == ContainType.Smaller) { return query.Constrain(key).Smaller(); }
            if (type == ContainType.Identity) { return query.Constrain(key).Identity(); }
            if (type == ContainType.Equal) { return query.Constrain(key).Equal(); }
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

        public static IObjectSet Find(IObjectContainer db, Type t, JoinType joinType, ContainType constrainType, params Dictionary<string, string>[] paras)
        {
            try
            {
                IQuery retQuery = db.Query();
                retQuery.Constrain(t);
                if (paras.Length > 0)
                {
                    foreach (Dictionary<string, string> dic in paras)
                    {
                        foreach (KeyValuePair<string, string> pair in dic)
                        {
                            IQuery temp = retQuery.Descend(pair.Key);

                            IConstraint constrain = GetConstraintByType(temp, pair.Value, constrainType);
                            //if (paras.Length > 1 && dic.Keys.Count > 1)
                            GetJointByType(retQuery.Constraints(), constrain, joinType);
                        }
                    }
                }


                IObjectSet result = retQuery.Execute();
                //object[] retObject = null;
                //if (result != null && result.Count>0)
                //{
                //    retObject = new object[result.Count];
                //    int i = 0;
                //    while (result.HasNext())
                //    {
                //        retObject[i] = result.Next();
                //        i++;
                //    }
                //}
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 查询函数(AND)与操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="paras">为两个参数一组，第一个为字段名，第二个为搜索Key值</param>
        /// <returns></returns>
        public static T[] Find<T>(IObjectContainer db, JoinType joinType, ContainType constrainType, params Dictionary<string, string>[] paras)
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

                            IConstraint constrain = GetConstraintByType(temp, pair.Value, constrainType);
                            GetJointByType(retQuery.Constraints(), constrain, joinType);
                        }
                    }
                }
                //retQuery.SortBy(new DoubleBallCompareImp());
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

        /// <summary>
        /// 查询函数(AND)与操作
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="db"></param>
        /// <param name="paras">为两个参数一组，第一个为字段名，第二个为搜索Key值</param>
        /// <returns></returns>
        public static T[] Find<T>(IObjectContainer db, JoinType joinType, ContainType constrainType, IDB4OCompare dbCompareImp, params Dictionary<string, string>[] paras)
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

                            IConstraint constrain = GetConstraintByType(temp, pair.Value, constrainType);
                            GetJointByType(retQuery.Constraints(), constrain, joinType);
                        }
                    }
                }
                retQuery.SortBy(dbCompareImp);
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

        public static T[] FindByExample<T>(IObjectContainer db, object example)
        {
            IObjectSet set = null;
            if (example != null)
            {
                if (IsKeysHaveValue(example.GetType(), example))
                {
                    KeyAttribute[] keyAtts = GetKeyAttribute(example.GetType()).ToArray();
                    Dictionary<string, string> searchDic = new Dictionary<string, string>();
                    if (keyAtts != null && keyAtts.Length > 0)
                    {
                        foreach (KeyAttribute k in keyAtts)
                        {
                            searchDic.Add(k.KeyName, CommonHelper.GetFieldValueByFieldName(example, k.KeyName).ToString());
                        }
                    }
                    set = DBHelper.Find(db, example.GetType(), JoinType.And, ContainType.Equal, searchDic);
                }
                else//无key
                {
                    set = db.QueryByExample(example);
                }

                T[] retSet = null;
                if (set != null && set.Count > 0)
                {
                    retSet = new T[set.Count];
                    for (int i = 0; i < set.Count; i++)
                    {
                        retSet[i] = (T)set[i];
                    }
                }
                return retSet;
            }
            return null;
        }

        public static T[] GetALL<T>(IObjectContainer db, string fieldName)
        {
            //IQuery q = db.Query();
            //q.Constrain(T);
            try
            {
                IQuery retQuery = db.Query();
                retQuery.Constrain(typeof(T));
                retQuery.Descend(fieldName);
                //retQuery.SortBy(new DoubleBallCompareImp());
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

        public static T GetObjectFromString<T>(string clazz)
        {
            Type t = Assembly.GetExecutingAssembly().GetType(clazz);
            return (T)Activator.CreateInstance(t, true);
        }



        public static TreeInforAttribute[] GetTreeInfoAttribute(Type t)
        {
            TreeInforAttribute[] atts = (TreeInforAttribute[])Attribute.GetCustomAttributes(t, typeof(TreeInforAttribute));
            return atts;
        }

        public static DB4OClassAttribute[] GetDB4OClassAttribute(Type t)
        {
            DB4OClassAttribute[] atts = (DB4OClassAttribute[])Attribute.GetCustomAttributes(t, typeof(DB4OClassAttribute));
            return atts;
        }
        /// <summary>
        /// 获取类型t中被标记Key属性实例。
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static List<KeyAttribute> GetKeyAttribute(Type t)
        {
            FieldInfo[] fis = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly);//"_rootName");

            List<KeyAttribute> retList = new List<KeyAttribute>();
            foreach (FieldInfo p in fis)
            {
                KeyAttribute[] atts = (KeyAttribute[])Attribute.GetCustomAttributes(p, typeof(KeyAttribute));
                if (atts != null && atts.Length > 0)
                {
                    foreach (KeyAttribute a in atts)
                    {
                        retList.Add(a);
                    }
                }
            }
            return retList;
        }

        /// <summary>
        /// 目标对象中是否所有标记为Key属性的字段都完成赋值。
        /// 没有Key属性标记返回false。
        /// </summary>
        /// <param name="t"></param>
        /// <param name="o"></param>
        /// <returns></returns>
        public static bool IsKeysHaveValue(Type t, object o)
        {
            List<KeyAttribute> _keys = GetKeyAttribute(t);
            if (_keys == null || _keys.Count == 0)
                return false;
            else
            {
                foreach (KeyAttribute k in _keys)
                {
                    object keyValue = CommonHelper.GetFieldValueByFieldName(o, k.KeyName);
                    if (keyValue == null || string.IsNullOrEmpty(keyValue.ToString())) return false;
                }
                return true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Kev.Dao
{
    public class KevProvider<T>
    {
        public bool Insert(T t)
        {
            if (t == null)
                return false;

            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            List<string> fields = new List<string>();
            List<object> values = new List<object>();

            PropertyInfo[] propertyInfos = t.GetType().GetProperties();
            foreach (PropertyInfo item in propertyInfos)
            {
                if (modelAttribute.AutoPrimaryKey && modelAttribute.PrimaryKey == item.Name)
                    continue;

                fields.Add(GetTPropertyName(item.Name));
                values.Add(GetTPropertyValue(t, item.Name));
            }


            string sql_inert = string.Format("INSERT INTO {0}({1}) VALUES({2})", modelAttribute.TableName, string.Join(",", fields), string.Join(",", values));

            int cout = 0;

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_inert;
                cout = command.ExecuteNonQuery();

                conn.Close();
            }

            return cout > 0;
        }

        public bool Delete(object primaryKey)
        {
            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            string sql_delete = string.Format("DELETE FROM {0} WHERE {1} = {2}", modelAttribute.TableName, GetTPropertyName(modelAttribute.PrimaryKey), primaryKey);

            int count = 0;

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_delete;
                count = command.ExecuteNonQuery();

                conn.Close();
            }

            return count > 0;
        }

        public bool Update(T t)
        {
            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            List<string> keyValues = new List<string>();

            PropertyInfo[] propertyInfos = typeof(T).GetProperties();
            foreach (PropertyInfo item in propertyInfos)
            {
                if (item.Name == modelAttribute.PrimaryKey)
                    continue;

                string name = GetTPropertyName(item.Name);
                string value = GetTPropertyValue(t, item.Name);
                keyValues.Add(name + " = " + value);

            }

            string sql_update = string.Format("UPDATE {0} SET {1} WHERE {2} = {3}", modelAttribute.TableName, string.Join(",", keyValues), modelAttribute.PrimaryKey, typeof(T).GetProperty(modelAttribute.PrimaryKey).GetValue(t));

            int count = 0;

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_update;
                count = command.ExecuteNonQuery();

                conn.Close();
            }

            return count > 0;
        }

        public T Get(object primaryKey)
        {
            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            T t = (T)Activator.CreateInstance(typeof(T));

            string sql_get = string.Format("SELECT * FROM {0} WHERE {1} = {2}", modelAttribute.TableName, GetTPropertyName(modelAttribute.PrimaryKey), primaryKey);

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_get;
                SqlDataReader myReader = command.ExecuteReader();
                if (myReader.Read())
                {
                    PropertyInfo[] propertyInfos = typeof(T).GetProperties();
                    foreach (PropertyInfo item in propertyInfos)
                    {
                        string name = GetTPropertyName(item.Name);
                        object value = myReader[name];

                        item.SetValue(t, value);
                    }
                }

                conn.Close();
            }

            return t;
        }

        public IEnumerable<object> GetPageList(int pageSize, int pageIndex)
        {
            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            string sql_pageList = string.Format("SELECT TOP {2} B.{1} FROM (SELECT TOP {3} {1} FROM {0} ORDER BY {1} DESC) A,{0} B WHERE B.{1} = A.{1} ORDER BY A.{1}", modelAttribute.TableName, GetTPropertyName(modelAttribute.PrimaryKey), pageSize, pageSize * pageIndex);

            List<object> ids = new List<object>();

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_pageList;
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ids.Add(dr[0]);
                }

                conn.Close();
            }

            return ids;
        }

        public IEnumerable<object> GetAll()
        {
            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            string sql_pageList = string.Format("SELECT {0} FROM {1} ORDER BY {2}", GetTPropertyName(modelAttribute.PrimaryKey), modelAttribute.TableName, GetTPropertyName(modelAttribute.PrimaryKey));

            List<object> ids = new List<object>();

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_pageList;
                SqlDataReader dr = command.ExecuteReader();
                while (dr.Read())
                {
                    ids.Add(dr[0]);
                }

                conn.Close();
            }

            return ids;
        }

        public IEnumerable<T> FillItemByIds(IEnumerable<object> primaryKeies)
        {
            KevModelAttribute modelAttribute = (KevModelAttribute)Attribute.GetCustomAttribute(typeof(T), typeof(KevModelAttribute));

            if (modelAttribute == null)
            {
                throw new Exception(typeof(T).Name + " Not Use KevModelAttribute");
            }

            List<string> items = new List<string>();
            foreach (object item in primaryKeies)
            {
                items.Add(GetSqlValue(item));
            }

            string sql_gets = string.Format("SELECT * FROM {0} WHERE {1} IN ({2})", modelAttribute.TableName, GetTPropertyName(modelAttribute.PrimaryKey), string.Join(",", items));

            List<T> items_obj = new List<T>();

            using (SqlConnection conn = new SqlConnection(GetSqlConnString()))
            {
                conn.Open();

                SqlCommand command = conn.CreateCommand();
                command.CommandText = sql_gets;
                SqlDataReader dr = command.ExecuteReader();

                while (dr.Read())
                {
                    T t = (T)Activator.CreateInstance(typeof(T));

                    PropertyInfo[] propertyInfos = typeof(T).GetProperties();
                    foreach (PropertyInfo item in propertyInfos)
                    {
                        string name = GetTPropertyName(item.Name);
                        object value = dr[name];

                        item.SetValue(t, value);
                    }

                    items_obj.Add(t);
                }

                conn.Close();
            }

            return items_obj;
        }

        #region Pirate Item Action

        protected string GetTPropertyName(string propertyName)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            if (property == null)
                return null;

            string name = null;

            KevDataMemberAttribute memberAttribute = (KevDataMemberAttribute)Attribute.GetCustomAttribute(property, typeof(KevDataMemberAttribute));
            if (memberAttribute == null)
            {
                name = property.Name;
            }
            else
            {
                name = memberAttribute.TableFieldName;
            }
            return name;
        }

        protected string GetTPropertyValue(T t, string propertyName)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);
            if (property == null)
                return null;

            string value = null;

            object obj = property.GetValue(t);
            value = GetSqlValue(obj);

            return value;
        }

        protected string GetSqlValue(object obj)
        {
            string value = null;

            if (obj == null)
            {
                value = "NULL";
            }
            else if (obj is string || obj is DateTime)
            {
                value = "'" + obj + "'";
            }
            else
            {
                value = obj.ToString();
            }

            return value;
        }

        protected string GetSqlConnString()
        {
            return ConfigurationManager.AppSettings["SqlConnStr"];
        }
        #endregion
    }
}

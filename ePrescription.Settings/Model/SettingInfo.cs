
using ePrescription.Data;
using System;
using System.Data;
using System.Data.Common;

namespace ePrescription.Settings.Model
{
    public class SettingInfo
    {
        #region members
        private Guid id;
        private CSharpTypes type;
        private string code;
        private string valueString;
        private byte[] valueBinary;
        #endregion members

        #region properties
        public Guid Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
        public CSharpTypes Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
        public string Code
        {
            get { return this.code; }
            set { this.code = value; }
        }
        public string ValueString
        {
            get { return this.valueString; }
            set { this.valueString = value; }
        }
        public byte[] ValueBinary
        {
            get { return this.valueBinary; }
            set { this.valueBinary = value; }
        }
        #endregion properties

        #region ctors
        public SettingInfo()
        {
        }
        public SettingInfo(Guid id, CSharpTypes type, string code, string valueString, byte[] valueBinary)
        {
            this.id = id;
            this.type = type;
            this.code = code;
            this.valueString = valueString;
            this.valueBinary = valueBinary;
        }
        #endregion ctors

        #region static methods
        /// <summary>
        /// I will use simple model for dealing with backend database
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static SettingInfo LoadSetting(string code)
        {
            TransactionManager trans = DataRepository.Provider.CreateTransaction();
            try
            {
                trans.BeginTransaction();
                string CommandText =
                                        @"IF OBJECT_ID('[dbo].[tblSettings]','U') IS NULL
                                        CREATE TABLE [dbo].[tblSettings](
                                        [ID] [uniqueidentifier] NOT NULL CONSTRAINT [DF_tblSettings_id]  DEFAULT (newid()),
                                        [Type] [tinyint] NOT NULL,
                                        [Code] [nvarchar](50) COLLATE Cyrillic_General_CI_AS NOT NULL,
                                        [ValueString] [ntext] COLLATE Cyrillic_General_CI_AS NULL,
                                        [ValueBinary] [varbinary](5000) NULL,
                                        CONSTRAINT [PK_tblSettings] PRIMARY KEY CLUSTERED 
                                        (
                                        [ID] ASC
                                        ) ON [PRIMARY]
                                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                    ";
                DbCommand command = trans.Database.GetSqlStringCommand(CommandText);

                DataRepository.Provider.ExecuteNonQuery(command);
                command.CommandText = "SELECT ID, Type, Code, ValueString, ValueBinary FROM tblSettings WHERE Code = @Code";
                DbParameter param = command.CreateParameter();
                param.DbType = System.Data.DbType.String;
                param.ParameterName = "Code";
                param.Value = code;
                command.Parameters.Add(param);

                using (IDataReader reader = DataRepository.Provider.ExecuteReader(command))
                {
                    if (reader.Read())
                    {
                        return new SettingInfo(
                                reader.GetGuid(0),
                                (CSharpTypes)reader.GetByte(1),
                                reader.GetString(2),
                                reader.IsDBNull(3) ? String.Empty : reader.GetString(3),
                                reader.IsDBNull(4) ? null : (byte[])reader["ValueBinary"]
                            );
                    }
                }
                trans.Commit();
            }
            catch (Exception)
            {
                trans.Rollback();
            } return null;
        }
        /// <summary>
        /// I will use simple model for dealing with backend database
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static void SaveSetting(SettingInfo setting)
        {
            //using (DbConnection connection = new SqlConnection(CustomSettings.Current.ConnectionString))
            //NetTiersServiceSection section = (NetTiersServiceSection)WebConfigurationManager.GetSection("DirectBilling.Data");
            //string Connectionstringname = section.Providers["SqlNetTiersProvider"].Parameters["connectionStringName"];
            //string Connectionstringname = DataRepository.Configuration.ConnectionStrings.ConnectionStrings["SqlNetTiersProvider"].ConnectionString;
            //using (DbConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings[Connectionstringname].ConnectionString))
            TransactionManager trans = DataRepository.Provider.CreateTransaction();
            try
            {
                trans.BeginTransaction();
                string CommandText = "";
                if (setting.id == Guid.Empty)
                {
                    setting.Id = Guid.NewGuid();

                    CommandText =
                                        @"INSERT INTO tblSettings (Id, Type, Code, ValueString, ValueBinary)
                                        VALUES (@ID, @Type, @Code, @ValueString, @ValueBinary)";
                }
                else
                {
                    CommandText =
                                        @"UPDATE tblSettings 
                                        SET Type = @Type, Code = @Code, ValueString = @ValueString, ValueBinary = @ValueBinary
                                        WHERE ID = @ID";
                }

                DbCommand command = trans.Database.GetSqlStringCommand(CommandText);

                #region params

                DbParameter param = command.CreateParameter();
                param.DbType = System.Data.DbType.Guid;
                param.ParameterName = "ID";
                param.Value = setting.Id;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = System.Data.DbType.Byte;
                param.ParameterName = "Type";
                param.Value = (byte)setting.Type;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = System.Data.DbType.String;
                param.ParameterName = "Code";
                param.Value = setting.Code;
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = System.Data.DbType.String;
                param.ParameterName = "ValueString";
                if (String.IsNullOrEmpty(setting.ValueString))
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = setting.ValueString;
                }
                command.Parameters.Add(param);

                param = command.CreateParameter();
                param.DbType = System.Data.DbType.Binary;
                param.ParameterName = "ValueBinary";
                if (setting.ValueBinary == null)
                {
                    param.Value = DBNull.Value;
                }
                else
                {
                    param.Value = setting.ValueBinary;
                }
                command.Parameters.Add(param);

                #endregion params

                DataRepository.Provider.ExecuteNonQuery(command);
                trans.Commit();
            }
            finally
            {
                if (trans != null && trans.IsOpen)
                    trans.Rollback();
            }
        }
        #endregion static methods
    }
}
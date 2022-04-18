using DynamicSurvey.Helpers;
using DynamicSurvey.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DynamicSurvey.Managers
{
    public class SurveyManager
    {
        public List<ReadSurveyModel> GetSurveyList(string keyword)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM Survey ";

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                commandText += " WHERE Account LIKE '%'+@keyword+'%'";
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        if (!string.IsNullOrWhiteSpace(keyword))
                        {
                            command.Parameters.AddWithValue("@keyword", keyword);
                        }

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        List<ReadSurveyModel> list = new List<ReadSurveyModel>();

                        while (reader.Read())
                        {
                            ReadSurveyModel readSurveyModel = new ReadSurveyModel()
                            {
                                QuestionID = (Guid)reader["QuestionID"],
                                StartDate=(DateTime)reader["StartDate"],
                                EndDate = (DateTime)reader["EndDate"],
                                Caption= reader["Caption"] as string,
                                IsEnable = (bool)reader["IsEnable"],
                                Name= reader["Name"] as string,
                                Phone = reader["Phone"] as string,
                                Age = (int)reader["Age"],
                                Chosen=reader["Chosen"]as string,
                            };

                            list.Add(readSurveyModel);
                        }

                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }
        public ReadSurveyModel GetSurveyByCaption(string account)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM [FirstTry]
                    WHERE [Caption] = @Caption ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@Caption", account);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ReadSurveyModel member = new ReadSurveyModel()
                            {
                                QuestionID = (Guid)reader["QuestionID"],
                                StartDate = (DateTime)reader["StartDate"],
                                EndDate = (DateTime)reader["EndDate"],
                                Caption = reader["Caption"] as string,
                                IsEnable = (bool)reader["IsEnable"],
                                Name = reader["Name"] as string,
                                Phone = reader["Phone"] as string,
                                Age = (int)reader["Age"],
                                Chosen = reader["Chosen"] as string,
                            };

                            return member;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }

        public ReadSurveyModel GetSurvey(Guid id)
        {
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  SELECT *
                    FROM FirstTry
                    WHERE QuestionID = @QuestionID ";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        command.Parameters.AddWithValue("@QuestionID", id);

                        conn.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            ReadSurveyModel member = new ReadSurveyModel()
                            {
                                QuestionID = (Guid)reader["QuestionID"],
                                StartDate = (DateTime)reader["StartDate"],
                                EndDate = (DateTime)reader["EndDate"],
                                Caption = reader["Caption"] as string,
                                IsEnable = (bool)reader["IsEnable"],
                                Name = reader["Name"] as string,
                                Phone = reader["Phone"] as string,
                                Age = (int)reader["Age"],
                                Chosen = reader["Chosen"] as string,
                            };

                            return member;
                        }

                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("MapContentManager.GetMapList", ex);
                throw;
            }
        }
        public void FillFromFront(ReadSurveyModel member)//out參數,發生時
        {
            // 1. 判斷資料庫是否有相同的 Account
            //1.判斷要寫入的問券抬頭
            //if (GetSurveyByCaption(member.Caption) = null)
            //    throw new Exception("已存在相同的問券")
            //if (this.GetSurvey(member.QuestionID) != null)
            //    throw new Exception("已存在相同的問券");

            // 2. 新增資料
            string connStr = ConfigHelper.GetConnectionString();
            string commandText =
                @"  INSERT INTO FirstTry
                        ( QuestionID,Name,Phone,Email,Age,Chosen,IsEnable)
                    VALUES
                        ( @QuestionID,@Name,@Phone,@Email,@Age,@Chosen,@IsEnable)";
            try
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    using (SqlCommand command = new SqlCommand(commandText, conn))
                    {
                        member.IsEnable = true;
                        member.QuestionID = Guid.NewGuid();
                        command.Parameters.AddWithValue("@Name", member.Name);
                        command.Parameters.AddWithValue("@Phone", member.Phone);
                        command.Parameters.AddWithValue("@Email", member.Email);
                        command.Parameters.AddWithValue("@Chosen", member.Chosen);                       
                        command.Parameters.AddWithValue("@Age", (int)member.Age);

                        conn.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog("Create", ex);
                throw;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.Security.Cryptography;

namespace Active_Record
{
    public class Users : ActiveRecord
    {
        private string _username;
        private string _password;
        private string _email;
        private string _location;
        private string _user_type;

        public Users()
        {
        }

        public Users(int id, string username, string password, string email, string location, string type)
        {
            this.myID = id;
            this._username = username;
            this._password = password;
            this._email = email;
            this._location = location;
            this._user_type = type;
        }

        public Users(string username, string password, string email, string location, string type)
        {
            this.myID = 0;
            this._username = username;
            this._password = password;
            this._email = email;
            this._location = location;
            this._user_type = type;
        }

        protected Users(DataRow row)
        {
            this.myID = (int)row["id_user"];
            this._username = (string)row["username"];
            this._password = (string)row["pass"];
            this._email = (string)row["email"];
            this._location = (string)row["location"];
            this._user_type = (string)row["user_type"];
        }

        public string getUsername { get { return _username; } }
        public string getPassword { get { return _password; } }
        public string getEmail { get { return _email; } }
        public string getLocation { get { return _location; } }
        public string getUserType { get { return _user_type; } }

        public static Users LoadById(int id)
        {
            try
            {
                DataSet ds = ExecuteQuery("Select * from users where id_user=" + id);
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return null;
                }
                else
                {
                    return new Users(ds.Tables[0].Rows[0]);
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static string GetLocationByUsername(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("select location from users where username='"+username+"'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["location"];
                    }
                    return aux;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
                return null;
            }
        }

        public static string getUserEmail(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("select email from users where username='" + username + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["email"];
                    }
                    return aux;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }



        public static string getUserTypeByUsername(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("select user_type from users where username='" + username + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["user_type"];
                    }
                    return aux;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static string GetPasswordByEmail(string email)
        {
            try
            {
                DataSet ds = ExecuteQuery("select pass from users where email='" + email + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["pass"];
                    }
                    return DecryptString(aux);
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static string GetEmailByUsername(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("select email from users where username='" + username + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["email"];
                    }
                    return aux;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static string GetUsernameByEmail(string email)
        {
            try
            {
                DataSet ds = ExecuteQuery("select username from users where email='" + email + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["username"];
                    }
                    return aux;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static string checkUser(string username, string location)
        {
            try
            {
                DataSet ds = ExecuteQuery("select id_user from [ARQSI36].[dbo].[users] where username='" + username + "' and location='" + location + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return "";
                }
                else
                {
                    string aux = "";
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        aux = (string)dr["id_user"];
                    }
                    return aux;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static string CheckPassword(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("Select * from users where username='" + username + "'");
                if (ds.Tables[0].Rows.Count != 1)
                {
                    return null;
                }
                else
                {
                    Users u = new Users(ds.Tables[0].Rows[0]);
                    return u._password;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return null;
            }
        }

        public static int CheckUsername(string username)
        {
            try
            {
                DataSet ds = ExecuteQuery("Select * from Users where username='" + username + "'");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public static int CheckEmail(string email)
        {
            try
            {
                DataSet ds = ExecuteQuery("Select * from Users where email='" + email + "'");

                if (ds.Tables[0].Rows.Count != 0)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        //retorna -1 se erro no insert na BD, -2 se erro no username, -3 se erro no email, 1 se sucesso
        public static int Register(string username, string password, string email, string location)
        {
            try
            {
                int e = CheckEmail(email);
                int u = CheckUsername(username);
                if (e == -99 || u == -99)
                {
                    return -99;
                }
                else
                {

                    if (e == 1 && u == 1)
                    {
                        string p = CalculateMD5Hash(password);

                        int q = ExecuteNonQuery("Insert into users (username, pass, email, location, user_type) values ('" + username + "', '" + p + "', '" + email + "', '" + location + "', 'Normal')");
                        if (q == -1)
                        {
                            return q;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        if (u == -1)
                        {
                            return -2;
                        }
                        else
                        {
                            return -3;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        //retorna -1 se erro no insert na BD, -2 se erro no username, -3 se erro no email, 1 se sucesso
        public static int Register(string username, string password, string email, string location, string type)
        {
            try
            {
                int e = CheckEmail(email);
                int u = CheckUsername(username);
                if (e == -99 || u == -99)
                {
                    return -99;
                }
                else
                {
                    if (e == 1 && u == 1)
                    {
                        string p = CalculateMD5Hash(password);

                        int q = ExecuteNonQuery("Insert into users (username, pass, email, location, user_type) values ('" + username + "', '" + p + "', '" + email + "', '" + location + "', '" + type + "')");
                        if (q == -1)
                        {
                            return q;
                        }
                        else
                        {
                            return 1;
                        }
                    }
                    else
                    {
                        if (u == -1)
                        {
                            return -2;
                        }
                        else
                        {
                            return -3;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public static int ValidateUser(string username, string password)
        {
            try
            {
                string s = CheckPassword(username);
                string pass = CalculateMD5Hash(password);

                if (s == pass)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception e)
            {
                string s = e.ToString();
                return -99;
            }
        }

        public override void Save()
        {
            BeginTransaction();

            System.Data.SqlClient.SqlCommand sqluser = new System.Data.SqlClient.SqlCommand();

            if (this.ID != 0)
            {
                sqluser.CommandText = "Update users set username=@, pass=@, email=@, location=@, user_type=@ where id_user=@";
            }/*
            else
            {
                sqluser.CommandText = "insert into users(username, pass, email, location, type) values (@, @, @, @, @)";
            }*/

            sqluser.Transaction = CurrentTransaction;
            System.Data.IDataParameter p = sqluser.Parameters.Add("@usrn", SqlDbType.Int);
            p.Value = _username;

            p = sqluser.Parameters.Add("@pas", SqlDbType.VarChar);
            p.Value = _password;

            p = sqluser.Parameters.Add("@em", SqlDbType.VarChar);
            p.Value = _email;

            p = sqluser.Parameters.Add("@lo", SqlDbType.VarChar);
            p.Value = _location;

            p = sqluser.Parameters.Add("@ty", SqlDbType.VarChar);
            p.Value = _user_type;

            /*if (this.ID != 0)
            {*/
            p = sqluser.Parameters.Add("@id", SqlDbType.Int);
            p.Value = this.ID;
            /* } */

            int id = ExecuteTransactedNonQuery(sqluser);

            /*if (this.ID == 0)
            {
                this.myID = id;
            }*/

            CommitTransaction();
        }

        public static string CalculateMD5Hash(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes("swAkepUFR*T7"));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the encoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(Message);

            // Step 5. Attempt to encrypt the string
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the encrypted string as a base64 encoded string
            return Convert.ToBase64String(Results);
        }

        public static string DecryptString(string Message)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

            // Step 1. We hash the passphrase using MD5
            // We use the MD5 hash generator as the result is a 128 bit byte array
            // which is a valid length for the TripleDES encoder we use below

            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes("swAkepUFR*T7"));

            // Step 2. Create a new TripleDESCryptoServiceProvider object
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

            // Step 3. Setup the decoder
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;

            // Step 4. Convert the input string to a byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(Message);

            // Step 5. Attempt to decrypt the string
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                // Clear the TripleDes and Hashprovider services of any sensitive information
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }

            // Step 6. Return the decrypted string in UTF8 format
            return UTF8.GetString(Results);
        }
    }
}
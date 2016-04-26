using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Collections;
using System.Diagnostics;

namespace Peer
{
    public class clsDatabase
    {
        private OleDbConnection mDB = null;
        private string dbPath = "";

        public clsDatabase(string path)
        {
            dbPath = path;
        }

        private void openDatabaseConnection()
        {
            mDB = new OleDbConnection(dbPath);
        }

        private void closeDatabaseConnection()
        {
            if (mDB != null)
            {
                mDB.Close();
            }
        }

        public void sqlNonQuery(string sql)
        {
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public int login(string un, string ps)
        {
            int userid = -1;
            String username = un;
            String password = "";
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [USER] WHERE UserName = '" + un + "';";
                //string sql = "SELECT UserID FROM USER;";
                cmd = new OleDbCommand(sql, mDB);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    userid = (int)rdr["UserID"];
                    password = (string)rdr["Password"];

                }
                password.Trim();
                rdr.Close();
            }
            finally
            {
                closeDatabaseConnection();
            }
        
            if (password.Trim() == ps.Trim())
            {
                return userid;
            }
            else
            {
                return -1;
            }
        }
        
        public int isAdmin(int uid)
        {
            int status = 0;
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT COUNT(*) AS C FROM ADMIN WHERE UserID = " + uid + ";";
                cmd = new OleDbCommand(sql, mDB);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();

                rdr.Read();
                status = (int)rdr["C"];
                
                rdr.Close();
            }
            finally
            {
                closeDatabaseConnection();
            }
            return status;

        }

        public List<Person> searchUsers (string nm)
        {
            List<Person> list = new List<Person>();
            int i = 0;
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [PERSON] WHERE FirstName = ?";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.Add("@fn", OleDbType.VarChar);
                cmd.Parameters["@fn"].Value = nm.Trim();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    i++;
                    int PersonID = (int)rdr["PersonID"];
                    String FirstName = (String)rdr["FirstName"];
                    String LastName = (String)rdr["LastName"];
                    String Email = (String)rdr["Email"];
                    int GraderNumber = Convert.ToInt16(rdr["GraderNumber"]);
                    int Status = Convert.ToInt16(rdr["Status"]);
                    Person p = new Person(PersonID, FirstName, LastName, Email, Status, GraderNumber);
                    list.Add(p);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return list;

        }

        public Person getPerson(int pid)
        {
            Person p = new Person();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [PERSON] WHERE PersonID = ?";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.Add("@pid", OleDbType.Integer);
                cmd.Parameters["@pid"].Value = pid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    //i++;
                    int PersonID = (int)rdr["PersonID"];
                    String FirstName = (String)rdr["FirstName"];
                    String LastName = (String)rdr["LastName"];
                    String Email = (String)rdr["Email"];
                    int GraderNumber = Convert.ToInt16(rdr["GraderNumber"]);
                    int Status = Convert.ToInt16(rdr["Status"]);
                    p = new Person(PersonID, FirstName, LastName, Email, Status, GraderNumber);
                    //list.Add(p);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return p;
        }

        public Team getTeamByUser(int uid)
        {
            Team t = new Team();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [TEAM] WHERE TeamID = (SELECT TeamID FROM [TEAM_USER] WHERE UserID = ?)";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.Add("@uid", OleDbType.Integer);
                cmd.Parameters["@uid"].Value = uid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    //i++;
                    int TeamID = (int)rdr["TeamID"];
                    int AdminID = (int)rdr["TeamLeader"];
                    t = new Team(TeamID, AdminID);
                    //u = new Person(PersonID, FirstName, LastName, Email, Status, GraderNumber);
                    //list.Add(p);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return t;
        }

        public List<Role> getRoleByUser(int uid)
        {
            List<Role> roles = new List<Role>();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [ROLE] WHERE RoleID IN (SELECT RoleID FROM [ROLE_USER] WHERE UserID = ?)";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.Add("@uid", OleDbType.Integer);
                cmd.Parameters["@uid"].Value = uid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    //i++;
                    int RoleID = (int)rdr["RoleID"];
                    String Name = (String)rdr["Name"];
                    String Description = (String)rdr["Description"];
                    Role r = new Role(RoleID, Name, Description);
                    //u = new Person(PersonID, FirstName, LastName, Email, Status, GraderNumber);
                    roles.Add(r);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return roles;
        }

        public User getUserbyPerson(Person p, int pid)
        {
            User u = new User();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [USER] WHERE PersonID = ?";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.Add("@pid", OleDbType.Integer);
                cmd.Parameters["@pid"].Value = pid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    //i++;
                    int UserID = (int)rdr["UserID"];
                    String UserName = (String)rdr["UserName"];
                    String Password = (String)rdr["Password"];
                    Team tid = this.getTeamByUser(UserID);
                    Debug.WriteLine(UserID.ToString());
                    List<Role> Roles = this.getRoleByUser(UserID);
                    //List<Role> Roles = new List<Role>();
                    u = new User(UserID, UserName, Password, tid, Roles,p.getPersonID(),p.getFirstName(),p.getLastName(),p.getEmail(),p.getStatus(),p.getGraderNumber());
                    //list.Add(p);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return u;
        }

        public User getUser(int uid)
        {
            User u = new User();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [USER] INNER JOIN [PERSON] ON USER.PersonID = PERSON.PersonID WHERE USER.UserID = ?";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.Add("@uid", OleDbType.Integer);
                cmd.Parameters["@uid"].Value = uid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    //i++;
                    int UserID = (int)rdr["UserID"];
                    String UserName = (String)rdr["UserName"];
                    String Password = (String)rdr["Password"];
                    Team tid = this.getTeamByUser(UserID);
                    List<Role> Roles = this.getRoleByUser(UserID);
                    int PersonID = (int)rdr["USER.PersonID"];
                    String FirstName = (String)rdr["FirstName"];
                    String LastName = (String)rdr["LastName"];
                    String Email = (String)rdr["Email"];
                    int GraderNumber = Convert.ToInt16(rdr["GraderNumber"]);
                    int Status = Convert.ToInt16(rdr["Status"]);

                    u = new User(UserID, UserName, Password, tid, Roles, PersonID, FirstName, LastName, Email, Status, GraderNumber);
                    //list.Add(p);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return u;
        }

        public List<User> getTLs()
        {
            List<User> TLs = new List<User>();
            
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [USER] INNER JOIN [PERSON] ON USER.PersonID = PERSON.PersonID WHERE USER.UserID = (SELECT TeamLeader FROM [TEAM])";
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.Add("@uid", OleDbType.Integer);
                //cmd.Parameters["@uid"].Value = uid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    User u = new User();
                    //i++;
                    int UserID = (int)rdr["UserID"];
                    String UserName = (String)rdr["UserName"];
                    String Password = (String)rdr["Password"];
                    Team tid = this.getTeamByUser(UserID);
                    List<Role> Roles = this.getRoleByUser(UserID);
                    int PersonID = (int)rdr["USER.PersonID"];
                    String FirstName = (String)rdr["FirstName"];
                    String LastName = (String)rdr["LastName"];
                    String Email = (String)rdr["Email"];
                    int GraderNumber = Convert.ToInt16(rdr["GraderNumber"]);
                    int Status = Convert.ToInt16(rdr["Status"]);

                    u = new User(UserID, UserName, Password, tid, Roles, PersonID, FirstName, LastName, Email, Status, GraderNumber);
                    TLs.Add(u);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return TLs;
        }

        public List<Role> getRoles()
        {
            List<Role> roles = new List<Role>();

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [ROLE]";
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.Add("@uid", OleDbType.Integer);
                //cmd.Parameters["@uid"].Value = uid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    Role r;
                    //i++;
                    int RoleID = (int)rdr["RoleID"];
                    String Name = (String)rdr["Name"];
                    String Description = (String)rdr["Description"];

                    r = new Role(RoleID, Name, Description);
                    roles.Add(r);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return roles;
        }

        public void updateUser(int pid, int uid, string un, string ps, string fn, string ln, string em, int gn, int tl)
        {
            Boolean cont = true;
            if (un == "")
            {
                cont = cont & false;
            }
            if (ps == "")
            {
                cont = cont & false;
            }
            if (fn == "")
            {
                cont = cont & false;
            }
            if (ln == "")
            {
                cont = cont & false;
            }
            if (em == "")
            {
                cont = cont & false;
            }
            if (gn <= 0)
            {
                cont = cont & false;
            }
            if (tl <= 0)
            {
                cont = cont & false;
            }
            if (cont)
            {
                try
                {
                    string sql = "UPDATE [USER] SET UserName = @user, [Password] = @pass WHERE UserID = @uid";
                    openDatabaseConnection();
                    mDB.Open();
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@user", un);
                    cmd.Parameters.AddWithValue("@pass", ps);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.ExecuteNonQuery();
                    //sqlNonQuery(sql);
                    sql = "UPDATE [PERSON] SET FirstName = @fn,LastName = @ln, Email = @em, GraderNumber = @gn WHERE PersonID = @pid";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@fn", fn);
                    cmd.Parameters.AddWithValue("@ln", ln);
                    cmd.Parameters.AddWithValue("@em", em);
                    cmd.Parameters.AddWithValue("@gn", gn);
                    cmd.Parameters.AddWithValue("@pid", pid);
                    cmd.ExecuteNonQuery();
                    //sqlNonQuery(sql);
                    sql = "UPDATE [TEAM_USER] SET TeamID = @tl WHERE UserID = @uid";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@tl", tl);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    cmd.ExecuteNonQuery();
                    //sqlNonQuery(sql);
                }
                finally
                {
                    closeDatabaseConnection();
                }
            }
        }

        public void addRoleToUser(int rid, int uid)
        {
            try
            {
                string sql = "INSERT INTO [ROLE_USER] (RoleID, UserID) VALUES (@rid, @uid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@rid", rid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public void removeRoleFromUser(int rid, int uid)
        {
            try
            {
                string sql = "DELETE FROM [ROLE_USER] where (RoleID = @rid AND UserID = @uid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@rid", rid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public int insertPerson(string fn, string ln, string em, int gn, int st)
        {
            int pid = -1;
            try
            {
                string sql = "INSERT INTO [PERSON] (FirstName, LastName, Email, GraderNumber, Status) VALUES (@fn, @ln, @em, @gn, @st)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@em", em);
                cmd.Parameters.AddWithValue("@gn", gn);
                cmd.Parameters.AddWithValue("@st", st);
                cmd.ExecuteNonQuery();

                sql = "SELECT PersonID FROM [PERSON] WHERE FirstName = @fn AND LastName = @ln AND Email = @em";
                
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@fn", fn);
                cmd.Parameters.AddWithValue("@ln", ln);
                cmd.Parameters.AddWithValue("@em", em);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pid = (int)rdr["PersonID"];
                    
                }
            }
            finally
            {
                closeDatabaseConnection();
            }
            return pid;
        }

        public int insertUser(string un, string ps, int pid)
        {
            int uid = -1;
            try
            {
                string sql = "INSERT INTO [USER] (UserName, [Password], PersonID) VALUES (@un, @ps, @pid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@un", un);
                cmd.Parameters.AddWithValue("@ps", ps);
                cmd.Parameters.AddWithValue("@pid", pid);
                cmd.ExecuteNonQuery();

                sql = "SELECT UserID FROM [USER] WHERE UserName = @un";

                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@un", un);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    uid = (int)rdr["UserID"];

                }
            }
            finally
            {
                closeDatabaseConnection();
            }
            return uid;
        }

        public void insertUserIntoTeam(int tlid, int uid)
        {
            try
            {
                string sql = "INSERT INTO [TEAM_USER] (TeamID, UserID) VALUES (@tlid, @uid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public int insertRole(String nm, String ds)
        {
            int rid = -1;
            try
            {
                bool cont = true;
                if (nm == "")
                {
                    cont = cont & false;
                }
                if (cont)
                {
                    string sql = "INSERT INTO [ROLE] (Name, Description) VALUES (@nm, @ds)";
                    openDatabaseConnection();
                    mDB.Open();
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@nm", nm);
                    cmd.Parameters.AddWithValue("@ds", ds);
                    cmd.ExecuteNonQuery();

                    sql = "SELECT RoleID FROM [ROLE] WHERE Name = @nm";

                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@nm", nm);
                    OleDbDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        rid = (int)rdr["RoleID"];

                    }
                }
            }
            finally
            {
                closeDatabaseConnection();
            }
            return rid;
        }

        public void updateRole(int rid, String nm, String ds)
        {
            try
            {
                bool cont = true;
                if (nm == "")
                {
                    cont = cont & false;
                }
                if (cont)
                {
                    string sql = "UPDATE [ROLE] SET Name = @nm, Description = @ds WHERE RoleID = @rid";
                    openDatabaseConnection();
                    mDB.Open();
                    OleDbCommand cmd;
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@nm", nm);
                    cmd.Parameters.AddWithValue("@ds", ds);
                    cmd.Parameters.AddWithValue("@rid", rid);
                    cmd.ExecuteNonQuery();
                }
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public void deleteRole(int rid)
        {
            try
            {
                string sql;
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                sql = "DELETE FROM [ROLE_USER] WHERE RoleID = @rid";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@rid", rid);
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM [ROLE] WHERE RoleID = @rid";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@rid", rid);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public Role getRoleByID(int rid)
        {
            Role r = new Role();
            try
            {
                String name = "";
                String desc = "";
                String sql = "SELECT * FROM [ROLE] WHERE RoleID = @rid";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@rid", rid);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    rid = (int)rdr["RoleID"];
                    name = (string)rdr["Name"];
                    desc = (string)rdr["Description"];
                }
                r.setRoleID(rid);
                r.setName(name);
                r.setDescription(desc);
            }
            finally
            {
                closeDatabaseConnection();
            }
            return r;
        }

        /*
        public ArrayList loadUser(string sql)
        {
            ArrayList users = new ArrayList();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //string userid = (string)rdr["UserID"];
                    //string pass = (string)rdr["Password"];
                    //string fname = (string)rdr["FirstName"];
                    //string lname = (string)rdr["LastName"];
                    //string email = (string)rdr["Email"];
                    //string phonenumber = (string)rdr["PhoneNumber"];
                    //string agegroup = (string)rdr["AgeGroup"];
                    //Decimal price = (Decimal)rdr["AdmissionPrice"];
                    //bool waiver = (bool)rdr["SignedWaiver"];
                    //string pfname = (string)rdr["ParentFirstName"];
                    //string plname = (string)rdr["ParentLastName"];
                    clsUsers user = new clsUsers((string)rdr["UserID"],
                        (string)rdr["Password"],
                        (string)rdr["FirstName"],
                        (string)rdr["LastName"],
                        (string)rdr["Email"],
                        (string)rdr["PhoneNumber"],
                        (string)rdr["AgeGroup"],
                        (Decimal)rdr["AdmissionPrice"],
                        (bool)rdr["SignedWaiver"],
                        (string)rdr["ParentFirstName"],
                        (string)rdr["ParentLastName"]);
                    users.Add(user);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                closeDatabaseConnection();
            }
            return users;
        }
        */

        public string DBPath
        {
            get { return dbPath; }
            set { dbPath = value; }
        }
    }
}

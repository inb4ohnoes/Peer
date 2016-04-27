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

        public List<User> searchUsers (string nm)
        {
            List<User> users = new List<User>();

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [USER] INNER JOIN [PERSON] ON USER.PersonID = PERSON.PersonID WHERE PERSON.FirstName LIKE @nm";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@nm", "%" + nm + "%");
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
                    users.Add(u);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return users;

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
                string sql = "SELECT * FROM [TEAM] WHERE TeamID = (SELECT TeamID FROM [TEAM_USER] WHERE UserID = @uid)";
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

        public List<User> getAdmins()
        {
            List<User> admins = new List<User>();

            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [USER] INNER JOIN [PERSON] ON USER.PersonID = PERSON.PersonID WHERE USER.UserID = (SELECT UserID FROM [ADMIN])";
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
                    admins.Add(u);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return admins;
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
                    sql = "SELECT COUNT(*) AS C FROM [TEAM_USER] WHERE UserID = @uid";
                    cmd = new OleDbCommand(sql, mDB);
                    //cmd.Parameters.AddWithValue("@tl", tl);
                    cmd.Parameters.AddWithValue("@uid", uid);
                    OleDbDataReader rdr;
                    rdr = cmd.ExecuteReader();
                    int count = -1;
                    while (rdr.Read())
                    {
                        count = (int)rdr["C"];
                    }
                    if (count > 0)
                    {
                        sql = "UPDATE [TEAM_USER] SET TeamID = @tl WHERE UserID = @uid";
                        cmd = new OleDbCommand(sql, mDB);
                        cmd.Parameters.AddWithValue("@tl", tl);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.ExecuteNonQuery();
                        //sqlNonQuery(sql);
                    }
                    else
                    {
                        sql = "INSERT INTO [TEAM_USER] (TeamID,UserID) VALUES (@tl, @uid)";
                        cmd = new OleDbCommand(sql, mDB);
                        cmd.Parameters.AddWithValue("@tl", tl);
                        cmd.Parameters.AddWithValue("@uid", uid);
                        cmd.ExecuteNonQuery();
                    }
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

        public Team insertUserIntoTeam(int tlid, int uid)
        {
            Team t = new Team();
            try
            {
                int tid = -1;
                string sql = "SELECT TeamID FROM [TEAM] WHERE TeamLeader = @tlid";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@tlid", tlid);
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    tid = (int)rdr["TeamID"];
                }

                sql = "INSERT INTO [TEAM_USER] (TeamID, UserID) VALUES (@tid, @uid)";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@tid", tid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();

                t.setAdmin(tlid);
                t.setTeamID(tid);
            }
            finally
            {
                closeDatabaseConnection();
            }
            return t;
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

        public void insertTeam(int uid)
        {
            try
            {
                string sql = "INSERT INTO [TEAM] (TeamLeader) VALUES (@uid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@uid", uid);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public void deleteTeam(int tlid)
        {
            try
            {
                string sql;
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                sql = "DELETE FROM [TEAM_USER] WHERE TeamID = (SELECT TeamID FROM [TEAM] WHERE TeamLeader = @ltid)";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.ExecuteNonQuery();

                sql = "DELETE FROM [TEAM] WHERE TeamLeader = @tlid";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.ExecuteNonQuery();

            }
            finally
            {
                closeDatabaseConnection();
            }
        }

        public Template getTemplate(int tid)
        {
            Template t = new Template();
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            string sql = "SELECT * FROM [TEMPLATE] WHERE TemplateID = @tid";
            cmd = new OleDbCommand(sql, mDB);
            cmd.Parameters.AddWithValue("@tid", tid);
            OleDbDataReader rdr;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                String name = (string)rdr["Name"];
                int cr = (int)rdr["Creator"];
                t.setTemplateID(tid);
                t.setName(name);
                User u = getUser(cr);
                t.setCreator(u);
            }

            return t;
        }

        public List<Template> getTemplates()
        {
            List<Template> listt = new List<Template>();
            openDatabaseConnection();
            mDB.Open();
            OleDbCommand cmd;
            string sql = "SELECT * FROM [TEMPLATE]";
            cmd = new OleDbCommand(sql, mDB);
           // cmd.Parameters.AddWithValue("@tid", tid);
            OleDbDataReader rdr;
            rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Template t = new Template();
                String name = (string)rdr["Name"];
                int cr = (int)rdr["Creator"];
                int tid = (int)rdr["TemplateID"];
                t.setTemplateID(tid);
                t.setName(name);
                User u = getUser(cr);
                t.setCreator(u);
                listt.Add(t);
            }

            return listt;
        }

        public List<Assessment> getAssessmentsForUser(User uid)
        {
            List<Assessment> asss = new List<Assessment>();
            try
            {
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                string sql = "SELECT * FROM [ASSESSMENT] WHERE Reviewer = @uid";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@uid", uid.getUserID());
                //cmd.Parameters.Add("@uid", OleDbType.Integer);
                //cmd.Parameters["@uid"].Value = uid;
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    Assessment r;
                    //i++;
                    int aid = (int)rdr["AssessmentID"];
                    int tid = (int)rdr["TemplateID"];
                    int rvr = (int)rdr["Reviewer"];
                    int rve = (int)rdr["Reviewee"];
                    Template t = getTemplate(tid);
                    User rr = getUser(rvr);
                    User re = getUser(rve);

                    r = new Assessment(aid, t, re, rr);
                    asss.Add(r);
                }
                sql = "SELECT * FROM [ASSESSMENT] WHERE Reviewee = @uid";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@uid", uid.getUserID());
                //cmd.Parameters.Add("@uid", OleDbType.Integer);
                //cmd.Parameters["@uid"].Value = uid;
                rdr = cmd.ExecuteReader();
                //Debug.WriteLine(i.ToString());

                while (rdr.Read())
                {
                    Assessment r;
                    //i++;
                    int aid = (int)rdr["AssessmentID"];
                    int tid = (int)rdr["TemplateID"];
                    int rvr = (int)rdr["Reviewer"];
                    int rve = (int)rdr["Reviewee"];
                    Template t = getTemplate(tid);
                    User rr = getUser(rvr);
                    User re = getUser(rve);

                    r = new Assessment(aid, t, re, rr);
                    asss.Add(r);
                }
                rdr.Close();
                //Debug.WriteLine(i.ToString());
            }
            finally
            {
                closeDatabaseConnection();
            }
            return asss;
        }

        public int insertMCQuestion(MultipleChoice mc)
        {
            int mcid = -1;
            string question = "";
            //int mcaid = -1;
            //string answer = "";

            try
            {
                question = mc.getQuestion();
                string sql = "INSERT INTO [MULTIPLECHOICE] (Question) VALUES (@qid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@qid", question);
                cmd.ExecuteNonQuery();

                sql = "SELECT MCID FROM [MULTIPLECHOICE] WHERE Question = @qid";
                //mDB.Open();
                //OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@qid", question);
                //cmd.ExecuteNonQuery();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    mcid = (int)rdr["MCID"];
                }

            }
            finally
            {
                closeDatabaseConnection();
            }
            return mcid;
        }

        public int insertQuestion(MultipleChoice mc, FreeResponse fr)
        {
            int qid = -1;
            int mcid = mc.getMCID();
            int frid = fr.getFRID();
            //int mcaid = -1;
            //string answer = "";

            try
            {
                String sql = "INSERT INTO [QUESTION] (MultipleChoice,FreeResponse) VALUES (@mcid, @frid)";
                //String sql = "";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@mcid", mcid);
                cmd.Parameters.AddWithValue("@frid", frid);
                /*
                if (mcid > 0)
                {
                    sql = "INSERT INTO [QUESTION] (MultipleChoice,FreeResponse) VALUES (@mcid, NULL)";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@mcid", mcid);
                    //cmd.Parameters.AddWithValue("@frid", DBNull.Value);
                }
                else
                {
                    //cmd.Parameters.AddWithValue("@mcid", DBNull.Value);
                    sql = "INSERT INTO [QUESTION] (MultipleChoice,FreeResponse) VALUES (NULL, @frid)";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@frid", frid);
                }
                /*
                if (mcid > 0)
                {
                    sql = "INSERT INTO [QUESTION] (MultipleChoice,FreeResponse) VALUES (@mcid, null)";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@mcid", mcid);

                }
                else
                {
                    sql = "INSERT INTO [QUESTION] (MultipleChoice,FreeResponse) VALUES (null, @frid)";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@frid", frid);
                }
                 */
                cmd.ExecuteNonQuery();
                qid = -1;
                sql = "SELECT QuestionID FROM [QUESTION] WHERE (MultipleChoice = @mcid AND FreeResponse = @frid)";
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@mcid", mcid);
                cmd.Parameters.AddWithValue("@frid", frid);
                //mDB.Open();
                /*
                OleDbCommand cmd1;
                if (mcid > 0)
                {
                    sql = "SELECT QID FROM [QUESTION] WHERE MultipleChoice = @mcid AND FreeResponse = @frid";
                    cmd1 = new OleDbCommand(sql, mDB);
                    cmd1.Parameters.AddWithValue("@mcid", mcid);
                    //cmd.Parameters.AddWithValue("@frid", DBNull.Value);
                }
                else
                {
                    //cmd.Parameters.AddWithValue("@mcid", DBNull.Value);
                    sql = "SELECT QID FROM [QUESTION] WHERE FreeResponse = @frid";
                    cmd1 = new OleDbCommand(sql, mDB);
                    cmd1.Parameters.AddWithValue("@frid", frid);
                }
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                /*
                if (mcid > 0)
                {
                    sql = "SELECT QID FROM [QUESTION] WHERE MultipleChoice = @mcid AND FreeResponse is null";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@mcid", mcid);

                }
                else
                {
                    sql = "SELECT QID FROM [QUESTION] WHERE MultipleChoice is null AND FreeResponse = @frid";
                    cmd = new OleDbCommand(sql, mDB);
                    cmd.Parameters.AddWithValue("@frid", frid);
                }
                 */
                cmd.ExecuteNonQuery();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    qid = (int)rdr["QuestionID"];
                }

            }
            finally
            {
                closeDatabaseConnection();
            }
            return qid;

        }
        
        public int insertTemplate(string nm, User cr)
        {
            int tid = -1;
            //int mcaid = -1;
            //string answer = "";

            try
            {
                String sql = "INSERT INTO [TEMPLATE] (Name, Creator) VALUES (@nm, @cr)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@nm", nm);
                cmd.Parameters.AddWithValue("@cr", cr.getUserID());
                cmd.ExecuteNonQuery();
                //qid = -1;
                sql = "SELECT TemplateID FROM [TEMPLATE] WHERE Name = @nm AND Creator = @cr";
                //mDB.Open();
                //OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@nm", nm);
                cmd.Parameters.AddWithValue("@cr", cr.getUserID());
                //cmd.ExecuteNonQuery();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tid = (int)rdr["TemplateID"];
                }

            }
            finally
            {
                closeDatabaseConnection();
            }
            return tid;
        }

        public void insertQuestionIntoTemplate(int t, int q)
        {
            //int tid = -1;
            //int mcaid = -1;
            //string answer = "";

            try
            {
                String sql = "INSERT INTO [TEMPLATE_QUESTION] (TemplateID, QuestionID) VALUES (@t, @q)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@t", t);
                cmd.Parameters.AddWithValue("@q", q);
                cmd.ExecuteNonQuery();
                //qid = -1;
                /*
                sql = "SELECT TemplateID FROM [TEMPLATE_USER] WHERE Name = @nm AND Creator = @cr";
                mDB.Open();
                //OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@nm", nm);
                cmd.Parameters.AddWithValue("@cr", cr);
                //cmd.ExecuteNonQuery();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    tid = (int)rdr["TemplateID"];
                }
                */

            }
            finally
            {
                closeDatabaseConnection();
            }
            //return tid;
        }

        public int insertMCAnswer(MCAnswer mc)
        {
            int mcid = -1;
            int mcaid = -1;
            string response = "";
            //int mcaid = -1;
            //string answer = "";
            mcid = mc.getMCID();
            response = mc.getAnswer();

            try
            {
                //response = mc.getAnswer();
                string sql = "INSERT INTO [MCANSWER] (MCID, Answer) VALUES (@mcid, @rp)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@mcid", mcid);
                cmd.Parameters.AddWithValue("@rp", response);
                cmd.ExecuteNonQuery();

                sql = "SELECT MCAnswerID FROM [MCANSWER] WHERE MCID = @mcid AND ANSWER = @rp";
                //mDB.Open();
                //OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                cmd.Parameters.AddWithValue("@mcid", mcid);
                cmd.Parameters.AddWithValue("@rp", response);
                //cmd.ExecuteNonQuery();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    mcaid = (int)rdr["MCAnswerID"];
                }

            }
            finally
            {
                closeDatabaseConnection();
            }
            return mcaid;
        }

        public int insertFRQuestion(FreeResponse fr)
        {
            int frid = -1;
            string question = "";
            //int mcaid = -1;
            //string answer = "";

            try
            {
                question = fr.getQuestion();
                string sql = "INSERT INTO [FREERESPONSE] (Question) VALUES (@qid)";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@qid", question);
                cmd.ExecuteNonQuery();

                sql = "SELECT FRID FROM [FREERESPONSE] WHERE Question = @qid";
                //mDB.Open();
                //OleDbCommand cmd;
                cmd = new OleDbCommand(sql, mDB);
                //cmd.Parameters.AddWithValue("@tlid", tlid);
                cmd.Parameters.AddWithValue("@qid", question);
                //cmd.ExecuteNonQuery();
                OleDbDataReader rdr;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    frid = (int)rdr["FRID"];
                }

            }
            finally
            {
                closeDatabaseConnection();
            }
            return frid;
        }

        public List<User> getAllUsers()
        {
            List<User> list = new List<User>();
            try
            {
                String sql = "SELECT * FROM [USER] INNER JOIN [PERSON] ON USER.PersonID = PERSON.PersonID";
                openDatabaseConnection();
                mDB.Open();
                OleDbCommand cmd;
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
                    list.Add(u);
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

        public string DBPath
        {
            get { return dbPath; }
            set { dbPath = value; }
        }
    }
}

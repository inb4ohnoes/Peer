using System;

namespace Peer {
    public class Admin
    {
        User user;

        public Admin()
        {
            user = new User();
        }

        public Admin(User u1)
        {
            user = u1;
        }
    }
}

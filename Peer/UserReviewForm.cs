using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peer
{
    public partial class UserReviewForm : Form
    {
        public UserReviewForm(User selectedUserin, Template selectedTemplateIn)
        {
            InitializeComponent();

            //No idea what else to do...
            label1.Text = selectedUserin.getFirstName() + "--------" + selectedTemplateIn.getName();

        }
    }
}

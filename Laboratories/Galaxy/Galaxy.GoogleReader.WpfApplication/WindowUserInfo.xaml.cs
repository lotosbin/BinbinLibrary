using System.Windows;
using System.Windows.Controls;
using Galaxy.GoogleReader.Client.Models.UserInfo;

namespace Galaxy.GoogleReader.WpfApplication
{
    /// <summary>
    /// Interaction logic for WindowUserInfo.xaml
    /// </summary>
    public partial class WindowUserInfo : Window
    {
        public WindowUserInfo()
        {
            InitializeComponent();
        }
        public UserInfoJson UserInfo { get; set; }
        public void DataBind()
        {
            this.textBox1.Text = this.UserInfo.UserId;
            this.textBox2.Text = this.UserInfo.IsBloggerUser.ToString();
            this.textBox3.Text = this.UserInfo.UserName;
            this.textBox4.Text = this.UserInfo.UserEmail;
            this.textBox5.Text = this.UserInfo.UserProfileId;
            this.textBox6.Text = this.UserInfo.SignupTimeSec.ToString();

        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
        }
    }
}

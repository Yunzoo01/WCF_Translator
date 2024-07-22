using System;
using System.IO;
using System.ServiceModel;
using System.Windows;
using _0427_ChatClient.ServiceReference1;
using Microsoft.Win32;

namespace _0427_ChatClient
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, IChatCallback
    {
        private bool Islogin;
        public string NickName
        {
            get { return nickname.Text; }
            set { nickname.Text = value; }
        }

        public string Message
        {
            get { return msgbox.Text; }
            set { msgbox.Text = value; }
        }
        public string SendTo_Name
        {
            get { return sendto_name.Text; }
            set { sendto_name.Text = value; }
        }


        private ChatClient chat = null;

        public MainWindow()
        {
            InitializeComponent();
            this.Title = "Login to chat";
            Islogin = false;

            InstanceContext site = new InstanceContext(this);
            chat = new ChatClient(site);
        }

        #region IChatCallback
        public void Receive(string nickname, string message)
        {
            string msgtemp = string.Format("[{0}] {1}", nickname, message);
            chatlist.Items.Add(msgtemp);
        }

        public void UserMessage(string msg)
        {
            chatlist.Items.Add(msg);
        }


        #endregion

        //public void UserLeave(string nickname)
        //{
        //    string msgtemp = string.Format("{0}님이 로그아웃하셨습니다.", nickname);
        //    chatlist.Items.Add(msgtemp);
        //}

        #region 버튼 핸들러
        private void Join_Click(object sender, RoutedEventArgs e)
        {
            string result = chat.Join(NickName);
            if (result == "OK")
            {
                UserMessage("[" + NickName + "] LogIn Success");
                nickname.IsReadOnly = true;
                this.Title = NickName;
                Islogin = true;
            }
            else
            {
                UserMessage(result);
            }
        }

        private void Leave_Click(object sender, RoutedEventArgs e)
        {
            chat.Leave(NickName);
            UserMessage("[" + NickName + "] LogOut Success");
            nickname.IsReadOnly = false;
            Islogin = false;
            this.Title = "Login to chat";
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            if (Islogin == false)
            {
                UserMessage("Login first");
                return;
            }

            chat.Say(NickName, Message, SendTo_Name);
            msgbox.Clear();

        }

        private void translate_Click(object sender, RoutedEventArgs e)
        {
            mainwindow.Width = ((mainwindow.Width) % 800 + 400);
        }

        public void FileServiceToClient(string nickname, string filename, byte[] data, string recivename)
        {
            if (MessageBox.Show(string.Format("recive <{0}> from [{1}]\nSave File?",filename,nickname), "YesOrNo", MessageBoxButton.OKCancel) == MessageBoxResult.OK)
            {
                System.Windows.Forms.FolderBrowserDialog folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog(); 
                if(folderBrowserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //MessageBox.Show("asd");
                    string path = folderBrowserDialog.SelectedPath.ToString();
                    FileStream fs = new FileStream(path+"\\"+filename, FileMode.Create, FileAccess.Write);
                    fs.Write(data, 0, data.Length);
                    fs.Close();
                }
            }
        }

        private void File_Click(object sender, RoutedEventArgs e)
        {
            FileStream filedata;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() != true)
                return;

            filedata = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            BinaryReader reader = new BinaryReader(filedata);
            byte[] bytefile = reader.ReadBytes(Convert.ToInt32( filedata.Length));
            string filename = openFileDialog.SafeFileName;

            chat.FileClientToService(NickName, filename, bytefile, SendTo_Name);



            //MessageBox.Show("OK");



        }
        #endregion

        private void mainwindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Leave_Click(sender, new RoutedEventArgs());
        }
    }
}

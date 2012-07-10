using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Google.Contacts;
using Google.GData.Client;
using Google.GData.Contacts;
using Google.GData.Extensions;

namespace Galaxy.GoogleContact.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.ApplicationName = "GalaxyGoogleContact";
            this.UserName = "lotosbin@gmail.com";
            this.PassWord = "Chaos@2010";
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RequestSettings rs = new RequestSettings("exampleCo-exampleApp-1", "lotosbin@gmail.com", "Chaos@2010");
            ContactsRequest cr = new ContactsRequest(rs);


            Contact newContact = new Contact();
            newContact.Title = "lotosbin(test)";

            EMail primaryEmail = new EMail("lotosbin@gmail.com");
            primaryEmail.Primary = true;
            primaryEmail.Rel = ContactsRelationships.IsWork;
            newContact.Emails.Add(primaryEmail);

            EMail secondaryEmail = new EMail("binbin@ymatou.com");
            secondaryEmail.Rel = ContactsRelationships.IsHome;
            newContact.Emails.Add(secondaryEmail);

            PhoneNumber phoneNumber = new PhoneNumber("555-555-5555");
            phoneNumber.Primary = true;
            phoneNumber.Rel = ContactsRelationships.IsMobile;
            newContact.Phonenumbers.Add(phoneNumber);

            PostalAddress postalAddress = new PostalAddress();
            postalAddress.Value = "123 somewhere lane";
            postalAddress.Primary = true;
            postalAddress.Rel = ContactsRelationships.IsHome;
            newContact.PostalAddresses.Add(postalAddress);

            newContact.Content = "Contact information for Liz";

            Uri feedUri = new Uri(ContactsQuery.CreateContactsUri("default"));

            //The example assumes the ContactRequest object (cr) is already set up.
            Contact createdContact = cr.Insert(feedUri, newContact);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            RequestSettings rs = new RequestSettings(this.ApplicationName, this.UserName, this.PassWord);
            // AutoPaging results in automatic paging in order to retrieve all contacts
            rs.AutoPaging = true;
            ContactsRequest cr = new ContactsRequest(rs);

            Feed<Contact> f = cr.GetContacts();
            foreach (Contact entry in f.Entries)
            {
                var listBoxItem = new ListBoxItem();
                listBoxItem.Content = entry.Title;

                this.listBox1.Items.Add(listBoxItem);
                //Console.WriteLine("\t" + entry.Title);
                //foreach (EMail email in entry.Emails)
                //{
                //    Console.WriteLine("\t" + email.Address);
                //}
                //foreach (GroupMembership g in entry.GroupMembership)
                //{
                //    Console.WriteLine("\t" + g.HRef);
                //}
                //foreach (IMAddress im in entry.IMs)
                //{
                //    Console.WriteLine("\t" + im.Address);
                //}
            }
        }

        protected string PassWord { get; set; }

        protected string UserName { get; set; }

        protected string ApplicationName { get; set; }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            RequestSettings rs = new RequestSettings(this.ApplicationName, this.UserName, this.PassWord);
            //AutoPaging results in automatic paging in order to retrieve all groups
            rs.AutoPaging = true;
            ContactsRequest cr = new ContactsRequest(rs);

            Feed<Group> fg = cr.GetGroups();
            foreach (Group g in fg.Entries)
            {
                var listBoxItem = new ListBoxItem();
                listBoxItem.Content = g.SystemGroup;
                this.listBox2.Items.Add(listBoxItem);
            }
        }
    }
}

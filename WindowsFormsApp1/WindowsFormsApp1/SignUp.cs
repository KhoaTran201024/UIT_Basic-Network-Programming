using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace WindowsFormsApp1
{
    public partial class SignUp : Form
    {
        string connectionString = "mongodb+srv://22520039:JaVHhoJmN7iHt9Sr@scopify.9dlayjt.mongodb.net/Users";
        string dbName = "simple_db";
        string collectionName = "people";

        public SignUp()
        {
            InitializeComponent();
        }

        public class PersonModel
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }
            public string Name { get; set; }
            public string Password { get; set; }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(dbName);
            var collection = db.GetCollection<PersonModel>(collectionName);

            var person = new PersonModel { Name = textBox1.Text, Password = textBox2.Text };

            await collection.InsertOneAsync(person);
            var results = await collection.FindAsync(_ => true);

            foreach (var result in results.ToList())
            {
                Console.WriteLine($"{result.Id}: {result.Name} {result.Password}");
            }

            /* list of databases
            var dbList = client.ListDatabases().ToList();

            Console.WriteLine("The list of databases on this server is: ");
            foreach (var dbl in dbList)
            {
                Console.WriteLine(dbl);
            }*/
        }
    }
}

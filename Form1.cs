using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using static student.Student;

namespace student
{
    public partial class Form1 : Form
    {
        Studenci studenci = new Studenci();
        String Imie, Nazwisko;
        int NrIndeksu, Rocznik;

        List<Student> listaStudentow = new List<Student>();
        void wyswietl()
        {
            listBox1.Items.Clear();
            studenci.listaStudentow.Clear();

            listaStudentow = XMLDeserialize("Studenci.xml");
          foreach (Student o in listaStudentow)
            {
                
                studenci.listaStudentow.Add(o);
                listBox1.Items.Add(o);
            }
        }

        public List<Student> XMLDeserialize(string xmlFile)
        {
            List<Student> obj;
            try
            {
               
                StreamReader xr = new StreamReader("Studenci.xml");
           
                XmlSerializer s = new XmlSerializer(typeof(List<Student>));
                obj = (List<Student>)s.Deserialize(xr);
                xr.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                obj = null;
            }
            
            return obj;
        }
         public void serializeToXml()
        {
            
            File.Delete("Studenci.xml");     
            var fStream = new FileStream("Studenci.xml", FileMode.OpenOrCreate);

            try
            {
                new XmlSerializer(typeof(List<Student>)).Serialize(fStream, studenci.listaStudentow);
        }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
              
            }
            finally
            {
                fStream.Close();
            }
        }
        public Form1()
        {

            InitializeComponent();
             wyswietl();

        }

        private void bodczyt_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            wyswietl();
        }

        private void bzapisz_Click(object sender, EventArgs e)
        {
            
            serializeToXml();
            listBox1.Items.Clear();

            wyswietl();
        }

        private void bDodaj_Click(object sender, EventArgs e)
        {
            
            Imie = txtImie.Text;
            Nazwisko = txtNazwisko.Text;
            NrIndeksu = Int32.Parse(txtIndeks.Text);
            Rocznik = Int32.Parse(txtRocznik.Text);

            
                Student s1 = new Student(Imie, Nazwisko, NrIndeksu, Rocznik);
                studenci.listaStudentow.Add(s1);

                
            if (listBox1.SelectedIndex == -1)
            {
                listBox1.Items.Add(s1);
            }
            else
            {
                studenci.listaStudentow.RemoveAt(listBox1.SelectedIndex);
                listBox1.Items.Remove(listBox1.SelectedItem);
                
                
                listBox1.Items.Add(s1);
            }

            txtImie.Clear();
            txtNazwisko.Clear();
            txtIndeks.Clear();
            txtRocznik.Clear();
            bDodaj.Text = "dodaj";
            button4.Visible = true;
            button2.Visible = true;
            listBox1.SelectedIndex = -1;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtImie.Clear();
            txtNazwisko.Clear();
            txtIndeks.Clear();
            txtRocznik.Clear();
        }

        private void Form1_Load(object sender, EventArgs e){ }
        
        
       
        private void zapiszToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            serializeToXml();
            listBox1.Items.Clear();
        }

        private void wyjdzToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serializeToXml();
            listBox1.Items.Clear();
            System.Windows.Forms.Application.Exit();
        }

        private void otworzToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            wyswietl();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Student s2 = (Student)listBox1.SelectedItem;
                txtImie.Text = s2.Imie;
                txtNazwisko.Text = s2.Nazwisko;
                txtIndeks.Text = s2.NrIndeksu.ToString();
                txtRocznik.Text = s2.Rocznik.ToString();
                bDodaj.Text = "zapisz";
                button4.Visible = false;
                button2.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            if(index != -1)
            {
                listBox1.Items.RemoveAt(index);

                studenci.listaStudentow.RemoveAt(index);
                
            }
            listBox1.SelectedIndex = -1;

        }
    }
}

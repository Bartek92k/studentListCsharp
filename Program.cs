using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace student
{
   
     class Program
    {
       
        [STAThread]

        
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
       
    }

    [Serializable()]
    public class Student
    {

        [System.Xml.Serialization.XmlElement("Imie")]
        public string Imie { get; set;}

        [System.Xml.Serialization.XmlElement("Nazwisko")]
        public string Nazwisko { get; set; }

        [System.Xml.Serialization.XmlElement("NrIndeksu")]
        public int NrIndeksu { get; set; }

        [System.Xml.Serialization.XmlElement("Rocznik")]
        public int Rocznik { get; set; }

        public Student(){}

        public Student(String i, String n, int nri, int r)
        {
            
            Imie = i;for (; Imie.Length < 20;) Imie += " ";
            Nazwisko = n;for (; Nazwisko.Length < 20;) Nazwisko += " ";
            NrIndeksu = nri;//for(;((String)NrIndeksu).Length<15;)
            Rocznik = r;
            

        }

        public override string ToString()
        {
            return string.Format("{0}    {1}    {2}    {3}", Imie, Nazwisko, NrIndeksu, Rocznik);

        }



        [Serializable()]
        [System.Xml.Serialization.XmlRoot("Studenci")]
        public class Studenci
        {
            [XmlArray("Studenci")]
            [XmlArrayItem("Student", typeof(Student))]
            public List<Student> listaStudentow { get; set; }
            public Studenci(object v)
            {
                listaStudentow = new List<Student>();
            }
            public Studenci()
            {
                listaStudentow = new List<Student>();
            }
        }

    }


}

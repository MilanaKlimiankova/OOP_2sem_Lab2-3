using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace _2
{
    public partial class Form1 : Form
    {
        [Serializable]
        public class Flat
        {
            public double meter { get; set; }
            public double room { get; set; }
            public string option { get; set; }
            public double floor { get; set; }
            public Adress adress = new Adress();
            public class Adress
            {
                [Required]
                [StringLength(50, MinimumLength = 3)]
                public string country { get; set; }
                [Required]
                [StringLength(50, MinimumLength = 3)]
                public string city { get; set; }
                [Required]
                [StringLength(50, MinimumLength = 3)]
                public string area { get; set; }
                [Required]
                [StringLength(50, MinimumLength = 3)]
                public string street { get; set; }
                [Required]
                [Range(1, 100)]
                public string house { get; set; }
                [Required]
                [Range(1, 100)]
                public string building { get; set; }
                [Required]
                [Range(1, 100)]
                public string flat { get; set; }
                public Adress()
                {

                }
                public Adress (string country, string city, string area, string street, string house, string building, string flat)
                {
                    this.country = country;
                    this.city = city;
                    this.area = area;
                    this.street = street;
                    this.house = house;
                    this.building = building;
                    this.flat = flat;
                }

            }
            public Flat()
            {
            }
            public Flat(double meter, double room, string option, double floor, Adress adress)
            {
                this.meter = meter;
                this.room = room;
                this.option = option;
                this.floor = floor;
                this.adress = adress;
            }
            public override string ToString()
            {
                string itog = $"Метраж: {meter}, \nКол-во комнат: {room}, \nОпции: {option},\nЭтаж: {floor}, \nАдрес: {adress.country}, {adress.city} \n ";
                return itog;
            }
        }

        public Form1()
        {
            InitializeComponent();
            this.Country.Tag = false;
            this.City.Tag = false;
            var results1 = new List<ValidationResult>();
            var context1 = new ValidationContext(flat);
            if (!Validator.TryValidateObject(flat, context1, results1, true))
            {
                foreach (var error in results1)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
            }
            Status.Text = "Количество объектов: " + Convert.ToString(count)+" "+DateTime.Now.ToLongDateString() + " Время запуска: " + DateTime.Now.ToLongTimeString();
        }
        Flat flat = new Flat();
        List<Flat> list = new List<Flat>();
        int count = 0;

        private void Meter_ValueChanged(object sender, EventArgs e)//метраж
        {
            flat.meter = Convert.ToDouble(Meter.Value);
        }
        private void groupBox1_Enter(object sender, EventArgs e)//комнаты
        {

        }
        private void one_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                flat.room = 1;
            }
        }
        private void two_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                flat.room = 2;
            }
        }
        private void three_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                flat.room = 3;
            }
        }
        private void four_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                flat.room = 4;
            }
        }
        private void five_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                flat.room = 5;
            }
        }
        private void six_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton radioButton = (RadioButton)sender;
            if (radioButton.Checked)
            {
                flat.room = 6;
            }
        }



        //опции
        private void Kitchen_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (Kitchen.Checked)
            {
                flat.option += Kitchen.Text + " ";
            }
        }
        private void Balk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (Balk.Checked)
            {
                flat.option += Balk.Text + " ";
            }
        }
        private void Bath_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (Bath.Checked)
            {
                flat.option += Bath.Text + " ";
            }
        }
        private void wifi_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (wifi.Checked)
            {
                flat.option += wifi.Text + " ";
            }
        }
        private void Toilet_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (Toilet.Checked)
            {
                flat.option += Toilet.Text + " ";
            }
        }
        private void basement_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            if (basement.Checked)
            {
                flat.option += basement.Text + " ";
            }
        }
        private void level_Scroll(object sender, EventArgs e)//этаж
        {
            flat.floor = level.Value;
        }

        private void Country_TextChanged(object sender, EventArgs e)//страна
        {

            TextBox tb = (TextBox)sender;
            flat.adress.country = Country.Text;
            if (tb.Text.Length == 0)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            Validate();
        }
        private void City_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            flat.adress.city = City.Text;
            if (tb.Text.Length == 0)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            Validate();
        }
        private void Area_TextChanged(object sender, EventArgs e)
        {
            flat.adress.area = Area.Text;

        }
        private void Street_TextChanged(object sender, EventArgs e)
        {
            flat.adress.street = Street.Text;
        }
        private void House_TextChanged(object sender, EventArgs e)
        {

            TextBox tb = (TextBox)sender;
            int s = Convert.ToInt32(flat.adress.house); //проверяю, чтобы были только цифры
            bool success = Int32.TryParse(House.Text, out s);
            if (!success)
            {
                tb.BackColor = Color.Red;
                tb.Tag = false;
            }
            else
            {
                tb.BackColor = System.Drawing.SystemColors.Window;
                tb.Tag = true;
            }
            Validate();
            flat.adress.house = House.Text;

        }
        private void Korp_TextChanged(object sender, EventArgs e)
        {
            flat.adress.building = Korp.Text;
        }
        private void Kvart_TextChanged(object sender, EventArgs e)
        {
            flat.adress.flat = Kvart.Text;
        }
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Flat));
        private void Save_Click(object sender, EventArgs e)//запись в файл
        {
            using (FileStream fs = new FileStream("file.xml", FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, flat);
            }
        }
        private void Load_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("File.xml", FileMode.OpenOrCreate))
            {
                Flat flat1 = xmlSerializer.Deserialize(fs) as Flat;
                Output.Text = flat1.ToString();
            }
        }


        private void Validate()
        {
            this.Save.Enabled = ((bool)(this.Country.Tag) &&
            (bool)(this.City.Tag));
        }

        private void Output_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        //=============лабораторная 3==================
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Клименкова Милана, версия программы 1.1", "О программе");
        }

        //поиск
        private void поКолвуОпцийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Results.Items.Clear();
            int n = Convert.ToInt32(Find.Text);
           Regex r3 = new Regex(@"\S\s\S", RegexOptions.IgnoreCase);
            foreach (Flat t in list)
            {
                MatchCollection col = r3.Matches(t.option);
                if (col.Count+1==n) Results.Items.Add(t);
            }
            Status.Text = "Выполнен поиск по кол-ву опций"; 
        }
        private void поМетражуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchStr = Find.Text;
            var result = list.FindAll(t => t.meter.ToString()==searchStr);
            Results.Items.Clear();
            foreach (Flat t in result)
            {
                Results.Items.Add(t);
            }
            Status.Text = "Выполнен поиск по метражу";
        }
        private void поГородуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchStr = Find.Text;
            var result = list.FindAll(t => t.adress.city == searchStr);
            Results.Items.Clear();
            foreach (Flat t in result)
            {
                Results.Items.Add(t);
            }
            Status.Text = "Выполнен поиск по городу";
        }
        private void поКолвуКомнатToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var searchStr = Find.Text;
            var result = list.FindAll(t => t.room.ToString() == searchStr);
            Results.Items.Clear();
            foreach (Flat t in result)
            {
                Results.Items.Add(t);
            }
            Status.Text = "Выполнен поиск по кол-ву комнат";
        }

        private void опцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var searchStr = Find.Text;
            var result = list.FindAll(t => t.option.Contains(searchStr));
            Results.Items.Clear();
            foreach (Flat t in result)
            {
                Results.Items.Add(t);
            }
            Status.Text = "Выполнен поиск по опциям";
        }
        private void поискToolStripMenuItem_Click(object sender, EventArgs e) 
        {
        }

        //сортировки
        private void поПлощадиToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            FlatList.Items.Clear();
            var result = from a in list
                         orderby a.meter
                         select a;

            foreach (Flat Item in result)
            {
                this.FlatList.Items.Add(Item);
            }
            Status.Text = "Выполнена сортировка по площади";
        }
        private void поКолвуКомнатToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlatList.Items.Clear();
            var result = from a in list
                         orderby a.room
                         select a;

            foreach (Flat Item in result)
            {
                this.FlatList.Items.Add(Item);
            }
            Status.Text = "Выполнена сортировка по кол-ву комнат";
        }
        private void поЭтажуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlatList.Items.Clear();
            var result = from a in list
                         orderby a.floor
                         select a;

            foreach (Flat Item in result)
            {
                this.FlatList.Items.Add(Item);
            }
            Status.Text = "Выполнена сортировка по номеру этажа";
        }
        
        private void Add_Click(object sender, EventArgs e) //добавление элемента в массив
        {
            double x = 0;//кол-во комнат
            bool check = false;
            if (this.one.Checked)
            {
                x = 1;
                check = true;
            }
            if (this.two.Checked)
            {
                x = 2;
                check = true;
            }
            if (this.three.Checked)
            {
                x = 3;
                check = true;
            }
            if (this.four.Checked)
            {
                x = 4;
                check = true;
            }
            if (this.five.Checked)
            {
                x = 5;
                check = true;
            }
            if (this.six.Checked)
            {
                x = 6;
                check = true;
            }
            string options=""; //опции
            bool check1 = false;
            if (this.Kitchen.Checked)
            {
                options+="Кухня ";
                check1 = true;
            }
            if (this.Bath.Checked)
            {
                options+=this.Bath.Text + " ";
                check1 = true;
            }
            if (this.Toilet.Checked)
            {
                options+=this.Toilet.Text + " ";
                check1 = true;
            }
            if (this.Balk.Checked)
            {
                options+=this.Balk.Text + " ";
                check1 = true;
            }
            if (this.wifi.Checked)
            {
                options+=this.wifi.Text + " ";
                check1 = true;
            }
            if (this.basement.Checked)
            {
                options+=this.basement.Text + " ";
                check1 = true;
            }
            Flat.Adress newAdress = new Flat.Adress(this.Country.Text, this.City.Text, this.Area.Text, this.Street.Text, this.House.Text, this.Korp.Text, this.Kvart.Text);
            Flat newFlat = new Flat(Convert.ToDouble(this.Meter.Value), x,  options, Convert.ToDouble(this.level.Value), newAdress);
            this.FlatList.Items.Add(newFlat);
            list.Add(newFlat);
            count++;
            Status.Text = "Объект добавлен в список. Количество объектов: " + Convert.ToString(count);
        }

        private void панельИнструментовToolStripMenuItem_Click(object sender, EventArgs e) //панель инструментов
        {
            if (toolStrip1.Visible)
            {
                toolStrip1.Hide();
            }
            else
                toolStrip1.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e) // окно о программе
        {
            MessageBox.Show("Клименкова Милана, версия программы 1.1", "О программе");
        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FlatList.Items.Clear();
            var result = from a in list
                         orderby a.meter
                         select a;

            foreach (Flat Item in result)
            {
                this.FlatList.Items.Add(Item);
            }
            Status.Text = "Выполнена сортировка по площади";
            count++;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializerSort = new XmlSerializer(typeof(Flat));
            using (FileStream fsort = new FileStream("fileSort.xml", FileMode.OpenOrCreate))
            {
                foreach (Flat Item in FlatList.Items)
                {
                    xmlSerializerSort.Serialize(fsort, Item);
                }

            }
            Status.Text = "Результат сортировки сохранён";
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(Find.Text);
            Regex r3 = new Regex(@"\S\s\S", RegexOptions.IgnoreCase);
            foreach (Flat t in list)
            {
                MatchCollection col = r3.Matches(t.option);
                if (col.Count + 1 == n) Results.Items.Add(t);
            }
            Status.Text = "Выполнен поиск по кол-ву опций";
        }

        //дальше вся сериализация
        private void button1_Click(object sender, EventArgs e)
        {
                        XmlSerializer xmlSerializerSort = new XmlSerializer(typeof(Flat));
            using (FileStream fsort = new FileStream("fileList.xml", FileMode.Append))
            {
                foreach (Flat Item in FlatList.Items)
                {
                    xmlSerializerSort.Serialize(fsort, Item);
                }

            }
            Status.Text = "Список сохранён";
        }

        private void результатПоискаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializerSort = new XmlSerializer(typeof(Flat));
            using (FileStream fsort = new FileStream("fileResearch.xml", FileMode.Append))
            {
                foreach (Flat Item in Results.Items)
                {
                    xmlSerializerSort.Serialize(fsort, Item);
                }

            }
            Status.Text = "Результат поиска сохранён";
        }

        private void результатСортировкиToolStripMenuItem_Click(object sender, EventArgs e)
        {

            XmlSerializer xmlSerializerSort = new XmlSerializer(typeof(Flat));
            using (FileStream fsort = new FileStream("fileSort.xml", FileMode.OpenOrCreate))
            {
                foreach (Flat Item in FlatList.Items)
                {
                    xmlSerializerSort.Serialize(fsort, Item);
                }

            }
            Status.Text = "Результат сортировки сохранён";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializerSort = new XmlSerializer(typeof(Flat));
            using (FileStream fsort = new FileStream("fileResearch.xml", FileMode.Append))
            {
                foreach (Flat Item in Results.Items)
                {
                    xmlSerializerSort.Serialize(fsort, Item);
                }

            }
            Status.Text = "Результат поиска сохранён";
        }
    }
}